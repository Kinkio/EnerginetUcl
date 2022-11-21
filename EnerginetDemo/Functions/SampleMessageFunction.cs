using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using EnerginetDemo.Application;
using EnerginetDemo.Application.Converters;
using EnerginetDemo.Common;
using EnerginetDemo.Infrastructure;
using EnerginetDemo.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace EnerginetDemo;

public class SampleMessageFunction
{
    public SampleMessageFunction (ISampleMessageConverter sampleMessageConverter,
        ISampleMessageDeserializer sampleMessageDeserializer,
        ISampleMessageValidator sampleMessageValidator,
        SampleMessageDbContext sampleMessageDbContext)
    {
        SampleMessageConverter = sampleMessageConverter;
        SampleMessageDeserializer = sampleMessageDeserializer;
        SampleMessageValidator = sampleMessageValidator;
        SampleMessageDbContext = sampleMessageDbContext;
    }

    private ISampleMessageConverter SampleMessageConverter { get; }
    private ISampleMessageDeserializer SampleMessageDeserializer { get; }
    private ISampleMessageValidator SampleMessageValidator { get; }
    private SampleMessageDbContext SampleMessageDbContext { get; }

    [FunctionName("SampleMessage")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
    {
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

    //TODO Extract to own class
    private SampleMessageDb SaveMessageInDatabase(SampleMessageDb sampleMessage)
    {
        var repository = new SampleMessageRepository(SampleMessageDbContext);
        return repository.Add(sampleMessage);
    }
}
