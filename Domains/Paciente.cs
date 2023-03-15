using System.ComponentModel.DataAnnotations;

namespace Clinica.Domains
{
    public class Paciente : Persona
    {
        [Key]
        public Guid H_Clinica { get; set; }
        public ICollection<Consulta> Consultas { get; set; }   //1 => many
    }
}
