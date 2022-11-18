using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml;
using System.Xml.Serialization;
using EnerginetDemo.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace EnerginetDemo
{
    public class Function1
    {

        [FunctionName("SampleMessage")]
        public static async Task<IActionResult> Run(
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

            // Gem i DB 

            // print til Konsol
            string responseMessage = string.IsNullOrEmpty(message.Text)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {message.ID}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        public static SampleMessage DeserializeMessage(string body)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SampleMessage));

            var stringReader = new StringReader(body);
            using (var reader = XmlReader.Create(stringReader))
            {
                return (SampleMessage)serializer.Deserialize(reader);
            }
        }
    }
}
