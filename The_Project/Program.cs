using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.IO;
using System.Collections.Generic;
using System.Security.Policy;

namespace Main
{
    internal class Program
    {

        static Random rnd = new Random();
        /*enum letters
        {
            a , b , c , d , e , f , g , h
        }

        struct stStudent
        {
            public string FirstName;
            public string LastName;
        }


        static void print()
        {
            Console.WriteLine("hello world");
            Console.WriteLine("hello world");
            Console.WriteLine("hello world");
        }

        static bool Isperfect(int num)
        {
            double sum = 0;
            for(int i = 1; i < num; i++)
            {
                if (num % i == 0)
                    sum += i;
            }

            if (num == sum)
            {
                return true;
            }
            return false;
            
        }

        static void printinrev(int num)
        {
            int mod;
            int res = 0;
            
            while(num > 0)
            {
                mod = num % 10;
                res = res*10 + mod;
                num /= 10;
            }
            Console.WriteLine("the reversed num is : " + res );
        }

        static void MyMethod(string child1, string child2, string child3 = "did not come")
        {
            Console.WriteLine("The youngest child is: " + child3);
        }

        static void Invertedletterlist(int number)
        {
            for(int i = 65 ; i <= number + 64; i++)
            {
                for(int j = 0; j <= i - 65; j++)
                {
                    Console.Write((char)i);
                }
                Console.WriteLine();
            }
        }


        static int Numoccuredinarray(int[] ints , int num)
        {

            int k = 0;

            foreach(int i in ints)
            {
                if(num == i)
                {
                    k++;
                }
            }

            return k;
        }


        static int[] Readarray(int[] ints , int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write("nums[{0}] : ", i);
                ints[i] = Convert.ToInt32(Console.ReadLine());
            }

            return ints;
        }

        

        static void Printarray(int[] nums)
        {
            foreach (var i in nums)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

        }



        static int[] Fillrandom(int[] nums , int size)
        {
            Random rnd = new Random();
            for( int i = 0; i < size; i++)
            {
                nums[i] = rnd.Next(1, 100);
            }

            return nums;
        }
        
        static void Swap(ref int a , ref int b)
        {
            (b, a) = (a, b);
        }

        static void Revarray(int[] nums , int size)
        {
            for(int i = 0;i < size/2; i++)
            {
                Swap(ref nums[i], ref nums[size - i - 1]);
            }
        }

        static void Shufflearray(int[] nums , int size)
        {
            Random rnd = new Random();
            for(int i = 0;i < size; i++)
            {
                Swap(ref nums[rnd.Next(0, size - 1)],ref nums[rnd.Next(0, size - 1)]);
            }
        }

        enum chartype
        {
            capchar , smallchar, specialchar , digitchar
        }

        static char generatechar(chartype type)
        {
            
            switch(type)
            {
                case chartype.capchar:
                    return (char)rnd.Next(65, 90);

                case chartype.smallchar:
                    return (char)rnd.Next(97, 122);

                case chartype.specialchar:
                    return (char)rnd.Next(33, 47);

                case chartype.digitchar:
                    return (char)rnd.Next(48, 57);

            }

            return (char)0;
        }


        static string generateword(int size)
        {
            string word = "";

            while(size-- > 0)
            {
                word += generatechar(chartype.capchar);
            }
            return word;
        }

        static string getkeys()
        {
            string word = "";

            for(int i = 0;i <4; i++)
            {
                word += generateword(4) + '-';
            }

            return word.Substring(0,word.Length - 1);
        }

        static void fillarraywithkeys(string[] nums)
        {
            for(int i = 0; i< nums.Length; i++)
            {
                nums[i] = getkeys();
            }


        }


        static bool ispalindromearray(int[] nums , int size)
        {
            for(int i=0; i<size/2; i++)
            {
                if (nums[i] != nums[size - 1 - i]) return false;
            }
            return true;
        }


        static int oddcount(int[] nums)
        {
            int count = 0;
            foreach(var i in nums)
            {
                if (i % 2 != 0) count++;
            }
            return count;
        }

        static int evencount(int[] nums)
        {
            int count = 0;
            foreach (var i in nums)
            {
                if (i % 2 == 0) count++;
            }
            return count;
        }

        static void resetscreen()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
        }

        enum Mode
        {
            easy = 1 , med , hard , mix
        }


        enum Operation
        {
            add = 1 , sub , mult , div , mix
        }

        struct Question
        {
            public int a;
            public int b;
            public Operation op;
            public bool res;
            public int correctans;
        }

        struct gameinfo
        {
            public int trials;
            public Mode mode;
            public Operation operation;
            public Question[] question;
        }


        static int gettrials()
        {
            Console.Write("enter number of trials : ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static Mode getmode()
        {
            Console.Write("enter desired mode : 1-easy , 2-med , 3-hard , 4-mix : ");
            return (Mode)Convert.ToInt32(Console.ReadLine());
        }

        static Operation getoperation()
        {
            Console.Write("enter operation : 1-add , 2-sub , 3-mult , 4-div , 5-mix : ");

            switch((Operation)Convert.ToInt32(Console.ReadLine()))
            {
                case Operation.add : return Operation.add;

                case Operation.sub: return Operation.sub;

                case Operation.mult:return Operation.mult;

                case Operation.div: return Operation.div;

                case Operation.mix: return Operation.mix;

            }

            return getoperation();
        }


        static Question genq(Mode m , Operation op)
        {
            Question q = new Question();
            return q ;


        }

        static void gengamequestions(ref gameinfo game)
        {
            
            for(int i=0; i<game.question.Length; i++)
            {
                game.question[i] = genq(game.mode, game.operation);
            }

        }

        static void playgame()
        {
            gameinfo game = new gameinfo();

            game.trials = gettrials();
            game.mode = getmode();
            game.operation = getoperation();

            game.question = new Question[game.trials];

            gengamequestions(ref game);

        }


        static void game()
        {
            char c = 'y';
            do
            {
                resetscreen();
                playgame();

            } while (c == 'y' || c == 'Y');

        }

        
        static void print_2D_array(int[,] ints)
        {
            for(int i = 0; i< ints.GetLength(0); i++)
            {
                for (int j = 0; j < ints.GetLength(1); j++)
                    Console.Write(ints[i,j] + " ");
                Console.WriteLine();
            }
            
        }


        static void fill_2d_random_numbers(int[,] ints)
        {
            for(int i = 0; i < ints.GetLength(0); i++)
                for (int j = 0; j < ints.GetLength(1); j++)
                    ints[i,j] = rnd.Next(1,20);
        }


        static int sum_of_row(int[,] ints, int i)
        {
            int sum = 0;
            for (int j = 0; j < ints.GetLength(1); j++)
                sum += ints[i, j];
            return sum;
        }


        static void print_sum_to_row(int[,] ints)
        {
            for (int i = 0; i < ints.GetLength(0); i++)
            {
                Console.Write("sum of row[{0}] = {1}\n", i, sum_of_row(ints, i));
            }

        }


        static int[] return_oned_of_col_sums(int[,] ints)
        {
            int[] oned = new int[ints.GetLength(0)];
            for (int i = 0; i < ints.GetLength(1); i++)
            {
                oned[i] = sum_of_col(ints, i);
            }
            return oned;
        }



        static int sum_of_col(int[,] ints, int i)
        {
            int sum = 0;
            for (int j = 0; j < ints.GetLength(0); j++)
                sum += ints[j, i];
            return sum;
        }



        static void print_sum_to_col(int[,] ints)
        { 
            for (int i = 0; i < ints.GetLength(1); i++)
            {
                Console.Write("sum of col[{0}] = {1}\n", i, sum_of_col(ints, i));
            }

        }




        static int[] return_oned_of_row_sums(int[,] ints)
        {
            int[] oned = new int[ints.GetLength(1)];
            for (int i = 0; i < ints.GetLength(0); i++)
            {
                oned[i] = sum_of_row(ints , i);
            }
            return oned;
        }


        static void fill_with_order_numbers_2D(int[,] ints)
        {
            int counter = 1;
            for (int i = 0; i < ints.GetLength(0); i++)
                for (int j = 0; j < ints.GetLength(1); j++)
                    ints[i, j] = counter++;
        }


        static int[,] transpose_matrix(int[,] ints)
        {
            int[,] mat = new int[ints.GetLength(0), ints.GetLength(1)];


            for (int i = 0; i < ints.GetLength(0); i++)
                for (int j = 0; j < ints.GetLength(1); j++)
                    mat[i, j] = ints[j, i];

            return mat;

        }


        static int[,] multiply_2d_matrix(int[,] a, int[,] b)
        {
            int[,] res = new int[a.GetLength(0), a.GetLength(1)];
            for( int i = 0; i < a.GetLength(0); i++)
            {
                for( int j = 0; j < b.GetLength(1); j++)
                {
                    res[i, j] = a[i, j] * b[i, j];
                }
            }

            return res;
        }


        static int sum_of_matrix(int[,] ints)
        {
            int sum = 0;
            for (int i = 0; i < ints.GetLength(0); i++)
                sum += sum_of_row(ints, i);

            return sum;
        }

        static int count_number_in_matrix(int[,] ints , int num)
        {
            int count = 0;
            for (int i = 0; i < ints.GetLength(0); i++)
                for (int j = 0; j < ints.GetLength(1); j++)
                    _ = (ints[i, j] == num) ? count++ : 0;

            return count;

        }



        static bool is_number_in_matrix(int[,] ints, int num)
        {
            for (int i = 0; i < ints.GetLength(0); i++)
                for (int j = 0; j < ints.GetLength(1); j++)
                    if (ints[i, j] == num) return true;

            return false;

        }


        static void print_intersected_numbers(int[,] a, int[,] b)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    int num = a[i, j];
                    if(is_number_in_matrix(b, num))
                        Console.Write(num + "    ");
                }
            }
            Console.WriteLine();
        }


        static bool is_palindrome_matrix(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1)/2; j++)
                    if (a[i, j] != a[i, a.GetLength(1) - 1 - j])
                        return false;
            return true;
        }


        static void print_first_n_fibbs(int n)
        {
            int[] a = new int[n];
            int one = 1, two = 1;
            while(n-- > 0)
            {
                Console.WriteLine(one + two);
            }
        }


        static void djfldjs(string s)
        {
            string ss = s;
            int i = 0;
            bool isf = true;
            foreach(char c in s)
            {
                if (c == ' ') { i++; isf = true; continue; }
                if(isf)
                {
                    //ss[i] = char.ToUpper(c);
                    isf = false;
                }
                i++;
            }
            Console.WriteLine(s);
        }*/





