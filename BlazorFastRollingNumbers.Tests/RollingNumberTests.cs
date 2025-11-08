using Bunit;
using BlazorFastRollingNumbers;
using Xunit;

namespace BlazorFastRollingNumbers.Tests;

public class BlazorFastRollingNumberTests : TestContext
{
    [Fact]
    public void BlazorFastBlazorFastRollingNumber_RendersPositiveNumber()
    {
        // Arrange & Act
        var cut = RenderComponent<BlazorFastRollingNumber>(parameters => parameters
            .Add(p => p.Value, 123));

        // Assert
        var wrapper = cut.Find(".bfrn");
        Assert.NotNull(wrapper);
        
        var digits = cut.FindAll(".bfrn__digit");
        Assert.Equal(3, digits.Count);
    }

    [Fact]
    public void BlazorFastRollingNumber_RendersNegativeNumber()
    {
        // Arrange & Act
        var cut = RenderComponent<BlazorFastRollingNumber>(parameters => parameters
            .Add(p => p.Value, -456));

        // Assert
        var digits = cut.FindAll(".bfrn__digit");
        Assert.Equal(4, digits.Count); // 3 digits + minus sign
        
        // First digit should show minus sign
        var firstDigit = cut.Find(".bfrn__digit .bfrn__value");
        Assert.Contains("-", firstDigit.TextContent);
    }

    [Fact]
    public void BlazorFastRollingNumber_RendersZero()
    {
        // Arrange & Act
        var cut = RenderComponent<BlazorFastRollingNumber>(parameters => parameters
            .Add(p => p.Value, 0));

        // Assert
        var digits = cut.FindAll(".bfrn__digit");
        Assert.Single(digits);
    }

    [Fact]
    public void BlazorFastRollingNumber_RespectsMinimumDigits()
    {
        // Arrange & Act
        var cut = RenderComponent<BlazorFastRollingNumber>(parameters => parameters
            .Add(p => p.Value, 5)
            .Add(p => p.MinimumDigits, 4));

        // Assert
        var digits = cut.FindAll(".bfrn__digit");
        Assert.Equal(4, digits.Count);
        
        // First 3 should be zero-width spaces (check via inline style)
        var allDigits = cut.FindAll(".bfrn__digit");
        var paddingCount = allDigits.Count(d => d.GetAttribute("style")?.Contains("--digit-offset: 10%") == true);
        Assert.Equal(3, paddingCount);
    }

    [Fact]
    public void BlazorFastRollingNumber_UpdatesWhenValueChanges()
    {
        // Arrange
        var cut = RenderComponent<BlazorFastRollingNumber>(parameters => parameters
            .Add(p => p.Value, 100));

        // Act
        cut.SetParametersAndRender(parameters => parameters
            .Add(p => p.Value, 999));

        // Assert
        var digits = cut.FindAll(".bfrn__digit");
        Assert.Equal(3, digits.Count);
        
        var allDigits = cut.FindAll(".bfrn__digit");
        var nineCount = allDigits.Count(d => d.GetAttribute("style")?.Contains("--digit-offset: -90%") == true);
        Assert.Equal(3, nineCount);
    }

    [Fact]
    public void BlazorFastRollingNumber_HandlesMaxInt()
    {
        // Arrange & Act
        var cut = RenderComponent<BlazorFastRollingNumber>(parameters => parameters
            .Add(p => p.Value, int.MaxValue));

        // Assert
        var digits = cut.FindAll(".bfrn__digit");
        Assert.Equal(10, digits.Count); // 2147483647
    }

    [Fact]
    public void BlazorFastRollingNumber_HandlesMinInt()
    {
        // Arrange & Act
        var cut = RenderComponent<BlazorFastRollingNumber>(parameters => parameters
            .Add(p => p.Value, int.MinValue));

        // Assert
        var digits = cut.FindAll(".bfrn__digit");
        Assert.Equal(11, digits.Count); // -2147483648
        
        // Check first digit has minus
        var firstValue = cut.Find(".bfrn__digit .bfrn__value");
        Assert.Contains("-", firstValue.TextContent);
    }

    [Fact]
    public void BlazorFastRollingNumber_HasCorrectCssClasses()
    {
        // Arrange & Act
        var cut = RenderComponent<BlazorFastRollingNumber>(parameters => parameters
            .Add(p => p.Value, 42));

        // Assert
        var wrapper = cut.Find(".bfrn");
        Assert.NotNull(wrapper);
        
        var digits = cut.FindAll(".bfrn__digit");
        foreach (var digit in digits)
        {
            var scale = digit.QuerySelector(".bfrn__scale");
            Assert.NotNull(scale);
            
            var value = digit.QuerySelector(".bfrn__value");
            Assert.NotNull(value);
        }
    }

