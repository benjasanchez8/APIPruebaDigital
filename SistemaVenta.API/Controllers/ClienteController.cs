using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DTO;
using SistemaVenta.API.Utilidad;

namespace SistemaVenta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteService _clienteServicio;

        public ClienteController(IClienteService ClienteServicio)
        {
            _clienteServicio = ClienteServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<ClienteDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _clienteServicio.Lista();

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }
            return Ok(rsp);
        }


        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] ClienteDTO cliente)
        {
            var rsp = new Response<ClienteDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _clienteServicio.Crear(cliente);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }
            return Ok(rsp);

        }


        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ClienteDTO cliente)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _clienteServicio.Editar(cliente);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }
            return Ok(rsp);

        }


        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _clienteServicio.Eliminar(id);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }
            return Ok(rsp);

        }



    }
}
