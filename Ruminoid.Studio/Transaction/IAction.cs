using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruminoid.Studio.Transaction
{
    public interface IAction
    {
        void Execute();

        void UnExecute();
    }
}
