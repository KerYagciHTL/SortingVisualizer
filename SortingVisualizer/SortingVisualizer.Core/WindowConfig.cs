namespace SortingVisualizer.Core;

public record WindowConfig(int Height, int Width, string Title, int TargetFps = 60, bool IsDebugMode = false);