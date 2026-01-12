# Testing philosophy

## What we test
- **Rendered markup shape**: correct number of digit columns, presence of required CSS classes.
- **Parameter effects**: value changes update offsets; `MinimumDigits` affects column count; custom `Duration` and `Easing` appear in styles.
- **Edge cases**: `0`, negative values, `int.MaxValue`, `int.MinValue`.

## What we avoid testing
- Browser-level animation behavior (timing, frame-by-frame): that belongs to E2E/visual tests.
- Implementation details that make refactoring hard without increasing confidence.

## Determinism rules
- Avoid time-based assertions.
- If randomness is used in demos, tests should not rely on random values.

