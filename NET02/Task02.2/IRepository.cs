namespace Task02._2
{
    internal interface IRepository
    {
        List<User> GetUsers (string pathToData);
        void SaveUsers(List<User> users);
    }
}
