using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ruminoid.Studio.Plugin
{
    public interface IInterfacePlugin : INamed
    {
        Collection<IInterfaceDock> Panels { get; }

        Collection<RoutedUICommand> Commands { get; }
    }
}
