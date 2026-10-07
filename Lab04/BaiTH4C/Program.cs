using Lab04;

namespace BaiTH4C;

internal static class AppEntryPoint
{
    
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FormMayTinh());
    }
}