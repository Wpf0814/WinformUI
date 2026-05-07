using Microsoft.Extensions.DependencyInjection;
using WinFormModel;
using WinFormService;

namespace WinFormUI
{
    public partial class ParentForm : Form
    {
        private readonly ChildMessageService? _childMessageService;
        private readonly IServiceProvider? _serviceProvider;
        private ChildrenForm? _childrenForm;
        private readonly string _id = "1";
        private readonly string _address = "中国";
        private readonly string _age = "100";

        public ParentForm()
        {
            InitializeComponent();
        }

        [ActivatorUtilitiesConstructor]
        public ParentForm(ChildMessageService childMessageService,
            IServiceProvider serviceProvider) : this()
        {
            _childMessageService = childMessageService;
            _serviceProvider = serviceProvider;
        }

        private void buttonOpenChild_Click(object sender, EventArgs e)
        {
            if (_childMessageService == null || _serviceProvider == null)
            {
                MessageBox.Show("ParentForm 未通过依赖注入创建，无法打开子窗体。");
                return;
            }

            if (_childrenForm == null || _childrenForm.IsDisposed)
            {
                var message = _childMessageService.BuildMessage(_address, _age, _id);
                _childrenForm = ActivatorUtilities.CreateInstance<ChildrenForm>(_serviceProvider);
                _childrenForm.UpdateFromParent(message);
                _childrenForm.ChildMessageChanged += ChildrenForm_ChildMessageChanged;
                _childrenForm.FormClosed += ChildrenForm_FormClosed;
            }

            _childrenForm.Show();
            _childrenForm.Activate();
        }

        private void ChildrenForm_ChildMessageChanged(object? sender, ChildMessageEventArgs e)
        {
            labelChildMessage.Text = $"子窗体回传：Address={e.Address}, Age={e.Age}, Id={e.Id}";
        }

        private void ChildrenForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (_childrenForm == null)
            {
                return;
            }

            _childrenForm.ChildMessageChanged -= ChildrenForm_ChildMessageChanged;
            _childrenForm.FormClosed -= ChildrenForm_FormClosed;
            _childrenForm = null;
        }

        private void buttonSendToChild_Click(object sender, EventArgs e)
        {
            if (_childMessageService == null)
            {
                MessageBox.Show("ParentForm 未通过依赖注入创建，无法向子窗体传值。");
                return;
            }

            if (_childrenForm == null || _childrenForm.IsDisposed)
            {
                buttonOpenChild_Click(sender, e);
            }

            var message = _childMessageService.BuildMessage("安徽", "100", "3");
            _childrenForm?.UpdateFromParent(message);
        }
    }
}
