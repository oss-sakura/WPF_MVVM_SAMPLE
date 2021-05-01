/*
 * OpenWindowCommand.cs
 *
 * Copyright (c) 2021 IT SUPPORT SAKURA Co., Ltd.
 *
 * Released under the MIT license.
 * see https://opensource.org/licenses/MIT
 *
 * This source code is based on OpenWindowCommand.cs :
 * MIT license | https://github.com/mike-eason/MVVM_WindowCommands/blob/master/LICENSE
 * 
 */

using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace WpfMVVMSample.Common
{
    public class OpenWindowCommand : ICommand
    {
        #region ICommand Implements
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            TypeInfo p = (TypeInfo)parameter;

            return p.BaseType == typeof(Window);
        }

        public void Execute(object parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException("TargetWindowType");

            //Get the type
            TypeInfo p = (TypeInfo)parameter;

            //Make sure the parameter passed in is a window.
            if (p.BaseType != typeof(Window))
                throw new InvalidOperationException("parameter is not a window type");

            //Create the window
            Window wnd = Activator.CreateInstance(p) as Window;

            OpenWindow(wnd);
        }
        #endregion

        protected void OpenWindow(Window wnd)
        {
            wnd.Show();
        }
    }
}
