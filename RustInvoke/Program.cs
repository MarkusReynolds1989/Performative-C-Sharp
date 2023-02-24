using System.Runtime.InteropServices;
using System.Text;

namespace RustInvoke;

internal static unsafe class Program
{
    private const string LowLevelAlgo =
        @"C:\Users\marku\Code\C#\Performative-C-Sharp\low_level_algo\target\debug\low_level_algo.dll";

    private ref struct Person
    {
        public readonly byte* Name;
        public readonly int Age;
    }

    [DllImport(LowLevelAlgo)]
    private static extern Person create_person(nint nameBytes, int count, int age);

    [DllImport(LowLevelAlgo)]
    private static extern Person increment_age(this Person person);

    [DllImport(LowLevelAlgo)]
    private static extern int* reverse_array(nint array, uint count);

    [DllImport(LowLevelAlgo)]
    private static extern int* c_sharp_map(nint array, nint function, uint count);

    private delegate int NumOp(int input);
    private static int Square(int input) => input * 2;
    
    private static void Main()
    {
        var array = (int*) Marshal.AllocHGlobal(sizeof(int) * 10);
        var arraySpan = new Span<int>(array, 10);

        for (var i = 0; i < arraySpan.Length; i += 1)
        {
            arraySpan[i] = i;
        }

        var reverseSpan = new Span<int>(reverse_array((nint)array, 10), 10);

        foreach (var item in reverseSpan)
        {
            Console.WriteLine(item);
        }

        NumOp square = Square;
        var squarePointer = Marshal.GetFunctionPointerForDelegate(square);
        
        var mappedArray = c_sharp_map((nint)array, squarePointer, 10);
        var mappedArraySpan = new Span<int>(mappedArray, 10);

        foreach (var item in mappedArraySpan)
        {
            Console.WriteLine(item);
        }
        
        Marshal.FreeHGlobal((nint) array);
        
        var (namePointer, pointerSize) = RustString.ToRustString("tom");

        var tom = create_person(namePointer, pointerSize, 32);
        Console.WriteLine($"Name: {RustString.FromRustString(tom.Name, 3)}, Age: {tom.Age}");

        var tomNew = tom.increment_age();
        Console.WriteLine($"Name: {RustString.FromRustString(tomNew.Name, 3)}, Age: {tomNew.Age}");
        
        Marshal.FreeHGlobal(namePointer);
    }
}

public static unsafe class RustString
{
    public static (nint, int) ToRustString(string input)
    {
        var length = input.Length;
        var stringPointer = Marshal.StringToHGlobalAnsi(input);
        return (stringPointer, length);
    }

    public static string FromRustString(byte* input, int length) =>
        Encoding.UTF8.GetString(new Span<byte>(input, length));
}