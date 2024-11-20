using System.ComponentModel.DataAnnotations;

namespace ProjectSite.Models
{
    public class Restaurant
    {
        [Key]
        public int id { get; set; }

        public string? res_name { get; set; }
        public string? adress { get; set; }
    }
}
