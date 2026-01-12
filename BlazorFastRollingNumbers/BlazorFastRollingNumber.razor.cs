using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components;

namespace BlazorFastRollingNumbers;

public partial class BlazorFastRollingNumber : ComponentBase
{
    // int.MinValue ("-2147483648") is 11 chars. Cap MinDigits to keep allocations bounded.
    private const int MaxMinimumDigits = 32;
    private const int MaxIntChars = 11;
    private const int BufferSize = MaxMinimumDigits > MaxIntChars ? MaxMinimumDigits : MaxIntChars;

    [Parameter]
    public int Value { get; set; }

    /// <summary>
    /// Minimum number of characters to render, including a possible '-' sign.
    /// Values &lt; 0 are treated as 0. Values &gt; <see cref="MaxMinimumDigits"/> are clamped.
    /// </summary>
    [Parameter]
    public int MinimumDigits { get; set; }

    /// <summary>
    /// CSS transition duration (e.g., "0.5s", "500ms").
    /// </summary>
    [Parameter]
    public string Duration { get; set; } = "1s";

    [Parameter]
    public Easing Easing { get; set; } = Easing.Ease;

    [Parameter]
    public string? CssClass { get; set; }

    /// <summary>
    /// Optional accessible label for the rendered number.
    /// If null, no aria-label is emitted (to avoid per-render string allocations).
    /// </summary>
    [Parameter]
    public string? AriaLabel { get; set; }

    /// <summary>
    /// Optional aria-live politeness setting (e.g. "polite" / "assertive").
    /// </summary>
    [Parameter]
    public string? AriaLive { get; set; }

    private readonly DigitData[] _digitData = new DigitData[BufferSize];
    private int _digitCount;

    private int _lastValue = int.MaxValue;
    private int _lastMinDigitsEffective = -1;

    protected override void OnParametersSet()
    {
        var minDigitsEffective = ClampMinDigits(MinimumDigits);

        // Only recompute if value or effective min digits changed
        if (_lastValue == Value && _lastMinDigitsEffective == minDigitsEffective)
            return;

        _lastValue = Value;
        _lastMinDigitsEffective = minDigitsEffective;

        var targetSize = Math.Max(minDigitsEffective, GetDigitCount(Value));
        _digitCount = targetSize;

        PopulateDigitData(Value, targetSize, _digitData);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int ClampMinDigits(int value)
    {
        if (value <= 0) return 0;
        return value <= MaxMinimumDigits ? value : MaxMinimumDigits;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int GetTransformOffset(char digit)
    {
        // Branchless computation for digits 0-9
        if ((uint)(digit - '0') <= 9)
            return (digit - '0') * -10;

        return digit switch
        {
            '\u200B' => 10,
            '-' => -100,
            _ => 0
        };
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int GetDigitCount(int value)
    {
        if (value == 0) return 1;
        if (value == int.MinValue) return 11;

        var absValue = Math.Abs(value);

        // Optimized digit count without log10
        var digits = 1;
        if (absValue >= 100000000) { digits += 8; absValue /= 100000000; }
        if (absValue >= 10000) { digits += 4; absValue /= 10000; }
        if (absValue >= 100) { digits += 2; absValue /= 100; }
        if (absValue >= 10) digits++;

        return value < 0 ? digits + 1 : digits;
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    private static void PopulateDigitData(int value, int targetSize, Span<DigitData> destination)
    {
        const char ZeroWidthSpace = '\u200B';

        Span<char> buffer = stackalloc char[MaxIntChars];

        if (!value.TryFormat(buffer, out var written))
        {
            destination[0] = new DigitData(ZeroWidthSpace, 10);
            return;
        }

        var padding = targetSize - written;

        // Fill padding
        for (var i = 0; i < padding; i++)
        {
            destination[i] = new DigitData(ZeroWidthSpace, 10);
        }

        // Copy actual digits
        for (var i = 0; i < written; i++)
        {
            var ch = buffer[i];
            destination[padding + i] = new DigitData(ch, GetTransformOffset(ch));
        }
    }

    private readonly struct DigitData
    {
        public readonly char Char;
        public readonly int Offset;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DigitData(char ch, int offset)
        {
            Char = ch;
            Offset = offset;
        }
    }
}

