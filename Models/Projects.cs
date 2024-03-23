using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApp.Models
{
    public class Projects
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Project Name")]
        public string? Name { get; set; }
        
        [DisplayName("Description ")]
        public string? Description { get; set; }
    }
}
