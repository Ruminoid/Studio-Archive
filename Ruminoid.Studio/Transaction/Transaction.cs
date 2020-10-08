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
