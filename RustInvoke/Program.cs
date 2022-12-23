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

        public Person(byte* name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    [DllImport(LowLevelAlgo)]
    private static extern Person create_person(nint nameBytes, int count, int age);

    [DllImport(LowLevelAlgo)]
    private static extern Person increment_age(Person person);

    private static void Main()
    {
        var (namePointer, pointerSize) = RustString.ToRustString("tom");

        var tom = create_person(namePointer, pointerSize, 32);
        Console.WriteLine($"Name: {RustString.FromRustString(tom.Name, 3)}, Age: {tom.Age}");

        var tomNew = increment_age(tom);
        Console.WriteLine($"Name: {RustString.FromRustString(tomNew.Name, 3)}, Age: {tomNew.Age}");
        Console.ReadLine();
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