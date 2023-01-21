using System.Runtime.InteropServices;

namespace NativeWebScrape;

// In this program we will wrap the curl dll.
// This is extremely simple and easy, use a tool like vcpkg to install the C lib libcurl
// Once you have that you can very easily use the library.
// This opens up a ton of doors, you can then write C libraries and test them from C#, or use 
// most any C++ or C library you find if there isn't one available for C#.

internal static class Program
{
    private const int CURLOPT_URL = 10002;

    [DllImport("libcurl.dll")]
    private static extern nint curl_easy_init();

    [DllImport("libcurl.dll")]
    private static extern void curl_easy_setopt(nint curl, int option, string url);

    [DllImport("libcurl.dll")]
    private static extern nint curl_easy_perform(nint curl);

    [DllImport("libcurl.dll")]
    private static extern void curl_easy_cleanup(nint curlInstance);

    private static void Main()
    {
        var curl = curl_easy_init();
        curl_easy_setopt(curl, CURLOPT_URL, "https://catfact.ninja/fact");
        var result = curl_easy_perform(curl);
        // Now that the pointer is a managed string, we can do whatever we like with it.
        var managedResult = Marshal.PtrToStringAuto(result);
        Console.WriteLine(managedResult);
        curl_easy_cleanup(curl);
    }
}