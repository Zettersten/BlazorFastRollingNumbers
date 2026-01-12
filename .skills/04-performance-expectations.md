# Performance expectations

## Hot paths
- **`OnParametersSet()`** in `BlazorFastRollingNumber`: runs on every parameter update.
- **Render loop**: iterating digit columns and emitting per-digit inline `--digit-offset`.

## Allocation rules of thumb
- Prefer **stackalloc + `TryFormat`** for number-to-chars conversion.
- Avoid generating intermediate strings during updates (especially in `OnParametersSet`).
- Keep internal buffers **bounded** to prevent “accidental O(N)” memory usage from untrusted inputs.

## What to measure when changing performance-sensitive code
- **Render frequency** (how often component re-renders for typical use).
- **Allocations per update** (should remain near zero for typical `Value` changes).
- **DOM size** (digit column count) for common `MinimumDigits` settings.

