using System.ComponentModel.DataAnnotations;

namespace Clinica.Domains
{
    public class Doctor : Persona
    {
        [Key]
        public Guid NMatricula { get; set; }
        public string Especialidad { get; set; }
    }
}
