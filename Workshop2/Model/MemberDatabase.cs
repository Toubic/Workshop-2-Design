using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Model
{
    /// <summary>
    /// Member database:
    /// </summary>
    class MemberDatabase
    {
        private List<Member> members;

        public MemberDatabase()
        {
            members = new List<Member>();
        }
        public List<Member> Members
        {
            get { return members; }
            private set { members = value; }
        }

        public void initializeDatabase()
        {

            //Read in database from text file:

            if (File.Exists("members.txt"))
            {
                StreamReader streamR = new StreamReader("members.txt");
                int numberOfMembers = Convert.ToInt32(streamR.ReadLine());
                string aMember;

                for (int i = 0; i < numberOfMembers; i++)
                {
                    aMember = streamR.ReadLine();
                    string[] member = aMember.Split(new char[0]);
                    this.createMember(member[0], member[1]);
                    if (member.Count() > 3)
                    {
                        for (int y = 3; y < member.Count(); y++)
                        {
                            Model.BoatType boatType;
                            switch (member[y])
                            {

                                case "Sailboat":
                                    boatType = Model.BoatType.Sailboat;
                                    members[i].registerBoat(boatType, Convert.ToInt32(member[(y + 1)]));
                                    break;
                                case "Motorsailer":
                                    boatType = Model.BoatType.Motorsailer;
                                    members[i].registerBoat(boatType, Convert.ToInt32(member[(y + 1)]));
                                    break;
                                case "Kayak":
                                    boatType = Model.BoatType.Kayak;
                                    members[i].registerBoat(boatType, Convert.ToInt32(member[(y + 1)]));
                                    break;
                                case "Canoe":
                                    boatType = Model.BoatType.Canoe;
                                    members[i].registerBoat(boatType, Convert.ToInt32(member[(y + 1)]));
                                    break;
                                case "Other":
                                    boatType = Model.BoatType.Other;
                                    members[i].registerBoat(boatType, Convert.ToInt32(member[(y + 1)]));
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }

                streamR.Close();
            }
        }
        public void saveDatabase()
        {
            //Write database to file:
            StreamWriter streamW = new StreamWriter("members.txt");
            streamW.WriteLine(members.Count());
            foreach (Model.Member element in members)
            {
                streamW.WriteLine(element.ToString("V"));
            }
            streamW.Close();
        }

        public void createMember(string name, string ssn)
        {
            Member newMember = new Member(name, ssn);
            members.Add(newMember);
        }
        public bool updateMember(int id, string name, string ssn)
        {
            for (int i = 0; i < members.Count(); i++)
            {
                if(members[i].ID == id){
                    members[i].Name = name;
                    members[i].SSN = ssn;
                    return true;
                }
            }
            return false;
        }
        public Member lookAtSpecificMember(int id)
        {
            for (int i = 0; i < members.Count(); i++)
            {
                if (members[i].ID == id)
                {
                    return members[i];
                }
            }
            return null;
        }

        public bool deleteMember(int id)
        {
            for (int i = 0; i < members.Count(); i++)
            {
                if (members[i].ID == id)
                {
                    members.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public string listMembers(string format)
        {
            string listOfMembers = "";

            foreach(Member element in members){
                listOfMembers += string.Format("{0} {1}", element.ToString(format), Environment.NewLine);
            }
            return listOfMembers;
        }
    }
}
