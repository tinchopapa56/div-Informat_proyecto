using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clinica.Domains;
using Clinica.Persistence;

namespace Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly ClinicaDB _context;

        public PacientesController(ClinicaDB context)
        {
            _context = context;
        }

        // GET: api/Pacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
        {
          if (_context.Pacientes == null)
          {
              return NotFound();
          }
            return await _context.Pacientes.ToListAsync();
        }

        // GET: api/Pacientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetPaciente(Guid id)
        {
          if (_context.Pacientes == null)
          {
              return NotFound();
          }
            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return paciente;
        }

        // PUT: api/Pacientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(Guid id, Paciente paciente)
        {
            if (id != paciente.H_Clinica)
            {
                return BadRequest();
            }

            _context.Entry(paciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(id))
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

        //NOT FULLY WORKING
        [HttpPost]
        public async Task<ActionResult<Paciente>> PostPaciente(Paciente paciente)
        {
          if (_context.Pacientes == null)  return Problem("Entity set 'ClinicaDB.Pacientes' (db) is null.");

            var pacienteId = _context.Pacientes.Any(p => p.H_Clinica == paciente.H_Clinica);
            if (pacienteId)   return StatusCode(409, $"Paciente ID {paciente.H_Clinica}' already Exists ");


            //var consulta = _context.Consultas
            //    .Include(c => c.ConsultaId)
            //    .Where(c => c.ConsultaId == p )
            //    .FirstOrDefault();
            //if (consulta == null) return null;

            //var consultaId = _context.Consultas.Any(cons => cons.ConsultaId == paciente.Consultas.ConsultaId);
            //if (consultaId)
            //{
            //    return StatusCode(409, $"Consulta ID {consulta.MedicoId}' already Exists ");
            //}

            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaciente", new { id = paciente.H_Clinica }, paciente);
        }

        // DELETE: api/Pacientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaciente(Guid id)
        {
            if (_context.Pacientes == null)
            {
                return NotFound();
            }
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PacienteExists(Guid id)
        {
            return (_context.Pacientes?.Any(e => e.H_Clinica == id)).GetValueOrDefault();
        }
    }
}
