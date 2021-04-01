using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Logic.Interfaces;
using PizzaBox.Repository;

namespace PizzaBox.Logic
{
    public class CustomerLogic : ICustomerLogic
    {
        private readonly CustomerRepository customerRepo;
        private readonly Mapper mapper = new Mapper();
        public CustomerLogic(CustomerRepository r)
        {
            customerRepo = r;
        }

        public Customer CreateCustomer(RawCustomer obj)
        {
            Customer newCustomer;
            if(customerRepo.IsExistingAccount(obj.Email.ToLower()))
            {
                return null;
            }
            else
            {
                newCustomer = mapper.CustomerMapper(obj);
                
                customerRepo.AddNewCustomer(newCustomer);
            }

            return newCustomer;
        }

        public Customer LoginCheck(RawCustomer obj)
        {
            if(!customerRepo.IsExistingAccount(obj.Email.ToLower()))
            {
                return null;
            }
            else
            {
                byte[] originalSalt = customerRepo.GetPasswordSalt(obj.Email.ToLower());
                byte[] originalPassword = customerRepo.GetHashedPassword(obj.Email.ToLower());
                byte[] currentPassword = mapper.PasswordHash(obj.Password, originalSalt);

                if(CompareHash(originalPassword, currentPassword))
                {
                    return customerRepo.GetCustomerByEmail(obj.Email.ToLower());
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Compares the hashed version of the user inputted password vs the original hashed version at account creation
        /// Returns false if they are not the same
        /// </summary>
        /// <param name="original">Hashed password at account creation</param>
        /// <param name="userInput">Hashed password from current user input</param>
        /// <returns></returns>
        private bool CompareHash(byte[] original, byte[] userInput)
        {
            if(original.Length != userInput.Length)
            {
                return false;
            }
            else
            {
                for(int i = 0; i < original.Length; i++)
                {
                    if(original[i] != userInput[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        
        //---------------------------------------------------------//
        // public void InitStoreOwners()
        // {
        //     RawCustomer tempCPK = new RawCustomer();
        //     tempCPK.Email = "cpk@gmail.com";
        //     tempCPK.Fname = "CPK";
        //     tempCPK.Lname = "Nick";
        //     tempCPK.Password = "Nick";
        //     Customer cpkOwner = mapper.CustomerMapper(tempCPK);
        //     customerRepo.InitStoreOwner(cpkOwner, "CPK");

        //     RawCustomer tempChi = new RawCustomer();
        //     tempChi.Email = "chicago@gmail.com";
        //     tempChi.Fname = "Chicago";
        //     tempChi.Lname = "Nick";
        //     tempChi.Password = "Nick";
        //     Customer chiOwner = mapper.CustomerMapper(tempChi);
        //     customerRepo.InitStoreOwner(chiOwner, "Chicago Pizza Store");

        //     RawCustomer tempFred = new RawCustomer();
        //     tempFred.Email = "chicago@gmail.com";
        //     tempFred.Fname = "Chicago";
        //     tempFred.Lname = "Nick";
        //     tempFred.Password = "Nick";
        //     Customer fredOwner = mapper.CustomerMapper(tempFred);
        //     customerRepo.InitStoreOwner(fredOwner, "Freddy's Pizza Store");

        //     RawCustomer tempNY = new RawCustomer();
        //     tempNY.Email = "chicago@gmail.com";
        //     tempNY.Fname = "Chicago";
        //     tempNY.Lname = "Nick";
        //     tempNY.Password = "Nick";
        //     Customer nyOwner = mapper.CustomerMapper(tempNY);
        //     customerRepo.InitStoreOwner(nyOwner, "NewYork Pizza Store");
        // }
    }
}
