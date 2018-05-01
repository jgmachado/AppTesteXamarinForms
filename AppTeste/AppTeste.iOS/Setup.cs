using AppTeste.Core;
using AppTeste.Core.Helpers;
using AppTeste.iOS.Helpers;
using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.iOS;
using MvvmCross.Forms.Platform;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using UIKit;

namespace AppTeste.iOS
{
    public class Setup : MvxFormsIosSetup
    {
        public Setup(IMvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new CoreApp();
        }
  
        protected override MvxFormsApplication CreateFormsApplication()
        {
            return new App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            // Registers IoC
            Mvx.RegisterSingleton<ILogPlataform>(new LogPlataform());
        }
    }
}