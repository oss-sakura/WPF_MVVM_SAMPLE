/*
 * OpenFileDialog.cs
 *
 * Copyright (c) 2021 IT SUPPORT SAKURA Co., Ltd.
 *
 * Released under the MIT license.
 * see https://opensource.org/licenses/MIT
 *
 */

namespace WpfMVVMSample.Common
{
    public class OpenFileDialog
    {
        private Microsoft.Win32.OpenFileDialog _dialog;
        private string _fileName = string.Empty;
        private string _filter = string.Empty;

        public OpenFileDialog()
        {
            if (this._dialog == null)
            {
                this._dialog = new Microsoft.Win32.OpenFileDialog();
            }
            ShowDialog();
        }

        public string FileName
        {
            get { return _fileName; }
            set { this._fileName = value; }
        }

        public string Filter
        {
            get { return this._filter; }
            set { this._filter = value; }
        }

        public bool ShowDialog()
        {
            if (this._dialog.ShowDialog() == true)
            {
                FileName = this._dialog.FileName;
                return true;
            }
            return false;
        }

    }
}
