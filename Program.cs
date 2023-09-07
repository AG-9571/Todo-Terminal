using System;
using System.Collections.Generic;

namespace ToDo;
    internal class Program
    {
        public static List<string> TaskList = new List<string>();

        static void Main(string[] args)
        {            
            int MenuSlected = 0;
            do
            {
                MenuSlected = ShowMainMenu();

                if ((Menu)MenuSlected == Menu.Add)                
                {
                    ShowMenuAdd();
                }
                else if ((Menu) MenuSlected == Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if ((Menu)MenuSlected == Menu.Pending)
                {
                    ShowMenuPending();
                }
                else if((Menu)MenuSlected >= Menu.NotValid || (Menu)MenuSlected < Menu.Add  )
                {
                    Console.WriteLine("Opción no valida");
                }                
            } while ((Menu)MenuSlected != Menu.Exit);
        }
        /// <summary>
        /// Show the options for task, 1. Add, 2. Remove, 3. Pending, 4. Exit
        /// </summary>
        /// <returns>Returns option selected by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");
            Console.WriteLine("----------------------------------------");

            string ReadLine = Console.ReadLine();
            int ConvertReadLine ;
            bool esEntero = int.TryParse(ReadLine, out ConvertReadLine);
            if (esEntero)
            {
                ConvertReadLine = Convert.ToInt32(ReadLine);
            }
            return ConvertReadLine;
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");                
                ShowTaskList();             

                string Readline = Console.ReadLine();

                // remove one position becouse the array start in 0
                int indexToRemove = Convert.ToInt32(Readline) - 1;
                
                if( indexToRemove > (TaskList.Count - 1 ) && TaskList.Count < -0 )
                {
                    Console.WriteLine("La tarea no existe"); 

                }else if(indexToRemove > -1 && TaskList.Count > 0)
                {
                    string SearchTask = TaskList[indexToRemove];
                    TaskList.RemoveAt(indexToRemove);
                    Console.WriteLine($"Tarea  {SearchTask} eliminada");
                }

            }
            catch (Exception Error )
            {       
                Console.WriteLine("Ha ocurrido un error al remover la tarea ");
                //Error.Message;     
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string ReadTask = Console.ReadLine();
                TaskList.Add(ReadTask);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuPending()
        {
            if ( TaskList?.Count <= 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                ShowTaskList();
            }
        }
        public static void ShowTaskList()
        {
            int indexTask = 1;

            Console.WriteLine("----------------------------------------");

            TaskList.ForEach(item => Console.WriteLine($"{indexTask++} . {item}"));                

            Console.WriteLine("----------------------------------------");
        }
    }
    public enum Menu 
    {
        Add = 1,
        Remove = 2,
        Pending = 3,
        Exit = 4,
        NotValid = 5        
    }

