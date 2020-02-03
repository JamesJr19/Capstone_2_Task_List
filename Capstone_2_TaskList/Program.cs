using System;
using System.Collections.Generic;

namespace Capstone_2_TaskList
{
    class Program
    {
        private static object actualListOfChores;

        public static bool Complete { get; private set; }

        static void Main(string[] args)
        {
            //create list of movies
            List<Chore> listOfChores = new List<Chore>

                {
                  new Chore ("James", "Clean the white boards", DateTime.Parse("02/03/2020")),
                  new Chore ("Matt", "Make sure all tables are wiped down", DateTime.Parse("02/07/2020")),
                  new Chore ("Mike", "Clean the coffee machine", DateTime.Parse("02/01/2020"))
                };


            Console.WriteLine("Welcome to the Task List\n");

            string userContinue = "y";

            //while loop to ask user to continue
            while (userContinue != "n")
            {
                Console.WriteLine("Pick an option below to get started:\n");
                Console.WriteLine($"1. List Tasks\n2. Add Task\n3. Delete Task\n4. Mark Task Complete\n5. Quit");

                bool tryAgain = true;
                while (tryAgain)
                {
                    string userSelected = Console.ReadLine().ToLower();
                    tryAgain = false;

                    List<string> actualListOfCharaters = new List<string>();

                    switch (userSelected)
                    {
                        //case 1
                        case "1":
                        case "list task":
                            Console.WriteLine($"You've selected 'List Tasks'.");

                            int i = 1;
                            foreach (Chore chore in listOfChores)
                            {
                                Console.WriteLine($"{i}. Employee - {chore.Name}\nTask Description - {chore.Desciption}\nDue Date - {chore.DueDate.ToShortDateString()}\nCompleted - {chore.Completed}\n");
                                i++;
                            }
                            break;
                        //case 1 ends


                        //case 2
                        case "2":
                        case "add task":
                            Console.WriteLine($"You've selected 'Add Task'.");

                            string addName = GetUserInput("What is the name of the employee you wish to add?\n");
                            string addDescription = GetUserInput("What is the task you wish to add?\n");
                            string addDueDate = "";

                            bool correctFormat = true;

                            while (correctFormat)
                            {
                                addDueDate = GetUserInput("When is this task due? (mm/dd/yyyy)\n");

                                try
                                {
                                    DateTime.Parse(addDueDate);
                                    correctFormat = false;
                                }
                                catch (Exception e)
                                {
                                    
                                    Console.WriteLine("error, please use correct format");
                                    correctFormat = true;
                                }
                            }
                            correctFormat = false;


                                listOfChores.Add(new Chore(addName, addDescription, DateTime.Parse(addDueDate)));

                                Console.WriteLine("Task added to list.");
                                break;
                                //case 2 ends


                        //case 3
                        case "3":
                        case "delete task":
                            Console.WriteLine($"You've selected 'Delete Task'.\n");

                            //display list to user so they can be reminded of the options
                            int j = 1;
                            foreach (Chore chore in listOfChores)
                            {

                                Console.WriteLine($"{j}. Employee - {chore.Name}\nTask Description - {chore.Desciption}\nDue Date - {chore.DueDate.ToShortDateString()}\nCompleted - {chore.Completed}\n");
                                j++;
                            }

                            int removeName = 0;
                            Console.WriteLine("Pick a number to delete that task:");

                            //takes user input and converts to int
                            removeName = int.Parse(Console.ReadLine());

                            //creat AreYouSure keyword to loop back to delete confirmation
                            string userContinue2 = "y";
                            Console.WriteLine($"You've selected task {removeName}. Are you sure? y/n\n");
                            userContinue2 = Console.ReadLine();

                            while (userContinue2 != "n")
                            {

                                //if statement to validate user input is y/n
                                if (userContinue2 == "y")
                                {
                                    listOfChores.RemoveAt(removeName - 1);
                                    Console.WriteLine($"it worked");
                                    Console.WriteLine($"Task {removeName} has been deleted.\n");
                                    break;
                                }
                                else if (userContinue2 == "n")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input.");
                                    break;
                                }
                            }
                            break;
                        //case 3 ends


                        //case 4
                        case "4":
                        case "mark task complete":
                            Console.WriteLine($"You've selected 'Mark Task Complete'.");

                            //display list to user so they can be reminded of the options
                            int k = 1;
                            foreach (Chore chore in listOfChores)
                            {
                                Console.WriteLine($"{k}. Employee - {chore.Name}\nTask Description - {chore.Desciption}\nDue Date - {chore.DueDate.ToShortDateString()}\nCompleted - {chore.Completed}\n");
                                k++;
                            }

                            int markComplete = 0;
                            Console.WriteLine("Pick a number to mark that task complete:");

                            //takes user input and converts to int
                            markComplete = int.Parse(Console.ReadLine());

                            string userContinue3 = "y";

                            //creat AreYouSure keyword to loop back to delete confirmation
                            Console.WriteLine($"You've selected task {markComplete}. Are you sure? y/n\n");
                            userContinue3 = Console.ReadLine();

                            while (userContinue3 != "n")
                            {
                                //if statement to validate user input is y/n
                                if (userContinue3 == "y")
                                {

                                    listOfChores[markComplete - 1].Completed = true;


                                    Console.WriteLine($"it worked");
                                    break;

                                }
                                else if (userContinue3 == "n")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input.");
                                    break;

                                }
                            }
                            break;
                        //case 4 ends

                        //case 5
                        case "5":
                        case "quit":
                            Console.WriteLine("Have a good day and remember to complete your assigned tasks.\n");
                            Console.WriteLine("Teamwork makes the dream work!");
                            goto Exit;

                        default:
                            tryAgain = true;
                            Console.WriteLine("Invalid. Try another option");
                            break;
                    }

                }
                Console.WriteLine("Would you like to return to the main menu? y/n");
                userContinue = Console.ReadLine();
            }
        Exit:;
        }

        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static void AddUserInputToList(List<string> stringList, string message)
        {
            string input = GetUserInput(message);
            stringList.Add(input);

            //can also write it this way
            //stringList.Add(GetUserInput(message));
        }
    }
}

