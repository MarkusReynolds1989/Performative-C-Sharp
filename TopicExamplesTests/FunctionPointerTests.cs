namespace Tests;
using System.Runtime.InteropServices;

public static class FunctionPointerTests
{
    [Fact]
    public static void AddTest()
    {
        FunctionPointerExample.MathOp funcAdd = FunctionPointerExample.Add;
        var addPointer = Marshal.GetFunctionPointerForDelegate(funcAdd);
        var addFunction = Marshal.GetDelegateForFunctionPointer(addPointer, typeof(FunctionPointerExample.MathOp));

        // Dereferencing the pointer in C# has the overhead of allocating it all on the heap.
        // So be careful when using it, favor using it in cases where you want to pass it to unmanaged code.
        Assert.Equal(addFunction.DynamicInvoke(3, 4), 7);
    }

    [Fact]
    public static void SubTest()
    {
        FunctionPointerExample.MathOp funcSub = FunctionPointerExample.Sub;

        var subPointer = Marshal.GetFunctionPointerForDelegate(funcSub);

        var subFunction = Marshal.GetDelegateForFunctionPointer(subPointer, typeof(FunctionPointerExample.MathOp));

        Assert.Equal(subFunction.DynamicInvoke(4, 3), 1);
    }

    [Fact]
    public static void ForeignFunctionTest()
    {
        // We pretend here that we are passing our function off to some foreign code.
        // For instance, we could package our function down and pass it to run in 
        // unmanaged C or C++ code.
        FunctionPointerExample.MathOp funcAdd = FunctionPointerExample.Add;
        var addPointer = Marshal.GetFunctionPointerForDelegate(funcAdd);
        Assert.Equal(FunctionPointerExample.SomeMethod(addPointer, typeof(FunctionPointerExample.MathOp)), new[] {2, 3, 4, 5});
    }
}