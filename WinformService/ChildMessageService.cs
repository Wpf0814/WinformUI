using WinFormModel;

namespace WinFormService
{
    public class ChildMessageService
    {
        public ChildMessageModel BuildMessage(string address, string age, string id)
        {
            return new ChildMessageModel
            {
                Address = address,
                Age = age,
                Id = id
            };
        }

        public ChildMessageEventArgs BuildEventArgs(ChildMessageModel message)
        {
            return new ChildMessageEventArgs(message.Address, message.Age, message.Id);
        }
    }
}
