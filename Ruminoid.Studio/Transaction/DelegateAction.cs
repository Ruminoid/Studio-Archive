﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruminoid.Studio.Transaction
{
    public class DelegateAction : ActionBase
    {
        #region Constructor

        public DelegateAction(
            Action execute,
            Action unExecute,
            string name = "",
            string icon = "")
        {
            _execute = execute;
            _unExecute = unExecute;
            if (!string.IsNullOrEmpty(name)) Name = name;
            if (!string.IsNullOrEmpty(icon)) Icon = icon;
        }

        #endregion

        #region Data

        private Action _execute;

        private Action _unExecute;

        #endregion

        #region Override

        public new string Name { get; } = "（未知操作）";

        public new string Icon { get; } = "DocumentUnknown";

        #endregion

        #region Operations

        public override void Execute()
        {
            if (_execute is null)
                throw new ArgumentNullException(nameof(_execute));
            _execute();
        }

        public override void UnExecute()
        {
            if (_unExecute is null)
                throw new ArgumentNullException(nameof(_unExecute));
            _unExecute();
        }

        #endregion
    }

    public class DelegateAction<T> : ActionBase
    {
        #region Constructor

        public DelegateAction(
            Action<T> execute,
            Action<T> unExecute,
            T state,
            string name = "",
            string icon = "")
        {
            _execute = execute;
            _unExecute = unExecute;
            _state = state;
            if (!string.IsNullOrEmpty(name)) Name = name;
            if (!string.IsNullOrEmpty(icon)) Icon = icon;
        }

        #endregion

        #region Data

        private Action<T> _execute;

        private Action<T> _unExecute;

        private T _state;

        #endregion

        #region Override

        public new string Name { get; } = "（未知操作）";

        public new string Icon { get; } = "DocumentUnknown";

        #endregion

        #region Operations

        public override void Execute()
        {
            if (_execute is null)
                throw new ArgumentNullException(nameof(_execute));
            _execute(_state);
        }

        public override void UnExecute()
        {
            if (_unExecute is null)
                throw new ArgumentNullException(nameof(_unExecute));
            _unExecute(_state);
        }

        #endregion
    }
}