    [Fact]
    public void BlazorFastRollingNumber_ScaleContainsAllDigitsAndMinus()
    {
        // Arrange & Act
        var cut = RenderComponent<BlazorFastRollingNumber>(parameters => parameters
            .Add(p => p.Value, 1));

        // Assert
        var scale = cut.Find(".bfrn__scale");
        var scaleSpans = scale.QuerySelectorAll("span");
        
        // Should have 11 spans: 0-9 plus minus
        Assert.Equal(11, scaleSpans.Length);
        
        // Last span should be minus
        var lastSpan = scaleSpans[scaleSpans.Length - 1];
        Assert.Equal("-", lastSpan.TextContent);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(10, 2)]
    [InlineData(99, 2)]
    [InlineData(100, 3)]
    [InlineData(1234, 4)]
    public void BlazorFastRollingNumber_CorrectDigitCount(int value, int expectedDigits)
    {
        // Arrange & Act
        var cut = RenderComponent<BlazorFastRollingNumber>(parameters => parameters
            .Add(p => p.Value, value));

        // Assert
        var digits = cut.FindAll(".bfrn__digit");
        Assert.Equal(expectedDigits, digits.Count);
    }

    [Theory]
    [InlineData(-1, 2)]
    [InlineData(-10, 3)]
    [InlineData(-999, 4)]
    public void BlazorFastRollingNumber_CorrectDigitCountForNegative(int value, int expectedDigits)
    {
        // Arrange & Act
        var cut = RenderComponent<BlazorFastRollingNumber>(parameters => parameters
            .Add(p => p.Value, value));

        // Assert
        var digits = cut.FindAll(".bfrn__digit");
        Assert.Equal(expectedDigits, digits.Count);
    }

    [Fact]
    public void BlazorFastRollingNumber_AnimationTriggersOnValueChange()
    {
        // Arrange
        var cut = RenderComponent<BlazorFastRollingNumber>(parameters => parameters
            .Add(p => p.Value, 100));

        var firstDigit = cut.Find(".bfrn__digit");
        var initialStyle = firstDigit.GetAttribute("style");

        // Act - Change value
        cut.SetParametersAndRender(parameters => parameters
            .Add(p => p.Value, 200));

        // Assert - Style should change (different offset)
        var newStyle = firstDigit.GetAttribute("style");
        Assert.NotEqual(initialStyle, newStyle);
    }

    [Fact]
    public void BlazorFastRollingNumber_NoAnimationWhenValueUnchanged()
    {
        // Arrange
        var cut = RenderComponent<BlazorFastRollingNumber>(parameters => parameters
            .Add(p => p.Value, 100)
            .Add(p => p.MinimumDigits, 5));

        var firstDigit = cut.Find(".bfrn__digit");
        var initialStyle = firstDigit.GetAttribute("style");

        // Act - Change only MinimumDigits, not Value
        cut.SetParametersAndRender(parameters => parameters
            .Add(p => p.Value, 100)
            .Add(p => p.MinimumDigits, 6));

        // Assert - Style should not change (same value)
        var newStyle = firstDigit.GetAttribute("style");
        Assert.Equal(initialStyle, newStyle);
    }

    [Fact]
    public void BlazorFastRollingNumber_SupportsCustomEasing()
    {
        // Arrange & Act
        var cut = RenderComponent<BlazorFastRollingNumber>(parameters => parameters
            .Add(p => p.Value, 123)
            .Add(p => p.Easing, "cubic-bezier(0.4, 0, 0.2, 1)"));

        // Assert
        var wrapper = cut.Find(".bfrn");
        var style = wrapper.GetAttribute("style");
        Assert.Contains("cubic-bezier(0.4, 0, 0.2, 1)", style);
    }

    [Fact]
    public void BlazorFastRollingNumber_SupportsCustomDuration()
    {
        // Arrange & Act
        var cut = RenderComponent<BlazorFastRollingNumber>(parameters => parameters
            .Add(p => p.Value, 123)
            .Add(p => p.Duration, "0.5s"));

        // Assert
        var wrapper = cut.Find(".bfrn");
        var style = wrapper.GetAttribute("style");
        Assert.Contains("0.5s", style);
    }
}

