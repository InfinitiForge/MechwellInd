using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace MechwellWebsite.Models
{
    public class Enquiry
    {
        [Required(ErrorMessage = "Kindly enter the name")]
        public String NAME { get; set; }

        [Required(ErrorMessage = "Kindly enter the contact number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Entered contact number is wrong")]
        public String CONTACT_NO { get; set; }


        [Required(ErrorMessage = "Kindly enter the email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Kindly enter valid email")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Kindly enter the enquiry")]
        public String QUERY { get; set; }
    }
}