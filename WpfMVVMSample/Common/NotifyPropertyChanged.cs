/*
 * NotificationObject.cs
 *
 * Copyright (c) 2021 IT SUPPORT SAKURA Co., Ltd.
 *
 * Released under the MIT license.
 * see https://opensource.org/licenses/MIT
 *
 * This source code is based on NotificationObject.cs :
 * MIT license | https://github.com/YKSoftware/YKToolkit.Controls/blob/master/LICENSE
 * 
 */

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfMVVMSample.Common
{
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var e = this.PropertyChanged;
            if (e != null) { e(this, new PropertyChangedEventArgs(propertyName)); }
        }

        protected bool SetProperty<T>(ref T v, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(v, value)) { return false; }
            v = value;
            RaisePropertyChanged(propertyName);

            return true;
        }
    }
}
