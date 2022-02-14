using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.Model
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage ="Name should only contain a max of 50 characters.")]
        public string Name { get; set; }
    }
}
