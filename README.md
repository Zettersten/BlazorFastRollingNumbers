# Blazor Fast Rolling Numbers

[![NuGet](https://img.shields.io/nuget/v/BlazorFastRollingNumbers.svg)](https://www.nuget.org/packages/BlazorFastRollingNumbers/)

Blazor Fast Rolling Numbers is a high-performance animated counter component for Blazor inspired by [`@layflags/rolling-number`](https://www.npmjs.com/package/@layflags/rolling-number). It delivers smooth, CSS-powered rolling number animations while embracing .NET's ahead-of-time (AOT) compilation and aggressive trimming so your applications remain lean without sacrificing fidelity.

> **Why another rolling counter?** Because shipping to WebAssembly or native ahead-of-time targets demands components that are deterministic, trimming safe, and optimized from the first render. Blazor Fast Rolling Numbers was built from the ground up with those goals in mind.

## Live Demo

🚀 **[View the interactive demo](https://zettersten.github.io/BlazorFastRollingNumbers/)**

## Highlights

- ⚡ **Pure CSS animations.** Smooth transitions using CSS transforms and custom properties—no JavaScript for animation logic.
- 🪶 **Trimming-friendly by design.** The library is marked as trimmable, ships without reflection, and has analyzers enabled so you can confidently publish with `PublishTrimmed=true`.
- 🚀 **AOT ready.** Validated against Native AOT constraints with `EnableAOTAnalyzer` enabled.
- 🎯 **Zero-allocation rendering.** Uses `Span<T>`, `stackalloc`, and aggressive inlining for minimal GC pressure.
- 🧭 **Deterministic layout.** No runtime measurements or JavaScript observers—just predictable, fast rendering.
- 🧩 **Composable.** Supports positive/negative integers, custom durations, easing functions, and minimum digit padding

## Getting Started

### Installation

Install the package from NuGet:

```bash
dotnet add package BlazorFastRollingNumbers
```

### Setup

**1. Configure your Blazor app** in `Program.cs`:

For **Blazor WebAssembly**:
```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
// ... rest of your configuration
await builder.Build().RunAsync();
```

For **Blazor Server** or **Blazor Web App**:
```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents(); // If using WebAssembly interactivity
```

**2. CSS is automatically included** via Blazor's static web assets system. The component's styles (`BlazorFastRollingNumber.razor.css`) are bundled and served automatically—no manual link tags required.

**3. Import the namespace** in your `_Imports.razor`:
```razor
@using BlazorFastRollingNumbers
```

### Usage

**Basic example:**

```razor
@page "/counter"
@using BlazorFastRollingNumbers

<BlazorFastRollingNumber Value="12345" />
```

**With custom styling:**

```razor
<BlazorFastRollingNumber 
    Value="@currentScore" 
    Duration="0.5s" 
    EasingFunction="cubic-bezier(0.4, 0, 0.2, 1)"
    CssClass="score-counter" />
```

Add some styling:

```css
.score-counter {
    --bfrn-font-family: 'Inter', sans-serif;
    --bfrn-font-size: 3rem;
    --bfrn-font-weight: 700;
    --bfrn-color: #3b82f6;
}
```

**Reactive counter:**

```razor
<BlazorFastRollingNumber Value="@counter" MinimumDigits="5" />
<button @onclick="() => counter++">Increment</button>

@code {
    private int counter = 0;
}
```

## Production Builds with Trimming & AOT

Blazor Fast Rolling Numbers is validated with trimming analyzers and Native AOT so you can ship the smallest possible payloads. When publishing your application run:

```bash
dotnet publish -c Release
```

The component is fully compatible with:
- `PublishTrimmed=true`
- `TrimMode=link`
- `RunAOTCompilation=true`

## Props

| Parameter | Type | Default | Description |
| :-------- | :--- | :------ | :---------- |
| `Value` | `int` | *required* | The number to display (supports positive and negative integers). |
| `MinimumDigits` | `int` | `0` | Minimum number of digits to display (pads with zero-width spaces). |
| `Duration` | `string` | `"1s"` | CSS transition duration (e.g., "0.5s", "500ms"). |
| `EasingFunction` | `string` | `"ease"` | CSS easing function (e.g., "ease-in-out", "cubic-bezier(0.4, 0, 0.2, 1)"). |
| `CssClass` | `string?` | `null` | Additional CSS class names for the container element. |

## Styling with CSS Variables

The component exposes CSS variables for easy customization:

```css
.my-counter {
    --bfrn-font-family: 'Courier New', monospace;
    --bfrn-font-size: 2rem;
    --bfrn-line-height: 2.5rem;
    --bfrn-font-weight: 700;
    --bfrn-color: #ff0000;
}
```

Or set global defaults:

```css
:root {
    --bfrn-font-family: 'Inter', sans-serif;
    --bfrn-font-size: 1.5rem;
    --bfrn-color: currentColor;
}
```

By default, the component inherits font styles from its parent

## Accessibility & Performance Tips

- Keep `Duration` within a comfortable range (0.3s–1s) for readability.
- The component automatically respects `prefers-reduced-motion` to disable animations for users who request it.
- Use semantic markup around the component and provide context (e.g., "Score: ") for screen readers.
- For rapidly changing values, consider debouncing updates to reduce render frequency.

## Testing

The solution includes automated BUnit tests covering:
- Positive/negative numbers and zero
- Minimum digit padding
- Edge cases (int.MaxValue, int.MinValue)
- Animation triggering on value changes
- Custom duration and easing
- CSS class structure

Run them locally with:

```bash
dotnet test
```

## License

MIT
