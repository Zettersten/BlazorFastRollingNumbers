# Project purpose

## What this repo is
- **Library**: A standalone **Blazor component** (`BlazorFastRollingNumber`) that renders an animated “rolling number” display using **CSS transforms**.
- **Demo app**: A Blazor WebAssembly site in `BlazorFastRollingNumbers.Demo/` that showcases common usage patterns.
- **Tests**: bUnit + xUnit component tests in `BlazorFastRollingNumbers.Tests/`.

## What this component is optimized for
- **Fast renders**: minimal work in `OnParametersSet` and no per-update string formatting allocations.
- **Deterministic layout**: no JS measurement and no runtime layout probing.
- **Trimming/AOT friendliness**: avoid reflection and dynamic patterns.

## What it is *not*
- A general-purpose numeric formatting library (currency/group separators/locales are handled outside the component).
- A charting/animation framework. This is a focused, small UI primitive.

