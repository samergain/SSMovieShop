using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepositroy;

        public AccountService(IUserRepository userRepositroy)
        {
            _userRepositroy = userRepositroy;
        }

        public async Task<UserLoginResponseModel> LoginUser(string email, string password)
        {
            var dbUser = await _userRepositroy.GetUserByEmail(email);
            if (dbUser == null)
            {
                throw new Exception("Email does not exist");
            }
            //for login authentication we
            //      1- get the salt from db
            //      2- hash the salt
            //      3- hash the entered password and add the hashed salt to it
            //      4- compare the hashed password stored in db to the entered password after hashing and adding salt
            var hashedPassword = GetHashedPassword(password, dbUser.Salt);
            if(hashedPassword == dbUser.HashedPassword)
            {
                //password is good
                var userLoginResponseModel = new UserLoginResponseModel
                {
                    Id = dbUser.Id,
                    Email = dbUser.Email,
                    FirstName = dbUser.FirstName,
                    LastName = dbUser.LastName
                };
                return userLoginResponseModel;
            }
            return null;
        }

        public async Task<bool> RegisterUser(UserRegisterModel model)
        {
            //step 1: check if email excists in db - (we need user repository to check email)
            var dbUser = await _userRepositroy.GetUserByEmail(model.Email);
            if (dbUser != null) //user already exists
            {
                throw new ConflictException("Email already exists!");
            }
            //step 2: create a random salt -> create hashed password with your salt added (hashing algorithms: pdbkf2, Bcrypt, Aargon2)
            //add package: Microsoft.AspNetCore.Cryptography.KeyDerivation and use System.Security.Cryptography
            var salt = GetRandomSalt();
            var hashedPassword = GetHashedPassword(model.Password, salt);
            //step 3: save the user object to User table
            var user = new User
            {
                Email = model.Email,
                Salt = salt,
                HashedPassword = hashedPassword,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth
            };

            var createdUser = await _userRepositroy.Add(user);
            if (createdUser.Id > 0)
            {
                return true;
            }
            return false;
        }


        private string GetRandomSalt()
        {
            var randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string GetHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password,
            Convert.FromBase64String(salt),
            KeyDerivationPrf.HMACSHA512,
            10000,
            256 / 8));
            return hashed;
        }
    }
}
