using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static void Main(string[] args)
        {
            /*Triangle num1 = new Triangle(7, 7, 7, -4, -2, 4);
            FileJSON.SafeTo(num1);*/
            Triangle num1 = FileJSON.ReadFrom("D:/1курс_2семестр/Програмування-2/LAB_1/triangles_laba1/triangles_laba1/file.json");
            Triangle num2 = new Triangle(1, 5, 6, -4, -2, 1);
            num1.EqualTriangle(1, 5, 6, -4, -2, 1);
            Console.WriteLine("-------------------------------------------------------------------");
            
            Console.WriteLine("Інформація про трикутник № 1");
            num1.Type();
            num1.Angle();
            Console.WriteLine("Периметр: " + Math.Round(num1.Perimetr(), 3));
            Console.WriteLine("Площа: " + Math.Round(num1.Area(), 3));
            Console.WriteLine("Висоти: " + num1.Heights());
            Console.WriteLine("Медіани: " + num1.Medians());
            Console.WriteLine("Бісектриси: " + num1.Bisectors());
            Console.WriteLine("Радіус описаного кола: " + Math.Round(num1.R(), 3));
            Console.WriteLine("Радіус вписаного кола: " + Math.Round(num1.r(), 3));
            Console.WriteLine("Поворот на кут відносно центру описаного кола: "); num1.RotateCenter(15);
            Console.WriteLine("Поворот на кут відносно заданої точки: "); num1.RotatePoint(30, 2, 3);
            Console.WriteLine("-------------------------------------------------------------------");
           
            Console.WriteLine("Інформація про трикутник № 2");
            num2.Type();
            num2.Angle();
            Console.WriteLine("Периметр: " + Math.Round(num2.Perimetr(), 3));
            Console.WriteLine("Площа: " + Math.Round(num2.Area(), 3));
            Console.WriteLine("Висоти: " + num2.Heights());
            Console.WriteLine("Медіани: " + num2.Medians());
            Console.WriteLine("Бісектриси: " + num2.Bisectors());
            Console.WriteLine("Радіус описаного кола: " + Math.Round(num2.R(), 3));
            Console.WriteLine("Радіус вписаного кола: " + Math.Round(num2.r(), 3));
            Console.WriteLine("Поворот на кут відносно центру описаного кола: "); num2.RotateCenter(15);
            Console.WriteLine("Поворот на кут відносно заданої точки: "); num2.RotatePoint(30, 2, 3);
        }
    }

    public class Triangle
    {
        public double x1, y1,x2, y2, x3, y3; //координаты вершин и сторон треугольников
        double a, b, c;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3) //конструктор
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;

            this.a = Math.Sqrt(Math.Pow(this.x2 - this.x1, 2) + Math.Pow(this.y2 - this.y1, 2)); //считаем стороны
            this.b = Math.Sqrt(Math.Pow(this.x3 - this.x2, 2) + Math.Pow(this.y3 - this.y2, 2));
            this.c = Math.Sqrt(Math.Pow(this.x3 - this.x1, 2) + Math.Pow(this.y3 - this.y1, 2));
        }

        private double A
        {
            get { return a; }
            set { a = value; }
        }

        private double B
        {
            get { return b; }
            set { b = value; }
        }
        private double C
        {
            get { return c; }
            set { c = value; }
        }

        public void EqualTriangle(double x1_2, double y1_2,     //метод що визначає чи рівні трикутики
       double x2_2, double y2_2,
       double x3_2, double y3_2)
        {

            double a_2 = Math.Sqrt(Math.Pow(x2_2 - x1_2, 2) + Math.Pow(y2_2 - y1_2, 2));
            double b_2 = Math.Sqrt(Math.Pow(x3_2 - x2_2, 2) + Math.Pow(y3_2 - y2_2, 2));
            double c_2 = Math.Sqrt(Math.Pow(x3_2 - x1_2, 2) + Math.Pow(y3_2 - y1_2, 2));

            if (a == a_2 && b == b_2 && c == c_2)
            {
                Console.WriteLine("Трикутники рівні");
            }
            else { Console.WriteLine("Трикутники НЕ рівні"); }

        }

        public double Perimetr()  //метод для периметра
        {
            double P;
            P = a + b + c;
            return P;
        }

        public double Area() //метод для площі
        {
            double p = Perimetr() / 2;
            return (Math.Sqrt(p * (p - a) * (p - b) * (p - c)));
        }


        public Tuple<double, double, double> Heights() //метод для висот
        {
            double h1 = Math.Round(Area() / a, 3);
            double h2 = Math.Round(Area() / b, 3);
            double h3 = Math.Round(Area() / c, 3);
            var heights = Tuple.Create(h1, h2, h3);
            return heights;
        }

        public Tuple<double, double, double> Medians() //метод для медіан
        {
            double m1 = Math.Round(Math.Sqrt(2 * (Math.Pow(c, 2) + Math.Pow(b, 2)) - Math.Pow(a, 2)) / 2, 3);
            double m2 = Math.Round(Math.Sqrt(2 * (Math.Pow(c, 2) + Math.Pow(a, 2)) - Math.Pow(b, 2)) / 2, 3);
            double m3 = Math.Round(Math.Sqrt(2 * (Math.Pow(a, 2) + Math.Pow(b, 2)) - Math.Pow(c, 2)) / 2, 3);
            var medians = Tuple.Create(m1, m2, m3);
            return medians;
        }


        public Tuple<double, double, double> Bisectors() //метод для бісектрис
        {
            double b1 = Math.Round(Math.Sqrt(a * b * (a + b + c) * (a + b - c)) / (a + b), 3);
            double b2 = Math.Round(Math.Sqrt(c * b * (a + b + c) * (c + b - a)) / (c + b), 3); ;
            double b3 = Math.Round(Math.Sqrt(a * c * (a + b + c) * (a + c - b)) / (a + c), 3);
            var bisectors = Tuple.Create(b1, b2, b3);
            return bisectors;
        }

        public double R() //метод для радіусу описаного кола
        {
            double R;
            R = (a * b * c) / (4 * Area());
            return R;
        }

        public double r() //метод для радіусу вписаного кола
        {
            double r;
            r = 2 * Area() / Perimetr();
            return r;
        }

        public void Type() //визначення типу трикутника
        {
            if ((a * a + b * b == c * c) || (a * a + c * c == b * b) || (c * c + b * b == a * a))
            {
                Console.WriteLine("Трикутник прямокутний");
            }
            if ((a == b) || (a == c) || (b == c))
            {
                Console.WriteLine("Трикутник рiвнобедренний");
            }
            if ((a == b) && (a == c) && (b == c))
            {
                Console.WriteLine("Трикутник правильний");
            }
            else
            {
                Console.WriteLine("Трикутник довiльний");
            }
        }

        public void Angle()
        {
            double cosA = (Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * b * c);
            double cosB = (Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) / (2 * a * c);
            double cosC = (Math.Pow(b, 2) + Math.Pow(a, 2) - Math.Pow(c, 2)) / (2 * b * a);
            if (cosA == 0 || cosB == 0 || cosC == 0)
                Console.WriteLine("Трикутник прямокутний");
            else if (cosA < 0 || cosB < 0 || cosC < 0)
                Console.WriteLine("Трикутник тупокутний");
            else
                Console.WriteLine("Трикутник гострокутний");
        }

        public void RotateCenter(double angle) //поворот на кут відносно центра
        {
            double x1_new = Math.Round(x1 * Math.Cos(angle) - y1 * Math.Sin(angle), 3);
            double y1_new = Math.Round(y1 * Math.Cos(angle) + x1 * Math.Sin(angle), 3);
            double x2_new = Math.Round(x2 * Math.Cos(angle) - y2 * Math.Sin(angle), 3);
            double y2_new = Math.Round(y2 * Math.Cos(angle) + x2 * Math.Sin(angle), 3);
            double x3_new = Math.Round(x3 * Math.Cos(angle) - y3 * Math.Sin(angle), 3);
            double y3_new = Math.Round(y3 * Math.Cos(angle) + x3 * Math.Sin(angle), 3);
            var point1 = Tuple.Create(x1_new, y1_new);
            var point2 = Tuple.Create(x2_new, y2_new);
            var point3 = Tuple.Create(x3_new, y3_new);
            var cordinates = Tuple.Create(point1, point2, point3);
            Console.WriteLine(cordinates);
        }

        public void RotatePoint(double angle, double x0, double y0)  //поворот на кут відносно точки
        {
            double x1_new = Math.Round((x1 - x0) * Math.Cos(angle) - (y1 - y0) * Math.Sin(angle), 3);
            double y1_new = Math.Round((y1 - y0) * Math.Cos(angle) + (x1 - x0) * Math.Sin(angle), 3);
            double x2_new = Math.Round((x2 - x0) * Math.Cos(angle) - (y2 - y0) * Math.Sin(angle), 3);
            double y2_new = Math.Round((y2 - y0) * Math.Cos(angle) + (x2 - x0) * Math.Sin(angle), 3);
            double x3_new = Math.Round((x3 - x0) * Math.Cos(angle) - (y3 - y0) * Math.Sin(angle), 3);
            double y3_new = Math.Round((y3 - y0) * Math.Cos(angle) + (x3 - x0) * Math.Sin(angle), 3);
            var point1 = Tuple.Create(x1_new, y1_new);
            var point2 = Tuple.Create(x2_new, y2_new);
            var point3 = Tuple.Create(x3_new, y3_new);
            var cordinates = Tuple.Create(point1, point2, point3);
            Console.WriteLine(cordinates);
        }
    }

}

