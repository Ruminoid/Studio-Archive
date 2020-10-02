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
            StringBuilder stringBuilder = new StringBuilder("错误详细信息：");

            foreach (Error error in obj)
            {
                stringBuilder.Append(error.Tag);
                stringBuilder.Append(" | ");
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

    }
}
