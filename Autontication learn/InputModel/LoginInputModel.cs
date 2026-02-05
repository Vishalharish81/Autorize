namespace Autontication_learn.InputModel
{

    public delegate int  CalculateDelegae (int x, int y);
    public class LoginInputModel
    {
        public string Password { get; set; }
        public string Email { get; set; }
     
    }
    public class Node
    {
        public int Data;
        public Node Next;

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }
    public abstract class Shape
    {
        public string Name { get; set; }

        public abstract double GetArea();

        public void Display()
        {

        }
    }

    

   

    // Service
   

    public class circle : shapes
    {
        public int b { get; set; }
        public int Y { get; set; }
    }
    public  class shapes
    {

        public int i { get; set; }
        public int Y { get; set; }
    }
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }


    public abstract class newabs
    {
        public abstract string name();
    }

    public class checking : newabs
    {
        public override string name()
        {
            return "this is abstract class";
        }
    }
    public class checking1 : newabs
    {
        public override string name()
        {
            return "this is abstract class";
        }
    }

    public class Rectangles : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double weight { get; set; }
        public override double GetArea()
        {
            return Width + Height  + weight;
        }
    }


    public class structkey
    {
        public int id { get; set; }
    }

    public struct authorixd 
    {
        public int name { get; set; }
    }


    public abstract class Employe
    {   public abstract string Employedetails();
        public abstract string Contractpeoples();
    }


    public  class employedetails : Employe
    {
        public string name { get; set;}
        public int id  { get; set; }
        public string mail { get; set; }

        public override string Contractpeoples()
        {
            return name;
        }

        public override string Employedetails()
        {
            return mail;
        }
    }

    public static class calculator
    {
        public static int add(int x, int y)
        {
            return x + y;
        }
        public static int sub(int x, int y)
        {
            return x - y;
        }
    }
}
