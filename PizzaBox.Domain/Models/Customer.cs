using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using PizzaBox.Domain.Abstracts;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PizzaBox.Domain.Models
{
    public class Customer
    {
        [Key]
        public Guid CustomerID { get; set; } = Guid.NewGuid();
        public string Fname { get; set; }
        public string Lname { get; set; }
        public byte[] PasswordHash { get; set; }//needed from user... but hashed behind the scenes
        public byte[] PasswordSalt { get; set; }// comes from the {} in the system
        public string Email { get; set; }
        public DateTime LastTimeOrdered { get; protected set; }
        public Guid LastStore { get; set; }
        public Guid StoreManger { get; set; }
        public Customer()
        {
            LastTimeOrdered = DateTime.MinValue;
        }

        public Customer(string fname, string lname) : this()
        {
            Fname = fname;
            Lname = lname;
        }

        // private bool CanOrder()
        // {

        //     if(DateTime.UtcNow.Subtract(LastTimeOrdered).TotalHours > 2) //If it has been more than 2 hours since last order
        //     {
        //         return true;
        //     }
        //     else
        //     { 
        //         return false;
        //     }
        // }

        // private bool CanChangeStore(AStore store)
        // {
        //     if(LastStore == null)
        //     {
        //         LastStore = store;
        //         return true;
        //     }
        //     else
        //     {
        //         if(LastStore.Name != store.Name)
        //         {
        //             if(DateTime.UtcNow.Subtract(LastTimeOrdered).TotalHours > 24) //If it has been 24 hours(1day) since last order
        //             {
        //                 return true;
        //             }
        //             else
        //             { 
        //                 return false;
        //             }
        //         }
        //         else
        //             return true;
        //     }
        // }

        // private TimeSpan TimeRemaining(int hoursCheck)
        // {
        //     TimeSpan temp = new TimeSpan(hoursCheck, 0, 0);
        //     return temp.Subtract(DateTime.UtcNow.Subtract(LastTimeOrdered));
        // }

        // public bool StartOrderCheck(AStore store)
        // {
        //     if(!CanChangeStore(store))
        //     {
        //         Console.WriteLine("Ordered from another store in last 24 hours. Can't order again. (Previous store: {0} - Time Remaining: {1})", LastStore, TimeRemaining(24));
        //         return false;
        //     }
        //     if(!CanOrder())
        //     {
        //         Console.WriteLine("Ordered in last 2 hours. Can't order again. (Time Remaining: {0})", TimeRemaining(2));
        //         return false;
        //     }
        //     LastStore = store;
        //     LastTimeOrdered = DateTime.UtcNow;
        //     return true;
        // }
    }
}