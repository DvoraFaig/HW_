using System;
using ObserverSystem;
using System.Collections;
using System.Collections.Generic;
using Enums;
using dataExceptions;

namespace ConsoleUI
{
    class Program
    {
        static IMeansObservationOperations observationList;
        static bool continueUserChoosing;

        

        static void Main(string[] args)
        {
            try {
                observationList = ObservationList.Instance; 
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            continueUserChoosing = false;
            do
            {
                Console.WriteLine("Press:" +
                    "\n1: Add new means of observation" +
                    "\n2: Delete means of observation" +
                    "\n3: Show all" +
                    "\n4: Show means of observation from one type" +
                    "\n5: Show all sorted by visionField" +
                    "\n6: Show means of observation with max aerial range and minimal vision field" +
                    "\n0: exit");

                try
                {
                    var choosing = Convert.ToInt32(Console.ReadLine());
                    continueUserChoosing = true;
                    switch (choosing)
                    {
                        case 0:
                            continueUserChoosing = false;
                            break;
                        case 1:
                            AddNewObservation();
                            break;
                        case 2:
                            DeleteObservation();
                            break;
                        case 3:
                            ShowAllObservations();
                            break;
                        case 4:
                            ShowByChoosenType();
                            break;
                        case 5:
                            ShowSorted();
                            break;
                        case 6:
                            ShowByMaxAerial();
                            break;
                        default:
                            break;
                    }
                }
                catch (System.FormatException)
                {
                    continueUserChoosing = true;
                    Console.WriteLine("Input Error, please try again...");                    
                }
            } while (continueUserChoosing);

        }
        static int[] types = { 0, 2 };

        static void AddNewObservation()
        {
            bool inputIsfalse = false;
            do
            {
                try
                {
                    int type, visionField, range;
                    Console.WriteLine("Enter Type (0-2): ");
                    type = GetIntInput();
                    if (type < types[0] || type > types[1])
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    Console.WriteLine("Enter aeriel range by metters: ");
                    range = GetIntInput();
                    Console.WriteLine("Enter vision field by degrees: ");
                    visionField = GetIntInput();
                    observationList.AddObserver(type, range, visionField);
                    inputIsfalse = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Input type error... please try again");
                    inputIsfalse = true;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Error: invalid observation type... try again");
                    inputIsfalse = true;
                }
                catch (UnableAccessDataException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception) { }
            } while (inputIsfalse);
        }

        static void DeleteObservation()
        {
            bool inputIsfalse = true;
            Console.WriteLine($"Enter num of observation to delete (0-{observationList.GetAll().Count})");
            do
            {
                try
                {
                    int id = GetIntInput();
                    if (id > observationList.GetAll().Count || id < 0)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    observationList.DeleteObservation(id);
                    inputIsfalse = false;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("observation not exist. please try again");
                    inputIsfalse = true;
                }
                catch (UnableAccessDataException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception) { }
                

            } while (inputIsfalse);
        }

        static void ShowAllObservations()
        {
            List<MeansObservation> l = observationList.GetAll();
            foreach(MeansObservation item in l)
            {
                Console.WriteLine(item.ToString());
            }
        }

        static void ShowByChoosenType()
        {
            bool inputIsfalse = true;
            do
            {
                try
                {
                    Console.WriteLine("Enter type to show: (0-2)");
                    int type = GetIntInput();
                    if (type < 0 || type > 2)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    List<MeansObservation> l = observationList.GetSpecificType((ObservationType)type); 
                    foreach (MeansObservation item in l)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    inputIsfalse = false;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Error: invalid type... try again");
                    inputIsfalse = true;
                }
            } while (inputIsfalse);
        }

        static void ShowSorted()
        {
            List<MeansObservation> l = observationList.GetSortedByRange();
            foreach (MeansObservation item in l)
            {
                Console.WriteLine(item.ToString());
            }
        }

        static void ShowByMaxAerial()
        {
            bool inputIsfalse = true;
            do
            {
                try
                {
                    Console.WriteLine("Enter max aerial range");
                    int maxAerial = GetIntInput();
                    if (maxAerial < 0)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    Console.WriteLine(
                        observationList.GetMaxObservationWithMinVisionField(maxAerial).ToString());
                    inputIsfalse = false;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Error: invalid input, try again");
                    inputIsfalse = true;
                }
            } while (inputIsfalse);
        }

        static int GetIntInput()
        {
            bool inputIsfalse = false;
            int input = new int();
            do
            {
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    inputIsfalse = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Input type error... please try again");
                    inputIsfalse = true;
                }
            } while (inputIsfalse);
            return input;
        }
    }
}
