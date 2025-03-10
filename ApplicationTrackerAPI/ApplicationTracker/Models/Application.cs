using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationTracker.Models
{
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string? CompanyName { get; set; }
        public string? Position { get; set; }
        public string? Status { get; set; }
        public DateTime? DateApplied { get; set; }
    }
}
