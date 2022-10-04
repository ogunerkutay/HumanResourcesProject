using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Models.DTOs
{
    public class LoginDTO
    {

        public string Token { get; set; }


        public string Email { get; set; }


        public string Password { get; set; }


        public string RePassword { get; set; }

    }
}
