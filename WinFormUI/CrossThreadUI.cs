using System.ComponentModel;
using WinFormModel;
using WinFormService;

namespace WinFormUI
{
    public partial class CrossThreadUI : Form
    {
        private readonly UserService? _userService;
        private BindingList<UserModel> _dataSource = new();

        public CrossThreadUI()
        {
            InitializeComponent();
        }

        [Microsoft.Extensions.DependencyInjection.ActivatorUtilitiesConstructor]
        public CrossThreadUI(UserService userService) : this()
        {
            _userService = userService;
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            if (_userService == null)
            {
                return;
            }

            await InitDataBindAsync();
        }

        private async Task InitDataBindAsync()
        {
            if (_userService == null)
            {
                return;
            }

            var users = await _userService.GetInitialUsersAsync();
            _dataSource = new BindingList<UserModel>(users);
            dataGridView1.DataSource = _dataSource;
        }

        private void buttonInvoke_Click(object sender, EventArgs e)
        {
            if (_userService == null)
            {
                MessageBox.Show("CrossThreadUI 未通过依赖注入创建，无法执行示例。");
                return;
            }

            buttonInvoke.Enabled = false;
            label1.Text = "Invoke示例：后台处理中...";

            Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(2000);
                    var newUser = await _userService.AddUserAsync("Invoke线程");

                    RunOnUiThread(() =>
                    {
                        _dataSource.Add(newUser);
                        label7.Text = "Invoke已更新";
                        label1.Text = "Invoke示例：UI已更新";
                        buttonInvoke.Enabled = true;
                    });
                }
                catch (Exception ex)
                {
                    RunOnUiThread(() =>
                    {
                        label1.Text = $"Invoke示例失败：{ex.Message}";
                        buttonInvoke.Enabled = true;
                    });
                }
            });
        }

        private async void buttonAsyncAwait_Click(object sender, EventArgs e)
        {
            if (_userService == null)
            {
                MessageBox.Show("CrossThreadUI 未通过依赖注入创建，无法执行示例。");
                return;
            }

            buttonAsyncAwait.Enabled = false;
            label1.Text = "async/await示例：后台处理中...";

            try
            {
                var newUser = await Task.Run(async () =>
                {
                    await Task.Delay(2000);
                    return await _userService.AddUserAsync("Await线程");
                });

                _dataSource.Add(newUser);
                label7.Text = "async/await已更新";
                label1.Text = "async/await示例：UI已更新";
            }
            catch (Exception ex)
            {
                label1.Text = $"async/await示例失败：{ex.Message}";
            }
            finally
            {
                buttonAsyncAwait.Enabled = true;
            }
        }

        private void RunOnUiThread(Action action)
        {
            if (IsDisposed || Disposing || !IsHandleCreated)
            {
                return;
            }

            if (InvokeRequired)
            {
                BeginInvoke(action);
                return;
            }

            action();
        }
    }
}
