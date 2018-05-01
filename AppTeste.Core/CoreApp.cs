using MvvmCross.Platform.IoC;
using MvvmCross.Core.ViewModels;
using AppTeste.Core.ViewModels;
using AppTeste.Core.Helpers;
using MvvmCross.Platform;

namespace AppTeste.Core
{
    public class CoreApp : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterNavigationServiceAppStart<MainViewModel>();
        }

        public static void Log2Plataform(string header, string message)
        {
            var log = Mvx.Resolve<ILogPlataform>();
            log.Log2Plataform(header, message);
        }
    }
}
