using System;
interface Drawable
{
    void draw();
}

abstract class Shape
{
    public abstract double Calculate_area();
    public abstract void draw();
}

class Rectangle : Shape, Drawable
{
    double length, width;

    public Rectangle(double length, double width)
    {
        this.length = length;
        this.width = width;
    }

    public double get_Length() => length;
    public double get_Width() => width;

    public override double Calculate_area()
    {
        return get_Length() * get_Width();
    }

    public override void draw()
    {
        Console.WriteLine("LENGTH = " + get_Length() + " WIDTH = " + get_Width());
        Console.WriteLine("Rectangle AREA = " + Calculate_area());
    }
}

class Circle : Shape, Drawable
{
    double pi = 3.14159;
    double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public double get_Radius() => radius;

    public override double Calculate_area()
    {
        return pi * radius * radius;
    }

    public override void draw()
    {
        Console.WriteLine("RADIUS = " + get_Radius());
        Console.WriteLine("Circle AREA = " + Calculate_area());
    }
}

class Triangle : Shape, Drawable
{
    double Base, height;

    public Triangle(double height, double Base)
    {
        this.height = height;
        this.Base = Base;
    }

    public double get_Base() => Base;
    public double get_height() => height;

    public override double Calculate_area()
    {
        return 0.5 * get_height() * get_Base();
    }

    public override void draw()
    {
        Console.WriteLine("Height = " + get_height() + " Base = " + get_Base());
        Console.WriteLine("Triangle Area = " + Calculate_area());
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nCHOOSE FROM THE MENU");
            Console.WriteLine("PRESS 1 TO FIND RECTANGLE AREA");
            Console.WriteLine("PRESS 2 TO FIND CIRCLE AREA");
            Console.WriteLine("PRESS 3 TO FIND TRIANGLE AREA");
            Console.WriteLine("PRESS 0 TO EXIT");

            char choice = Console.ReadLine()[0];

            switch (choice)
            {
                case '1':
                    Console.WriteLine("ENTER LENGTH AND WIDTH");
                    double l = double.Parse(Console.ReadLine());
                    double w = double.Parse(Console.ReadLine());
                    Shape rect = new Rectangle(l, w);
                    rect.draw();
                    break;

                case '2':
                    Console.WriteLine("ENTER RADIUS OF CIRCLE");
                    double r = double.Parse(Console.ReadLine());
                    Shape circle = new Circle(r);
                    circle.draw();
                    break;

                case '3':
                    Console.WriteLine("ENTER HEIGHT AND BASE");
                    double h = double.Parse(Console.ReadLine());
                    double B = double.Parse(Console.ReadLine());
                    Shape tri = new Triangle(h, B);
                    tri.draw();
                    break;

                case '0':
                    Console.WriteLine("EXITING THE PROGRAM...");
                    return;

                default:
                    Console.WriteLine("INVALID CHOICE");
                    break;
            }
        }
    }
}

