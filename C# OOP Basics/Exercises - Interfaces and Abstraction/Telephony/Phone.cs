using System;
using System.Collections.Generic;
using System.Text;

namespace TelephonyProj
{
    class Phone : ICallable
    {
        private string numberId;

        public Phone(string number)
        {
            this.NumberId = number;
        }

        public string NumberId {
            get
            {
                return numberId;
            }
            set
            {
                numberId = value;
            }
        }

        private bool IsValid()
        {
            string phoneNumber = this.NumberId;
            foreach (var item in phoneNumber)
            {
                if (!char.IsDigit(item))
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            if (IsValid())
            {
                return "Invalid number!";
            }
            else
            {
                return $"Calling... {NumberId}";
            }
        }
    }
}