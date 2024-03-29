﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting
{
    class Election
    {
        private ArrayList candidates;
        private String position;

        public Election (String name)
        {
            position = name;
            candidates = new ArrayList();
        }

        public bool search (String fN, String lN)
        {
            foreach (Candidate i in candidates)
            {
                String name = i.getFullName();
                if ((fN + " " + lN).Equals(name, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        public bool search (String fN, String mN, String lN)
        {
            foreach (Candidate i in candidates)
            {
                String name = i.getFullName();
                if ((fN + " " + mN + " " + lN).Equals(name, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        public void addCandidate (String fN, String lN, String party)
        {
            if (!search(fN, lN))
                candidates.Add(new Candidate(fN, lN, position, party));
            else
                Console.WriteLine("Candidate is already on the ballot for this election.");
        }

        public void addCandidate(String fN, String mN, String lN, String party)
        {
            if (!search(fN, mN, lN))
                candidates.Add(new Candidate(fN, mN, lN, position, party));
            else
                Console.WriteLine("Candidate is alreadon the ballor for this election.");
        }

        public void printBallot ()
        {
            Console.WriteLine("Candidates for " + position + ":");
            int i = 1;
            foreach (Candidate j in candidates)
            {
                Console.WriteLine("(" + i + ") " + j.getFullName());
                i++;
            }
            Console.WriteLine();
        }

        public String getPosition()
        {
            return position;
        }

        public void vote (int i)
        {
            i--;
            ((Candidate)candidates[i]).vote();

            this.printResults();
        }

        public void printResults ()
        {
            foreach (Candidate j in candidates)
                Console.WriteLine(j.getFullName() + " " + j.getVotes());
        }
    }
}
