using AppTeste.Core.ViewModels;
using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;

namespace AppTeste.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : MvxContentPage<MainViewModel>
    {
        public MainView()
        {
            InitializeComponent();
        }
    }
}