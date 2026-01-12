# Versioning and releases

## Versioning
- Use **SemVer**.
- Tag releases as `vMAJOR.MINOR.PATCH`.

## Release process expectations
- CI must pass (restore/build/test).
- Update `CHANGELOG.md` with release notes.
- Ensure NuGet metadata and README match the shipped behavior.

## Preview releases
- Use prerelease identifiers (e.g. `-preview.1`) when publishing experimental changes.

