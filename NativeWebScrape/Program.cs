using System.Runtime.InteropServices;

namespace NativeWebScrape;

// In this program we will wrap the curl dll.
// This is extremely simple and easy, use a tool like vcpkg to install the C lib libcurl
// Once you have that you can very easily use the library.
// This opens up a ton of doors, you can then write C libraries and test them from C#, or use 
// most any C++ or C library you find if there isn't one available for C#.

// In the C lib these are all just constants, we can clean them up here.
public enum CurlResponse
{
    CurlOk = 0,
    CurlUrlMalFormat = 3,
    CurlCouldntResolveHost = 6
}

// Same as above, it's more clear when they are under an Enum.
public enum CurlOptions
{
    Url = 10002
}

internal static class Program
{
    [DllImport("libcurl.dll")]
    private static extern nint curl_easy_init();

    [DllImport("libcurl.dll")]
    private static extern void curl_easy_setopt(nint curl, CurlOptions option, string url);

    [DllImport("libcurl.dll")]
    private static extern nint curl_easy_perform(nint curl);

    [DllImport("libcurl.dll")]
    private static extern void curl_easy_cleanup(nint curlInstance);

    private static void Main()
    {
        const string url = "https://catfact.ninja/fact";

        var curl = curl_easy_init();
        curl_easy_setopt(curl, CurlOptions.Url, url);
        var result = curl_easy_perform(curl);

        if (result == (nint) CurlResponse.CurlOk)
        {
            // Now that the pointer is a managed string, we can do whatever we like with it.
            var managedResult = Marshal.PtrToStringAuto(result);
            Console.WriteLine(managedResult);
        }
        else if (result == (nint) CurlResponse.CurlCouldntResolveHost)
        {
            Console.WriteLine("Couldn't resolve host.");
        }

        curl_easy_cleanup(curl);
    }
}