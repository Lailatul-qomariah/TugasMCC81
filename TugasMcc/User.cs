using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace TugasMcc;

public class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public int Id { get; set; }
    public string Username { get; set; }

    public User()
    {
        //constructor untuk membuat objek tanpa parameter
    }
    public User(int id, string firstName, string lastName, string password, List<User> cekUser) //counstructor parameter
    {

        FirstName = firstName;
        LastName = lastName;
        Password = password;
        Username = GenerateUserName(firstName, lastName, cekUser);
        Id = id;
    }

    public string GenerateUserName(string firstName, string lastName, List<User> cekUser)
    {
        string twoFirstName = firstName.Substring(0, Math.Min(2, firstName.Length));
        string twoLastName = lastName.Substring(0, Math.Min(2, firstName.Length));
        string userName = twoFirstName + twoLastName;
        int incrementUsrnm = 1;
        string username = userName;
        while (cekUser.Any(u => u.Username == username)) //cek apakah current username sama dengan username oldnya
        {
            username = $"{userName}{incrementUsrnm}"; //jika sama, maka akan diset dengan menambahkan nilai +1 di belakang current username
            incrementUsrnm++;
        }
        return username;
    }


    public static bool ValidatePassword(string password)
    {
        if (password.Length < 8) //cek psswd apakah lebih dari 8 karakter
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