        struct Client
        {
            public string accnumber, pincode, name, phone;
            public double balance;
        }

        static Client read_client_data()
        {
            Console.WriteLine("Adding New Client: ");



            Client client = new Client();



            Console.Write("Enter account number : ");
            client.accnumber = Console.ReadLine();
            while (found_client_accnumber(client.accnumber))
            {
                Console.WriteLine("Client with [{0}] already exists, Enter another" +
                    " Account Number", client.accnumber);
                client.accnumber = Console.ReadLine();

            }
            Console.Write("Enter pincode : ");
            client.pincode = Console.ReadLine();
            Console.Write("Enter your name: ");
            client.name = Console.ReadLine();
            Console.Write("Enter phone number : ");
            client.phone = Console.ReadLine();
            Console.Write("Enter account balance : ");
            client.balance = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            return client;
        }


        static string client_data_to_line(Client client, string sep = "#//#")
        {
            string res = "";
            res += client.accnumber + sep;
            res += client.pincode + sep;
            res += client.name + sep;
            res += client.phone + sep;
            res += client.balance;

            return res;
        }


        static Client line_to_client_data(string line, string sep = "#//#")
        {
            Client client = new Client();
            string[] client_data = line.Split(sep.ToCharArray());

            client.accnumber = client_data[0];
            client.pincode = client_data[4];
            client.name = client_data[8];
            client.phone = client_data[12];
            client.balance = Convert.ToDouble(client_data[16]);

            return client;
        }

