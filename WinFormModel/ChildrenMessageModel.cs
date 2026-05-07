namespace WinFormModel
{
    public class ChildMessageModel
    {
        public string Address { get; set; } = string.Empty;

        public string Age { get; set; } = string.Empty;

        public string Id { get; set; } = string.Empty;
    }

    public class ChildMessageEventArgs : EventArgs
    {
        public string Address { get; }

        public string Age { get; }

        public string Id { get; }

        public ChildMessageEventArgs(string address, string age, string id)
        {
            Address = address;
            Age = age;
            Id = id;
        }
    }
}
