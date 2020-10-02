using YDock.Interface;

namespace Ruminoid.Studio.Plugin
{
    public interface IInterfaceDock : IDockSource
    {
        bool IsDock { get; }
    }
}
