using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Repository;

namespace PizzaBox.Logic
{
    public class CustomerLogic
    {
        private readonly CustomerRepository customerRepo;
        public CustomerLogic(CustomerRepository r)
        {
            customerRepo = r;
        }

        public void LogicRepoGap()
        {
            customerRepo.RunInits();
        }

        public Customer CreateCustomer(Customer obj)
        {
            if(customerRepo.IsExistingAccount(obj.Email.ToLower()))
            {
                return null;
            }
            else
            {
                obj.Email.ToLower();
                Console.WriteLine(obj);
                obj.Password = PasswordHash(obj.Password);
                obj.LastStore = Guid.Empty;
                obj.StoreManger = Guid.Empty;
                customerRepo.AddNewCustomer(obj);
            }

            return obj;
        }

        /// <summary>
        /// Check if the user has a valid login information. 
        /// If valid, return the Customer object from database.
        /// If invalid, return null
        /// </summary>
        /// <param name="obj">Customer info based off login form</param>
        public Customer loginCheck(Customer obj)
        {
            if(!customerRepo.IsExistingAccount(obj.Email.ToLower()))
            {
                return null;
            }
            else
            {
                string dbpw = customerRepo.GetHashedPassword(obj.Email.ToLower());
                dbpw = PasswordUnhash(dbpw);

                if(obj.Password == dbpw)
                {
                    return customerRepo.GetCustomer(obj.Email.ToLower());
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// This is a placeholder to hash the password
        /// Currently only reverses the password to be stored in the database
        /// </summary>
        /// <param name="password">Unencrypted user password</param>
        /// <returns></returns>
        private string PasswordHash(string password)
        {
            char[] hashed = password.ToCharArray();
            Array.Reverse(hashed);
            return new string(hashed);
        }

        /// <summary>
        /// This is a placeholder to unencrypt the password
        /// Will reverse the password stored in the database
        /// </summary>
        /// <param name="password">Encrypyed user password</param>
        /// <returns></returns>
        private string PasswordUnhash(string password)
        {
            char[] unhashed = password.ToCharArray();
            Array.Reverse(unhashed);
            return new string(unhashed);
        }

    }
}
