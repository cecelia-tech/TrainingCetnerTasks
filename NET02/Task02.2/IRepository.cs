using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02._2
{
    internal interface IRepository
    {
        void Write(List<User> users);
        void Read();
    }
}
