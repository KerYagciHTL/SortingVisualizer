using Raylib_cs;

namespace SortingVisualizer.Core;

public class Array(int[] array, WindowConfig config)
{
    public const int FontSize = 16;
    public const int Width = 150;

    private const float StepDelay = 0.5f;

    private readonly bool[] _selectedIndices = new bool[array.Length];
    private IEnumerator<bool>? _sortSteps;
    private float _stepTimer;
    private bool _isSorted;

    public void Draw()
    {
        var margin = (config.Width - array.Length * Width) / (array.Length + 1);
        var curPosX = margin;
        var baseline = (int)(config.Height / 1.2f);

        var maxValue = array.Max();
        var availableHeight = (int)(config.Height * 0.75f);

        for (var i = 0; i < array.Length; i++)
        {
            var value = array[i];
            var ratio = maxValue > 0 ? (float)value / maxValue : 0f;
            var barHeight = (int)(ratio * availableHeight);

            Raylib.DrawRectangle(curPosX, baseline - barHeight, Width, barHeight,
                _selectedIndices[i] ? Color.Green : Color.SkyBlue);

            if (config.IsDebugMode)
            {
                //Starting Points
                Raylib.DrawCircle(curPosX, baseline, 5, Color.Red);
                Raylib.DrawCircle(curPosX + Width, baseline, 5, Color.Red);

                //Display number
                var text = value.ToString();
                var textWidth = Raylib.MeasureText(text, FontSize);

                var textX = curPosX + (Width - textWidth) / 2;
                var textY = baseline - barHeight + (barHeight - FontSize) / 2;

                Raylib.DrawText(text, textX, textY, FontSize, Color.Black);
            }

            curPosX += Width + margin;
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