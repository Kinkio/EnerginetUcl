using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml;
using System.Xml.Serialization;
using EnerginetDemo.Application.Converters;
using EnerginetDemo.Infrastructure;
using EnerginetDemo.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace EnerginetDemo;

public class SampleMessageFunction
{

    public SampleMessageFunction (ISampleMessageConverter sampleMessageConverter)
    {
        SampleMessageConverter = sampleMessageConverter;
    }

    public ISampleMessageConverter SampleMessageConverter { get; }

    [FunctionName("SampleMessage")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

        var message = DeserializeMessage(requestBody);

        var validationResult = new SampleMessageValidator().Validate(message);

        if (!validationResult.IsValid)
        {
            return new BadRequestErrorMessageResult(validationResult.Errors.First().ErrorMessage);
        }

        var convertedSampleMessage = SampleMessageConverter.Convert(message);

        var savedEntity = SaveMessageInDatabase(convertedSampleMessage);
        var responseMessage = $"A message with id: {savedEntity.Id} was saved in the database";

        return new OkObjectResult(responseMessage);
    }

    public SampleMessage DeserializeMessage(string body)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(SampleMessage));

        var stringReader = new StringReader(body);
        using (var reader = XmlReader.Create(stringReader))
        {
            return (SampleMessage)serializer.Deserialize(reader);
        }
    }

    public static SampleMessageDb SaveMessageInDatabase(SampleMessageDb sampleMessage)
    {
        var repository = new SampleMessageRepository(new SampleMessageContext());
        return repository.Add(sampleMessage);
    }
}
