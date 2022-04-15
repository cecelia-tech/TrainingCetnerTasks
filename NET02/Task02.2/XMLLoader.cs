using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02._2
{
    internal class XMLLoader : IRepository
    {

        public List<User> GetUsersFromXML(string xmlDocument)
        {
            //read and parse xml, but the task is to return the list of users
            List<User> users = new List<User>();
            //after parse xmland add user to the list
            //create user like List<WindowSettings>
            return List<User>
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Write()
        {
            throw new NotImplementedException();
        }
    }
}
