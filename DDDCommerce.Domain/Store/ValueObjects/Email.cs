using System;
using DDDCommerce.Shared.ValueObject;
using Flunt.Validations;

namespace DDDCommerce.Domain.Store.ValueObjects
{
    public class Email : ValueObject
    {
        //Just for EF
        protected Email()
        {

        }

        public Email(string mailAddress)
        {
            MailAddress = mailAddress;

            if(String.IsNullOrEmpty(mailAddress))
               AddNotification("mailAddress", "endereço do e-mail vazio");

        }

        public string MailAddress { get; set; }

    }
}