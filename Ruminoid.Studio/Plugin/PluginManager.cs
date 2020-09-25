using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruminoid.Studio.Plugin
{
    public sealed class PluginManager
    {
        #region Current

        public static PluginManager Current { get; } = new PluginManager();

        #endregion

        #region Constructor

        private PluginManager()
        {

        }

        #endregion
    }
}
