using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage = "Ad alanı gereklidir")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı gereklidir")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı alanı gereklidir")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "E-Posta alanı gereklidir")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı gereklidir")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre alanı gereklidir")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor" )]
        public string ConfirmPassword { get; set; }

    }
}
