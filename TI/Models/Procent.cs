using System.ComponentModel.DataAnnotations.Schema;

namespace TI.Models
{
    [Table("procente")]
    public class Procent
    {
        public int ID { get; set; }
        public string NumeVariabila { get; set; }
        public double ProcentProp { get; set; }
    }
}