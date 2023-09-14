using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace TugasMcc;

public class Program
{

    public static void MenuUser()
    {
        UserCrud user1 = new UserCrud();
        bool isRunning = true;
        while (isRunning)
        {
            //Console.Clear();
            Console.WriteLine("\n========================================" +
            "\n\t BASIC AUTHENTICATION \t\n========================================");
            Console.WriteLine("1. Create User \n2. Show User \n3. Search User \n4. Login User \n5. Exit");
            Console.WriteLine("-------------------------------------");
            Console.Write("input : ");
            //Console.ReadLine(); // hanya untuk enter, karena diatas menggunakan Console.Clear()
            if (int.TryParse(Console.ReadLine(), out int input))

            {
                switch (input) //inputan user dijadikan sebagai kondisi dalam switch
                {
                    case 1:
                       
                        string passwd;
                        bool validPsswd;
                        Console.Write("First Name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Last Name : ");
                        string lastName = Console.ReadLine();
                        do
                        {
                            Console.Write("Password : ");
                            passwd = Console.ReadLine();
                            validPsswd = User.ValidatePassword(passwd); //cek validasi password
                            if (validPsswd == false)
                            {
                                Console.WriteLine("Password must have at least 8 characters with at" +
                                " least one Capital letter, one lower case letter, and one number.");
                            }

                        } while (validPsswd == false);
                        {
                            user1.CreateUser(firstName, lastName, passwd);

                        }
                        
                        break;
                    case 2:
                        user1.ShowUser();
                        Console.WriteLine("Menu\n1. Edit \n2. Delete \n3. Back");
                        int inpCrud = int.Parse(Console.ReadLine());
                        bool isLoop = true;
                        switch (inpCrud)
                        {
                            case 1:
                                
                                Console.Write("Enter the ID you want to EDIT : ");
                                if (int.TryParse(Console.ReadLine(), out int inpUpdates))
                                {
                                    user1.EditUser(inpUpdates);
                                    
                                }
                               
                                
                                break;
                            case 2:
                                
                                Console.WriteLine("Enter the ID you want to DELETE : ");
                                if (int.TryParse(Console.ReadLine(), out int inpDeletes))
                                {
                                    user1.DeleteUser(inpDeletes);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid ID.");
                                }
                                
                                break;
                            case 3:
                                isLoop = false;
                                break;
                        }
                        break;
                    case 3:
                        
                        Console.WriteLine("==CARI AKUN==");
                        Console.WriteLine("Enter name: ");
                        string checkUser = Console.ReadLine();
                        user1.SearchUser(checkUser);
                        
                        break;
                    case 4:
                        
                        Console.Write("USERNAME : ");
                        string inpUserName = Console.ReadLine();
                        Console.Write("PASSWORD : ");
                        string inpPsswd = Console.ReadLine();
                        user1.Login(inpUserName, inpPsswd);
                        
                        break;
                    case 5:
                        isRunning = false; //set isRunning to false untuk exit
                        break;
                    default:
                        isRunning = false; //set isRunning to false untuk exit
                        break;
                }
            }
            else
            {
                Console.WriteLine("Enter the menu options correctly!!!"); //output ketika inputan pilihan menu user != int
                
            }
        }
    }

    public static void Main(string[] args)
    {
        MenuUser();
    }
}
