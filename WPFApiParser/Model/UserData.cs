using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFApiParser.Model
{
    public class UserData
    {
        private int userid;
        public int UserId
        {
            get { return userid; }
            set { userid = value; }
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string body;
        public string Body
        {
            get { return body; }
            set { body = value; }
        }

    }
}
