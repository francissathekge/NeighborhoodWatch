using System.Collections.Generic;

namespace NeighborhoodWatch.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
