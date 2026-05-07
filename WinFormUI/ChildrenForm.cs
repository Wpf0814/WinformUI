using WinFormModel;
using WinFormService;
using Microsoft.Extensions.DependencyInjection;

namespace WinFormUI
{
    public partial class ChildrenForm : Form
    {
        private readonly ChildMessageService? _childMessageService;
        private ChildMessageModel _currentMessage = new()
        {
            Address = "上海",
            Age = "100",
            Id = "2"
        };

        public event EventHandler<ChildMessageEventArgs>? ChildMessageChanged;

        public ChildrenForm()
        {
            InitializeComponent();
        }

        [ActivatorUtilitiesConstructor]
        public ChildrenForm(ChildMessageService childMessageService) : this()
        {
            _childMessageService = childMessageService;
        }

        public void UpdateFromParent(ChildMessageModel message)
        {
            _currentMessage = message;
            GetParentInfo.Text = $"父窗体传值：Address={message.Address}, Age={message.Age}, Id={message.Id}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_childMessageService == null)
            {
                MessageBox.Show("ChildrenForm 未通过依赖注入创建，无法回传数据。");
                return;
            }

            ChildMessageChanged?.Invoke(this, _childMessageService.BuildEventArgs(_currentMessage));
        }
    }
}
