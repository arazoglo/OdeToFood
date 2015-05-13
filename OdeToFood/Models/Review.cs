﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OdeToFood.Models
{
    public class Review : IValidatableObject
    {
        public int ID { get; set; }
        public Restaurant Restaurant { get; set; }
        [Range(1,10)]
        public int Rating { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
        [DisplayName("Dining Date")]
        [DataType(DataType.Date)]
        public DateTime DiningDate { get; set; }

        #region IValidatableObject Members

        public IEnumerable<ValidationResult> 
            Validate(ValidationContext validationContext)
        {
            var field = new[] { "DiningDate" };
            if (DiningDate < DateTime.Now)
            {
                yield return new ValidationResult("Dining date cannont be too far in the future");
            }
            if (DiningDate < DateTime.Now.AddYears(-1))
            {
                yield return new ValidationResult("Dining date cannont be too far in the past");
            }
        }

        #endregion
    }
}