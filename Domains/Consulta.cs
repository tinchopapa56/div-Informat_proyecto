using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clinica.Domains
{
    public enum ConsultaOPractica
    {
        Consulta,
        Practica
    }
    public class Consulta
    {
        [Key]
        public Guid ConsultaId { get; set; }

        [ForeignKey("Medico")]
        public Guid MedicoId { get; set; }
        public DateTime Fecha { get; set; }
        public int Costo { get; set; }
        public int CostoMateriales { get; set; }   //float

        public string Descripcion { get; set; }
    }
}