        static void out_put_client_data(Client client)
        {
            Console.WriteLine("Client Record :     ");
            Console.WriteLine("Account Number : {0}", client.accnumber);
            Console.WriteLine("PinCode :        {0}", client.pincode);
            Console.WriteLine("Name :           {0}", client.name);
            Console.WriteLine("Phone Number :   {0}", client.phone);
            Console.WriteLine("Balance :        {0}", client.balance);
        }


        static void out_put_client_data(string accnum)
        {
            List<Client> clients = clients_from_file();

            foreach(Client client in clients)
            {
                if(client.accnumber == accnum)
                {
                    out_put_client_data(client);
                    break;
                }
            }
        }



        // a txt file should exist in a path you can edit -----------------------------------------
        static string gfilepath = @"D:\c++ projects\c# app tst\bin\Debug\myfile.txt";

        static void addclienttofile(string filepath, string contents)
        {
            File.AppendAllText(filepath, contents + Environment.NewLine);

        }


        static void Addnewclient()
        {
            Client client = read_client_data();
            
            addclienttofile(gfilepath, client_data_to_line(client));
        }



        static void Addclients()
        {
            char c;
            do
            {

                Console.WriteLine("Enter a new Client :");
                Console.WriteLine();


                Addnewclient();


                Console.WriteLine("do you want to continue to add more clients (y/n):");
                c = Convert.ToChar(Console.ReadLine());
            } while (char.ToLower(c) == 'y');
        }




