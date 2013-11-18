using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Voting
{
    class Voting
    {
        public static void menu ()
        {
            Console.WriteLine("NJ Voter System:");
            Console.WriteLine("(1) Sign up a new voter");
            Console.WriteLine("(2) View this year's election ballot");
            Console.WriteLine("(9) VOTE");
            Console.WriteLine("(0) Exit");
        }

        static void Main(string[] args)
        {
            ArrayList voters = new ArrayList();
            Ballot november2012 = new Ballot(16, 10, 2013);

            november2012.addElection("US Senator");
            november2012.addCandidate("US Senator", "Cory", "Booker", "Democrat");
            november2012.addCandidate("US Senator", "Steven", "M", "Lonegan", "Republican");
            november2012.addCandidate("US Senator", "Edward", "C", "Stackhouse, Jr.", "Ed the Barber");
            november2012.addCandidate("US Senator", "Robert", "Depasquale", "Independent");
            november2012.addCandidate("US Senator", "Stuart", "David", "Meissner", "Alimony Reform Now");

            int choice = 0;

            do
            {
                menu();
                Console.Write("What will yu like to do? ");
                String t = Console.ReadLine().Trim();
                t = Regex.Replace(t, "[^0-9]", "");
                choice = Convert.ToInt32(t);

                switch (choice)
                {
                    case 1:
                        bool found = false;
                        Voter temp = new Voter();
                        if (temp.getCriminalRecord())
                            Console.WriteLine("You may not vote because you have an active criminal record.");
                        else if (!temp.ofAge())
                            Console.WriteLine("You may not vote because you are not of age.");
                        else
                        {
                            foreach (Voter v in voters)
                            {
                                if (v.compare(temp))
                                {
                                    Console.WriteLine("This person is already registered.");
                                    found = true;
                                }
                            }

                            if (!found)
                            {
                                voters.Add(temp);
                                Console.WriteLine("You are registered to vote.");
                            }
                        }
                        break;
                    case 2:
                        november2012.printBallot();
                        break;
                    case 9:

                        november2012.vote();
                        break;
                    case 0:
                        Console.WriteLine("Exit program");
                        break;
                    default:
                        Console.WriteLine("Invalid entry");
                        break;
                }
                Console.WriteLine();
            } while (choice != 0);
        }
    }
}
