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
    public class ConsultasController : ControllerBase
    {
        private readonly ClinicaDB _context;

        public ConsultasController(ClinicaDB context)
        {
            _context = context;
        }

        // GET: api/Consultas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consulta>>> GetConsultas()
        {
          if (_context.Consultas == null)
          {
              return NotFound();
          }
            return await _context.Consultas.ToListAsync();
        }

        // GET: api/Consultas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consulta>> GetConsulta(Guid id)
        {
          if (_context.Consultas == null)
          {
              return NotFound();
          }
            var consulta = await _context.Consultas.FindAsync(id);

            if (consulta == null)
            {
                return NotFound();
            }

            return consulta;
        }

        // PUT: api/Consultas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsulta(Guid id, Consulta consulta)
        {
            if (id != consulta.ConsultaId)
            {
                return BadRequest();
            }

            _context.Entry(consulta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultaExists(id))
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


        //[HttpPost]
        //public async Task<ActionResult<Consulta>> PostConsulta(Consulta consulta, Guid pacienteId)
        //{
        //    if (_context.Consultas == null) { return Problem("Entity set 'ClinicaDB.Consultas'  is null."); }
        //    if (consulta == null) { return BadRequest("consulta is null."); }
        //    if (pacienteId == null) { return BadRequest("must put pacienteId."); }



        //    var consultaId = _context.Consultas.Any(cons => cons.ConsultaId == consulta.ConsultaId);
        //    if (consultaId) return StatusCode(409, $"Consulta ID {consulta.MedicoId}' already Exists ");

        //    var doctorId = _context.Doctores.Any(doctor => doctor.NMatricula == consulta.MedicoId);
        //    if (!doctorId) return StatusCode(409, $"Doctor with Id '{consulta.MedicoId}' doesnt exists.");

        //    var paciente = _context.Pacientes.Include(p => p.Consultas).Where(p => p.H_Clinica == pacienteId).FirstOrDefault();
        //    if (paciente == null) return StatusCode(409, $"No existe un paciente con este ID '{pacienteId}'");

        //    _context.Consultas.Add(consulta);
        //    paciente.Consultas.Add(consulta);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetConsulta", new { id = consulta.ConsultaId }, consulta);
        //}
        [HttpPost]
        public IActionResult PostConsulta(Consulta consulta, Guid pacienteId)
        {
            if (_context.Consultas == null) { return Problem("Entity set 'ClinicaDB.Consultas'  is null."); }
            if (consulta == null) { return BadRequest("consulta is null."); }
            if (pacienteId == null) { return BadRequest("must add pacienteId."); }



            var consultaId = _context.Consultas.Any(cons => cons.ConsultaId == consulta.ConsultaId);
            if (consultaId) return StatusCode(409, $"Consulta ID {consulta.MedicoId}' already Exists ");

            var doctorId = _context.Doctores.Any(doctor => doctor.NMatricula == consulta.MedicoId);
            if (!doctorId) return StatusCode(409, $"Doctor with Id '{consulta.MedicoId}' doesnt exists.");

            var paciente = _context.Pacientes.Include(p => p.Consultas).Where(p => p.H_Clinica == pacienteId).FirstOrDefault();
            if (paciente == null) return StatusCode(409, $"No existe un paciente con este ID '{pacienteId}'");

            _context.Consultas.Add(consulta);
            paciente.Consultas.Add(consulta);
            _context.SaveChanges();

            return CreatedAtAction("GetConsulta", new { id = consulta.ConsultaId }, consulta);
        }

        // DELETE: api/Consultas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsulta(Guid id)
        {
            if (_context.Consultas == null)
            {
                return NotFound();
            }
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }

            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsultaExists(Guid id)
        {
            return (_context.Consultas?.Any(e => e.ConsultaId == id)).GetValueOrDefault();
        }
    }
}
