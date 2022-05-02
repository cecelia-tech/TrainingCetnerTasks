namespace Task02._2
{
    [Serializable]
    public class WindowSettings
    {
        public WindowSettings()
        {
        }

        public WindowSettings(string name, int? top, int? left, int? width, int? height)
        {
            Title = name ?? throw new ArgumentNullException(nameof(name));

            if (top < 0 || left < 0 || width < 0 || height < 0)
            {
                throw new ArgumentException("Window settings can't be negative");
            }

            Top = top;
            Left = left;
            Width = width;
            Height = height;
        }

        public string Title { get; set; }
        public int? Top { get; set; }
        public int? Left { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }

        public WindowSettings GetCorrectedWindowSettings()
        {
            return new WindowSettings(Title, Top ?? 0, Left ?? 0, Width ?? 400, Height ?? 150);
        }

    }
}
