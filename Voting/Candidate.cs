using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting
{
    class Candidate
    {
        private String firstName, middleName, lastName;
        private String politicalParty;
        private String position;
        private int votes;

        public Candidate (String f, String m, String l, String pos, String pP)
        {
            firstName = f;
            middleName = m;
            lastName = l;
            politicalParty = pP;
            position = pos;
            votes = 0;
        }

        public Candidate(String f, String l, String pos, String pP)
        {
            firstName = f;
            middleName = null;
            lastName = l;
            politicalParty = pP;
            position = pos;
            votes = 0;
        }

        public String getFullName ()
        {
            if (String.IsNullOrEmpty(middleName))
                return (firstName + " " + lastName);
            else
                return (firstName + " " + middleName + " " + lastName);
        }

        public String getParty ()
        {
            return politicalParty;
        }

        public String getPosition ()
        {
            return position;
        }

        public void printSlogan ()
        {
            if (String.IsNullOrEmpty(middleName))
                Console.Write(firstName + " " + lastName + ", " + politicalParty + " for " + politicalParty);
            else
                Console.Write(firstName + " " + middleName + " " + lastName + ", " + politicalParty + " for " + politicalParty);
        }

        public void vote ()
        {
            votes++;
        }

        public int getVotes ()
        {
            return votes;
        }
    }
}
