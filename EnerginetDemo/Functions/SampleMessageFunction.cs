using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using EnerginetDemo.Application;
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

    public SampleMessageFunction (ISampleMessageConverter sampleMessageConverter,
        ISampleMessageDeserializer sampleMessageDeserializer,
        ISampleMessageValidator sampleMessageValidator)
    {
        SampleMessageConverter = sampleMessageConverter;
        SampleMessageDeserializer = sampleMessageDeserializer;
        SampleMessageValidator = sampleMessageValidator;
    }

    public ISampleMessageConverter SampleMessageConverter { get; }

    public ISampleMessageDeserializer SampleMessageDeserializer { get; }

    public ISampleMessageValidator SampleMessageValidator { get; }

    [FunctionName("SampleMessage")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");
        var message = await SampleMessageDeserializer.DeserializeMessageAsync(req.Body);

        var validationResult = SampleMessageValidator.Validate(message);

        if (!validationResult.IsValid)
        {
            return new BadRequestErrorMessageResult(validationResult.Errors.First().ErrorMessage);
        }

        var convertedSampleMessage = SampleMessageConverter.Convert(message);

        var savedEntity = SaveMessageInDatabase(convertedSampleMessage);
        var responseMessage = $"A message with id: {savedEntity.Id} was saved in the database";

        return new OkObjectResult(responseMessage);
    }

    public static SampleMessageDb SaveMessageInDatabase(SampleMessageDb sampleMessage)
    {
        var repository = new SampleMessageRepository(new SampleMessageContext());
        return repository.Add(sampleMessage);
    }
}
