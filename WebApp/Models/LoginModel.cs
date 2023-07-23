using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class LoginModel
    {
        //logini e-mail ilede gerçekleştirilebilir 
        //burada isim ile gerçekleştirdik

        private string? _returnUrl;

        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }
        public string ReturnUrl
        {
            get
            {
                if (_returnUrl is null)
                    return "/";
                else
                    return _returnUrl;
            }

            set { _returnUrl = value; }
        }




    }
}
