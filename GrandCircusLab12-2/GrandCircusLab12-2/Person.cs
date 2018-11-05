using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandCircusLab12_2
{
    class Person
    {

        public Person()
        {
        }

        public string Name { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return string.Format("{0,-10}", "Name: ") + Name + "\n" + string.Format("{0,-10}", "Address: ") + Address;
        }

        public void EditName(string name) { Name = name; }

        public void EditAddress(string address) { Address = address; }

    }
}
