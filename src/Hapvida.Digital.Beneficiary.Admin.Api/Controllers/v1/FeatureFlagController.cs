using System.Net;
using Hapvida.Core.Api.Http.Controllers;
using Hapvida.Core.Api.Http.Models;
using Hapvida.Core.Domain.Contracts;
using Hapvida.Core.Domain.Models;
using Hapvida.Digital.Beneficiary.Admin.Infra.Data.Queries.v1.FeatureFlags.GetFlags;

namespace Hapvida.Digital.Beneficiary.Admin.Api.Controllers.v1;

[Route("api/v1")]
public class FeatureFlagController : BaseController

{
    public FeatureFlagController(IMediator bus, IDomainContextNotifications domainNotificationContext,
        ApplicationSettings settings) : base(bus, domainNotificationContext, settings)
    {
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello World");
    }

    [HttpGet("feature-flags")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetFeatureFlagsAsync(CancellationToken cancellationToken = default)
    {
        return await ExecuteAsync(
            new GetFlagsQuery(),
            StatusCodes.Status200OK, StatusCodes.Status422UnprocessableEntity, cancellationToken);
    }

}