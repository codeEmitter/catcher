using Microsoft.AspNetCore.Mvc;
using Catcher.Stores;

namespace Catcher.Controllers.mem
{
    
    [Route("api/v1/catch/[controller]/mem")]
    [ApiController]
    public class StringController : ControllerBase
    {
        private readonly IStore _store;

        public StringController(IStore store) => _store = store;

        [HttpGet]
        public IActionResult Get() => Ok(_store.Read());

        [HttpPost]
        public IActionResult Post([FromBody] string value) => 
            Created(Request.Path.Value, _store.Save(value));
    }
}
