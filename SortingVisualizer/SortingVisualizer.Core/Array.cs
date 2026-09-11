using Raylib_cs;

namespace SortingVisualizer.Core;

public class Array(int[] array, WindowConfig config)
{
    public const int MinFontSize = 8;
    public const int MaxFontSize = 32;
    public const int Margin = 10;

    private const float StepDelay = 0f;

    private readonly bool[] _selectedIndices = new bool[array.Length];
    private IEnumerator<bool>? _sortSteps;
    private float _stepTimer;
    private bool _isSorted;

    public void Draw()
    {
        var width = (config.Width - Margin * (array.Length + 1)) / array.Length;
        var fontSize = Math.Clamp(width / 3, MinFontSize, MaxFontSize);
        var curPosX = Margin;
        var baseline = (int)(config.Height / 1.2f);

        var maxValue = array.Max();
        var availableHeight = (int)(config.Height * 0.75f);

        for (var i = 0; i < array.Length; i++)
        {
            var value = array[i];
            var ratio = maxValue > 0 ? (float)value / maxValue : 0f;
            var barHeight = (int)(ratio * availableHeight);

            Raylib.DrawRectangle(curPosX, baseline - barHeight, width, barHeight,
                _selectedIndices[i] ? Color.Green : Color.White);

            if (config.IsDebugMode)
            {
                //Display number
                var text = value.ToString();
                var textWidth = Raylib.MeasureText(text, fontSize);

                var textX = curPosX + (width - textWidth) / 2;
                var textY = baseline - barHeight + (barHeight - fontSize) / 2;

                Raylib.DrawText(text, textX, textY, fontSize, Color.Black);
            }

            curPosX += width + Margin;
        }
    }

    private void Sort()
    {
        _sortSteps = BubbleSort().GetEnumerator();
    }

    public void Update(float dt)
    {
        if (_isSorted) return;

        if (_sortSteps is null)
        {
            Sort();
            return;
        }

        _stepTimer += dt;
        if (_stepTimer < StepDelay) return;
        _stepTimer = 0f;

        if (_sortSteps.MoveNext()) return;

        _sortSteps = null;
        _isSorted = true;
        System.Array.Fill(_selectedIndices, true);
    }

    private IEnumerable<bool> BubbleSort()
    {
        for (var i = 0; i < array.Length - 1; i++)
        {
            for (var j = 0; j < array.Length - i - 1; j++)
            {
                System.Array.Clear(_selectedIndices);
                _selectedIndices[j] = true;
                _selectedIndices[j + 1] = true;
                yield return true;

                if (array[j] <= array[j + 1]) continue;

                (array[j], array[j + 1]) = (array[j + 1], array[j]);
                yield return true;
            }
        }
    }
}