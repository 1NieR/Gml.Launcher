using Avalonia;
using Avalonia.ReactiveUI;
using System;
using System.Reactive;
using Gml.Launcher.Core.Extensions;
using Gml.Launcher.Core.Guard;
using ReactiveUI;
using Sentry;

namespace Gml.Launcher;

class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        try
        {

            // AvnApi.Load(@"C:\Users\aa.terentiev\CLionProjects\GravitGuard\x64\Release\GuardDLL.dll");
            // var test = AvnApi.API.AvnIsFileSigned.Invoke(@"C:\Users\aa.terentiev\CLionProjects\Avanguard\x64\Release\Avanguard.dll", true);

            RxApp.DefaultExceptionHandler = Observer.Create<Exception>(GlobalExceptionHandler);
            BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args);


        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private static void GlobalExceptionHandler(Exception exception)
    {

        SentrySdk.CaptureException(exception);
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .RegisterServices()
            .LogToTrace()
            .UseReactiveUI();
}
