using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using Microsoft.Data.SqlClient;

namespace PizzaBox.Repository
{
    public class CustomerRepository
    {
        private readonly CustomerContext context;
        //private readonly StoreContext sContext;

        public void RunInits()
        {
            //InitStoreOwners();
        }

        public CustomerRepository(CustomerContext c)//, StoreContext sc)
        {
            context = c;
            //sContext = sc;
        }

        public void AddNewCustomer(Customer newCustomer)
        {
            context.Add<Customer>(newCustomer);
            context.SaveChanges();
        }

        public bool IsExistingAccount(string email)
        {
            var findEmail = context.Customers.SingleOrDefault(n => n.Email.ToLower() == email);
            if(findEmail is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string GetHashedPassword(string email)
        {
            var findEmail = context.Customers.SingleOrDefault(n => n.Email.ToLower() == email);
            
            return findEmail.Password;
        }

        public Customer GetCustomer(string email)
        {
            var customerInfo = context.Customers.SingleOrDefault(n => n.Email.ToLower() == email);

            return customerInfo;
        }

        
        //------------------------------------------------------------------------//
        // private void InitStoreOwners()
        // {
        //     Customer cpkOwner = new Customer();
        //     cpkOwner.Email = "cpk@gmail.com";
        //     cpkOwner.Fname = "CPK";
        //     cpkOwner.Lname = "Nick";
        //     cpkOwner.Password = "kciN";
        //     cpkOwner.LastStore = Guid.Empty;
        //     var cpkStore = sContext.Stores.SingleOrDefault(n => n.Name == "CPK");
        //     if(cpkStore is null)
        //         return;
        //     cpkOwner.StoreManger = cpkStore.StoreID;
        //     AddNewCustomer(cpkOwner);

        //     Customer chicagoOwner = new Customer();
        //     chicagoOwner.Email = "chicago@gmail.com";
        //     chicagoOwner.Fname = "Chicago";
        //     chicagoOwner.Lname = "Nick";
        //     chicagoOwner.Password = "kciN";
        //     chicagoOwner.LastStore = Guid.Empty;
        //     var chicago = sContext.Stores.SingleOrDefault(n => n.Name == "Chicago Pizza Store");
        //     if(chicago is null)
        //         return;
        //     chicagoOwner.StoreManger = chicago.StoreID;
        //     AddNewCustomer(chicagoOwner);

        //     Customer freddyOwner = new Customer();
        //     freddyOwner.Email = "freddy@gmail.com";
        //     freddyOwner.Fname = "Freddy ";
        //     freddyOwner.Lname = "Nick";
        //     freddyOwner.Password = "kciN";
        //     freddyOwner.LastStore = Guid.Empty;
        //     var freddy = sContext.Stores.SingleOrDefault(n => n.Name == "Freddy's Pizza Store");
        //     if(freddy is null)
        //         return;
        //     freddyOwner.StoreManger = freddy.StoreID;
        //     AddNewCustomer(freddyOwner);

        //     Customer nyOwner = new Customer();
        //     nyOwner.Email = "newyork@gmail.com";
        //     nyOwner.Fname = "NewYork";
        //     nyOwner.Lname = "Nick";
        //     nyOwner.Password = "kciN";
        //     nyOwner.LastStore = Guid.Empty;
        //     var ny = sContext.Stores.SingleOrDefault(n => n.Name == "NewYork Pizza Store");
        //     if(ny is null)
        //         return;
        //     nyOwner.StoreManger = ny.StoreID;
        //     AddNewCustomer(nyOwner);
        // }
    }
}