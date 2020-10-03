using System;
using System.ComponentModel.Composition;

namespace Ruminoid.Studio.Utils
{
    [Export]
    public sealed class LogHelper : IDisposable
    {
        public void Dispose()
        {
        }
    }
}
