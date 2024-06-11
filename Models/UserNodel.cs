using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCAuth.Models
{
    public class UserModel
    {

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        [StringLength(100)]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        
        public string PhoneNumber { get; set; }



    }
}
