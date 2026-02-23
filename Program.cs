// See https://aka.ms/new-console-template for more information

// See https://aka.ms/new-console-template for more information


using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;



class Program
{
    static void Main()
    {
        Console.Write("Enter the JSON file name to load/save contacts (e.g., contacts.json): ");
        string fileName = Console.ReadLine();

        ContactManager manager = new ContactManager();
        manager.LoadFromJson(fileName);

        while (true)
        {
            Console.WriteLine("\n=== Contact Manager ===");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Edit Contact");
            Console.WriteLine("3. Delete Contact");
            Console.WriteLine("4. View Contact");
            Console.WriteLine("5. List Contacts");
            Console.WriteLine("6. Search Contact");
            Console.WriteLine("7. Filter Contacts");
            Console.WriteLine("8. Save");
            Console.WriteLine("9. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Phone: ");
                    string phone = Console.ReadLine();
                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    manager.AddContact(name, phone, email);
                    break;

                case "2":
                    Console.Write("Enter Contact Id to edit: ");
                    int editId = int.Parse(Console.ReadLine());
                    manager.EditContactInteractive(editId);
                    break;

                case "3":
                    Console.Write("Enter Contact Id to delete: ");
                    int delId = int.Parse(Console.ReadLine());
                    manager.DeleteContact(delId);
                    break;

                case "4":
                    Console.Write("Enter Contact Id to view: ");
                    int viewId = int.Parse(Console.ReadLine());
                    manager.ViewContact(viewId);
                    break;

                case "5":
                    manager.ListContacts();
                    break;

                case "6":
                    Console.Write("Enter keyword to search (Name or Phone): ");
                    string keyword = Console.ReadLine();
                    manager.SearchContact(keyword);
                    break;

                case "7":
                    manager.FilterContactsInteractive();
                    break;

                case "8":
                    manager.SaveToJson(fileName);
                    break;

                case "9":
                    return;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}

