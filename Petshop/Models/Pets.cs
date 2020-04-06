using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Petshop.Models
{
    public class Pets
    {
        [Key]
        public int PetUID { get; set; }
        [Display(Name = "Pet Name")]
        [Required(ErrorMessage ="Pet Name is Required")]
        public String PetName { get; set; }


    }

    public class Settings
    {
        [Key]
        public int SettingUID { get; set; }

        public String Key { get; set; }
        public String Value { get; set; }
    }

    public class PetsDBContext : DbContext
    {
        public PetsDBContext()
        {

        }

        public DbSet<Pets> Pets { get; set; }


    }
}