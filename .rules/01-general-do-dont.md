# General do/don't rules

## Do
- Keep changes **small, coherent, and reviewable**.
- Prefer **simple, explicit code** over clever abstractions.
- Maintain **public API stability** unless a breaking change is justified and documented.
- Ensure `dotnet restore`, `dotnet build`, and `dotnet test` pass before merging.

## Don't
- Don't introduce new dependencies unless they materially improve the library.
- Don't add build artifacts or generated output to git (e.g. `bin/`, `obj/`, `.packages/`).
- Don't add JavaScript dependencies for animation (this component is CSS-driven).

