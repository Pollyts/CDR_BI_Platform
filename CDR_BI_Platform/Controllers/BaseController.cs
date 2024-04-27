using Microsoft.AspNetCore.Mvc;
using CDR_BI_Platform.Models;
using CDR_BI_Platform.Services.Interfaces;

namespace CDR_BI_Platform.Controllers
{
    [Route("api/[controller]")]
    public abstract class BaseController<TEntity> : Controller
        where TEntity : class, IEntityDb, new()
    {
        protected readonly IBaseService<TEntity> _service;

        public BaseController(IBaseService<TEntity> service)
        {
            _service = service;
        }

        public virtual ActionResult Get()
        {
            return new JsonResult(_service.GetAll());
        }

        [HttpGet("{id}")]
        public virtual ActionResult Get(int id)
        {
            return new JsonResult(_service.Get(id));
        }
    }
}
