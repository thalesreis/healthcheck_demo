using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace healthcheck
{
    public class CheckWebserviceHealthStatus : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            //Variável boolean para receber o resultado das verificações
            bool healthStatus = true;

            try
            {
                throw new Exception("Falha na conexão com o webservice de consulta de valores.");
                if (healthStatus)
                {
                    return Task.FromResult(
                        HealthCheckResult.Healthy("Tudo parece OK com o webservice de consulta de valores"));
                }
            }
            catch (System.Exception e)
            {
                var infoData = new Dictionary<string, object>()
                {
                    { "info", new { Source = e.Source, Stack = e.StackTrace } },
                    { "tries", 5 },
                    { "last_activity", DateTime.Now.AddDays(-10) }
                };                
                return Task.FromResult(
                    HealthCheckResult.Unhealthy(e.Message, e, infoData));
            }
        }
    }
}