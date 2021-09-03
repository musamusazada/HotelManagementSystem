using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ManSys.Moduls
{
    class ADMIN
    {
        //Personal Information
        public string FullName;
        public byte age;
        public int phoneNumber;

        //Access
        private string secureID;
        private string username;
        private string pwd;
        private string security_question;
        private string security_answer;

        public ADMIN(string userName , string PWD, byte Age, string Security_Question, string Security_Answer)
        {
            this.username = userName;
            this.pwd = PWD;
            this.age = Age;
            this.secureID = ID_Generator(userName, Age,Security_Answer);
            this.security_question = Security_Question;
            this.security_answer = Security_Answer;
        }

        //Generating Unique Secure ID;
        private string ID_Generator(string usrname, byte age,string answer)
        {
            Random r = new Random();
            byte randNum = (byte)(r.Next(1, 100));

            return $"{usrname.Substring(0, 2)}{randNum * age}{answer.Length}";
        }


        //GETTERS FOR PRIVATE FIELDS
        public string SECUREID { get => this.secureID; }
        public string USERNAME { get => this.username; }
        public string PWD { get => this.pwd; }
        public string SECURITY_QUESTION { get => this.security_question; }
        public string SECURITY_ANSWER { get => this.security_answer; }

    }
}
