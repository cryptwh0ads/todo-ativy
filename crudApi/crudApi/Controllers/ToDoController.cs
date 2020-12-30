using System;
using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using crudApi.Services;
using crudApi.Common;
using crudApi.Models;

namespace crudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : CustomController<ToDo, ToDoService>
    {
        public ToDoController(ToDoService service, ILogger<ToDoController> logger)
            : base(service, logger)
        {
        }
    }
}
