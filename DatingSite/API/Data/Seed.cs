using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace API.Data
{
    public class Seed
    {
        public static async Task SendUser(DataContext context)
        {
            if (await context.Users.AnyAsync())
            {
                return;
            }
            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<AppUser>>(userData);
            
            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();
                user.UserName = user.UserName.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")); //fake password for all users in json file
                user.PasswordSalting = hmac.Key;
                context.Users.Add(user);
            }
            await context.SaveChangesAsync();
        }
    }
}