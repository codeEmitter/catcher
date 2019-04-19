using Microsoft.AspNetCore.Mvc;
using Catcher.Stores;

namespace Catcher.Controllers.Mem
{
    
    [Route("api/v1/catch/mem/[controller]")]
    [ApiController]
    public class SimpleListController : ControllerBase
    {
        private readonly IStore _store;

        public SimpleListController(IStoreInMemory store) => _store = store;

        [HttpGet]
        public IActionResult Get() => Ok(_store.Read());

        [HttpPost]
        public IActionResult Post([FromBody] string value) => 
            Created(Request.Path.Value, _store.Save(value));

        [HttpDelete]
        public IActionResult Delete() =>
            Ok($"{_store.Clear()} items cleared.");
    }
}
