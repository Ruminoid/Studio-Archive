using System;
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

        // MEF imports will be placed here.

        #endregion

        public static IContainer Compose()
        {
            // Create Builder

            ContainerBuilder builder = new ContainerBuilder();

            // Add MEF Catalogs

            builder.RegisterComposablePartCatalog(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            builder.RegisterComposablePartCatalog(new DirectoryCatalog("Extensions", "*.rmx"));

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
