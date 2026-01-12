# Public API and behavior

## `BlazorFastRollingNumber` parameters
- **`Value`** (`int`, required): number to display.
- **`MinimumDigits`** (`int`, default `0`): minimum characters to render. Values > 32 are **clamped** to keep work bounded.
- **`Duration`** (`string`, default `"1s"`): CSS transition duration (e.g. `"500ms"`, `"0.5s"`).
- **`Easing`** (`Easing`, default `Easing.Ease`): CSS timing function applied to the transition.
- **`CssClass`** (`string?`): extra class(es) applied to the root container.
- **`AriaLabel`** (`string?`): optional `aria-label` for accessibility (recommended in meaningful contexts).
- **`AriaLive`** (`string?`): optional `aria-live` politeness (e.g. `"polite"`).

## Behavioral guarantees
- **No JS required** for animation or measurement.
- **Stable markup shape**: digit columns are predictable and deterministic.
- **Allocation-aware updates**: internal digit buffer is reused and bounded.

## Non-goals
- No automatic numeric formatting (grouping separators, currency, locale).
- No floating-point support (by design; keep API small and predictable).

