# Testing rules

## Do
- Keep tests **deterministic** and independent.
- Prefer asserting on:
  - rendered DOM structure
  - parameter-driven behavior
  - edge cases
- Use bUnit patterns compatible with current versions.

## Don't
- Don't test browser animation timing details in unit tests.
- Don't assert fragile implementation details that prevent refactoring.

