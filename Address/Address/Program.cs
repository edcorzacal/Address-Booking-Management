using System;
using System.IO;

namespace AddressBookManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Username\Documents\AddressBook.txt"; // change the path to your desired file path

            while (true)
            {
                Console.WriteLine("\nAddress Book Management System");
                Console.WriteLine("1. Add Record");
                Console.WriteLine("2. Show Records");
                Console.WriteLine("3. Search Record");
                Console.WriteLine("4. Modify Record");
                Console.WriteLine("5. Delete Record");
                Console.WriteLine("6. Exit");

                Console.Write("\nEnter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        Console.Write("\nEnter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Phone Number: ");
                        string phoneNumber = Console.ReadLine();
                        Console.Write("Enter Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Enter Address: ");
                        string address = Console.ReadLine();

                        using (StreamWriter writer = new StreamWriter(path, true))
                        {
                            writer.WriteLine($"{name},{phoneNumber},{email},{address}");
                        }
                        Console.Clear();
                        Console.WriteLine("\nRecord added successfully!");
                        break;

                    case 2:
                        if (File.Exists(path))
                        {
                            using (StreamReader reader = new StreamReader(path))
                            {
                                string line;
                                Console.WriteLine("\nName\t\tPhone Number\t\tEmail\t\tAddress\n");

                                while ((line = reader.ReadLine()) != null)
                                {
                                    string[] words = line.Split(',');
                                    Console.WriteLine($"{words[0]}\t\t{words[1]}\t\t{words[2]}\t\t{words[3]}");
                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\nNo records found!");
                        }
                        break;

                    case 3:
                        Console.Write("\nEnter name to search: ");
                        string searchName = Console.ReadLine();

                        if (File.Exists(path))
                        {
                            using (StreamReader reader = new StreamReader(path))
                            {
                                string line;
                                bool found = false;

                                while ((line = reader.ReadLine()) != null)
                                {
                                    string[] words = line.Split(',');

                                    if (words[0].Equals(searchName))
                                    {
                                        Console.WriteLine("\nName\t\tPhone Number\t\tEmail\t\tAddress\n");
                                        Console.WriteLine($"{words[0]}\t\t{words[1]}\t\t{words[2]}\t\t{words[3]}");
                                        found = true;
                                        break;
                                    }
                                }

                                if (!found)
                                {
                                    Console.Clear();
                                    Console.WriteLine("\nRecord not found!");
                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\nNo records found!");
                        }
                        break;

                    case 4:
                        Console.Write("\nEnter name to modify: ");
                        string modifyName = Console.ReadLine();

                        if (File.Exists(path))
                        {
                            string[] lines = File.ReadAllLines(path);
                            bool found = false;

                            for (int i = 0; i < lines.Length; i++)
                            {
                                string[] words = lines[i].Split(',');

                                if (words[0].Equals(modifyName))
                                {
                                    Console.WriteLine("\nEnter New Phone Number: ");
                                    string newPhoneNumber = Console.ReadLine();
                                    Console.WriteLine("Enter New Email: ");
                                    string newEmail = Console.ReadLine();
                                    Console.WriteLine("Enter New Address: ");
                                    string newAddress = Console.ReadLine();
                                    lines[i] = $"{modifyName},{newPhoneNumber},{newEmail},{newAddress}";
                                    File.WriteAllLines(path, lines);
                                    Console.WriteLine("\nRecord modified successfully!");
                                    found = true;
                                    break;
                                }
                            }

                            if (!found)
                            {
                                Console.WriteLine("\nRecord not found!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNo records found!");
                        }
                        break;

                    case 5:
                        Console.Write("\nEnter name to delete: ");
                        string deleteName = Console.ReadLine();

                        if (File.Exists(path))
                        {
                            string[] lines = File.ReadAllLines(path);
                            bool found = false;

                            for (int i = 0; i < lines.Length; i++)
                            {
                                string[] words = lines[i].Split(',');

                                if (words[0].Equals(deleteName))
                                {
                                    lines[i] = null;
                                    File.WriteAllLines(path, lines);
                                    Console.WriteLine("\nRecord deleted successfully!");
                                    found = true;
                                    break;
                                }
                            }

                            if (!found)
                            {
                                Console.WriteLine("\nRecord not found!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNo records found!");
                        }
                        break;

                    case 6:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice!");
                        break;
                }
            }
        }
    }
}