﻿using System;
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
    public class CallController : ControllerBase //, BaseController<Call>
    {
        IBaseService<Call> _service;
        private readonly IMapper _mapper;

        public CallController(
            IBaseService<Call> service,
            IMapper mapper,
            ICallService translationJobService)
        //: base(service)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var dbObjects = _service.GetAll().ToList();
                List<> viewModels = _mapper.Map<List<Call>, List<>>(dbObjects);
                return JsonResult(200, viewModels);
            }
            catch (Exception e)
            {
                return JsonErrorResult(e);
            }
        }

        [HttpPost]
        public ActionResult Create(model)
        {
            try
            {
                var create = _mapper.Map<Call>(model);
                return JsonResult(201, _service.Create(create));
            }
            catch (Exception e)
            {
                return JsonErrorResult(e);
            }
        }

        [HttpPost("[action]")]
        public ActionResult CreateWithFile(IFormFile file, string customerName = "")
        {
            try
            {

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
                    StatusCode= 400,
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