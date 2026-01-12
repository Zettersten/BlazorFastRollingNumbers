# Architecture overview

## Solution layout
- **`BlazorFastRollingNumbers/`**: the NuGet library containing the component and supporting types.
- **`BlazorFastRollingNumbers.Demo/`**: demo site (Blazor WebAssembly).
- **`BlazorFastRollingNumbers.Tests/`**: bUnit + xUnit tests.

## Component design
- **Rendering**: `BlazorFastRollingNumber` renders one “digit column” per character (digits + minus + padding).
- **State updates**: `OnParametersSet()` computes a bounded array of `DigitData` and the markup renders it.
- **Animation**: CSS transitions translate a stacked 0–9 and '-' column using a per-digit `--digit-offset` CSS custom property.

## Demo site design
- Single landing page that showcases:
  - value updates (click + random)
  - timing and easing changes
  - styling via CSS variables/classes
  - accessibility usage patterns

## Solutions files
- **`BlazorFastRollingNumbers.sln`**: traditional solution file.
- **`BlazorFastRollingNumbers.slnx`**: modern solution format generated via `dotnet sln migrate`.

