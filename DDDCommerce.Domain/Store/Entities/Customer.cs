using System;
using System.Collections.Generic;
using DDDCommerce.Domain.Store.ValueObjects;
using DDDCommerce.Shared.Entities;
using Flunt.Validations;

namespace DDDCommerce.Domain.Store.Entities
{
    public class Customer : Entity
    {
        //Just for EF
        protected Customer()
        {
            
        }

        public Customer(
            Name name,
            string document,
            Email email,
            string phone)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;

            if (String.IsNullOrEmpty(Name.FirstName))
            {
                AddNotifications(new Contract()
                    .IsNull(Name, "Name", "Nome não pode ser nulo")
                    .HasMaxLen(Name.FirstName, 40, "FirstName", "Name should have no more than 40 chars")
                    .HasMinLen(Name.FirstName, 3, "FirstName", "Name should have at least 3 chars")
                );
            }



        }

        public Name Name { get; private set; }
        public string Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }


    }
}
