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
        private readonly StoreContext sContext;

        public CustomerRepository(CustomerContext c, StoreContext sc)
        {
            context = c;
            sContext = sc;
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

        public byte[] GetHashedPassword(string email)
        {
            var findEmail = context.Customers.SingleOrDefault(n => n.Email.ToLower() == email);
            
            return findEmail.PasswordHash;
        }

        public byte[] GetPasswordSalt(string email)
        {
            var findEmail = context.Customers.SingleOrDefault(n => n.Email.ToLower() == email);
            
            return findEmail.PasswordSalt;
        }

        public Customer GetCustomer(string email)
        {
            var customerInfo = context.Customers.SingleOrDefault(n => n.Email.ToLower() == email);

            return customerInfo;
        }

        
        //------------------------------------------------------------------------//
        public void InitStoreOwner(Customer customer, string store)
        {
            var cpkStore = sContext.Stores.SingleOrDefault(n => n.Name == store);
            if(cpkStore is null)
                return;
            customer.StoreManger = cpkStore.StoreID;
            AddNewCustomer(customer);
        }
    }
}