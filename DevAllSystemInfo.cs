using System.Globalization;
using System.Runtime.InteropServices;

public static class DevAllSystemInfo
{
    public static string Platform => RuntimeInformation.OSDescription;

    public static string OSVersion => Environment.OSVersion.Version.ToString();

    public static string Locale => CultureInfo.CurrentCulture.Name;

    public static bool IsPhysicalDevice => !IsRunningInContainer();

    // Exemplo simples para detectar container (pode ser aprimorado)
    private static bool IsRunningInContainer()
    {
        return Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";
    }

    public static DevAllDeviceInfo GetDefaultDeviceInfo()
    {
        return new DevAllDeviceInfo
        {
            Platform = Platform,
            OSVersion = OSVersion,
            Locale = Locale,
            IsPhysicalDevice = IsPhysicalDevice
        };
    }
}

public class DevAllDeviceInfo
{
    public string Platform { get; set; } = "";
    public string OSVersion { get; set; } = "";
    public string Locale { get; set; } = "";
    public bool IsPhysicalDevice { get; set; } = true;
}
