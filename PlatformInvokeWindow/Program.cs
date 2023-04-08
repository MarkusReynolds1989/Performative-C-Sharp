using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;

namespace PlatformInvokeWindow;

// Use this website for finding out all the different libraries that can be used to platform invoke.
// https://www.pinvoke.net/

internal static class Program
{
    [DllImport("user32.dll")]
    private static extern int MessageBox(nint handle, string text, string caption, long type);

    [DllImport("kernel32.dll")]
    private static extern bool AttachConsole(int dwProcessId);

    private const int ParentProcess = -1;

    private static void Main()
    {
        MessageBox(0, "Enter a todo:", "Input", 0x10CF0000);
        AttachConsole(ParentProcess);
        
        var todoItems = new StringBuilder("Todo List:\n");
        var currentTodo = 1;

        var todo = Console.ReadLine();
        todoItems.AppendLine($"{currentTodo}. {todo}");

        while (currentTodo < 20)
        {
            MessageBox(0, todoItems.ToString(), "Todo List", 0);
            currentTodo += 1;
            MessageBox(0, "Enter a todo:", "Input", 0x10CF0000);
            AttachConsole(ParentProcess);
            todo = Console.ReadLine();
            todoItems.AppendLine($"{currentTodo}. {todo}");
        }
    }
}