namespace BaiTH4D;

static class Program
{
    [STAThread]
    static void Main()
    {
        
        ApplicationConfiguration.Initialize();
        Application.Run(new FormKhachSan());
    }    
}