        static List<Client> clients_from_file()
        {

            List<Client> clients = new List<Client>();

            string[] strings = File.ReadAllLines(gfilepath);

            foreach (string s in strings) 
            {
                clients.Add(line_to_client_data(s));
            }

            return clients;
        }



        static void list_the_clients(List<Client> clients)
        {
            Console.Write("\n\t\t\t\t\tClient List (\"  {0}  \") Client(s).", clients.Count);

            Console.WriteLine("\n________________________________________________________________________________________________\n");

            foreach (Client client in clients)
            {
                out_put_client_data(client);
                Console.WriteLine();
                Console.WriteLine();
            }
        }


        static bool found_client_accnumber(string accnumber, ref Client client)
        {
            List<Client> clients = clients_from_file();

            foreach(Client client1 in clients)
            {
                if(client1.accnumber == accnumber)
                {
                    client = client1;
                    return true;
                }
            }
            return false;
        }

        static bool found_client_accnumber(string accnumber)
        {


            List<Client> clients = clients_from_file();

            foreach (Client client1 in clients)
                if (client1.accnumber == accnumber)
                {
                    return true;
                }

            return false;
        }




        static void read_client_account_number()
        {
            Console.Write("Enter the account number :");
            string accnum = Console.ReadLine();

            Client client = new Client();

            if(found_client_accnumber(accnum, ref client))
            {
                out_put_client_data(client);
            }

            else
            {
                Console.WriteLine("Client with the Account Number {0} is not found", accnum);
            }
        }



        static void delete_client_by_accnum()
        {
            Console.Write("Enter Account Number of the client to delete : ");

            string accnum = Console.ReadLine();

            List<Client> clients = clients_from_file();

            if(!found_client_accnumber(accnum))
            {
                Console.WriteLine("Client with the Account Number {0} is not found", accnum);
                return;
            }


            foreach (Client client in clients)
            {
                if(client.accnumber == accnum)
                {
                    out_put_client_data(client);

                    Console.Write("Are you sure you want to delete this client?");
                    if(Console.ReadLine() == "y")
                        clients.Remove(client);
                    break;
                }
            }

            File.WriteAllText(gfilepath, string.Empty);

            add_clients_to_file(clients);
            

        }



        static void add_clients_to_file(List<Client> clients)
        {
            foreach(Client client in clients)
            {
                addclienttofile(gfilepath, client_data_to_line(client));
            }
        }

        static void update_client(ref Client client)
        {
            Console.Write("Enter pincode : ");
            client.pincode = Console.ReadLine();
            Console.Write("Enter your name: ");
            client.name = Console.ReadLine();
            Console.Write("Enter phone number : ");
            client.phone = Console.ReadLine();
            Console.Write("Enter account balance : ");
            client.balance = (float)Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
        }



        static void update_client_by_accnum()
        {
            Console.WriteLine("enter account number to edit");
            string accnum = Console.ReadLine();

            if(found_client_accnumber(accnum))
            {
                List<Client> clients = clients_from_file();

                foreach (Client client in clients)
                {
                    if(client.accnumber == accnum)
                    {
                        out_put_client_data(client);

                        Console.WriteLine("Eneter new client record");

                        Client c = client; 
                        update_client(ref c);
                        clients.Remove(client);
                        clients.Add(c);
                        break;
                    }
                }

                File.WriteAllText(gfilepath, string.Empty);

                add_clients_to_file(clients);
                Console.WriteLine("Client Updated successfuly.");
            }
            else
            {
                Console.WriteLine("Client with the Account Number {0} is not found", accnum);
                return;
            }

            

        }



        static void clear_mainmenu() 
        {
            Console.WriteLine("Press Any Key To Go Back To Main Menu");
            Console.ReadKey();
            Console.Clear();
            
            show_main_menu();
        }

        static void clear_transaction()
        {
            Console.WriteLine("Press Any Key To Go Back To Transaction Menu");
            Console.ReadKey();
            Console.Clear();

            show_transaction_menu();
        }



        


