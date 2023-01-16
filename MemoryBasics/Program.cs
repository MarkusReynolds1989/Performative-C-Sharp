using System.Text;

namespace MemoryBasics;

public static class Program
{
    // Think of the variables that we are using as not only going on the stack, but also
    // as an array of local variables that Main has access to at any one time.
    private static void Main()
    {
        // All of these value types get stack allocated, then they get popped off the stack
        // and stored as local integers of the Main method.
        int item = 3;
        double dollars = 100.00;
        char itemTwo = 'a';
        int final = 43;

        var result = final + itemTwo;

        // This is a reference type, so a reference is allocated to the stack and the memory of the actual string
        // is somewhere on the heap.
        // The reference is also popped off the stack and stored locally in the method.
        StringBuilder test = new StringBuilder("this is a test.");
        // Even though the reference is stored locally for the method, the reference is still loaded to the top of the stack.
        // Then the "a" is added to the stack.
        // Finally, the virtual method for appending to a string builder is called.
        // This virtual method has a return value which gets pushed on the stack, so it is then popped off.
        test.Append("a");
        // Alternatively, you can assign the value to a local variable instead of ignoring it by popping it off the stack.
        // When we assign it like this, a local variable gets created for the Main Method.
        //var _ = test.Append("a");

        References();

        // Boxing
        // When we have a value type that we want to put on the heap, it gets boxed. 
        // This sometimes happens without us realizing, it's considered an implementation detail.
        // Even if you declare a variable as a struct it can be boxed and put on the heap, that's why you can't trust that
        // a struct is "stack allocated". 

        // Box x by assigning it to an object.
        int x = 3;
        // Because we are "upcasting" this to be of an object type it is now considered box, that is
        // the box variable is a reference to the value type x.
        object box = x;
        ChangeBoxedValue(ref box);
        Console.WriteLine(box);

        string y = "test";
        // The string won't get boxed because it already is, it's a reference type.
        object boxString = y;
        y = "one";

        // String builder also won't get boxed because it's a reference type.
        object boxStringBuilder = test;
    }

    private static void ChangeBoxedValue(ref object item)
    {
        item = 32;
    }

    private static void References()
    {
        // This stringBuilder object will get put on the heap, and the reference to it will be on the stack.
        var item = new StringBuilder();
        // This sill be a continuation of the stack from Main, so this will just keep getting pushed on top of Main.
        // When the reference gets popped off the stack, the actual object will still be alive on the heap.
        // A garbage collector will come and deallocate the memory automatically when it detects that there are no more
        // references in use for it (provided the program even lives that long).
        item.Append("a");
    }
}