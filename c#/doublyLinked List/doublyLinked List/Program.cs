using System;

public class Node<T>
{
    public T Value;
    public Node<T> Next;
    public Node<T> Previous;

    public Node(T value)
    {
        Value = value;
        Next = null;
        Previous = null;
    }
}

public class DoublyLinkedList<T>
{
    private Node<T> head;
    private Node<T> current;

    public void AddLast(T value)
    {
        Node<T> newNode = new Node<T>(value);

        if (head == null)
        {
            head = newNode;
            current = head;
        }
        else
        {
            Node<T> temp = head;
            while (temp.Next != null)
                temp = temp.Next;

            temp.Next = newNode;
            newNode.Previous = temp;
        }
    }

    public void PrintForward()
    {
        Node<T> temp = head;
        Console.WriteLine("Forward:");
        while (temp != null)
        {
            Console.Write(temp.Value + " ");
            temp = temp.Next;
        }
        Console.WriteLine();
    }

    public void PrintBackward()
    {
        if (head == null)
            return;

        Node<T> temp = head;
        while (temp.Next != null)
            temp = temp.Next;

        Console.WriteLine("Backward:");
        while (temp != null)
        {
            Console.Write(temp.Value + " ");
            temp = temp.Previous;
        }
        Console.WriteLine();
    }

    public void Undo()
    {
        if (current != null && current.Previous != null)
        {
            current = current.Previous;
            Console.WriteLine("Undo: Now at version " + current.Value);
        }
        else
        {
            Console.WriteLine("Undo not possible.");
        }
    }

    public void Redo()
    {
        if (current != null && current.Next != null)
        {
            current = current.Next;
            Console.WriteLine("Redo: Now at version " + current.Value);
        }
        else
        {
            Console.WriteLine("Redo not possible.");
        }
    }

    public void ShowCurrent()
    {
        if (current != null)
            Console.WriteLine("Current version: " + current.Value);
        else
            Console.WriteLine("No current version.");
    }
}

class Program
{
    static void Main()
    {
        DoublyLinkedList<string> versions = new DoublyLinkedList<string>();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add version");
            Console.WriteLine("2. Show all versions (forward)");
            Console.WriteLine("3. Show all versions (backward)");
            Console.WriteLine("4. Undo");
            Console.WriteLine("5. Redo");
            Console.WriteLine("6. Show current version");
            Console.WriteLine("7. Exit");
            Console.Write("Enter choice: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Enter version to add (e.g., v1): ");
                    string newVer = Console.ReadLine();
                    versions.AddLast(newVer);
                    Console.WriteLine("Version added.");
                    break;

                case "2":
                    versions.PrintForward();
                    break;

                case "3":
                    versions.PrintBackward();
                    break;

                case "4":
                    versions.Undo();
                    break;

                case "5":
                    versions.Redo();
                    break;

                case "6":
                    versions.ShowCurrent();
                    break;

                case "7":
                    running = false;
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
