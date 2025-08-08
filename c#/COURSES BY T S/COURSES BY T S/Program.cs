using System;
using System.Collections.Generic;

interface I_CAN_TEACH
{
    void TeachCourse(Course c);
}

interface I_CAN_STUDY
{
    void EnrolledCourse(Course c);
}

abstract class Person
{
    protected string id, name, email;

    public Person(string id, string name, string email)
    {
        this.id = id;
        this.name = name;
        this.email = email;
    }

    public abstract string GetId();
    public abstract string GetName();
    public abstract string GetEmail();
}

public class Course
{
    public string c_id, c_title, c_credits;

    public Course(string c_id, string c_title, string c_credits)
    {
        this.c_id = c_id;
        this.c_title = c_title;
        this.c_credits = c_credits;
    }

    public string GetId() => c_id;
    public string GetTitle() => c_title;
    public string GetCredits() => c_credits;

    public override string ToString()
    {
        return $"{c_title} ({c_id}) - Credits: {c_credits}";
    }
}

class Student : Person, I_CAN_STUDY
{
    private string grade;
    private List<Course> enrolledCourses;

    public Student(string id, string name, string email, string grade)
        : base(id, name, email)
    {
        this.grade = grade;
        enrolledCourses = new List<Course>();
    }

    public override string GetId() => id;
    public override string GetName() => name;
    public override string GetEmail() => email;

    public void EnrolledCourse(Course c)
    {
        enrolledCourses.Add(c);
        Console.WriteLine($"{name} enrolled in {c.c_title}");
    }

    public void ShowEnrolledCourses()
    {
        Console.WriteLine($"{name}'s Enrolled Courses:");
        foreach (Course c in enrolledCourses)
        {
            Console.WriteLine(" - " + c);
        }
    }
}

class Teacher : Person, I_CAN_TEACH
{
    string subject;
    List<Course> assignedcourse;

    public Teacher(string subject, string id, string name, string email)
        : base(id, name, email)
    {
        this.subject = subject;
        assignedcourse = new List<Course>();
    }

    public override string GetId() => id;
    public override string GetName() => name;
    public override string GetEmail() => email;

    public void TeachCourse(Course c)
    {
        assignedcourse.Add(c);
        Console.WriteLine($"{name} has been assigned to teach {c.c_title}");
    }
    public void SHOWTEACHCourses()
    {
        Console.WriteLine($"{name}'s TEACHING Courses:");
        foreach (Course c in assignedcourse)
        {
            Console.WriteLine(" - " + c);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Course c1 = new Course("102", "Urdu", "23213");
        Course c2 = new Course("103", "English", "98913");

        Student s1 = new Student("1", "Umar", "umer@gmail.com", "A");
        Student s2 = new Student("2", "Ibrar", "ibrar@gmail.com", "B");

        s1.EnrolledCourse(c1);
        s1.EnrolledCourse(c2);
        Console.WriteLine();
        s2.EnrolledCourse(c2);
        Console.WriteLine();
        s1.ShowEnrolledCourses();
        Console.WriteLine();
        s2.ShowEnrolledCourses();

        Teacher t = new Teacher("Urdu", "1002", "Ismail", "ismail@gmail.com");
        t.TeachCourse(c1);
        t.TeachCourse(c2);
        Console.WriteLine();
        t.SHOWTEACHCourses();
    }
}
