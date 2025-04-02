using System.ComponentModel.DataAnnotations;

namespace L02P02_2022MQ650_2022DS601.Models
{
    public class autores
    {
        [Key]
        public int id { get; set; }
        public string autor { get; set; }
    }
}
