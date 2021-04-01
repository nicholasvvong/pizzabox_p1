using System;
using PizzaBox.Domain.Models;

namespace PizzaBox.Logic.Interfaces
{
    interface IOrderLogic
    {
        /// <summary>
        /// Creates the order and adds it to the database. Mapped from raworder from clientside
        /// Performs necessary inventory and customer information updates as well
        /// </summary>
        /// <param name="obj">RawOrder object from clientside.</param>
        /// <returns></returns>
        Order CreateOrder(RawOrder obj);

        /// <summary>
        /// Gets the order history of the customer based off his Guid from database.
        /// Returns a raworderhistory for the client to be read/parsed
        /// </summary>
        /// <param name="id">Customer's guid</param>
        /// <returns></returns>
        RawOrderHistory GetCustomerOrderHistory(Guid ID);
        
        /// <summary>
        /// Gets the order history of a store
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <returns></returns>
        RawOrderHistory GetStoreOrderHistory(Guid ID);
    }
}