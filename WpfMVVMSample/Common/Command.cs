/*
 * Command.cs
 *
 * Copyright (c) 2021 IT SUPPORT SAKURA Co., Ltd.
 *
 * Released under the MIT license.
 * see https://opensource.org/licenses/MIT
 *
 */

using System;
using System.Windows.Input;

namespace WpfMVVMSample.Common
{
    public class Command : ICommand
    {

        public Command(Action<object> execute) : this(execute, null) { }
        public Command(Action<object> execute, Func<object, bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        private Func<object, bool> _canExecute;
        private Action<object> _execute;

        #region ICommand Implements
        public bool CanExecute(object parameter)
        {
            if (this._canExecute != null)
                return this._canExecute(parameter);
            return true;
        }

        public void Execute(object parameter)
        {
            if (this._execute != null) { this._execute(parameter); }
        }

        public event EventHandler CanExecuteChanged;
        #endregion

        public void RaiseCanExecuteChange()
        {
            EventHandler evth = this.CanExecuteChanged;
            if (evth != null) { evth(this, EventArgs.Empty); }
        }

    }
}
