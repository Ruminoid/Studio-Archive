using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using Autofac;
using Autofac.Core;
using Ookii.Dialogs.Wpf;

namespace Ruminoid.Studio.Plugin
{
    public static class PluginManager
    {
        public static IContainer Compose() => new Composer().Compose();
    }

    internal class Composer
    {
        #region Imports

        // MEF imports will be placed here.

        #endregion

        public IContainer Compose()
        {
            // Create MEF CompositionContainer

            DirectoryCatalog catalog = new DirectoryCatalog("Extensions", "*.rmx");
            CompositionContainer mefContainer = new CompositionContainer(catalog);

            try
            {
                mefContainer.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                new TaskDialog
                {
                    EnableHyperlinks = false,
                    MainInstruction = "加载插件时发生了错误。",
                    WindowTitle = "错误",
                    Content = compositionException.Message,
                    MainIcon = TaskDialogIcon.Error,
                    MinimizeBox = false,
                    Buttons =
                    {
                        new TaskDialogButton(ButtonType.Ok)
                    }
                }.ShowDialog();

                Environment.Exit(1);
            }

            // Create Autofac ContainerBuilder

            ContainerBuilder builder = new ContainerBuilder();

            // Add Plugins

            // Add Global Instances

            foreach (Type type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(ass => ass.GetTypes())
                .Where(type => Attribute.GetCustomAttribute(type, typeof(RuminoidGlobalInstanceAttribute)) != null))
                builder.RegisterType(type).SingleInstance();

            return builder.Build();
        }
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class RuminoidGlobalInstanceAttribute : Attribute
    {
    }
}
