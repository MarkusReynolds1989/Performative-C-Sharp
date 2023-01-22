namespace TopicExampleCode;

public class AlgorithmicTimeSpaceComplexity
{
    // O(1) <- Always the same amount, no variance.
    public static void ConstantComplexity()
    {
        var array = new[] {1, 2, 3, 4};
        // Getting an item from an array by index is a constant time operation.
        // It will happen the same speed no matter what, no matter what index you give it.
        // A million element array will have the same speed to get the first index and last.
        // Keep in mind this is true for arrays, but not true for every other collection.
        // Usually, a collection implementation has documentation about what kind of complexity
        // you can expect for different operations.

        Console.WriteLine(array[1]);
    }

    // O(n log n) <- where n is the amount of items.
    public static void LogarithmicComplexity()
    {
        // Binary search, we don't go through the whole collection
        // instead, we sub divide the collection each cycle to make it smaller and smaller until
        // we get the result. Thus, much faster and efficient operation.
        // Not always easy to use, for instance to use Binary search we have to have our elements pre-sorted.
        // Merge sort is also an example of Logarithmic Complexity. 
    }

    // O(n) <- where n is the amount of items.
    public static void LinearComplexity()
    {
        // Each item will be touched one at a time until the collection is done.
        // This is linear complexity, the time it takes to do the process scales with 
        // the amount of elements there are in the collection.
        var array = new[] {1, 2, 3, 4};
        foreach (var item in array)
        {
            Console.WriteLine(item);
        }
    }

    // O(n^2) <- Where n is the amount of items.
    public static void QuadraticComplexity()
    {
        // A typical example of quadratic time is when you have a nested for loop.
        // This increases the time complexity because you have to cycle through the top collection and then each sub collection.
        var list = new List<List<int>> { };
        list.Add(new List<int> {1, 2, 3, 4});
        list.Add(new List<int> {1, 2, 3, 4});

        foreach (var item in list)
        {
            foreach (var subItem in item)
            {
                Console.WriteLine(subItem);
            }
        }

        // Any time you see a quadratic algorithm and you've profiled it to verify it's slow in the context
        // of your program, you should refactor it so that it's flat.
        // Thus, you can reduce the time complexity by handling the complexity it yourself.
        // TODO: Test for double checking.
        // This algorithm now has linear complexity.
        var innerIndex = 0;
        for (var outerIndex = 0; outerIndex < list.Count; outerIndex += 1)
        {
            if (innerIndex < list[outerIndex].Count)
            {
                Console.WriteLine(list[outerIndex][innerIndex]);
                innerIndex += 1;
            }
            else
            {
                innerIndex = 0;
            }
        }
    }

    // 2O^n <- Where n is the amount of items.
    public static void ExponentialComplexity()
    {
        // This is often seen in situations where you have 3 + nested loops.
        // If you have a collection of collections and you need to gather some sort of permutation data
        // you can run into this situation, where you have to run permutations against permutations.    
        // If you see something like this it may take some deeper thinking about the problem but it's very likely
        // worth a refactor.
        // There are some problems that REQUIRE this approach, however, such as the traveling salesman problem using
        // dynamic programming.
    }
}