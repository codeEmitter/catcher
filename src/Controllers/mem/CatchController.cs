using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Stores;

namespace src.Controllers.mem
{
    
    [Route("api/v1/catch/[controller]/mem")]
    [ApiController]
    public class StringController : ControllerBase
    {
        private readonly IStore _store;

        public StringController(IStoreInMemory store) => _store = store;

        [HttpGet]
        public IActionResult Get() => Ok(_store.Read());

        [HttpPost]
        public IActionResult Post([FromBody] string value) => 
            Created(Request.Path.Value, _store.Save(value));
    }
}
