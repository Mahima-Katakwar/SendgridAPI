using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult SendgridEmail()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendgridEmailSubmit(Emailmodel emailmodel)
        {
            ViewData["Message"] = "Email Sent!!!...";
            Example emailexample = new Example();
            await emailexample.Execute(emailmodel.From, emailmodel.To, emailmodel.Subject, emailmodel.Body
                , emailmodel.Body);

            return View("SendgridEmail");
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    internal class Example
    {      
        public async Task Execute(string From,string To,string subject,string plainTextContent,string htmlContent)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("mahimakatakwar599@gmail.com");            
            var to = new EmailAddress("mahimakatakwar599@gmail.com");           
            htmlContent = "<strong>" + htmlContent +"</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
