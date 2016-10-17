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
                            Model.BoatType theType;
                            switch (member[y])
                            {

                                case "Sailboat":
                                    theType = Model.BoatType.Sailboat;
                                    members[i].registerBoat(theType, Convert.ToInt32(member[(y + 1)]));
                                    break;
                                case "Motorsailer":
                                    theType = Model.BoatType.Motorsailer;
                                    members[i].registerBoat(theType, Convert.ToInt32(member[(y + 1)]));
                                    break;
                                case "Kayak":
                                    theType = Model.BoatType.Kayak;
                                    members[i].registerBoat(theType, Convert.ToInt32(member[(y + 1)]));
                                    break;
                                case "Canoe":
                                    theType = Model.BoatType.Canoe;
                                    members[i].registerBoat(theType, Convert.ToInt32(member[(y + 1)]));
                                    break;
                                case "Other":
                                    theType = Model.BoatType.Other;
                                    members[i].registerBoat(theType, Convert.ToInt32(member[(y + 1)]));
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
                if(members[i].id == id){
                    members[i].name = name;
                    members[i].ssn = ssn;
                    return true;
                }
            }
            return false;
        }
        public Member lookAtSpecificMember(int id)
        {
            for (int i = 0; i < members.Count(); i++)
            {
                if (members[i].id == id)
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
                if (members[i].id == id)
                {
                    members.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public void listMembers(string format)
        {
            foreach(Member element in members){
                Console.WriteLine(element.ToString(format));
            }
        }
    }
}
