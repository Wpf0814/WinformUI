using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WinFormData;
using WinFormService;

namespace WinFormUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();

            using var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((_, configuration) =>
                {
                    configuration.SetBasePath(AppContext.BaseDirectory);
                    configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    ConfigureDatabase(context.Configuration, services);

                    services.AddScoped<IUserRepository, UserRepository>();
                    services.AddScoped<UserService>();
                    services.AddScoped<ChildMessageService>();

                    services.AddTransient<ParentForm>();
                    services.AddTransient<ChildrenForm>();
                    services.AddTransient<CrossThreadUI>();
                    services.AddTransient<DataGridView_ComboBox>();
                })
                .Build();

            InitializeDatabase(host.Services);
            Application.Run(host.Services.GetRequiredService<DataGridView_ComboBox>());
        }

        private static void ConfigureDatabase(IConfiguration configuration, IServiceCollection services)
        {
            var provider = configuration.GetValue<string>("Database:Provider");

            services.AddDbContextFactory<AppDbContext>(options =>
            {
                if (string.Equals(provider, "SqlServer", StringComparison.OrdinalIgnoreCase))
                {
                    options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
                    return;
                }

                if (string.Equals(provider, "Sqlite", StringComparison.OrdinalIgnoreCase))
                {
                    var connectionString = configuration.GetConnectionString("Sqlite");
                    EnsureSqliteDirectoryExists(connectionString);
                    options.UseSqlite(connectionString);
                    return;
                }

                throw new InvalidOperationException($"Unsupported database provider: {provider}");
            });
        }

        private static void EnsureSqliteDirectoryExists(string? connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                return;
            }

            var builder = new Microsoft.Data.Sqlite.SqliteConnectionStringBuilder(connectionString);
            if (string.IsNullOrWhiteSpace(builder.DataSource) || builder.DataSource == ":memory:")
            {
                return;
            }

            var dataSourcePath = Path.IsPathRooted(builder.DataSource)
                ? builder.DataSource
                : Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, builder.DataSource));
            var directory = Path.GetDirectoryName(dataSourcePath);

            if (!string.IsNullOrWhiteSpace(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private static void InitializeDatabase(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
            using var dbContext = dbContextFactory.CreateDbContext();
            dbContext.Database.EnsureCreated();
        }
    }
}
