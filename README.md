[![](https://img.shields.io/nuget/v/soenneker.attio.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.attio.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.attio.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.attio.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.attio.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.attio.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.attio.httpclients/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.attio.httpclients/actions/workflows/codeql.yml)

# Soenneker.Attio.HttpClients

A DI-ready, cached `HttpClient` configured for authenticated requests to the Attio API.

## Installation

```bash
dotnet add package Soenneker.Attio.HttpClients
```

## Configuration

Add the API key to your configuration:

```json
{
  "Attio": {
    "ApiKey": "your-attio-access-token"
  }
}
```

Requests use `https://api.attio.com` and this authentication header by default:

```text
Authorization: Bearer {ApiKey}
```

For a compatible proxy or alternate authentication scheme, set `Attio:ClientBaseUrl`, `Attio:AuthHeaderName`, or `Attio:AuthHeaderValueTemplate`. The value template must contain `{token}` if the API key should be inserted.

## Registration and use

```csharp
using Soenneker.Attio.HttpClients.Abstract;
using Soenneker.Attio.HttpClients.Registrars;

builder.Services.AddAttioOpenApiHttpClientAsSingleton();

public sealed class AttioService(IAttioOpenApiHttpClient clientProvider)
{
    public async Task<string> GetCurrentTokenInfo(CancellationToken cancellationToken)
    {
        HttpClient client = await clientProvider.Get(cancellationToken);
        return await client.GetStringAsync("/v2/self", cancellationToken);
    }
}
```

Use `AddAttioOpenApiHttpClientAsScoped()` when the wrapper itself should be scoped. Both registrations use the shared HTTP client cache underneath.

## Behavior

- `Get()` returns the cached `HttpClient`; it does not create a client per request.
- The cache key is shared by all `AttioOpenApiHttpClient` instances in the process.
- Configuration is applied when the cached client is first created. Changing configuration afterward does not rebuild it.
- Disposing the wrapper removes and disposes its named client from the shared cache. Avoid disposing a wrapper obtained from DI manually.
- A missing `Attio:ApiKey` causes client creation to fail instead of producing an unauthenticated client.

For the generated, strongly typed Attio API surface, use `Soenneker.Attio.OpenApiClient` or the DI-oriented `Soenneker.Attio.OpenApiClientUtil` package.
