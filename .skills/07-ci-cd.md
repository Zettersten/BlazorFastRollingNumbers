# CI/CD overview

## Workflows
- **NuGet build/test/pack/publish**: `.github/workflows/nuget-publish.yml`
  - Runs restore/build/test
  - Packs artifacts
  - Publishes on version tags
- **Demo deploy**: `.github/workflows/deploy-demo.yml`
  - Publishes demo with `BaseHref` for GitHub Pages
  - Deploys pages artifact

## Supported toolchain
- CI uses **.NET 10** (`10.0.x`).

