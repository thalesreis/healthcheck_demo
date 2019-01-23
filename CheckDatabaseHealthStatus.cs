using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace healthcheck
{
    public class CheckDatabaseHealthStatus : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            //Variável boolean para receber o resultado das verificações
            bool healthStatus = true;

            /*
                Essa váriavél é do tipo Dictionary onde podemos criar um relação de chave e valor
                para podermos retornar informações úteis para quem quer verificar o status da nossa API
            */
            var infoData = new Dictionary<string, object>()
            {
                { "tabelas_criadas", "true" },
                { "info_db", new { version = 1.00, info_size = 1024, any_value = "anything" } },
                { "last_activity", DateTime.Now }
            };

            /*
                Aqui é onde é feito o retorno da verificação. Se tudo "correu" bem nas verificações
                o valor de "healthStatus" será true
            */            
            if (healthStatus)
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy("Tudo parece OK com o banco de dados.", infoData));
            }

            //Quando healthStatus = false
            return Task.FromResult(
                HealthCheckResult.Unhealthy("Serviço de banco de dados indisponível."));
        }
    }
}