using Microsoft.AspNetCore.Identity;

namespace MyPortfolioWebApp.Models
{
    // IdentityUser는 AspNetCore.Identity에 위치하는 클래스
    // 회원가입시 추가로 받고싶은 정보를 넣기 위해 IdentityUser를 상속받아 CustomUser 클래스를 만듬
    public class CustomUser : IdentityUser
    {
        public string? Mobile { get; set; } // 휴대폰 번호
        public string? City { get; set; } // 도시
        public string? Hobby { get; set; } // 취미

    }
}
