using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_2_TaskList
{
    class Chore
    {
        //(team member’s name, taskc description, due date.

        //s data members, the task should include
        //1. Team member’s name
        //2. Brief description
        //3. Due date
        //4. Whether it’s been completed or not

        //fields
        private string name;
        private string description;
        private DateTime dueDate;
        private bool completed;

        //properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Desciption
        {
            get { return description; }
            set { description = value; }
        }

        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }
        public bool Completed
        {
            get { return completed; }
            set { completed = value; }
        }
        //Constructors
        public Chore()
        {

        }

        public Chore (bool _completed)
        {
            completed = _completed;
        }

        public Chore(string _name, string _description, DateTime _dueDate, bool _completed = false)
        {
            name = _name;
            description = _description;
            dueDate = _dueDate;
            completed = _completed;
        }

        //create list of tasks
        private static List<string> GetListOfChores(List<Chore> choreList)
        {
            List<string> listOfChores = new List<string>();
            foreach (Chore chore in choreList)
            {
                if (listOfChores.Contains(chore.description))
                {
                    listOfChores.Add(chore.description);
                }

            }
            return listOfChores;
        }

      
        public static void PrintListOfChores(List<Chore> choreList)
        {
            List<string> listOfChores = GetListOfChores(choreList);
            foreach (string chore in listOfChores)
            {
                Console.WriteLine($"{chore}");
            }
        }
    }
}
