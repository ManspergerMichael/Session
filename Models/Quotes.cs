using System;
using System.ComponentModel.DataAnnotations;
namespace Session.Models
{
    public class Quotes
    {
        [Required]
        [MinLength(5)]
        [Display(Name = "Your Name:")]
        public string name {get;set;}
        //[Required]
        [Display(Name = "Quote:")]
        public string quote{get;set;}
        public DateTime createdAt {get;set;}
    }
}