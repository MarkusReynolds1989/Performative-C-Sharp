using System.Runtime.InteropServices;
using System.Text;

namespace RustInvoke;

internal static unsafe class Program
{
    private const string MaxPath = @"C:\Users\marku\Code\C#\Performative-C-Sharp\NativeInvoke\c_dlls\other_ffi.dll";
    private const string MinPath = @"C:\Users\marku\Code\C#\Performative-C-Sharp\NativeInvoke\d_dlls\more_ffi.dll";

    [DllImport(MaxPath)]
    private static extern int max(int* array, nint length);

    [DllImport(MinPath)]
    private static extern int min(int* array, nint length);

    private static void Main()
    {
        var nums = (int*) Marshal.AllocHGlobal(5 * sizeof(int));
        for (var i = 0; i < 5; i += 1)
        {
            nums[i] = i;
        }

        var result = max(nums, 5);
        
        Console.WriteLine(result);

        result = min(nums, 5); 
        
        Console.WriteLine(result);
        
        Marshal.FreeHGlobal((nint) nums);
    }
}