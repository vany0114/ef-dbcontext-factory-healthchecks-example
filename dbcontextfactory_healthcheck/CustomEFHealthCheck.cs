using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace dbcontextfactory_healthcheck
{
    // TODO: we can make this guy generic.
    public class CustomEFHealthCheck : IHealthCheck
    {
        private readonly Func<MyDbContext> _dbContextFactory;
        
        public CustomEFHealthCheck(Func<MyDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            using (var dbContext = _dbContextFactory())
            {
                if (await dbContext.Database.CanConnectAsync(cancellationToken))
                {
                    return HealthCheckResult.Healthy();
                }

                return HealthCheckResult.Unhealthy();
            }
        }
    }
}
