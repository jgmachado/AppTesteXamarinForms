using System;
using System.Threading;
using System.Threading.Tasks;
using AppTeste.Core.Model;
using AppTeste.Core.Services;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Xamarin.Forms;

namespace AppTeste.Core.ViewModels
{
    public class ModalViewModel : MvxViewModel<RequestModel>
    {
        private int timeout;
        private readonly IMvxNavigationService _navigationService;
        private RequestModel _request;
        private HtmlWebViewSource response;

        private HtmlWebViewSource _source;
        public HtmlWebViewSource Source
        {
            get { return _source; }
            set
            {
                SetProperty(ref _source, value);
                RaisePropertyChanged(() => Source);
            }
        }

        public ModalViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            timeout = 10000; // 10 seconds
        }

        private async void CallWebServer()
        {
            var tokenSource = new CancellationTokenSource();
            var task = WebServerService.Initiate.RequestView(_request, tokenSource.Token);
            if (task == await Task.WhenAny(task, Task.Delay(timeout, tokenSource.Token)))
            {
                Source = await task;
            }
            else
            {
                // Timeout
                tokenSource.Cancel();
                CoreApp.Log2Plataform("TIMEOUT CallWebServer", "Timeout de execucao");
                response = new HtmlWebViewSource();
                response.Html = @"TIMEOUT DE EXECUÇÃO...";
                Source = response;
            }
        }

        public override void Prepare(RequestModel parameter)
        {
            _request = parameter;

            // Create and call webserver
            CallWebServer(); 
        }

        private IMvxAsyncCommand _closeModalCommand;
        public IMvxAsyncCommand CloseModalCommand =>
        _closeModalCommand = _closeModalCommand ?? new MvxAsyncCommand(async () =>
        {
            //Close Modal screen
            await _navigationService.Close(this);
        });
    }
}
