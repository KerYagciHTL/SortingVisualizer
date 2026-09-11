namespace SortingVisualizer.Core;

public static class NativeMethods
{
    public static int[] GetRandomSortedArray(int minValue = 0, int maxValue = int.MaxValue, int size = 10)
    {
        var random = new Random();
        var array = new int[size];

        for (var i = 0; i < size; i++)
        {
            array[i] = random.Next(minValue, maxValue);
        }
        
        return array;
    }
}