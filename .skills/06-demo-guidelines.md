# Demo guidelines

## Goals
- Show **realistic, common** usage patterns with minimal code.
- Demonstrate customization via **CSS variables** and **parameters**.
- Keep interactions simple and self-explanatory.

## Patterns to demonstrate
- **Dashboard metric** (rapid updates): recommend debouncing/throttling externally if needed.
- **Scores/counters** (click-to-increment).
- **Negative values** (temperature / deltas).
- **Accessibility**: `AriaLabel` and optional `AriaLive`.

## Anti-patterns to avoid
- Hiding important usage behind complex helper code.
- Adding unrelated UI frameworks just for the demo.

