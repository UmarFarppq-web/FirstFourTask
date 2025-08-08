using System;

public class Node<T>
{
    public T data;
    public Node<T> next;

    public Node(T value)
    {
        data = value;
        next = null;
    }
}
public class Stack<T>
{
    public Node<T> top;

    public void PushItem(T item)
    {
        Node<T> newNode = new Node<T>(item);
        newNode.next = top;
        top = newNode;
    }

    public bool IsEmpty()
    {
        return top == null;
    }

    public T Pop()
    {
        if (IsEmpty())
        {
            Console.WriteLine("NO DATA IN THE STACK");
        }
        T value = top.data;
        top = top.next;
        return value;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            Console.WriteLine("NO DATA IN THE STACK");
        }

        return top.data;
    }
}

class Program
{
    public static void Main()
    {
        Stack<string> browsedata = new Stack<string>();
        browsedata.PushItem("HOME");
        browsedata.PushItem("ABOUT");
        browsedata.PushItem("CONTACT");

        Console.Write("CURRENT PAGE IS : " + browsedata.Peek());
        Console.WriteLine();
        browsedata.Pop();
        Console.Write("CURRENT PAGE IS : " + browsedata.Peek());
        Console.WriteLine();
        browsedata.Pop();
        Console.Write("CURRENT PAGE IS : " + browsedata.Peek());


    }
}