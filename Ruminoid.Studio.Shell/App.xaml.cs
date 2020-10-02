using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Ruminoid.Studio.Shell.Helpers;

namespace Ruminoid.Studio.Shell
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e) => LifecycleHelper.StartUp(e.Args);
    }
}