        static void out_put_balances(Client client)
        {
            Console.WriteLine("Client Record :     ");
            Console.WriteLine("Account Number : {0}", client.accnumber);
            Console.WriteLine("Name :           {0}", client.name);
            Console.WriteLine("Balance :        {0}", client.balance);
        }


        static void show_total_balances()
        {
            List<Client> clients = clients_from_file();
            Console.Write("\n\t\t\t\t\tClient List (\"  {0}  \") Client(s).", clients.Count);

            Console.WriteLine("\n________________________________________________________________________________________________\n");

            foreach (Client client in clients)
            {
                out_put_balances(client);
                Console.WriteLine();
                Console.WriteLine();
            }
        }


        static void money_to_from_account(bool dep = true)
        {
            string accnum = "does not exist";
            double amount;

            while (!found_client_accnumber(accnum))
            {
                Console.Write("Enter Account Number to Perform transaction on : ");
                accnum = Console.ReadLine();
                Console.WriteLine("Client with [{0}] does not exists. ", accnum);
            }

            out_put_client_data(accnum);


            if(dep)
            {
                Console.Write("enter amount to deposit : ");
                amount = Convert.ToDouble(Console.ReadLine());
            }


            else
            {
                Console.Write("enter amount to withdraw : ");
                amount = Convert.ToDouble(Console.ReadLine());
                amount *= -1;
            }


            List<Client> clients = clients_from_file();

            foreach (Client client in clients)
            {
                if (client.accnumber == accnum)
                {
                    while(!dep && client.balance < -1 * amount)
                    {
                        Console.WriteLine("Cannot withdraw {0} the max is {1}", -1*amount, client.balance);
                        Console.Write("enter another amount? ");
                        amount = Convert.ToDouble(Console.ReadLine());
                        amount *= -1;
                    }


                    Client c = client;
                    c.balance += amount;
                    clients.Remove(client);
                    clients.Add(c);
                    break;
                }
            }

            File.WriteAllText(gfilepath, string.Empty);

            add_clients_to_file(clients);
        }




        static void show_transaction_menu()
        {
            Console.Clear();


            Console.WriteLine("\n--------------------------------------------------------------------------------------\n");
            Console.WriteLine("Transaction Menu Screen.");

            Console.WriteLine("[1] Deposit.");
            Console.WriteLine("[2] WithDraw.");
            Console.WriteLine("[3] Total Balances.");
            Console.WriteLine("[4] Main Menu.");

            sbyte choice = Convert.ToSByte(Console.ReadLine());


            switch (choice)
            {
                case 1:
                    money_to_from_account();
                    clear_transaction();
                    break;
                case 2:
                    money_to_from_account(false);
                    clear_transaction();
                    break;
                case 3:
                    show_total_balances();
                    clear_transaction();
                    break;
                case 4:
                    Console.Clear();
                    show_main_menu();
                    break;

            }

            }







        static void show_main_menu()
        {
            Console.WriteLine("\n\n\n----------------------------------------------------\n");
            Console.WriteLine("[1] Show Client List.");
            Console.WriteLine("[2] Add New Client.");
            Console.WriteLine("[3] Delete Client.");
            Console.WriteLine("[4] Update Client Info.");
            Console.WriteLine("[5] Find Client.");
            Console.WriteLine("[6] Transactions.");
            Console.WriteLine("[7] Exit.");
            Console.WriteLine("\n\n\n----------------------------------------------------\n");
            Console.Write("Choos What do you want to do? [1 to 7]?");
            
            sbyte choice = Convert.ToSByte(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    list_the_clients(clients_from_file());
                    clear_mainmenu();
                    break;
                case 2:
                    Addclients();
                    clear_mainmenu();
                    break;
                case 3:
                    delete_client_by_accnum();
                    clear_mainmenu();
                    break;
                case 4:
                    update_client_by_accnum();
                    clear_mainmenu();
                    break;
                case 5:
                    read_client_account_number();
                    clear_mainmenu();
                    break;
                case 6:
                    show_transaction_menu();
                    break;
                default:
                    Console.WriteLine("Exited bye bye.");
                    return;
            }
            

        }




        static void Main()
        {
            show_main_menu();
        }
    }
}
/*
  
        // it skips the readline if read is before eg : read -> readline;




while(!element == sortedlist.get(index) && ++index < sortedlist.size());
return (index < sortedlist.size()) : index : -1;







*/
