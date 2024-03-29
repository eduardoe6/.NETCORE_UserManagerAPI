using System;
using System.Collections.Generic;
using Manager.Domain.Validators;

namespace Manager.Domain.Entities
{
    public class User : Base
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        // EF
        protected User() { }

        public User(long id,string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            _errors = new List<string>();
        }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                _errors.Clear();
                foreach (var error in validation.Errors) _errors.Add(error.ErrorMessage);

                throw new Exception("Alguns campos estão inválidos, por favor corrija-os." + _errors[0]);
            }

            return true;
        }
    }
}