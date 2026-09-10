namespace SortingVisualizer.Core;

public record WindowConfig(int Width, int Height, string Title, int TargetFps = 60, bool IsDebugMode = false);