using System;
using PizzaBox.Domain.Models;

namespace PizzaBox.Logic.Interfaces
{
    interface ICustomerLogic
    {
        /// <summary>
        /// Creates a new customer to the database
        /// Checks if the new email already exists before creating
        /// </summary>
        /// <param name="obj">RawCustomer</param>
        /// <returns>Customer if exist. Null if doesn't exist</returns>
        Customer CreateCustomer(RawCustomer obj);

        /// <summary>
        /// Check if the user has a valid login information. 
        /// If valid, return the Customer object from database.
        /// If invalid, return null
        /// </summary>
        /// <param name="obj">Customer info based off login form</param>
        Customer LoginCheck(RawCustomer obj);
    }
}