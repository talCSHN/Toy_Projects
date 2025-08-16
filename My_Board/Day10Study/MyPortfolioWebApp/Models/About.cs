using System.ComponentModel.DataAnnotations;

namespace MyPortfolioWebApp.Models
{
    public class About
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Summary { get; set; }
        [Required]
        public string Title { get; set; }

        public DateTime BirthDate { get; set; }

        public string WebSite { get; set; }
        
        public string Mobile { get; set; }

        public string Address { get; set; }

        public string Education { get; set; }

        public string Email { get; set; }

        public string Job { get; set; }

        public string Introduction { get; set; }

        public string PhotoUrl { get; set; }
    }
}
