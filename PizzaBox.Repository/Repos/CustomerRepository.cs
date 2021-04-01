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

        public CustomerRepository(CustomerContext c)//, StoreContext sc)
        {
            context = c;
            //sContext = sc;
        }

        /// <summary>
        /// Add a new customer to the database
        /// </summary>
        /// <param name="newCustomer">Customer object to be added</param>
        public void AddNewCustomer(Customer newCustomer)
        {
            context.Add<Customer>(newCustomer);
            context.SaveChanges();
        }

        /// <summary>
        /// Check if the account already exists based off email
        /// </summary>
        /// <param name="email">User email</param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Get the hashed password from the database
        /// </summary>
        /// <param name="email">User email</param>
        /// <returns></returns>
        public byte[] GetHashedPassword(string email)
        {
            var findEmail = context.Customers.SingleOrDefault(n => n.Email.ToLower() == email);
            
            return findEmail.PasswordHash;
        }

        /// <summary>
        /// Get the password salt from database
        /// </summary>
        /// <param name="email">User email</param>
        /// <returns></returns>
        public byte[] GetPasswordSalt(string email)
        {
            var findEmail = context.Customers.SingleOrDefault(n => n.Email.ToLower() == email);
            
            return findEmail.PasswordSalt;
        }

        /// <summary>
        /// Update the last store the user purchased from
        /// </summary>
        /// <param name="obj">RawOrder obj</param>
        /// <returns></returns>
        public Customer UpdateLastStore(RawOrder obj)
        {
            var customerInfo = context.Customers.SingleOrDefault(n => Guid.Equals(n.CustomerID, obj.CustomerID));
            if(customerInfo is null)
            {
                return null;
            }
            else
            {
                customerInfo.LastStore = obj.StoreID;
                context.SaveChanges();
                return customerInfo;
            }
        }

        /// <summary>
        /// Gets a customer based off their id.
        /// If customer not found, return null.
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <returns></returns>
        public Customer GetCustomerByID(Guid id)
        {
            var customerInfo = context.Customers.SingleOrDefault(n => Guid.Equals(n.CustomerID, id));
            if(customerInfo is null)
            {
                return null;
            }
            else
            {
                return customerInfo;
            }
        }

        /// <summary>
        /// Gets all customer info based off their email
        /// </summary>
        /// <param name="email">email of user</param>
        /// <returns></returns>
        public Customer GetCustomerByEmail(string email)
        {
            var customerInfo = context.Customers.SingleOrDefault(n => n.Email.ToLower() == email);

            return customerInfo;
        }

        
        //------------------------------------------------------------------------//
        // public void InitStoreOwner(Customer customer, string store)
        // {
        //     var cpkStore = sContext.Stores.SingleOrDefault(n => n.Name == store);
        //     if(cpkStore is null)
        //         return;
        //     customer.StoreManger = cpkStore.StoreID;
        //     AddNewCustomer(customer);
        // }
    }
}