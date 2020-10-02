using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Integration.Mef;
using Ookii.Dialogs.Wpf;

namespace Ruminoid.Studio.Plugin
{
    [Export]
    public class PluginManager
    {
        #region Imports

        [ImportMany]
        public IEnumerable<ITransform> Transforms;

        [ImportMany]
        public IEnumerable<ITarget> Targets;

        [ImportMany]
        public IEnumerable<IInterfacePlugin> InterfacePlugins;

        #endregion

        public static IContainer Compose()
        {
            // Create Builder

            ContainerBuilder builder = new ContainerBuilder();

            // Add MEF Catalogs

            builder.RegisterComposablePartCatalog(new DirectoryCatalog("Extensions", "*.rmx"));

            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                builder.RegisterComposablePartCatalog(new AssemblyCatalog(assembly));

            return builder.Build();
        }
    }
}
