using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Mvc;
using MechwellWebsite.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Text;
using System.Net;
using System.Web.UI.HtmlControls;

namespace MechwellWebsite.Controllers
{
    public class HomeController : Controller
    {
        string conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        //httpget start
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Contact());
        }

        [HttpGet]
        public ActionResult About()
        {
            return View(new Contact());
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View(new Contact());
        }

        [HttpGet]
        public ActionResult Gallery()
        {
            return View(new Contact());
        }

        [HttpGet]
        public ActionResult Services()
        {
            return View(new Contact());
        }

        [HttpGet]
        public ActionResult Enquiry()
        {
            DataTable dt = new DataTable();
            using (SqlConnection Sqlcon = new SqlConnection(conn))
            {
                Sqlcon.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from MechwellEngg..TBL_ENQUERY", Sqlcon);
                sda.Fill(dt);
            }
            return View(dt);

        }

        [HttpGet]
        public ActionResult Coming_soon()
        {
            return View(new Contact());
        }
        [HttpGet]

        public ActionResult Product()
        {
            return View(new Contact());
        }
        //httpget end

        //httppost start
        [HttpPost]
        public ActionResult Index(Contact Cont)
        {
            string NAME = Cont.NAME;
            string Email = Cont.Email;
            string CONTACT_NO = Cont.CONTACT_NO;
            string QUERY = Cont.QUERY;
            //string name = Cont.NAME;
            if (Cont.NAME == null || Cont.Email == null || Cont.CONTACT_NO == null || Cont.QUERY == null)
            {
                ViewBag.Cont = Cont;
            }
            else
            {
                Data(NAME.ToString(), Email.ToString(), CONTACT_NO.ToString(), QUERY.ToString());
            }
            return View();
        }

        [HttpPost]
        public ActionResult About(Contact Cont)
        {
            string NAME = Cont.NAME;
            string Email = Cont.Email;
            string CONTACT_NO = Cont.CONTACT_NO;
            string QUERY = Cont.QUERY;
            //string name = Cont.NAME;
            if (Cont.NAME == null || Cont.Email == null || Cont.CONTACT_NO == null || Cont.QUERY == null)
            {
                ViewBag.Cont = Cont;
            }
            else
            {
                Data(NAME.ToString(), Email.ToString(), CONTACT_NO.ToString(), QUERY.ToString());
            }
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contact Cont)
        {
            string NAME = Cont.NAME;
            string Email = Cont.Email;
            string CONTACT_NO = Cont.CONTACT_NO;
            string QUERY = Cont.QUERY;
            //string name = Cont.NAME;
            if (Cont.NAME == null || Cont.Email == null || Cont.CONTACT_NO == null || Cont.QUERY == null)
            {
                ViewBag.Cont = Cont;
            }
            else
            {
                Data(NAME.ToString(), Email.ToString(), CONTACT_NO.ToString(), QUERY.ToString());
            }
            return View("Contact");
        }

        [HttpPost]
        public ActionResult Gallery(Contact Cont)
        {
            string NAME = Cont.NAME;
            string Email = Cont.Email;
            string CONTACT_NO = Cont.CONTACT_NO;
            string QUERY = Cont.QUERY;
            //string name = Cont.NAME;
            if (Cont.NAME == null || Cont.Email == null || Cont.CONTACT_NO == null || Cont.QUERY == null)
            {
                ViewBag.Cont = Cont;
            }
            else
            {
                Data(NAME.ToString(), Email.ToString(), CONTACT_NO.ToString(), QUERY.ToString());
            }
            return View();
        }

        [HttpPost]
        public ActionResult Services(Contact Cont)
        {
            string NAME = Cont.NAME;
            string Email = Cont.Email;
            string CONTACT_NO = Cont.CONTACT_NO;
            string QUERY = Cont.QUERY;
            //string name = Cont.NAME;
            if (Cont.NAME == null || Cont.Email == null || Cont.CONTACT_NO == null || Cont.QUERY == null)
            {
                ViewBag.Cont = Cont;
            }
            else
            {
                Data(NAME.ToString(), Email.ToString(), CONTACT_NO.ToString(), QUERY.ToString());
            }
            return View();
        }

        [HttpPost]
        public ActionResult Coming_soon(Contact Cont)
        {
            string NAME = Cont.NAME;
            string Email = Cont.Email;
            string CONTACT_NO = Cont.CONTACT_NO;
            string QUERY = Cont.QUERY;
            //string name = Cont.NAME;
            if (Cont.NAME == null || Cont.Email == null || Cont.CONTACT_NO == null || Cont.QUERY == null)
            {
                ViewBag.Cont = Cont;
            }
            else
            {
                Data(NAME.ToString(), Email.ToString(), CONTACT_NO.ToString(), QUERY.ToString());
            }
            return View();
        }

        [HttpPost]
        public ActionResult Product(Contact Cont)
        {
            string NAME = Cont.NAME;
            string Email = Cont.Email;
            string CONTACT_NO = Cont.CONTACT_NO;
            string QUERY = Cont.QUERY;
            //string name = Cont.NAME;
            if (Cont.NAME == null || Cont.Email == null || Cont.CONTACT_NO == null || Cont.QUERY == null)
            {
                ViewBag.Cont = Cont;
            }
            else
            {
                Data(NAME.ToString(), Email.ToString(), CONTACT_NO.ToString(), QUERY.ToString());
            }
            return View();
        }
        //httppost end

        protected void Data(string NAME, string Email, string CONTACT_NO, string QUERY)
        {
            using (SqlConnection Sqlcon = new SqlConnection(conn))
            {
                Sqlcon.Open();
                String Query = "INSERT INTO MechwellEngg..TBL_ENQUERY VALUES(@NAME,@EMAIL,@CONTACT_NO,@QUERY,@SDATE)";
                SqlCommand cmd = new SqlCommand(Query, Sqlcon);
                cmd.Parameters.AddWithValue("@NAME", NAME.ToString());
                cmd.Parameters.AddWithValue("@Email", Email.ToString());
                cmd.Parameters.AddWithValue("@CONTACT_NO", CONTACT_NO.ToString());
                cmd.Parameters.AddWithValue("@QUERY", QUERY.ToString());
                cmd.Parameters.AddWithValue("@SDATE", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
            ModelState.Clear();
            var fromAddress = new MailAddress("enquiry.mechwell@gmail.com", "Mechwellind.com");
            //const string fromPassword = "9029286815";
            var toAddress = new MailAddress(Email.ToString(), "To Name");
            const string subject = "Thank you for enquiring to MECHWELL";
            StringBuilder body = new StringBuilder();
            body.Append("Dear " + NAME.ToString());
            body.Append("\n");
            body.Append("\nThank you for your interest in our products or services.");
            body.Append("\n");
            body.Append("\nWe would like to know your requirements in more detail and describe you how our products or services can help you in that regard.");
            body.Append("\n");
            body.Append("\nLooking forward to doing business with you.");
            body.Append("\n");
            body.Append("\n");
            body.Append("\nThank you!!!");
            body.Append("\n");
            body.Append("\n");
            body.Append("\nThanks and regards,");
            body.Append("\nMECHWELL ENGINEERING ");
            body.Append("\n");
            body.Append("\n");
            body.Append("\n");
            body.Append("Disclaimer: This is system generated email from an unmonitored inbox.Please do not reply to this email.");
            // body.Append("< span style = 'font-family:'monospace' > Disclaimer: This is system generated email from an unmonitored inbox.Please do not reply to this email.</ span >");
            var smtp = new SmtpClient
            {
                Host = "relay-hosting.secureserver.net",
                Port = 25,
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, "9029286815"),
                Timeout = 200000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body.ToString()
            })
            {
                smtp.Send(message);
            }
            var toAddress1 = new MailAddress("enquiry.mechwell@gmail.com", "To Name");
            StringBuilder subject1 = new StringBuilder();
            subject1.Append("Enquiry from " + NAME.ToString().ToUpper());
            //"Thank you for enquiring to MECHWELL";
            StringBuilder body1 = new StringBuilder();
            body1.Append("Name : " + NAME.ToString());
            body1.Append("\nEmail : " + Email.ToString());
            body1.Append("\nContact : " + CONTACT_NO.ToString());
            body1.Append("\nEnquiry : " + QUERY.ToString());
            var smtp1 = new SmtpClient
            {
                Host = "relay-hosting.secureserver.net",
                Port = 25,
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, "9029286815"),
                Timeout = 200000
            };
            using (var message = new MailMessage(fromAddress, toAddress1)
            {
                Subject = subject1.ToString(),
                Body = body1.ToString()
            })
            {
                smtp1.Send(message);
            }
            Response.Write(@"<script language='javascript'>alert('Message: \n" + "Your enquiry has been submited" + " .');</script>");
        }
    }
}

