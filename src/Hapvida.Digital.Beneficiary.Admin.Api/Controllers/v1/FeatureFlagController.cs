using System.Net;
using Hapvida.Core.Api.Http.Controllers;
using Hapvida.Core.Api.Http.Models;
using Hapvida.Core.Domain.Contracts;
using Hapvida.Core.Domain.Models;
using Hapvida.Digital.Beneficiary.Admin.Infra.Data.Queries.v1.FeatureFlags.GetAll;

namespace Hapvida.Digital.Beneficiary.Admin.Api.Controllers.v1;

[Route("api/")]
public class FeatureFlagController : BaseController

{
    public FeatureFlagController(IMediator bus, IDomainContextNotifications domainNotificationContext,
        ApplicationSettings settings) : base(bus, domainNotificationContext, settings)
    {
    }

    [HttpGet]
    [ProducesResponseType(typeof(Response), 200)]
    [ProducesResponseType(typeof(Response), 400)]
    public async Task<IActionResult> GetByFilter(
        CancellationToken cancellationToken)
    {
        return await ExecuteAsync(new GetAllQuery(), cancellationToken);
    }

}