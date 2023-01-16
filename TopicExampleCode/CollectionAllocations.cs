namespace TopicExampleCode;

public static class CollectionAllocations
{
    // From least to most expensive.

    // Note: Span by itself isn't really a collection, it's more of a window over a collection that allows operations
    // to be more efficient or more safe, for instance when working with pointers or stack allocated data.
    public static ReadOnlySpan<byte> StackSpanExample()
    {
        // Using stackalloc will return a stack allocated collection.
        Span<int> items = stackalloc int[100];
        // This memory is usually fastest to access and takes up what it says on the tin, so 100 integers on the stack is 
        // the size of 100 integers on the stack.
        for (var i = 0; i < 100; i += 1)
        {
            items[i] = i + 1;
        }

        // At the end of this method the items will pop off of the stack and we don't have to worry about
        // a GC hit at all.

        // Adding u8 is the same as asking for a ReadOnlySpan<byte> which is a UTF8 style string.
        var name = "tom"u8;
        // This is on the stack as well so is more efficient memory usage.
        return name;
    }

    public static void ArrayExample()
    {
        // Arrays are heap allocated in C#, they are reference types.
        // These are usually pretty efficient collections that you should try to use most of the time.
        var test = new[] {1, 2, 3, 4};
        test[0] = 55;
        // If you want your array to be stack allocated, you will need to look at the solution above using the stackalloc keyword.
    }
}