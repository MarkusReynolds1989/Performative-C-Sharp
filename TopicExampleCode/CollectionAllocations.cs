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
        // The efficiency here is that an array isn't growable, so the memory use is going to stay consistent,
        // the memory will be allocated one time when the array is created and not more.
        var test = new[] {1, 2, 3, 4};
        test[0] = 55;
        // If you want your array to be stack allocated, you will need to look at the solution above using the stackalloc keyword.
    }

    public static void ListExample()
    {
        // Lists are resizeable arrays.
        var list = new List<int>(200)
        {
            [0] = 1
        };

        // What's actually happening behind the scenes is that an array is being allocated.
        // When we exceed capacity, our items are copied over to a new array with an extended
        // capacity.
        // If we set the capacity, the array will be bigger and thus it will take longer before we need to allocate
        // again.
        // Remember, allocations are slow and we should avoid them if possible (and we have a verified bottleneck).

        list.Capacity = 400;
        // When we add more items than we have set aside capacity for it has to allocate more memory.
        // It doesn't just add the space needed, there is usually an algorithm that will allocated more than needed.
        list.AddRange(Enumerable.Range(0, 1000));
        list.Clear();
        // I will show List.cs here to show how the extra memory gets allocated.
    }
    
    public static void DictionaryExample()
    {
        // Very similar to the List, there is a capacity that must get resized and then
        // data has to get copied over.
        var dict = new Dictionary<int, int>();
        dict.Add(1,2);
        dict.Add(4,5);
    }
}