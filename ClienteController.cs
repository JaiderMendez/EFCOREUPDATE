using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuSuperService.Models;
using AutoMapper;
using TuSuperService.DTOS;


namespace TuSuperService.Controllers
{
    [Produces("application/json")]
    [Route("api/Clientes")]
    public class ClientesController : Controller
    {
        private readonly SUPERDBContext _context;

        public ClientesController(SUPERDBContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<ClientesDTO> GetClientes()
        {
            return Mapper.Map<IEnumerable<ClientesDTO>>(_context.Clientes);
        }
        // GET: api/Clientes/Reset/5/5
        [HttpGet("Reset/{user}/{mail}")]
        public async Task<IActionResult> GetUsertoReset([FromRoute] string user,[FromRoute] string mail)
        {
            return Ok(Mapper.Map<IEnumerable<ClientesDTO>>(_context.Clientes.OrderBy(m => m.Id).Where(m => m.UserName == user && m.Correo == mail)));
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //var clientes = await _context.Clientes.SingleOrDefaultAsync();

            //if (clientes == null)
            //{
            //    return NotFound();
            //}

            //return Ok(Mapper.Map<ClientesDTO>(clientes));
        }
        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientes([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clientes = await _context.Clientes.SingleOrDefaultAsync(m => m.Id == id);

            if (clientes == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<ClientesDTO>( clientes));
        }
        // GET: api/Clientes/Check/5
        [HttpGet("Check/{user}/{tel}/{pass}")]
        public async Task<IActionResult> GetClientesCheck([FromRoute] string user, [FromRoute] string tel, [FromRoute] string pass)
        {
            return Ok(Mapper.Map<IEnumerable<ClientesDTO>>(_context.Clientes.OrderBy(m => m.Id).Where(m => m.UserName == user || m.Telefono == tel && m.Password == pass)));

        }
        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientes([FromRoute] string id, [FromBody] ClientesDTO clientes)
        {



            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientes.Id)
            {
                return BadRequest();
            }


           //_context.Entry(Mapper.Map<Clientes>(clientes)).State = EntityState.Modified;
           //_context.Entry(Mapper.Map<Clientes>(clientes)).Property(x => x.Ctrl).IsModified = false;
            //Solucion
             var thisRole = _context.Clientes.Where(r => r.Id.Equals(clientes.Id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            _context.Clientes.Attach(thisRole);
            thisRole.NumeroEnvios = clientes.NumeroEnvios;
            
            try
            {
             
                await _context.SaveChangesAsync();
            }
            //catch (DbUpdateConcurrencyException)
             catch (Exception ex)
            {
                if (!ClientesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        // POST: api/Clientes
        [HttpPost]
        public async Task<IActionResult> PostClientes([FromBody] ClientesDTO clientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var map = Mapper.Map<Clientes>(clientes);
            _context.Clientes.Add(map);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientes", new { id = map.Id }, clientes);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientes([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clientes = await _context.Clientes.SingleOrDefaultAsync(m => m.Id == id);
            if (clientes == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(clientes);
            await _context.SaveChangesAsync();

            return Ok(Mapper.Map<ClientesDTO>( clientes));
        }

        private bool ClientesExists(string id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
