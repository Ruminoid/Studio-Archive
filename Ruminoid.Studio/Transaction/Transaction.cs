using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.ViewModels;

namespace Ruminoid.Studio.Transaction
{
    public class Transaction : MvxNotifyPropertyChanged, IAction
    {
        #region Display

        public string Name { get; set; } = "（未知操作）";

        public string Icon { get; set; } = "DocumentUnknown";

        #endregion

        #region IAction

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void UnExecute()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
