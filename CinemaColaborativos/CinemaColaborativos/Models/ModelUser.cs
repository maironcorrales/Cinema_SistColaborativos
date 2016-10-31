using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaColaborativos.Models
{
    public class ModelUser
    {
        private int id;
        private string mail;
        private string birthday;
        private string phone;
        private int userType;
        private bool state;

        public ModelUser(int id, string mail, string birthday, string phone, int userType, bool state)
        {
            this.id = id;
            this.mail = mail;
            this.birthday = birthday;
            this.phone = phone;
            this.userType = userType;
            this.state = state;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Mail
        {
            get
            {
                return mail;
            }

            set
            {
                mail = value;
            }
        }

        public string Birthday
        {
            get
            {
                return birthday;
            }

            set
            {
                birthday = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public int UserType
        {
            get
            {
                return userType;
            }

            set
            {
                userType = value;
            }
        }

        public bool State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }
    }
}