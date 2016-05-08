
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Jannine.Forms.ViewModels
{
	public class BaseViewModel: INotifyPropertyChanged
	{
		private string _title = String.Empty;
		private string _icon = null;
		private bool _isBusy = false;
		private bool _canLoadMore = true;

		public string Title {
			get { return _title; }
			set { SetProperty (ref _title, value);}
		}

		public string Icon {
			get { return _icon; }
			set { SetProperty (ref _icon, value); }
		}

		public bool IsBusy {
			get { return _isBusy; }
			set { SetProperty (ref _isBusy, value); }
		}

		public bool CanLoadMore {
			get { return _canLoadMore; }
			set { SetProperty (ref _canLoadMore, value); }
		}

		protected bool SetProperty<T> ( ref T backingStore,
									  T value,
									  [CallerMemberName] string propertyName = "",
									  Action onChange = null)
		{
			if (EqualityComparer<T>.Default.Equals (backingStore, value)) return false;

			backingStore = value;
			if (onChange != null) {
				onChange ();
			}

			OnPropertyChanged (propertyName);
			return true;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged ([CallerMemberName] string propertyName = "")
		{
			var changed = PropertyChanged;
			if (changed == null) return;
			changed (this, new PropertyChangedEventArgs (propertyName));
		}
	}
}

