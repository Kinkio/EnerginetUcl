﻿using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using EnerginetDemo.Application.Converters;
using EnerginetDemo.Application.Validators;
using EnerginetDemo.Domain.Database;
using EnerginetDemo.Infrastructure;

namespace EnerginetDemo.Application
{
    public class SampleMessageService : ISampleMessageService
    {
        public SampleMessageService (ISampleMessageConverter sampleMessageConverter,
            ISampleMessageDeserializer sampleMessageDeserializer,
            ISampleMessageValidator sampleMessageValidator,
            ISampleMessageRepository sampleMessageRepository)
        {
            SampleMessageConverter = sampleMessageConverter;
            SampleMessageDeserializer = sampleMessageDeserializer;
            SampleMessageValidator = sampleMessageValidator;
            SampleMessageRepository = sampleMessageRepository;
        }

        private ISampleMessageConverter SampleMessageConverter { get; }

        private ISampleMessageDeserializer SampleMessageDeserializer { get; }

        private ISampleMessageValidator SampleMessageValidator { get; }

        private ISampleMessageRepository SampleMessageRepository { get; }

        public async Task<SampleMessageDb> HandleIncomingSampleMessage(Stream body)
        {
            var message = await SampleMessageDeserializer.DeserializeMessageAsync(body);

            var validationResult = await SampleMessageValidator.ValidateAsync(message);

            if (!validationResult.IsValid)
            {
                throw new XmlSchemaValidationException(validationResult.Errors.First().ErrorMessage);
            }

            var convertedSampleMessage = SampleMessageConverter.Convert(message);

            return await SaveMessageInDatabase(convertedSampleMessage);
        }

        private async Task<SampleMessageDb> SaveMessageInDatabase(SampleMessageDb sampleMessage)
        {
            return await SampleMessageRepository.AddAsync(sampleMessage);
        }
    }
}
