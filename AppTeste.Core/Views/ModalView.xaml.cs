using System;
using System.Collections.Generic;
using AppTeste.Core.ViewModels;
using MvvmCross.Forms.Views;
using MvvmCross.Forms.Views.Attributes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTeste.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxModalPresentation()] // Modal Attribute
    public partial class ModalView : MvxContentPage<ModalViewModel>
    {
        public ModalView()
        {
            InitializeComponent();
        }
    }
}
