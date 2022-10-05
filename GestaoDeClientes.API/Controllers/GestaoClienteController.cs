using GestaoDeClientes.API.Model;
using GestaoDeClientes.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeClientes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestaoClienteController : ControllerBase
    {
        private readonly IGestaoRepository _repository;
        public GestaoClienteController(IGestaoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Cliente>> Get()
        {
            return await _repository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CadastroFull>> GetClientes(int id)
        {
            return await _repository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente([FromBody] Cliente cliente)
        {
            var newcliente = await _repository.Create(cliente);

            return CreatedAtAction(nameof(GetClientes), new {id = newcliente.ID}, newcliente);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> PutClientes(int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.ID)
                return BadRequest();

            await _repository.Update(cliente);
            return NoContent();
        }
    }
}
