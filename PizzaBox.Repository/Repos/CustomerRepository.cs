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

        public CustomerRepository(CustomerContext c)
        {
            context = c;
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
    }
}