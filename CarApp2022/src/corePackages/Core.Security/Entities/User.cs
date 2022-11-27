﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Persistence.Repositories;

namespace Core.Security.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
        public virtual Role Role { get; set; }

        public User()
        {

        }

        public User(int id, string firstName, string lastName, string email, int roleId,byte[] passwordSalt, byte[] passwordHash, bool status)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            RoleId = roleId;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            Status = status;
        }
    }
}
