namespace SortingVisualizer.Core;

public static class NativeMethods
{
    public static int[] GetRandomArray(int minValue = 0, int maxValue = int.MaxValue, int size = 10)
    {
        var random = new Random();
        var array = new int[size];

        for (var i = 0; i < size; i++)
        {
            array[i] = random.Next(minValue, maxValue);
        }

        return array;
    }

    public static IEnumerable<SortStep> BubbleSort(int[] array)
    {
        for (var i = 0; i < array.Length - 1; i++)
        {
            for (var j = 0; j < array.Length - i - 1; j++)
            {
                yield return new SortStep(j, j + 1);

                if (array[j] <= array[j + 1]) continue;

                (array[j], array[j + 1]) = (array[j + 1], array[j]);
                yield return new SortStep(j, j + 1);
            }
        }
    }

    public static IEnumerable<SortStep> SelectionSort(int[] array)
    {
        for (var i = 0; i < array.Length - 1; i++)
        {
            var minIndex = i;

            for (var j = i + 1; j < array.Length; j++)
            {
                yield return new SortStep(minIndex, j);

                if (array[j] < array[minIndex]) minIndex = j;
            }

            if (minIndex == i) continue;

            (array[i], array[minIndex]) = (array[minIndex], array[i]);
            yield return new SortStep(i, minIndex);
        }
    }

    public static IEnumerable<SortStep> InsertionSort(int[] array)
    {
        for (var i = 1; i < array.Length; i++)
        {
            var j = i;

            while (j > 0)
            {
                yield return new SortStep(j - 1, j);

                if (array[j - 1] <= array[j]) break;

                (array[j - 1], array[j]) = (array[j], array[j - 1]);
                yield return new SortStep(j - 1, j);
                j--;
            }
        }
    }
}
