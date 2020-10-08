using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruminoid.Studio.Transaction
{
    public interface IAction
    {
        #region Display

        string Name { get; set; }

        string Icon { get; set; }

        #endregion
        
        #region Operations

        void Execute();

        void UnExecute();

        #endregion
    }

    public abstract class ActionBase : IAction
    {
        public string Name { get; set; } = "（未知操作）";

        public string Icon { get; set; } = "DocumentUnknown";

        public virtual void Execute()
        {
            throw new NotImplementedException();
        }

        public virtual void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
