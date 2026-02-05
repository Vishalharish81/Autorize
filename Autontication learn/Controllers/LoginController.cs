using Autontication_learn.InputModel;
using Autontication_learn.Interface;
using Autontication_learn.Mailservices;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Security.AccessControl;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        [Route("MedianArray")]

        public IActionResult MedianArray(LoginInputModel LoginInputModel)
        {
            int[] nums1 = [2, 2, 4, 4];
            int[] nums2 = [2, 2, 2, 4, 4];
            int[] nums3 = nums1.Concat(nums2).OrderBy(x=>x).ToArray();
            int n = nums3.Length;

            // If odd length
            if (n % 2 != 0)
            {

                double f1 = n / 2;
                return Ok(nums3[n / 2]);
            }
            // If even length
            else
            {
                return Ok((nums3[(n / 2) - 1] + nums3[n / 2]) / 2.0);
            }
        }
        [HttpGet]
        [Route("LinkedList")]

        public IActionResult LinkedList(LoginInputModel LoginInputModel)
        {
            int[] val = [3, 2, 0, -4];
            Node head = null;
            Node current  = null;

            foreach (var item in val)
            {
                if(head == null)
                {
                    head = new Node(item);
                    current = head;
                }
                else
                {
                    current.Next = new Node(item);
                    current = current.Next;
                }
            }


            return Ok(current);
        }
        public Node Insert(Node node , int data)
        {
            Node newnode = new Node(data);
            newnode.Next = node;
            return newnode;   // new head
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
        [HttpGet]
        [Route("insertposition")]

        public IActionResult insertposition()
        {
            int[] nums = [1, 3, 5, 6];
            int target = 7;
            int result = 0;
            for(int i=0; i < nums.Length;i++)
            {
                if (nums[i] < target)
                {
                    result++;
                }
            }

            return Ok(result);
        }
        [HttpGet]
        [Route("plusdigit")]

        public IActionResult plusdigit()
        {

            int[] digits = [9, 8, 9, 9];
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return Ok(digits);
                }

                digits[i] = 0;
            }

            int[] result = new int[digits.Length + 1];
            result[0] = 1;
            return Ok(result);

            
            
        }
        [HttpGet]
        [Route("LongestSubstring")]

        public IActionResult LongestSubstring()
        {

            string s = "pwwkew";
            int removeduplicate = s.Distinct().Count();

            return Ok(removeduplicate);


        }


        [HttpGet]
        [Route("lastword")]

        public IActionResult lastword()
        {
             int result = 0;
            string s = "   fly me   to   the moon  ";
             s.Trim(); 
            string result1 = s.Trim();
            char[] chararray = result1.ToCharArray();
             Array.Reverse(chararray);
             string  newarray = new string (chararray);

            string[] newsplit = newarray.Split(" ");

            return Ok(newsplit[0].Length);
        }
        [HttpGet]
        [Route("findindex")]

        public IActionResult findindex()
        { 
           string  haystack = "hello";
            string needle = "ll";
            int returns = haystack.IndexOf("leetc");
            return Ok(haystack.IndexOf(needle));
        }
            [HttpGet]
        [Route("DSA")]

        public IActionResult structure()
        {
            // var TwoSum1 =  TwoSum([1, 6, 2, 8], 10);

            //bool ischeck = IsPalindrome(121);
            // int r = RomanToInt("MCMXCIV");
            //bool Parentheses = Parenthesesss("()");
            //string result = inputval(["flower", "flow", "flight"]);
          // int res=  removeduplicate([0, 0, 1, 1, 1, 2, 2, 3, 3, 4]);

            int res = removeduplicatenew([0, 1, 2, 2, 3, 0, 4, 2], 2);

            return Ok(res);
        }
       public int  removeduplicate(int[] nums)
        {
            int[] removedduplicate = nums.Distinct().ToArray();

            int index = 1;
            for(int i =1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i-1])
                {
                    nums[index] = nums[i];
                    index++;
                }
            }
            

         
            return removedduplicate.Length;
        }
        public int removeduplicatenew(int[] nums,int val)
        {
            int[] removedduplicate = nums.Distinct().ToArray();

            int index = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[index] = nums[i];
                    index++;
                }
            }



            return index;
        }

        public bool Parenthesesss(string s)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in s)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count == 0)
                        return false;

                    char top = stack.Peek();

                    if ((c == ')' && top == '(') ||
                        (c == '}' && top == '{') ||
                        (c == ']' && top == '['))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

      


        public string inputval(string []result)
        {
            string results = string.Empty;
            if (result.Length > 0)
            {
                Array.Sort(result);
                string prefix = result[0];
                string prefix1 = result[result.Length - 1];

                for (int i = 0; i < prefix.Length; i++) 
                {
                    if (prefix.ToCharArray()[i] == prefix1.ToCharArray()[i])
                    {
                        char v = prefix1.ToCharArray()[i];
                        results =  results + v;
                    }
                    else
                    {
                        break;
                    }
                   
                }

            }
            else
            {
                results = "";
            }
            


            return results;
        }
        public int RomanToInt(string s)
        {
            Dictionary<char, int> romanMap = new Dictionary<char, int>()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };
            int res = 0;
            for(int i = 0;i <s.Length; i++)
            {
                int value = i + 1;
                int slength = s.Length;
                int romalvalue = romanMap[s[i]];
                int romanlength = romanMap[s[i +1 ]];

                if (value < slength && romanlength < romalvalue)
                {
                    res += romanMap[s[i]] - romanMap[s[i + 1]];
                }
                else
                {
                    res += romanMap[s[i]];
                }
                   
                
            }

            return res;
        }
         public bool IsPalindrome( int x )
        {
           if (x < 0) return false;
           int original = x;
            int reverse = 0;

            while (x>0)
            {
                int lastdigit = x % 10;
                reverse = reverse * 10 + lastdigit ;
                 x = x / 10;

                
            }


            return (reverse == original);
        }
        public int[] TwoSum(int[] nums, int target)
        {
            var map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int diff = target - nums[i];
                if (map.ContainsKey(diff))
                    return new int[] { map[diff], i };

                map[nums[i]] = i;
            }
            return Array.Empty<int>();
        }

    }
}
