using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using Ookii.Dialogs.Wpf;

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

        private static void RunOptions(CommandLineOptions obj)
        {
            
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
