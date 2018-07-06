using System;
using System.Windows.Input;
using ReactiveUI;
using Xamarin.Forms;

namespace XF1.ViewModels.Items
{
    public class ItemViewModelBase<T> : ViewModelBase where T : class
    {
        public virtual T Model
        {
            get;
            set;
        }

        public virtual Action<ItemViewModelBase<T>> ClickAction
        {
            get;
            set;
        } = null;

        protected virtual void OnClicked(ItemViewModelBase<T> itemViewModelBase)
        {
            if (ClickAction != null)
            {
                ClickAction.Invoke(itemViewModelBase);
            }
        }
        public virtual ICommand ClickCommand
        {
            get
            {
                return ReactiveCommand.Create(() =>
                {
                    OnClicked(this);
                });
            }
        }

        public ItemViewModelBase(T model)
        {
            Model = model;
        }

        public virtual Page Page
        {
            get;
            set;
        }

    }
}
