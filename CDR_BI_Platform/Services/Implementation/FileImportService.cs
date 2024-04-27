using System.Collections.Generic;
using System.Linq;
using System;
using CDR_BI_Platform.Models;
using CDR_BI_Platform.Repositories.Interfaces;
using CDR_BI_Platform.Services.Interfaces;
using CDR_BI_Platform.Extentions;
using Microsoft.Extensions.Logging;
using CDR_BI_Platform.ViewModels;
using System.IO;

namespace CDR_BI_Platform.Services.Implementation
{
    public class FileImportService : IFileImportService
    {
        protected readonly IBaseRepository<ImportFile> _repository;
        private readonly ILogger<Call> _logger;

        public FileImportService(IBaseRepository<ImportFile> repository,
            ILogger<Call> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public void Save(IFormFile file)
        {
            byte[] fileData;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);

                fileData = memoryStream.ToArray();
            }

            _repository.Add(new ImportFile()
            {
                DataFS = fileData
            });

            _repository.SaveChanges();
        }
    }
}

