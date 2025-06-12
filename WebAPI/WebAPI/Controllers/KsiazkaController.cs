using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KsiazkaController : ControllerBase
    {
        private readonly IKsiazkaService _ksiazkaService;

        public KsiazkaController(IKsiazkaService ksiazkaService)
        {
            _ksiazkaService = ksiazkaService;
        }

        [HttpGet]
        public IEnumerable<KsiazkaDTO> Get()
        {
            return _ksiazkaService.Get();
        }

        [HttpGet("{id}")]
        public KsiazkaDTO GetById(int id)
        {
            return _ksiazkaService.GetById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] KsiazkaBodyDTO body)
        {
            try
            {
                _ksiazkaService.Post(body);
                return Ok(); 
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Błąd serwera: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] KsiazkaBodyDTO body)
        {
            try
            {
                _ksiazkaService.Put(id, body);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Błąd serwera: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ksiazkaService.Delete(id);
        }
    }
}
