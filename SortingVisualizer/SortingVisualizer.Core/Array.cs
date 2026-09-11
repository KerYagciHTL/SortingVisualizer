using Raylib_cs;

namespace SortingVisualizer.Core;

public class Array(int[] array, WindowConfig config)
{
    public const int Width = 150;
    public void Draw()
    {
        var margin = (config.Width - array.Length * Width) / (array.Length + 1);
        var curPosX = margin;
        var baseline = (int)(config.Height / 1.2f);

        var maxValue = array.Max();
        var availableHeight = (int)(config.Height * 0.75f);

        foreach (var value in array)
        {
            var ratio = maxValue > 0 ? (float)value / maxValue : 0f;
            var barHeight = (int)(ratio * availableHeight);

            Raylib.DrawRectangle(curPosX, baseline - barHeight, Width, barHeight, Color.SkyBlue);
            curPosX += Width + margin;
        }
    }

    public void Update(float dt)
    {
    }
}