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
        private string _secureID;
        private string _username;
        private string _pwd;
        private string _security_question;
        private string _security_answer;

        //Constructor
        public ADMIN(string userName , string PWD, byte Age, string Security_Question, string Security_Answer)
        {
            this._username = userName;
            this._pwd = PWD;
            this.age = Age;
            this._secureID = ID_Generator(userName, Age,Security_Answer);
            this._security_question = Security_Question;
            this._security_answer = Security_Answer;
        }

        //Generating Unique Secure ID;
        private string ID_Generator(string usrname, byte age,string answer)
        {
            Random r = new Random();
            byte randNum = (byte)(r.Next(1, 100));

            return $"{usrname.Substring(0, 2)}{randNum * age}{answer.Length}";
        }


        //GETTERS FOR PRIVATE FIELDS
        public string SECUREID { get => this._secureID; }
        public string USERNAME { get => this._username; }
        public string PWD { get => this._pwd; }
        public string SECURITY_QUESTION { get => this._security_question; }
        public string SECURITY_ANSWER { get => this._security_answer; }

    }
}
