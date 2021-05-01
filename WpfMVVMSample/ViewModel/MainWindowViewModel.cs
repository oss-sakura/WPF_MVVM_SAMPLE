/*
 * MainWindowViewModel.cs
 *
 * Copyright (c) 2021 IT SUPPORT SAKURA Co., Ltd.
 *
 * Released under the MIT license.
 * see https://opensource.org/licenses/MIT
 *
 */

using System.Windows;

namespace WpfMVVMSample.ViewModel
{
    public class MainWindowViewModel : Common.NotifyPropertyChanged
    {
        private Common.Command _uppperButtonCommand;
        private Common.Command _lowerButtonCommand;
        private Common.Command _shutdownButtonCommand;
        private Common.Command _showMsgBoxButtonCommand1;
        private Common.Command _showMsgBoxButtonCommand2;

        private Common.Command _openFileDialogCommand;

        private string _upperText = string.Empty;
        private string _lowerText = string.Empty;

        private string _txtBoxText = string.Empty;
        private string _txtblkText = string.Empty;

        private string _msgText1 = string.Empty;
        private string _msgText2 = string.Empty;

        private string _isEnableShowMsgButtonCommand1 = "False";

        private Model.UpperLower _upperLowerModel;

        public MainWindowViewModel()
        {
            this._upperLowerModel = new Model.UpperLower();
            OpenWindowCommand = new Common.OpenWindowCommand();
            ShowDialogCommand = new Common.ShowDialogCommand(PostOpenDialog, PreOpenDialog);
        }

        public Common.OpenWindowCommand OpenWindowCommand { get; set; }
        public Common.ShowDialogCommand ShowDialogCommand { get; set; }

        public Common.Command UpperButtonCommand
        {
            get
            {
                if (this._uppperButtonCommand == null)
                {
                    this._uppperButtonCommand = new Common.Command(_ => { this.ToUpper(); });
                }
                return this._uppperButtonCommand;
            }
        }

        public Common.Command LowerButtonCommand
        {
            get
            {
                if (this._lowerButtonCommand == null)
                {
                    this._lowerButtonCommand = new Common.Command(_ => { this.ToLower(); });
                }
                return this._lowerButtonCommand;
            }
        }

        public Common.Command ShowMsgButtonCommand1
        {
            get
            {
                if (this._showMsgBoxButtonCommand1 == null)
                {
                    this._showMsgBoxButtonCommand1 = new Common.Command(_ => { MessageBox.Show(MsgText1); });
                }
                return this._showMsgBoxButtonCommand1;
            }
        }

        public Common.Command ShowMsgButtonCommand2
        {
            get
            {
                if (this._showMsgBoxButtonCommand2 == null)
                {
                    this._showMsgBoxButtonCommand2 = new Common.Command(
                        _ => { MessageBox.Show(MsgText2); }
                        ,
                        _ => { return CanExecuteShowMsgButtonCommand2(); });
                }
                return this._showMsgBoxButtonCommand2;
            }
        }

        private bool CanExecuteShowMsgButtonCommand2()
        {
            if (string.IsNullOrEmpty(MsgText2)) { return false; }
            return true;
        }

        public string IsEnableShowMsgButtonCommand1
        {
            get { return this._isEnableShowMsgButtonCommand1; }
            set
            {
                SetProperty(ref this._isEnableShowMsgButtonCommand1, value);
            }
        }

        public string TxtBoxText
        {
            get { return this._txtBoxText; }
            set
            {
                if (SetProperty(ref this._txtBoxText, value))
                {
                    TxtBlkText = value.ToUpper();
                }

            }
        }

        public string TxtBlkText
        {
            get { return this._txtblkText; }
            set
            {
                SetProperty(ref this._txtblkText, value);
            }
        }

        public string MsgText1
        {
            get { return this._msgText1; }
            set
            {
                SetProperty(ref this._msgText1, value);
                if (string.IsNullOrEmpty(MsgText1))
                {
                    IsEnableShowMsgButtonCommand1 = "False";
                }
                else
                {
                    IsEnableShowMsgButtonCommand1 = "True";
                }
            }
        }

        public string MsgText2
        {
            get { return this._msgText2; }
            set
            {
                if (SetProperty(ref this._msgText2, value))
                {
                    ShowMsgButtonCommand2.RaiseCanExecuteChange();
                }
            }
        }

        public Common.Command Shutdown
        {
            get
            {
                if (this._shutdownButtonCommand == null)
                {
                    this._shutdownButtonCommand = new Common.Command(_ => { Application.Current.Shutdown(); });
                }
                return this._shutdownButtonCommand;
            }
        }

        public string UpperText
        {
            get
            {
                return this._upperText;
            }
            set
            {
                SetProperty(ref this._upperText, value);
            }
        }

        public string LowerText
        {
            get
            {
                return this._lowerText;
            }
            set
            {
                SetProperty(ref this._lowerText, value);
            }
        }

        private void ToUpper()
        {
            UpperText = this._upperLowerModel.Upper(UpperText);
        }

        private void ToLower()
        {
            LowerText = this._upperLowerModel.Lower(LowerText);
        }



        public void PreOpenDialog()
        {
            //Console.WriteLine("The dialog is about to be opened");
        }

        public void PostOpenDialog(bool? dialogResult)
        {
            //Console.WriteLine(string.Format("The dialog has been closed and the result was {0}", dialogResult));
        }

        public Common.Command OpenFileDialogCommand
        {
            get
            {
                if (this._openFileDialogCommand == null)
                {
                    this._openFileDialogCommand = new Common.Command(_ => { new Common.OpenFileDialog(); });
                }
                return this._openFileDialogCommand;
            }
        }

    }
}
