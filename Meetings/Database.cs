﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Meetings
{
    class Database
    {
        private string Name;
        public Database(string Name)
        {
            this.Name = Name;
        }

        public void SetName(String value)
        {
            this.Name = value;
            MessageBox.Show(value);
        }
        public string GetName()
        {
            return this.Name;
        }
    }
}
