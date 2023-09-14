using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace TugasMcc
{
    public class User
    {
        public static List<User> userList = new List<User>();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public string Username { get; set; }
        private int id;

        public User()
        {

        }
        public User(int id, string firstName, string lastName, string password)
        {

            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Username = GenerateUserName(firstName, lastName);
            Id = id;
        }

        public string GenerateUserName(string firstName, string lastName)
        {
            string twoFristName = firstName.Substring(0, 2);
            string twoLastName = lastName.Substring(0, 2);
            string userName = twoFristName + twoLastName;
            return userName;
        }

        public void CreateUser(string firstName, string lastName, string password)
        {

            
                int Id = userList.Count + 1;
                User newUser = new User(Id, firstName, lastName, password);
                userList.Add(newUser);
                Console.WriteLine("User berhasil dibuat.");    
        }

        public void ShowUser()
        {
            Console.WriteLine("=======SHOW USER=======");
            foreach (User user in userList)
            {
                Console.WriteLine("========================");
                Console.WriteLine(
                    $"Id User       : {user.Id} " +
                    $"\nFirst Name  : {user.FirstName} " +
                    $"\nLast Name   : {user.LastName}, " +
                    $"\nUsername    : {user.Username}," +
                    $"\nPassword    : {user.Password}"
                    );
                Console.WriteLine("========================");
            }
        }

        public void SearchUser(string checkUser)
        {
            // untuk membandingkan antara inputan dan data yang ada pada userList itu sama atau ndak
            var resultSearch = userList.Where(u => u.FirstName == checkUser || u.LastName == checkUser).ToList();

            if (resultSearch.Count > 0) // ini untuk cek apakah list > 0 
            {
                foreach (var user in resultSearch)
                {
                    Console.WriteLine("========================");
                    Console.WriteLine($"ID       : {user.Id}");
                    Console.WriteLine($"Name     : {user.FirstName} {user.LastName}");
                    Console.WriteLine($"Username : {user.Username}");
                    Console.WriteLine($"Password : {user.Password}");
                    Console.WriteLine("========================");
                }
            }
            else
            {
                Console.WriteLine("User tidak ditemukan!");
            }

        }

        public void Login(string inpUserName, string inpPsswd)
        {
            var pswdLogin = userList.FirstOrDefault(u => u.Username == inpUserName && u.Password == inpPsswd);
            if (pswdLogin != null && pswdLogin.Password == inpPsswd)
            {
                Console.WriteLine($"Login berhasil, Anda Login sebagai {pswdLogin.FirstName} {pswdLogin.LastName}");

                TugasMcc.Program.MenuGanjilGenap();
            }
            else
            {
                Console.WriteLine("Login Gagal gais! pastikan usernam atau passwordnya benar");
            }
        }

        public void EditUser(int inpUpdate)
        {
            


            if (inpUpdate >= 1 && inpUpdate <= userList.Count)
            {

                User userEdit = userList[Id];
                Console.Write("New First Name: ");
                userEdit.FirstName = Console.ReadLine();

                Console.Write("New Last Name: ");
                userEdit.LastName = Console.ReadLine();
                userEdit.Username = GenerateUserName(userEdit.FirstName, userEdit.LastName);
                string passwd;
                bool validPsswd;
                do
                {

                    Console.Write("New Password: ");
                    userEdit.Password = Console.ReadLine();
                    validPsswd = User.ValidatePassword(userEdit.Password);
                    if (validPsswd == false)
                    {
                        Console.WriteLine("Password must have at least 8 characters with at" +
                        " least one Capital letter, one lower case letter, and one number.");
                    }
                    } while (validPsswd == false);
                    {

                        Console.WriteLine("User Sudah Berhasil Di Edit");
                    }
            }
            else
            {
                Console.WriteLine("Invalid ID. User not found.");
            }
       
        
        }

        public void DeleteUser(int inpDelete)
        {
            if (inpDelete >= 1 && inpDelete <= userList.Count)
            {
                User userDelete = userList[Id];
                userList.Remove(userDelete);
                Console.WriteLine("user berhasil dihapus");
            } else
            {
                Console.WriteLine("data id tidak valid");
            }

        }

        public static bool ValidatePassword(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }

            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUpperCase = true;
                }
                else if (char.IsLower(c))
                {
                    hasLowerCase = true;
                }
                else if (char.IsDigit(c))
                {
                    hasDigit = true;
                }
            }

            return hasUpperCase && hasLowerCase && hasDigit;
        }

    }



}
