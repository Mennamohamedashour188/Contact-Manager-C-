using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

// Handles all contact operations (CRUD + Search + Filter + JSON Persistence)
class ContactManager
{
    private List<Contact> contacts = new List<Contact>();
    private int nextId = 1; 


    public void AddContact(string name, string phone, string email)
    {
        Contact c = new Contact(nextId, name, phone, email); 
        contacts.Add(c);                                     
        nextId++;                                            
        Console.WriteLine("Contact added successfully!");   
    }

    public void EditContactInteractive(int id)
    {
        Contact c =contacts.FirstOrDefault(x =>x.Id==id);
        if (c ==null)
        {
            Console.WriteLine("Contact not found!");
            return;
        }

        Console.WriteLine($"Editing Contact {c.Id}: {c.Name} | {c.Phone} | {c.Email}");

        Console.Write($"New Name (leave empty to keep '{c.Name}'): ");
        string newName =Console.ReadLine();
        if (!string.IsNullOrEmpty(newName))
            c.Name =newName;

        Console.Write($"New Phone (leave empty to keep '{c.Phone}'): ");
        string newPhone = Console.ReadLine();
        if (!string.IsNullOrEmpty(newPhone))
            c.Phone =newPhone;

        Console.Write($"New Email (leave empty to keep '{c.Email}'): ");
        string newEmail =Console.ReadLine();
        if (!string.IsNullOrEmpty(newEmail))
            c.Email =newEmail;

        Console.WriteLine("Contact updated successfully!");
    }
     // Deletes contact by ID
    public void DeleteContact(int id)
    {
        int removed = contacts.RemoveAll(c => c.Id == id);
        if (removed > 0)
            Console.WriteLine("Contact deleted successfully!");
        else
            Console.WriteLine("Contact not found!");
    }

    public void ViewContact(int id)
    {
        Contact c = contacts.FirstOrDefault(x => x.Id == id);
        if (c != null)
            Console.WriteLine($"{c.Id}: {c.Name} | {c.Phone} | {c.Email} | {c.CreationDate}");
        else
        
            Console.WriteLine("Contact not found!");
    }

    public void SearchContact(string keyword)
    {
        var results =contacts.Where(c => c.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)|| c.Phone.Contains(keyword)).ToList();
        if (results.Count > 0)
        {
            foreach (var c in results)
            {
                Console.WriteLine($"{c.Id}: {c.Name} | {c.Phone} | {c.Email}");
            }
        }
                
        else
        {
            Console.WriteLine("No contacts found!");
        }
    }

    public void FilterContactsInteractive()
    {
    Console.WriteLine("\n--- Filter Contacts ---");
    Console.WriteLine("1. By full or partial Name");
    Console.WriteLine("2. By first letter of Name");
    Console.Write("Choose filter option: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Enter full or partial name: ");
            string nameKeyword =Console.ReadLine();
            var byName =contacts.Where(c => c.Name.Contains(nameKeyword, StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayContacts(byName);
            break;

        case "2":
            Console.Write("Enter first letter: ");
            char letter =Console.ReadLine()[0];
            var byLetter =contacts.Where(c => c.Name.StartsWith(letter.ToString(), StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayContacts(byLetter);
            break;

        default:
            Console.WriteLine("Invalid option!");
            break;
    }
    }

    public void ListContacts()
    {
        foreach (var c in contacts)
        {
            Console.WriteLine($"{c.Id}: {c.Name} | {c.Phone} | {c.Email} | {c.CreationDate}");
        }
    }

    public void SaveToJson(string filePath)
    {
        string json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

    public void LoadFromJson(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            contacts = JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
            if (contacts.Count > 0)
                nextId = contacts.Max(c => c.Id) + 1;
        }
    }

    private void DisplayContacts(List<Contact> list)
    {
        if (list.Count == 0)
            Console.WriteLine("No contacts found!");
        else
            foreach (var c in list)
                Console.WriteLine($"{c.Id}: {c.Name} | {c.Phone} | {c.Email} | {c.CreationDate}");
    }




}