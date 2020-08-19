using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace AtualizacaoTabelasContagemDeVidaService
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<ContagemDeVida>(s =>
                {
                    s.ConstructUsing(contagemVida => new ContagemDeVida());
                    s.WhenStarted(contagemVida => contagemVida.Start());
                    s.WhenStopped(contagemVida => contagemVida.Stop());
                });

                x.RunAsLocalSystem();

                x.SetServiceName("AtualizacaoTabelasContagemDeVidaService");
                x.SetDisplayName("Atualizacao Tabelas Contagem De Vida Service");
                x.SetDescription("Este serviço atualiza tabelas usadas pelo outro serviço de Contagem de Vidas no Importer.");

            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
