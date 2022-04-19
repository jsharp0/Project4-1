using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project4_1.Models
{
    public class Contact
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter a first name")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Please enter a phone number")]
        public string phone { get; set; }

        [Required(ErrorMessage = "Please enter an email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please select a category")]
        public string categoryID;
        public Category category { get; set; }

        public string organization { get; set; }

        public DateTime CreatedDate { get; set; }

        public string nameSlug
        {
            get
            {
                return $"{firstName}-{lastName}";
            }
        }


    }
}
