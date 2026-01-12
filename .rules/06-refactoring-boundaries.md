# Refactoring boundaries

## Library code (`BlazorFastRollingNumbers/`)
- Refactor freely **internals** to improve correctness, readability, and performance.
- Avoid refactors that change public behavior without a clear user-facing benefit.

## Demo code (`BlazorFastRollingNumbers.Demo/`)
- Keep examples minimal and focused on the library’s API.
- Prefer extracting static sections into small components when a page grows too large.

## Tests (`BlazorFastRollingNumbers.Tests/`)
- Refactor tests to match current frameworks and conventions.
- Remove redundant tests if they do not increase confidence.

