﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// Member database:
    /// </summary>
    class MemberDatabase
    {
        public List<Member> members;

        public MemberDatabase()
        {
            members = new List<Member>();
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
