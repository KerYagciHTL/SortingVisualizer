using Raylib_cs;

namespace SortingVisualizer.Core;

public class Array(int[] array, WindowConfig config)
{
    public const int FontSize = 16;
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
    
            if (config.IsDebugMode)
            {
                //Starting Points
                Raylib.DrawCircle(curPosX, baseline, 5, Color.Red);
                Raylib.DrawCircle(curPosX + Width, baseline, 5, Color.Red);
                
                //Display number
                var text = value.ToString();
                var textWidth = Raylib.MeasureText(text, FontSize);

                var textX = curPosX + (Width - textWidth) / 2;
                var textY = (baseline - barHeight) + (barHeight - FontSize) / 2;

                Raylib.DrawText(text, textX, textY, FontSize, Color.Black);
            }

            curPosX += Width + margin;
        }
    }

    public void Update(float dt)
    {
    }
}