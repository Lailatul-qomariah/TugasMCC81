using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace TugasMcc;

public class Program
{
    public static void MenuGanjilGenap()
    {
        /*
         * <summary>method untuk menampilkan menu yang tersedia<summary>
         */

        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\n========================================" +
            "\n\t MENU GANJIL GENAP \t\n========================================");
            Console.WriteLine("1. Cek Ganjil Genap \n2. Cek Ganjil/Genap (dengan Limit) \n3. Exit");
            Console.WriteLine("-------------------------------------");
            Console.Write("Pilihan 1/2/3: ");

            if (int.TryParse(Console.ReadLine(), out int inpChoiceMenu))
            //untuk cek apakah inputan user = int menggunakan tryparse
            //tryparse untuk convert string to int dan disimpan dalam variabel inpChoiceMenu
            {
                Console.WriteLine(inpChoiceMenu);
                switch (inpChoiceMenu) //inputan user dijadikan sebagai kondisi dalam switch
                {
                    case 1:
                        Console.WriteLine("Pilihan 1");
                        Console.Write("Masukkan bilangan yang ingin di cek :");
                        if (int.TryParse(Console.ReadLine(), out int input)) // penggunaannya sama seperti inpChoiceMenu 
                        {
                            string resultCheck = EventOddCheck(input); //pemanggilan method untuk cek angka genap atau ganjil
                            Console.Write(resultCheck);
                        }
                        else
                        {
                            Console.Write("Masukkan bilangan dengan benar");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Pilihan 2");
                        Console.Write("Pilih Ganjil/Genap : ");
                        string choice = Console.ReadLine().ToLower(); //convert all abjad to lower case
                        Console.Write("Masukkan limit: ");
                        if (int.TryParse(Console.ReadLine(), out int limit)) // penggunaannya sama seperti inpChoiceMenu
                        {
                            PrintEventOdd(limit, choice); // pemanggilan method hitung ganjil genap dengan limit
                        }
                        else
                        {
                            Console.Write("Masukkan bilangan limit dengan benar");
                        }
                        break;
                    case 3:
                        isRunning = false; //set isRunning to false untuk exit
                        break;
                    default:
                        Console.WriteLine("Tidak ada dalam menu");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Masukkan pilihan menu dengan benar"); //output ketika inputan pilihan menu user != int
            }

        }
    }

    static void PrintEventOdd(int limit, string choice)
    {
        /*
        *<summary> method untuk melakukan print angka genap dan ganjil 
        *sesuai dengan inputan user <summary>*/
        /*<Param int = limit > menampung limit angka inputan user dan digunakan untuk perhitungan </param>*/
        /*<Param string = choice> menampung data inputan pilihan user </param>
         */


        if (limit <= 0) //cek jika inputan limit = 0 dan bilangan negatif
        {
            Console.WriteLine("Input Limit tidak valid!!! Inputan tidak boleh 0 atau negatif");

        }

        //cek jika inputan tidak sama dengan genap dan tidak sama dengan ganjil
        if (choice != "genap" && choice != "ganjil")
        {
            Console.WriteLine("Input Pilihan tidak valid!!!");

        }
        Console.WriteLine($"Print bilangan 1 - {limit}:");

        //melakukan perulangan dari 1 sampai <= inputan limit setiap perulangan akan bertambah i++
        for (int i = 1; i <= limit; i++)
        {
            if ((i % 2 == 0 && choice == "genap") || (i % 2 != 0 && choice == "ganjil"))
            {
                Console.Write($"{i}, ");
            }
        }

    }

    static string EventOddCheck(int input)
    {
        /*
        * <summary>method untuk melakukan cek angka genap dan ganjil 
        * pada method ini, dibuat inputan, terus melakukan cek inputan menggunakan if,
        * jika inputan adalah 0 dan negatif akan menampilkan pesan kesalahan
        * jika inputan >= 1 maka akan dilakukan pengecekan modulus 
        * jika amodulus input = 0 maka dia adalah bilangan genap dan sebaliknya <summary>*/
        /*<Param int = input > menampung angka yang menjadi inputan dg tipe int</param> */
        if (input < 1)
        {
            return "Invalid input!!!! Inputan tidak boleh 0 atau negatif ";
        }
        if (input % 2 == 0)
        {
            return "Genap";
        }
        return "Ganjil";
    }


    public static void MenuUser()
    {
        User user1 = new User();
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\n========================================" +
            "\n\t BASIC AUTHENTICATION \t\n========================================");
            Console.WriteLine("1. Create User \n2. Show User \n3. Search User \n4. Login User \n5. Exit");
            Console.WriteLine("-------------------------------------");
            Console.Write("input : ");

            if (int.TryParse(Console.ReadLine(), out int input))

            {
                //Console.WriteLine(input); tidak usah ditampilkan
                switch (input) //inputan user dijadikan sebagai kondisi dalam switch
                {
                    case 1:
                        Console.Write("First Name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Last Name : ");
                        string lastName = Console.ReadLine();
                        string passwd;
                        bool validPsswd;
                        do
                        {
                            Console.Write("Password : ");
                            passwd = Console.ReadLine();
                            validPsswd = User.ValidatePassword(passwd);
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

                        Console.WriteLine("menampilkan data semua user");
                        user1.ShowUser();
                        Console.WriteLine("Menu\n1. Edit \n2. Delete \n3. Back");
                        int inpCrud = int.Parse(Console.ReadLine());
                        bool isLoop = true;
                        switch (inpCrud)
                        {
                            case 1:
                                Console.Write("Masukkan Id yang ingin di EDIT : ");
                                if (int.TryParse(Console.ReadLine(), out int inpUpdates))
                                {
                                    user1.EditUser(inpUpdates);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid ID.");
                                }
                                break;

                            case 2:
                                Console.WriteLine("Masukkan Id yang ingin di DELETE : ");
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
                        Console.WriteLine("Masukkan nama : ");
                        string checkUser = Console.ReadLine();
                        user1.SearchUser(checkUser);
                        break;
                    case 4:
                        Console.WriteLine("ini untuk login");
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
                Console.WriteLine("Masukkan pilihan menu dengan benar"); //output ketika inputan pilihan menu user != int
            }

        }

    }

    public static void Main(string[] args)
    {
        MenuUser();


    }

}
