using System.ComponentModel.DataAnnotations;

namespace MyPortfolioWebApp.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "이름 입력 필수")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
