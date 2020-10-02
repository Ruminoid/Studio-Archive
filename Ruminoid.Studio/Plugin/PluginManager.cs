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
            builder.RegisterComposablePartCatalog(new AssemblyCatalog(Assembly.GetExecutingAssembly()));

            // Add Global Instances

            foreach (Type type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(ass => ass.GetTypes())
                .Where(type => Attribute.GetCustomAttribute(type, typeof(RuminoidGlobalInstanceAttribute)) != null))
                builder.RegisterType(type).SingleInstance().Exported(x => x.As(type));

            return builder.Build();
        }
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class RuminoidGlobalInstanceAttribute : Attribute
    {
    }
}
