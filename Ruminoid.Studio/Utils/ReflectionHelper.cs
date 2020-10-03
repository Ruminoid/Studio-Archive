namespace Ruminoid.Studio.Utils
{
    public static class ReflectionHelper
    {
        public static string GetAssemblyName(object context) =>
            context.GetType().Assembly.GetName().Name;

        public static string GetFullName(object context) =>
            $"{GetAssemblyName(context)}.{context.GetType()}";
    }
}
