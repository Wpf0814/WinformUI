using System.Collections.ObjectModel;
using System.ComponentModel;
using WinFormModel;
using WinFormService;

namespace WinFormUI
{
    public partial class DataGridView_ComboBox : Form
    {
        private readonly UserService? _userService;
        private BindingList<UserModel> _dataSource = new();
        private ObservableCollection<string> _enableType = new();
        private List<UserModel> _dataSource1 = new();

        public DataGridView_ComboBox()
        {
            InitializeComponent();
        }

        [Microsoft.Extensions.DependencyInjection.ActivatorUtilitiesConstructor]
        public DataGridView_ComboBox(UserService userService) : this()
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

            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            comboBox1.Items.Clear();
            _enableType = new()
            {
                "Enable_A661_TRUE",
                "Enable_A661_FALSE",
            };
            comboBox1.DataSource = _enableType;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
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

        private async Task InitDataAsync()
        {
            if (_userService == null)
            {
                return;
            }

            _dataSource1 = await _userService.GetInitialUsersAsync();

            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Add("colName", "Id");
            dataGridView1.Columns.Add("colAge", "姓名");
            dataGridView1.Columns.Add("colClass", "年龄");
            foreach (var item in _dataSource1)
            {
                dataGridView1.Rows.Add(item.Id, item.UserName, item.Age);
            }
        }

        private void comboBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            MessageBox.Show("You selected: " + comboBox1.SelectedItem?.ToString());
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (_userService == null)
            {
                MessageBox.Show("DataGridView_ComboBox 未通过依赖注入创建，无法新增数据。");
                return;
            }

            var newUser = await _userService.AddUserAsync("赵六");
            _dataSource.Add(newUser);
        }
    }
}
