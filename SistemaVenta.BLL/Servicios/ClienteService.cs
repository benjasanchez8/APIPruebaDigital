using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DAL.Repositorios.Contrato;
using SistemaVenta.DTO;
using SistemaVenta.Model;



namespace SistemaVenta.BLL.Servicios
{
    public class ClienteService : IClienteService
    {
        private readonly IGenericRepository<Cliente> _clienteRepositorio;
        private readonly IMapper _mapper;

        public ClienteService(IGenericRepository<Cliente> clienteRepositorio, IMapper mapper)
        {
            _clienteRepositorio = clienteRepositorio;
            _mapper = mapper;
        }

        public async Task<List<ClienteDTO>> Lista()
        {
            try
            {
                var listaClientes = await _clienteRepositorio.Consultar();      
                return _mapper.Map<List<ClienteDTO>>(listaClientes).ToList();          
            }
            catch {
                throw;
            }


        }

      public async Task<ClienteDTO> Crear(ClienteDTO modelo)
        {
            try {

                var clienteCreado = await _clienteRepositorio.Crear(_mapper.Map<Cliente>( modelo));

                if(clienteCreado.IdCliente == 0)
                    throw new TaskCanceledException("No se pudo crear");

                return _mapper.Map<ClienteDTO>(clienteCreado);

            }
            catch {
                throw;
            }
        }

        public async Task<bool> Editar(ClienteDTO modelo)
        {
            try
            {
                var clienteModelo = _mapper.Map<Cliente>( modelo);

                var clienteEncontrado = await _clienteRepositorio.Obtener(u => u.IdCliente == clienteModelo.IdCliente);

                if(clienteEncontrado == null)
                    throw new TaskCanceledException("El cliente no existe");

                clienteEncontrado.Nombre = clienteModelo.Nombre;
                clienteEncontrado.Edad = clienteModelo.Edad;
                clienteEncontrado.Telefono = clienteModelo.Telefono;
                clienteEncontrado.Correo = clienteModelo.Correo;
                clienteEncontrado.EsActivo = clienteModelo.EsActivo;

                bool respuesta = await _clienteRepositorio.Editar(clienteEncontrado);

                if(!respuesta)
                    throw new TaskCanceledException("No se pudo editar");

                return respuesta;
            }
            catch {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var clienteEcontrado = await _clienteRepositorio.Obtener(c => c.IdCliente == id);

                if(clienteEcontrado == null) 
                    throw new TaskCanceledException("El cliente no existe");

                bool respuesta = await _clienteRepositorio.Eliminar(clienteEcontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo eliminar");

                return respuesta;
            }
            catch {
                throw;
            }
        }

      
    }
}
