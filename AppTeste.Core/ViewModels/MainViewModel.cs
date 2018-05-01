using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AppTeste.Core.Model;
using AppTeste.Core.Services;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.Views;

namespace AppTeste.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private int timeout;
        private readonly IMvxNavigationService _navigationService;

        public MainViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private string _text;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        private IMvxAsyncCommand _showModalCommand;
        public IMvxAsyncCommand ShowModalCommand =>
        _showModalCommand = _showModalCommand ?? new MvxAsyncCommand(async() => 
        {
            //Open Modal screen
            IsLoading = true;
            Text = "Usando MVVVM !!!";

            var tokenSource = new CancellationTokenSource();
            var task = CreateIDService.Initiate.CreateGuid(tokenSource.Token);
            if (task == await Task.WhenAny(task, Task.Delay(timeout, tokenSource.Token)))
            {
                Guid id = await task;

                if (id != Guid.Empty)
                {
                    Text = string.Format("Guid: {0}", id.ToString());

                    // Loads Modal page
                    RequestModel request = new RequestModel()
                    { GUid = id.ToString() };
                    await _navigationService.Navigate<ModalViewModel, RequestModel>(request);
                }
                else
                {
                    // Error
                    CoreApp.Log2Plataform("ERROR ShowModalCommand", "Id vazio");
                    Text = "ID VAZIO";
                }
            }
            else
            {
                // Timeout
                tokenSource.Cancel();
                CoreApp.Log2Plataform("TIMEOUT ShowModalCommand", "Timeout de execucao");
                Text = "TIMEOUT DE EXECUCAO";
            }

            IsLoading = false;
        });

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                SetProperty(ref _isLoading, value);
                RaisePropertyChanged(() => IsLoading);
            }
        }

        public override void Start()
        {
            timeout = 10000; // 10 seconds
            base.Start();
            _isLoading = false;
        }

        public override Task Initialize()
        {
            return base.Initialize();
        }
    }
}
