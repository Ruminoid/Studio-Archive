using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

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
            
        }

        public static void CleanUp()
        {

        }
    }

    public sealed class CommandLineOptions
    {

    }
}
