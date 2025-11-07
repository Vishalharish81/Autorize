using Autontication_learn.InputModel;
using Autontication_learn.Interface;
using Autontication_learn.Mailservices;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace Autontication_learn.Controllers
{
    public class LoginController : Controller
    {
        
        private readonly Login login;
        private readonly Mailservicescs _emailService;
        readonly string a = "vsvsv";
        public LoginController(Login _login , Mailservicescs mailservicescs ) 
        {
          login = _login;
         _emailService = mailservicescs;
        }

        [HttpGet("send-mail")]
        public IActionResult SendMail()
        {
            BackgroundJob.Schedule<Mailservicescs>(
                service => service.SendEmail("vishalharish81@gmail.com", "Test Mail", "Hello, this mail was sent by Hangfire!"),
                TimeSpan.FromSeconds(2)
            );

            return Ok("Mail scheduled, check your inbox in ~2 seconds.");
        }

        [HttpGet("Https")]
        public IActionResult Https()
        {
            var result = login.Https();

            return Ok(result);
        }
        [HttpGet("circle")]
        public IActionResult GetCircleArea(double radius)
        {
            Shape shape = new Circle { Radius = radius };
            var responseValue = new
            {
                status = "success",
                uom = shape.GetArea()
            };
            return Ok(responseValue);
        }

        [HttpGet("rectangle")]
        public IActionResult GetRectangleArea(double width, double height, double weight)
        {
            Shape shape = new Rectangles { Width = width, Height = height, weight = weight };
            var responseValue = new
            {
                status = "success",
                uom = shape.GetArea()
            };
            return Ok(responseValue);
        }
        [HttpGet("Employe")]
        public IActionResult Employe(int id , string name , string email)
        {
            Employe Employe = new employedetails { id = id, mail= email, name = name  };
            var responseValue = new
            {
                status = "success",
                details = "An abstract method is a method that has no body (implementation) in the base (abstract) class, and must be implemented by any derived class.",
                contract = Employe.Contractpeoples(),
                employe = Employe.Employedetails(),
                
            };
            return Ok(responseValue);
        }
        [HttpGet("const")]
        public IActionResult const1()
        {
            var responseValue = new
            {
                
                status = "success",
                readyonly = "Can be assigned at runtime (in constructor)  Can hold runtime values (e.g., values computed in constructor) Can be instance-level or static ",
                cons = "Must be assigned at compile time Must be a compile-time constant (e.g., numbers, strings, etc.) Implicitly static"


            };
            return Ok(responseValue);
        }

        [HttpGet("GG")]
        public IActionResult GG()
        {
            Console.WriteLine("Before creating objects...");
            Console.WriteLine("Memory used: " + GC.GetTotalMemory(false));
            var res1 = GC.GetTotalMemory(false);
            for (int i = 0; i < 10000; i++)
            {
                var obj = new object();
            }

            Console.WriteLine("After creating objects...");
            Console.WriteLine("Memory used: " + GC.GetTotalMemory(false));
            var res2 = GC.GetTotalMemory(false);
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("After GC.Collect()");
            Console.WriteLine("Memory used: " + GC.GetTotalMemory(false));
            var res3 = GC.GetTotalMemory(false);
            var responseValue = new
            {

                status = "success",
                readyonly = "Can be assigned at runtime (in constructor)  Can hold runtime values (e.g., values computed in constructor) Can be instance-level or static ",
                cons = "Must be assigned at compile time Must be a compile-time constant (e.g., numbers, strings, etc.) Implicitly static",
                res1 = res1 + GC.GetTotalMemory(false),
                res2 = res2 + GC.GetTotalMemory(false),
                res3 = res3 + GC.GetTotalMemory(false)

            };
            return Ok(responseValue);
        }
        [HttpGet("tup")]
        public IActionResult tup()
        {
            Tuple<int, int, int,string> tuple = new Tuple<int, int, int,string>(1, 2, 3,"tyuio");

            var responseValue = new
            {

                status = "success",
               tupple = tuple.Item4

            };
            return Ok(responseValue);
        }
        [HttpGet]
        [Route("Delegate")]

        public IActionResult Delegate(LoginInputModel LoginInputModel)
        {
            int x = 10;
            int y = 20;
            string c = login.delegat(x,y);
            return Ok(c);
        }
        

        [HttpGet]
        [Route("abstract")]

        public IActionResult abstractc (LoginInputModel LoginInputModel)
        {
            int x = 10;
            int y = 20;
            string c = login.abstractc(x, y);
            return Ok(c);
        }

        [HttpGet]
        [Route("structkey")]

        public IActionResult structkey(LoginInputModel LoginInputModel)
        {
            int x = 10;
            int y = 20;
            string c = login.structkey(x, y);
            return Ok(c);
        }
            [HttpGet]
        [Route("Logincontrol")]

        public IActionResult LoginMethod(LoginInputModel LoginInputModel)
        {

            var resut = login.ApplyDiscount(100);
            return Ok(resut);
        }
    }
}
