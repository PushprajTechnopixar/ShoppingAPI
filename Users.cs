using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ShoppingVS.Models

{
    public partial class Users
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter Name..")]  
        public string Name { get; set; }

         [Required(ErrorMessage ="Please Enter Email..")]  
        public string Email { get; set; }

         [Required(ErrorMessage ="Please Enter Password..")]  
        public string Password { get; set; }

         [Required(ErrorMessage ="Please Enter State..")]  
        public string State { get; set; }
    }
}
