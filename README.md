# BlazorFastRollingNumbers

A high-performance Blazor component library for animated rolling number transitions, inspired by YouTube's subscriber counter.

## Features

✨ **Pure CSS animations** - Smooth transitions using CSS transforms
🚀 **Extreme performance** - Uses `Span<T>`, `stackalloc`, and aggressive optimizations
🎯 **Zero-allocation rendering** - Minimal GC pressure
📏 **Flexible sizing** - Automatic or fixed digit count
➖ **Negative number support** - Handles positive and negative integers
🧪 **Fully tested** - Comprehensive bUnit test suite

## Live Demo

Try the interactive demo:

```bash
cd BlazorFastRollingNumbers.Demo
dotnet run
```

The demo showcases:
- Interactive playground with random number generator
- Multiple examples (counter, score, easing, temperature)
- Different animation speeds and easing functions
- All component features in action

## Installation

```bash
dotnet add package BlazorFastRollingNumbers
```

## Usage

### Basic Example

Add the component to your Blazor page:

```razor
@using BlazorFastRollingNumbers

<BlazorFastRollingNumber Value="12345" />
```

### With Minimum Digits (Padding)

```razor
<BlazorFastRollingNumber Value="@currentScore" MinimumDigits="5" />
```

### Custom Animation Duration

```razor
<BlazorFastRollingNumber Value="@subscriberCount" Duration="0.5s" />
```

### Custom Easing Function

```razor
<BlazorFastRollingNumber Value="@score" EasingFunction="cubic-bezier(0.4, 0, 0.2, 1)" />
```

### Reactive Updates

```razor
<BlazorFastRollingNumber Value="@counter" />
<button @onclick="() => counter++">Increment</button>

@code {
    private int counter = 0;
}
```

## Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `Value` | `int` | *required* | The number to display (supports positive and negative) |
| `MinimumDigits` | `int` | `0` | Minimum number of digits to display (pads with zero-width spaces) |
| `Duration` | `string` | `"1s"` | CSS transition duration (e.g., "0.5s", "500ms") |
| `EasingFunction` | `string` | `"ease"` | CSS easing function (e.g., "ease-in-out", "cubic-bezier(0.4, 0, 0.2, 1)") |

## How It Works

### CSS-Only Animation

Each digit is rendered as a vertical strip containing all digits (0-9) plus a minus sign. The visible digit is controlled by CSS `transform: translate3d()` based on the `data-value` attribute. When the value changes, CSS transitions smoothly animate the vertical shift.

### Bleeding-Edge CSS Features

The component leverages the latest CSS features for maximum performance:

- **`translate3d()`** - 3D transforms for GPU acceleration
- **`will-change: transform`** - Hints browser to create composite layer
- **`contain: layout style paint`** - CSS containment for rendering isolation
- **`content-visibility: auto`** - Skips rendering off-screen content
- **`overflow: clip`** - Modern alternative to `overflow: hidden`
- **Logical properties** - `inset-inline-start`, `inset-block-end` for RTL support
- **`backface-visibility: hidden`** - Prevents flicker during animation
- **`@media (prefers-reduced-motion)`** - Respects accessibility preferences
- **`@container` queries** - Container-aware responsive design
- **`color-scheme`** - Dark mode support

### Animation Triggering

The component uses a render version tracking system to ensure animations trigger reliably on every value change:

1. Each value change increments an internal `_renderVersion` counter
2. The version is applied as a `data-version` attribute on the wrapper
3. Each digit gets a unique `@key` based on version + index
4. CSS transitions animate the transform when `data-value` changes

This guarantees smooth animations even with rapid value updates.

### Performance Optimizations

- **`stackalloc`**: Number formatting uses stack-allocated buffers (no heap allocation)
- **`Span<T>`**: Zero-copy string operations
- **`TryFormat`**: Direct integer-to-span conversion
- **`MethodImplOptions.AggressiveOptimization`**: JIT hints for performance-critical paths
- **`will-change: transform`**: GPU-accelerated animations
- **`@key` directives**: Stable component identity for optimal Blazor diffing

### Architecture

The component is a single `.razor` file with:
- Inline CSS using scoped styles
- No JavaScript dependencies
- Pure Blazor/C# implementation

## Building and Publishing

### Run Tests

```bash
dotnet test
```

### Build the Package

```bash
dotnet pack -c Release
```

### Publish to NuGet

```bash
dotnet nuget push bin/Release/BlazorFastRollingNumbers.1.0.0.nupkg --source https://api.nuget.org/v3/index.json --api-key YOUR_API_KEY
```

## Development

### Project Structure

```
BlazorFastRollingNumbers/
├── BlazorFastRollingNumbers/          # Component library
│   ├── RollingNumber.razor            # Main component
│   ├── RollingNumber.razor.css        # Scoped styles
│   └── _Imports.razor                 # Shared usings
├── BlazorFastRollingNumbers.Tests/    # bUnit tests
│   └── RollingNumberTests.cs          # Test suite
└── README.md
```

### Testing

The project uses [bUnit](https://bunit.dev/) for component testing:

```bash
dotnet test
```

Tests cover:
- Positive/negative numbers
- Zero handling
- Minimum digit padding
- Value updates
- Edge cases (int.MaxValue, int.MinValue)
- CSS class structure

## Browser Compatibility

Works in all modern browsers that support:
- CSS Transforms
- CSS Transitions
- Flexbox

## License

MIT
