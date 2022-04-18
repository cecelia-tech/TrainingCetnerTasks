using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02._2
{
    internal interface IRepository
    {
        List<User> GetUsers (string xmlPath);
    }
}
