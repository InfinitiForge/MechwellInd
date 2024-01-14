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
    public class ProductsController : Controller
    {
        string conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        // GET: Products
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        public ActionResult Marine_Fabrication()
        {
            return View(new Contact());
        }
        [HttpGet]
        public ActionResult Machining_Works()
        {
            return View(new Contact());
        }
        [HttpGet]
        public ActionResult VFFS_Packaging_Machine()
        {
            return View(new Contact());
        }
        [HttpGet]
        public ActionResult Pharma_cosmetic()
        {
            return View(new Contact());
        }
        [HttpGet]
        public ActionResult Shredding_Machine()
        {
            return View(new Contact());
        }


        [HttpPost]
        public ActionResult Marine_Fabrication(Contact Cont)
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
            return View(new Contact());
        }
        [HttpPost]
        public ActionResult Machining_Works(Contact Cont)
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
            return View(new Contact());
        }
        [HttpPost]
        public ActionResult VFFS_Packaging_Machine(Contact Cont)
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
            return View(new Contact());
        }
        [HttpPost]
        public ActionResult Pharma_cosmetic(Contact Cont)
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
            return View(new Contact());
        }
        [HttpPost]
        public ActionResult Shredding_Machine(Contact Cont)
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
            return View(new Contact());
        }

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
            const string fromPassword = "9029286815";
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
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
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
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
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