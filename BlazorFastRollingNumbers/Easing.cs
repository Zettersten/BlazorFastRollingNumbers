namespace BlazorFastRollingNumbers;

/// <summary>
/// Represents a CSS easing function for animations.
/// Provides static defaults for common easing functions and supports custom easing strings.
/// </summary>
public readonly struct Easing
{
    private readonly string _value;

    /// <summary>
    /// Creates an Easing with a custom CSS easing function string.
    /// </summary>
    /// <param name="value">The CSS easing function (e.g., "ease-in-out", "cubic-bezier(0.4, 0, 0.2, 1)").</param>
    public Easing(string value)
    {
        _value = value ?? Linear._value;
    }

    /// <summary>
    /// Implicitly converts a string to an Easing.
    /// </summary>
    public static implicit operator Easing(string value) => new(value);

    /// <summary>
    /// Converts the Easing to its CSS string representation.
    /// </summary>
    public override string ToString() => _value;

    // Standard CSS easing functions
    public static readonly Easing Linear = new("linear");
    public static readonly Easing Ease = new("ease");
    public static readonly Easing EaseIn = new("ease-in");
    public static readonly Easing EaseOut = new("ease-out");
    public static readonly Easing EaseInOut = new("ease-in-out");

    // Common cubic-bezier presets
    public static readonly Easing EaseInSine = new("cubic-bezier(0.12, 0, 0.39, 0)");
    public static readonly Easing EaseOutSine = new("cubic-bezier(0.61, 1, 0.88, 1)");
    public static readonly Easing EaseInOutSine = new("cubic-bezier(0.37, 0, 0.63, 1)");

    public static readonly Easing EaseInQuad = new("cubic-bezier(0.11, 0, 0.5, 0)");
    public static readonly Easing EaseOutQuad = new("cubic-bezier(0.5, 1, 0.89, 1)");
    public static readonly Easing EaseInOutQuad = new("cubic-bezier(0.45, 0, 0.55, 1)");

    public static readonly Easing EaseInCubic = new("cubic-bezier(0.32, 0, 0.67, 0)");
    public static readonly Easing EaseOutCubic = new("cubic-bezier(0.33, 1, 0.68, 1)");
    public static readonly Easing EaseInOutCubic = new("cubic-bezier(0.65, 0, 0.35, 1)");

    public static readonly Easing EaseInQuart = new("cubic-bezier(0.5, 0, 0.75, 0)");
    public static readonly Easing EaseOutQuart = new("cubic-bezier(0.25, 1, 0.5, 1)");
    public static readonly Easing EaseInOutQuart = new("cubic-bezier(0.76, 0, 0.24, 1)");

    public static readonly Easing EaseInQuint = new("cubic-bezier(0.64, 0, 0.78, 0)");
    public static readonly Easing EaseOutQuint = new("cubic-bezier(0.22, 1, 0.36, 1)");
    public static readonly Easing EaseInOutQuint = new("cubic-bezier(0.83, 0, 0.17, 1)");

    public static readonly Easing EaseInExpo = new("cubic-bezier(0.7, 0, 0.84, 0)");
    public static readonly Easing EaseOutExpo = new("cubic-bezier(0.16, 1, 0.3, 1)");
    public static readonly Easing EaseInOutExpo = new("cubic-bezier(0.87, 0, 0.13, 1)");

    public static readonly Easing EaseInCirc = new("cubic-bezier(0.55, 0, 1, 0.45)");
    public static readonly Easing EaseOutCirc = new("cubic-bezier(0, 0.55, 0.45, 1)");
    public static readonly Easing EaseInOutCirc = new("cubic-bezier(0.85, 0, 0.15, 1)");

    public static readonly Easing EaseInBack = new("cubic-bezier(0.36, 0, 0.66, -0.56)");
    public static readonly Easing EaseOutBack = new("cubic-bezier(0.34, 1.56, 0.64, 1)");
    public static readonly Easing EaseInOutBack = new("cubic-bezier(0.68, -0.6, 0.32, 1.6)");
}
