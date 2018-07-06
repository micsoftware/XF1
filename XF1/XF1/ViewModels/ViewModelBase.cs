using System;
using System.Windows.Input;
using ReactiveUI;

namespace XF1.ViewModels
{
    public abstract class ViewModelBase : ReactiveObject
    {
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                this.RaisePropertyChanging(nameof(IsBusy));
                isBusy = value;
                this.RaisePropertyChanged(nameof(IsBusy));
            }
        }

        bool isLoading = false;
        public bool IsLoading
        {
            get { return isLoading; }
            set
            {
                this.RaisePropertyChanging(nameof(IsLoading));
                isLoading = value;
                this.RaisePropertyChanged(nameof(IsLoading));
            }
        }

        bool isEnabled = true;
        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                this.RaisePropertyChanging(nameof(IsEnabled));
                isEnabled = value;
                this.RaisePropertyChanged(nameof(IsEnabled));
            }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set
            {
                this.RaisePropertyChanging(nameof(Title));
                title = value;
                this.RaisePropertyChanged(nameof(Title));
            }
        }

        public Action<ViewModelBase> BackAction
        {
            get;
            set;
        } = null;
        public virtual ICommand BackCommand
        {
            get
            {
                return ReactiveCommand.Create(() =>
                {
                    if (BackAction != null)
                    {
                        BackAction(this);
                    }
                });
            }
        }
    }
}
