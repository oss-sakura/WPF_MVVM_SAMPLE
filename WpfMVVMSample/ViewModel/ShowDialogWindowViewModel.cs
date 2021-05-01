using System.Windows;

namespace WpfMVVMSample.ViewModel
{
    public class ShowDialogWindowViewModel : Common.NotifyPropertyChanged
    {
        private Common.Command _okButtonCommand;
        private Common.Command _cancelButtonCommand;

        public Common.Command OkButtonCommand
        {
            get
            {
                if (this._okButtonCommand == null)
                {
                    this._okButtonCommand = new Common.Command(p => { this.OkCommand(p); });
                }
                return this._okButtonCommand;
            }
        }

        public Common.Command CancelButtonCommand
        {
            get
            {
                if (this._cancelButtonCommand == null)
                {
                    this._cancelButtonCommand = new Common.Command(_ => { this.CancelCommand(); });
                }
                return this._cancelButtonCommand;
            }
        }

        private void CancelCommand()
        {
            // Do nothing.
        }

        private void OkCommand(object param)
        {
            if (param != null)
            {
                ((Window)param).DialogResult = true;
                ((Window)param).Close();
            }
        }

    }
}
