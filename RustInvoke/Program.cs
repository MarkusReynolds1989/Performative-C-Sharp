using System.Runtime.InteropServices;
using System.Text;

namespace RustInvoke;

internal static unsafe class Program
{
    private ref struct Person
    {
        public byte* Name;
        public int Age;

        public Person(byte* name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    [DllImport(@"C:\Users\marku\Code\C#\Performative-C-Sharp\low_level_algo\target\debug\low_level_algo.dll")]
    private static extern Person create_person(nint nameBytes, uint count, int age);

    private static void Main()
    {
        const int nameSize = 3;
        var namePointer = stackalloc byte[nameSize];
        var name = new Span<byte>(namePointer, nameSize)
        {
            [0] = (byte) 't',
            [1] = (byte) 'o',
            [2] = (byte) 'm'
        };

        var tom = create_person((nint) namePointer, 3, 32);
        Console.WriteLine($"Name: {Encoding.UTF8.GetString(new Span<byte>(tom.Name, 3))}, Age: {tom.Age}");
        Marshal.FreeHGlobal((nint) tom.Name);
    }
}