using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using Autofac;
using CommandLine;
using MetroRadiance.UI;
using Ookii.Dialogs.Wpf;
using Ruminoid.Studio.Plugin;
using Ruminoid.Studio.Project;
using Ruminoid.Studio.Shell.Properties;
using Ruminoid.Studio.Shell.Windows;
using Ruminoid.Studio.Utils;
using Serilog.Events;

namespace Ruminoid.Studio.Shell.Helpers
{
    public static class LifecycleHelper
    {
        public static void StartUp(string[] args)
        {
            Parser.Default.ParseArguments<CommandLineOptions>(args)
                .WithParsed(RunOptions)
                .WithNotParsed(HandleParseError);
        }

        private static void RunOptions(CommandLineOptions options)
        {
            // Build Container

            IContainer container = PluginManager.Compose();

            // Initialize Context Logger

            LogHelper logHelper = container.Resolve<LogHelper>();
            ContextLogger logger = logHelper.CreateContextLogger(Application.Current);

            // Test Logging

            string appVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            logger.Log(LogEventLevel.Information, "Ruminoid Studio - 版本{AppVersion}", appVersion);

            // Add Event Handler

            Application.Current.DispatcherUnhandledException += (sender, args) =>
            {
                args.Handled = true;

                logger.LogException(LogEventLevel.Error, "发生了一个故障。", args.Exception);

                new TaskDialog
                {
                    EnableHyperlinks = false,
                    MainInstruction = "发生了一个故障。",
                    WindowTitle = "灾难性故障",
                    Content = args.Exception.Message,
                    MainIcon = TaskDialogIcon.Error,
                    MinimizeBox = false,
                    Buttons =
                    {
                        new TaskDialogButton(ButtonType.Ok)
                    }
                }.ShowDialog();
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                if (!(args.ExceptionObject is Exception)) return;

                logger.LogException(LogEventLevel.Fatal, "发生了一个故障。", (Exception)args.ExceptionObject);

                new TaskDialog
                {
                    EnableHyperlinks = false,
                    MainInstruction = "发生了一个故障。",
                    WindowTitle = "灾难性故障",
                    Content = ((Exception)args.ExceptionObject).Message ?? "Exception",
                    MainIcon = TaskDialogIcon.Error,
                    MinimizeBox = false,
                    Buttons =
                    {
                        new TaskDialogButton(ButtonType.Ok)
                    }
                }.ShowDialog();
            };

            // Load Project

            logger.Log(LogEventLevel.Warning, "Lifecycle Helper: 开始加载项目。");

            ProjectManager projectManager = container.Resolve<ProjectManager>();
            projectManager.Load(options.ProjectFile);

            // Change Default Culture

            Resources.Culture = CultureInfo.CurrentUICulture;

            // Register Theme Service

            ThemeService.Current.Register(Application.Current, Theme.Windows, Accent.Windows);

            // Initialize Main Window

            Application.Current.MainWindow = new MainWindow();
            Application.Current.MainWindow.Show();

            // Change Default Theme

            Application.Current.Dispatcher?.Invoke(() => ThemeService.Current.ChangeTheme(Theme.Dark));
            Application.Current.Dispatcher?.Invoke(() => ThemeService.Current.ChangeAccent(Accent.Blue));
        }

        private static void HandleParseError(IEnumerable<Error> obj)
        {
            if (obj.Count() == 1 && obj.FirstOrDefault().Tag == ErrorType.MissingRequiredOptionError)
            {
                new TaskDialog
                {
                    EnableHyperlinks = false,
                    MainInstruction = "项目文件位置缺失。",
                    WindowTitle = "错误",
                    Content = "需要提供项目文件的位置，程序才能启动。\n请尝试在启动参数中加入项目文件的位置。",
                    MainIcon = TaskDialogIcon.Error,
                    MinimizeBox = false,
                    Buttons =
                    {
                        new TaskDialogButton(ButtonType.Ok)
                    }
                }.ShowDialog();

                Environment.Exit(1);
            }

            StringBuilder stringBuilder = new StringBuilder("错误详细信息：");

            bool first = true;

            foreach (Error error in obj)
            {
                if (first) first = false;
                else stringBuilder.Append(" | ");
                stringBuilder.Append(error.Tag);
            }

            new TaskDialog
            {
                EnableHyperlinks = false,
                MainInstruction = "未能解析的命令行参数。请考虑检查调用方。",
                WindowTitle = "错误",
                Content = stringBuilder.ToString(),
                MainIcon = TaskDialogIcon.Error,
                MinimizeBox = false,
                Buttons =
                {
                    new TaskDialogButton(ButtonType.Ok)
                }
            }.ShowDialog();

            Environment.Exit(1);
        }

        public static void CleanUp()
        {

        }
    }

    public sealed class CommandLineOptions
    {
        [Value(0, Required = true, HelpText = "要打开的项目文件。")]
        public string ProjectFile { get; set; }
    }
}
