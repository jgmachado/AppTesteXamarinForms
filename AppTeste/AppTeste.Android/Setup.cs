using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using AppTeste.Core;
using MvvmCross.Forms.Droid.Platform;
using MvvmCross.Forms.Platform;
using MvvmCross.Platform;
using AppTeste.Core.Helpers;
using AppTeste.Droid.Helpers;

namespace AppTeste.Droid
{
    public class Setup : MvxFormsAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override MvxFormsApplication CreateFormsApplication()
        {
            return new App();
        }

        protected override IMvxApplication CreateApp()
        {
            return new CoreApp();
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