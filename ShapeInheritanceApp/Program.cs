using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ShapeInheritanceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.MainMenu();
        }

        public class Shape
        {
            public double Length { get; set; }
            public double Width { get; set; }

            public void DisplayInfo()
            {
                WriteLine("Your {0} has a length of {1} and a width of {2} and an area of {3}.", GetType().Name, Length, Width, GetArea());
            }

            public double GetArea()
            {
                return Length * Width;
            }
        }

        public class Rectangle : Shape
        {

            public Rectangle(double length, double width)
            {
                Length = length;
                Width = width;
            }

            public void AcceptDetails()
            {
                WriteLine("Length is " + Length + ". Width is " + Width);
                WriteLine("Do you accept these details? Enter Y for Yes or N for No.");
                var answer = ReadLine().ToLower();
                if (answer == "y")
                {
                    WriteLine("Thank you! Rectangle saved.");
                }
                else if (answer == "n")
                {
                    WriteLine("Please reenter the length: ");
                    Length = Convert.ToDouble(ReadLine());
                    WriteLine("Please reenter the width: ");
                    Width = Convert.ToDouble(ReadLine());
                }
                else
                {
                    WriteLine("Invalid response. Please try again.");
                    AcceptDetails();
                }

            }

            public void Display()
            {
                WriteLine("Here is a picture of your rectangle.");
                for (int y = 0; y < Length; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        Console.Write("*");
                    }

                    Console.WriteLine();
                }
            }
        }

        public class Triangle : Shape
        {

            public Triangle(double length, double width)
            {
                Length = length;
                Width = width;
            }

            public new double GetArea()
            {
                return (Length * Width) / 2;
            }

            public void AcceptDetails()
            {
                WriteLine("Length is " + Length + ". Width is " + Width);
                WriteLine("Do you accept these details? Enter Y for Yes or N for No.");
                var answer = ReadLine().ToLower();
                if (answer == "y")
                {
                    WriteLine("Thank you! Rectangle saved.");
                }
                else if (answer == "n")
                {
                    WriteLine("Please reenter the length: ");
                    Length = Convert.ToDouble(ReadLine());
                    WriteLine("Please reenter the width: ");
                    Width = Convert.ToDouble(ReadLine());
                }
                else
                {
                    WriteLine("Invalid response. Please try again.");
                    AcceptDetails();
                }

            }

            public void Display()
            {
                WriteLine("Here is a picture of your triangle.");
                WriteLine("*");
                int x = 1;
                int y = 1;
                while (y++ < Width)
                {

                    Write("*");


                    var l = (int)Length * y / Width;


                    x = 1;
                    while (x++ < l - 3)
                    {
                        Write(" ");
                    }
                    WriteLine("*");
                }


                x = 0;
                while (x++ < Length)
                {
                    Write("*");
                }
                WriteLine();
            }
        }

        public class Octagon : Shape
        {
            public double SideLength { get; set; }

            public new double GetArea()
            {
                double area = 2 * (1 + Math.Sqrt(2)) * (SideLength * SideLength);
                return area;
            }

            public Octagon(double sidelength)
            {
                SideLength = sidelength;
            }

            public void Display()
            {
                WriteLine("Side Length is {0}", SideLength);
                WriteLine("Area is {0}", GetArea());
            }

            public void AcceptDetails()
            {
                WriteLine("The side length is {0}", SideLength);
                WriteLine("Do you accept the details? Enter Y for yes or N for no.");

                var answer = ReadLine().ToLower();
                if (answer == "y")
                {
                    WriteLine("Thank you! Octagon saved.");
                }
                else if (answer == "n")
                {
                    WriteLine("Please reenter the side length: ");
                    SideLength = Convert.ToDouble(ReadLine());
                }
                else
                {
                    WriteLine("Invalid response. Please try again.");
                    AcceptDetails();
                }
            }
        }

        public class Square : Shape
        {

            public Square(double length, double width)
            {
                Length = length;
                Width = width;
            }

            

            public void AcceptDetails()
            {
                WriteLine("Length is " + Length + ". Width is " + Width);
                WriteLine("Do you accept these details? Enter Y for Yes or N for No.");
                var answer = ReadLine().ToLower();
                if (answer == "y")
                {
                    WriteLine("Thank you! Square saved.");
                }
                else if (answer == "n")
                {
                    WriteLine("Please reenter the length and width: ");
                    Length = Convert.ToDouble(ReadLine());
                    Width = Length;
                }
                else
                {
                    WriteLine("Invalid response. Please try again.");
                    AcceptDetails();
                }

            }

            public void Display()
            {
                WriteLine("Here is a picture of your square.");
                for (int y = 0; y < Length; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        Write("*");
                    }

                    WriteLine();
                }
            }
        }

        public class TimesTable
        {
            public double Number { get; set; }

            public TimesTable(double n)
            {
                Number = n;
            }

            public void Display()
            {
                WriteLine("Here is your times table:");
                for (int i = 0; i <= 10; i++)
                {
                    WriteLine(Number * i);
                }
            }
        }

        public static class Menu
        {
            public static void MainMenu()
            {
                WriteLine("Welcome to the Math assignment in C Sharp!");
                WriteLine("Enter 1 to build a rectangle, 2 for a square, 3 for a triangle, 4 for an octagon or 5 for a times table.");
                WriteLine("Or enter 0 to exit.");
                var answer = ReadLine();
                if (answer == "0")
                {
                    WriteLine("Goodbye!");
                    Environment.Exit(0);
                }
                else if (answer == "1")
                {
                    WriteLine("Enter the length of your rectangle: ");
                    double length = 0;
                    double width = 0;
                    try
                    {
                        length = Convert.ToDouble(ReadLine());
                    }
                    catch (SystemException)
                    {
                        WriteLine("Error! Invalid value. Going back to main menu...");
                        Menu.MainMenu();
                    }
                    WriteLine("Enter the width of your rectangle: ");
                    try
                    {
                        width = Convert.ToDouble(ReadLine());
                    }
                    catch (SystemException)
                    {
                        WriteLine("Error! Invalid value. Going back to main menu...");
                        Menu.MainMenu();
                    }

                    Rectangle rectangle = new Rectangle(length, width);

                    WriteLine("The area of your rectangle is " + rectangle.GetArea());
                    rectangle.AcceptDetails();
                    rectangle.Display();
                    rectangle.DisplayInfo();
                    Menu.MainMenu();


                }
                else if (answer == "2")
                {
                    WriteLine("Enter the length and width of your square: ");
                    double length = 0;
                    try
                    {
                        length = Convert.ToDouble(ReadLine());
                    }
                    catch (SystemException)
                    {
                        WriteLine("Error. Invalid value specified. Returning to main menu...");
                        Menu.MainMenu();
                    }

                    var width = length;

                    Square square = new Square(length, width);

                    WriteLine("The area of your rectangle is " + square.GetArea());
                    square.AcceptDetails();
                    square.Display();
                    Menu.MainMenu();
                }
                else if (answer == "3")
                {
                    WriteLine("Enter the length of your triangle: ");
                    double length = 0;
                    double width = 0;
                    try
                    {
                        length = Convert.ToDouble(ReadLine());
                    }
                    catch (SystemException)
                    {
                        WriteLine("Error! Invalid value. Going back to main menu...");
                        Menu.MainMenu();
                    }
                    WriteLine("Enter the width of your triangle: ");
                    try
                    {
                        width = Convert.ToDouble(ReadLine());
                    }
                    catch (SystemException)
                    {
                        WriteLine("Error! Invalid value. Going back to main menu...");
                        Menu.MainMenu();
                    }

                    Triangle triangle = new Triangle(length, width);

                    WriteLine("The area of your triangle is " + triangle.GetArea());
                    triangle.AcceptDetails();
                    triangle.Display();
                    Menu.MainMenu();
                }
                else if (answer == "4")
                {
                    WriteLine("Enter the side length of your octagon: ");
                    double sidelength = 0;
                    try
                    {
                        sidelength = Convert.ToDouble(ReadLine());
                    }
                    catch (SystemException)
                    {
                        WriteLine("Error! Invalid value. Going back to main menu...");
                        Menu.MainMenu();
                    }

                    Octagon octagon = new Octagon(sidelength);

                    octagon.AcceptDetails();
                    octagon.Display();
                    Menu.MainMenu();
                }
                else if (answer == "5")
                {
                    WriteLine("Please enter your value for a times table.");
                    double value = 0;
                    try
                    {
                        value = Convert.ToDouble(ReadLine());
                    }
                    catch (SystemException)
                    {

                    }
                    TimesTable table = new TimesTable(value);
                    table.Display();
                    Menu.MainMenu();
                }
                else
                {
                    WriteLine("Invalid response! Try again.");
                    Menu.MainMenu();
                }
            }
        }
    }
}