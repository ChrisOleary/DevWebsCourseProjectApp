using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevWebsCourseProjectApp.Entities
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [MaxLength(500)]
        public string Surname { get; set; }
        public List<Address> Addresses { get; set; }

        // see ApplicationDBContext.cs on how this is creating a computed column
        public string DisplayName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] // generates the date when updated or inserted
        public DateTime Updated { get; set; }



    }
}
