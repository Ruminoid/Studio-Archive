using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
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

        #region Container

        private CompositionContainer _container;

        #endregion

        #region Constructor

        private PluginManager()
        {
            DirectoryCatalog catalog = new DirectoryCatalog("Extensions", "*.rmx");
            _container = new CompositionContainer(catalog);

            try
            {
                _container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                // Ignore
            }
        }

        #endregion
    }
}
