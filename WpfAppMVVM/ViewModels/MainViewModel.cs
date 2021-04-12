using MVVMTools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WpfAppMVVM.Message;
using WpfAppMVVM.Models;
using WpfAppMVVM.Services;

namespace WpfAppMVVM.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get => currentViewModel;
            set => ChangeProp(out currentViewModel, value);
        }

        public MainViewModel(IMessanger messanger)
        {
            messanger.Subcribe<NavigationMessage>(item => 
            {
                var message = item as NavigationMessage;
                var type = message.ViewModelType;
                if (type == typeof(AddViewModel))
                {
                    CurrentViewModel = App.addViewModel;
                }
                if(type == typeof(HomeViewModel))
                {
                    CurrentViewModel = App.homeViewModel;
                }
                if (type == typeof(DetailViewModel))
                {
                    CurrentViewModel = App.detailViewModel;
                }
            });
        }
    }
}