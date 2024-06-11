using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCAuth.Models
{
    public class LoginModel
    {
        
        public int Id { get; set; }
       
        [DisplayName("User Name")]
        [Required(ErrorMessage = "User Name is required")]
        public string? UserName { get; set; }
        public string? Name { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }



    }
}
