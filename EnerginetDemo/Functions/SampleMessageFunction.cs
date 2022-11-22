using System.Threading.Tasks;
using System.Web.Http;
using System.Xml.Schema;
using EnerginetDemo.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace EnerginetDemo.Functions;

public class SampleMessageFunction
{
    public SampleMessageFunction (ISampleMessageService sampleMessageService)
    {
        SampleMessageService = sampleMessageService;
    }

    private ISampleMessageService SampleMessageService { get; }

    [FunctionName("SampleMessage")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
    {
        try
        {
            var savedMessage = await SampleMessageService.HandleIncomingSampleMessage(req.Body);
            var responseMessage = $"A message with id: {savedMessage.Id} was saved in the database";
            return new OkObjectResult(responseMessage);
        }
        catch (XmlSchemaValidationException e)
        {
            return new BadRequestErrorMessageResult(e.Message);
        }
    }
}
