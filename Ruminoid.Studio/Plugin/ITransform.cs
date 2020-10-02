using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ruminoid.Studio.Project;

namespace Ruminoid.Studio.Plugin
{
    public interface ITransform : INamed
    {
        string Convert(RumiItem item);
    }
}
