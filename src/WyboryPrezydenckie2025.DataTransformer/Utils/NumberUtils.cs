using System;

namespace WyboryPrezydenckie2025.DataTransformer.Utils;

public static class NumberUtils
{
    public static int RoundToNearestInterval(this int value, int interval)
    {
        return (int) Math.Round(value / (double) interval) * interval;
    }

    public static int RoundToNearestInterval(this double value, int interval)
    {
        return (int)Math.Round(value / (double)interval) * interval;
    }
}