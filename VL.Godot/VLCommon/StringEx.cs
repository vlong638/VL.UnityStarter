using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Godot;

namespace VL.Godot.VLCommon
{
    public static class StringEx
    {
        private static readonly Random _rand = new Random();

        public static string ToPrint(this List<Vector2> list)
        {
            return string.Join(", ", list);
        }
        public static string ToGDSignal(this string signal)
        {
            const string suffix = "EventHandler";

            return signal.EndsWith(suffix, StringComparison.Ordinal)
                ? signal[..^suffix.Length]
                : signal;
        }
    }
}
