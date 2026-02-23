using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

// Represents a single contact in the system
class Contact
{
    public int Id{get;set;}
    public string Name{get;set;}
    public string Phone{get;set;}
    public string Email{get;set;}
    public DateTime CreationDate { get; set; }
    public Contact(int id, string name, string phone, string email)
    {
        Id = id;
        Name = name;
        Phone = phone;
        Email = email;
        CreationDate = DateTime.Now;
    }
    
}
