namespace Task02._2
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }
        public List<WindowSettings> WindowSettings { get; set; } = new List<WindowSettings>();
        public User()
        {
        }

        public User(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void AddWindowSettings(WindowSettings windowSetting)
        {
            WindowSettings.Add(windowSetting ?? throw new ArgumentNullException(nameof(windowSetting)));
        }
    }
}
