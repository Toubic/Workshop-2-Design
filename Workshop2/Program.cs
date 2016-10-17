using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace View
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Model.MemberDatabase theDatabase;
                theDatabase = new Model.MemberDatabase();

                //Read in database from text file:

                if(File.Exists("members.txt")){
                    StreamReader streamR = new StreamReader("members.txt");
                    int numberOfMembers = Convert.ToInt32(streamR.ReadLine());
                    string aMember;

                    for (int i = 0; i < numberOfMembers; i++)
                    {
                        aMember = streamR.ReadLine();
                        string[] member = aMember.Split(new char[0]);
                        theDatabase.createMember(member[0], member[1]);
                        if (member.Count() > 3)
                        {
                            for (int y = 3; y < member.Count(); y++)
                            {
                                Model.BoatType theType;
                                switch (member[y])
                                {

                                    case "Sailboat":
                                        theType = Model.BoatType.Sailboat;
                                        theDatabase.members[i].registerBoat(theType, Convert.ToInt32(member[(y + 1)]));
                                        break;
                                    case "Motorsailer":
                                        theType = Model.BoatType.Motorsailer;
                                        theDatabase.members[i].registerBoat(theType, Convert.ToInt32(member[(y + 1)]));
                                        break;
                                    case "Kayak":
                                        theType = Model.BoatType.Kayak;
                                        theDatabase.members[i].registerBoat(theType, Convert.ToInt32(member[(y + 1)]));
                                        break;
                                    case "Canoe":
                                        theType = Model.BoatType.Canoe;
                                        theDatabase.members[i].registerBoat(theType, Convert.ToInt32(member[(y + 1)]));
                                        break;
                                    case "Other":
                                        theType = Model.BoatType.Other;
                                        theDatabase.members[i].registerBoat(theType, Convert.ToInt32(member[(y + 1)]));
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }

                    streamR.Close();
                }
                //Main menu:
                int option = 0;

                while (option != 9)
                {
                    Console.WriteLine("Main menu:");
                    Console.WriteLine("--------");
                    Console.WriteLine("1. Create a new member.");
                    Console.WriteLine("2. List all members.");
                    Console.WriteLine("3. Delete a member.");
                    Console.WriteLine("4. Update a member.");
                    Console.WriteLine("5. Look at a specific member.");
                    Console.WriteLine("6. Register a new boat.");
                    Console.WriteLine("7. Delete a boat.");
                    Console.WriteLine("8. Update a boat's information.");
                    Console.WriteLine("9. Exit.");
                    Console.WriteLine("Your choice: ");
                    try
                    {
                        option = Convert.ToInt32(Console.ReadLine());
                        if (option < 1 || option > 9)
                            throw new ArgumentOutOfRangeException();
                        Console.Clear();
                    }
                    catch (FormatException)
                    {
                        Console.Clear();
                        Console.WriteLine("The input had wrong format.");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.Clear();
                        Console.WriteLine("The option was not in the range of 1-9.");
                    }
                    
                    int id;
                    int index;
                    string name;
                    string ssn;
                    Model.Member theMember;

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Enter name: ");
                            name = Console.ReadLine();
                            Console.WriteLine("Enter social security number: ");
                            ssn = Console.ReadLine();
                            theDatabase.createMember(name, ssn);
                            break;
                        case 2:
                            Console.WriteLine("Compact List:");
                            foreach(Model.Member element in theDatabase.members)
                                Console.WriteLine(element.ToString("C"));
                            Console.WriteLine();
                            Console.WriteLine("Verbose List:");
                            foreach (Model.Member element in theDatabase.members)
                                Console.WriteLine(element.ToString("V"));
                            Console.WriteLine();
                            break;
                        case 3:
                            try
                            {
                                Console.WriteLine("Enter member id: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                if (theDatabase.deleteMember(id)) { }
                                else
                                    Console.WriteLine("The member id does not exist.");
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("The input had wrong format.");
                            }
                            break;
                        case 4:
                            try
                            {
                                Console.WriteLine("Enter member id: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Input new name: ");
                                name = Console.ReadLine();
                                Console.WriteLine("Input new social security number: ");
                                ssn = Console.ReadLine();
                                if (theDatabase.updateMember(id, name, ssn)) { }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("The member id does not exist.");
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("The input had wrong format.");
                            }
                            break;

                        case 5:
                            try
                            {
                                Console.WriteLine("Enter member id: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                theMember = theDatabase.lookAtSpecificMember(id);
                                if (theMember != null)
                                {
                                    Console.WriteLine(theMember.ToString("C"));
                                    Console.WriteLine();
                                    Console.WriteLine(theMember.ToString("V"));
                                    Console.WriteLine();
                                }
                                else
                                    Console.WriteLine("The member does not exist.");
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("The input had wrong format.");
                            }
                            break;
                        case 6:
                            try
                            {
                                Console.WriteLine("Enter member id: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                theMember = theDatabase.lookAtSpecificMember(id);
                                if (theMember != null)
                                    registerBoat(theMember);
                                else
                                    Console.WriteLine("The member id does not exist.");
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("The input had wrong format.");
                            }
                                break;
                        case 7:
                            try
                            {
                                Console.WriteLine("Enter member id: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                theMember = theDatabase.lookAtSpecificMember(id);
                                if (theMember != null)
                                {
                                    Console.WriteLine("Enter index of the boat: ");
                                    index = Convert.ToInt32(Console.ReadLine());
                                    if (theMember.deleteBoat(index)) { }
                                    else
                                        Console.WriteLine("Index of the boat or the boats does not exist, try another index starting from index 0.");
                                }
                                else
                                    Console.WriteLine("The member id does not exist.");
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("The input had wrong format.");
                            }
                            break;
                        case 8:
                            try
                            {
                                Console.WriteLine("Enter member id: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                theMember = theDatabase.lookAtSpecificMember(id);
                                if (theMember != null)
                                {
                                    Console.WriteLine("Enter index of the boat: ");
                                    index = Convert.ToInt32(Console.ReadLine());
                                    updateBoat(index, theMember);
                                }
                                else
                                    Console.WriteLine("The member id does not exist.");
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("The input had wrong format.");
                            }
                            break;
                        case 9: // "Exit."
                            break;
                        default:
                            break;

                    }

                    //Write database to file:
                    StreamWriter streamW = new StreamWriter("members.txt");
                    streamW.WriteLine(theDatabase.members.Count());
                    foreach(Model.Member element in theDatabase.members){
                        streamW.WriteLine(element.ToString("V"));
                    }
                    streamW.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Handle input boat type:
        public static void registerBoat(Model.Member theMember)
        {
            int option;
            Model.BoatType theType;
            int length;
     
            Console.WriteLine("Which boat type?:");
            Console.WriteLine("--------");
            Console.WriteLine("1. Sailboat.");
            Console.WriteLine("2. Motorasiler.");
            Console.WriteLine("3. Kayak.");
            Console.WriteLine("4. Canoe.");
            Console.WriteLine("5. Other.");
            Console.WriteLine("Your choice: ");
            option = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Enter length of the boat: ");
            length = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (option < 1 || option > 5)
                    throw new ArgumentOutOfRangeException();
                switch (option)
                {

                    case 1:
                        theType = Model.BoatType.Sailboat;
                        theMember.registerBoat(theType, length);
                        break;
                    case 2:
                        theType = Model.BoatType.Motorsailer;
                        theMember.registerBoat(theType, length);
                        break;
                    case 3:
                        theType = Model.BoatType.Kayak;
                        theMember.registerBoat(theType, length);
                        break;
                    case 4:
                        theType = Model.BoatType.Canoe;
                        theMember.registerBoat(theType, length);
                        break;
                    case 5:
                        theType = Model.BoatType.Other;
                        theMember.registerBoat(theType, length);
                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("The option was not in the range of 1-5.");
            }
        }
        public static void updateBoat(int index, Model.Member theMember)
        {
            int option;
            Model.BoatType theType;
            int length;

            Console.WriteLine("Which boat type?:");
            Console.WriteLine("--------");
            Console.WriteLine("1. Sailboat.");
            Console.WriteLine("2. Motorasiler.");
            Console.WriteLine("3. Kayak.");
            Console.WriteLine("4. Canoe.");
            Console.WriteLine("5. Other.");
            Console.WriteLine("Your choice: ");
            option = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter length of the boat: ");
            length = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {

                case 1:
                    theType = Model.BoatType.Sailboat;
                    if(theMember.updateBoat(index, theType, length)){}
                    else
                        Console.WriteLine("Index of the boat or the boats does not exist, try another index starting from index 0.");
                    break;
                case 2:
                    theType = Model.BoatType.Motorsailer;
                    if (theMember.updateBoat(index, theType, length)) { }
                    else
                        Console.WriteLine("Index of the boat or the boats does not exist, try another index starting from index 0.");
                    break;
                case 3:
                    theType = Model.BoatType.Kayak;
                    if (theMember.updateBoat(index, theType, length)) { }
                    else
                        Console.WriteLine("Index of the boat or the boats does not exist, try another index starting from index 0.");
                    break;
                case 4:
                    theType = Model.BoatType.Canoe;
                    if (theMember.updateBoat(index, theType, length)) { }
                    else
                        Console.WriteLine("Index of the boat or the boats does not exist, try another index starting from index 0.");
                    break;
                case 5:
                    theType = Model.BoatType.Other;
                    if (theMember.updateBoat(index, theType, length)) { }
                    else
                        Console.WriteLine("Index of the boat or the boats does not exist, try another index starting from index 0.");
                    break;
                default:
                    break;
            }

        }
    }
}
