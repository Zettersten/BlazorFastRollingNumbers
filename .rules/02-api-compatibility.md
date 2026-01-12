# API compatibility rules

## Public API is sacred
- Treat `BlazorFastRollingNumber` parameters as **public API**.
- Avoid renaming/changing semantics without:
  - Updating README
  - Updating CHANGELOG
  - Updating demo and tests

## Additive changes preferred
- Prefer adding new optional parameters over breaking existing ones.
- If a parameter must be constrained (e.g., for performance), ensure behavior is:
  - **documented**
  - **test-covered**
  - **non-surprising** (e.g. clamping with clear limits)

