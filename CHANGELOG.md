# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## Unreleased

### Changed
- Updated the solution to target **.NET 10** (`net10.0`).
- Upgraded NuGet dependencies to their latest compatible versions.
- Demo and CI workflows now use **.NET 10**.

### Fixed
- The `Easing` parameter now affects the CSS transition timing function.

### Performance
- Rendering updates reuse a bounded internal digit buffer to keep typical value updates allocation-free.

### Added
- Optional accessibility parameters: `AriaLabel` and `AriaLive`.

