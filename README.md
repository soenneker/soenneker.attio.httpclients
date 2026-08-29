[![](https://img.shields.io/nuget/v/soenneker.attio.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.attio.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.attio.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.attio.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.attio.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.attio.httpclients/)

# Soenneker.Attio.HttpClients

A .NET thread-safe singleton HttpClient for.

## Install

```bash
dotnet add package Soenneker.Attio.HttpClients
```

## Quick start

```csharp
using Soenneker.Attio.HttpClients.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddAttioOpenApiHttpClientAsSingleton();
```

Adds `AttioOpenApiHttpClient` as a singleton service.

## What you get

- `IAttioOpenApiHttpClient` — A .NET thread-safe singleton HttpClient for.
- `AttioOpenApiHttpClientRegistrar` — Registers the OpenAPI HttpClient wrapper for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `AttioOpenApiHttpClientRegistrar.AddAttioOpenApiHttpClientAsSingleton(services)` | Adds `AttioOpenApiHttpClient` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `AttioOpenApiHttpClientRegistrar.AddAttioOpenApiHttpClientAsScoped(services)` | Adds `AttioOpenApiHttpClient` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
