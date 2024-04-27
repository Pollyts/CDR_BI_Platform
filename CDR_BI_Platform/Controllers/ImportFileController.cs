using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CDR_BI_Platform.Controllers;
using CDR_BI_Platform.Extentions;
using CDR_BI_Platform.Models;
using CDR_BI_Platform.Services.Implementation;
using CDR_BI_Platform.Services.Interfaces;
using CDR_BI_Platform.ViewModels;

namespace CDR_BI_Platform.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ImportFileController : ControllerBase //, BaseController<TranslationJob>
    {
        IFileImportService _fileImportService;

        public ImportFileController(
            IMapper mapper,
            IFileImportService fileImportService)
        {
            _fileImportService = fileImportService;
        }

        [HttpPost]
        public ActionResult Post(IFormFile file)
        {
            try
            {
                _fileImportService.Save(file);
                return JsonResult(201, null);
            }
            catch (Exception e)
            {
                return JsonErrorResult(e);
            }            
        }

        private JsonResult JsonResult(int code, object value)
        {
            return new JsonResult(value)
            {
                StatusCode = code
            };
        }

        private JsonResult JsonErrorResult(Exception e)
        {
            if (e is ClientException)
            {
                return new JsonResult(e.Message)
                {
                    StatusCode = 400,
                };
            }
            else
            {
                return new JsonResult(e.Message)
                {
                    StatusCode = 500,
                };
            }
        }
    }
}