# Performance and allocation rules

## Do
- Keep the component **allocation-aware** on the update path.
- Prefer:
  - `Span<T>` / `ReadOnlySpan<T>`
  - `stackalloc`
  - small, bounded caches
- Keep per-update work proportional to the number of rendered characters.

## Don't
- Don't allocate strings in hot paths unless unavoidable.
- Don't allow unbounded inputs (like huge padding) to allocate unbounded buffers.
- Don't micro-optimize code that is not on the render/update path.

