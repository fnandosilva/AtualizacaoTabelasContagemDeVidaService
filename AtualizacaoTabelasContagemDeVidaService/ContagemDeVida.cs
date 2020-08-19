using Mantris.Acts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace AtualizacaoTabelasContagemDeVidaService
{

    public class ContagemDeVida
    {
        private readonly System.Timers.Timer _timer;
        public static int dia = 26;
        public static int mes = DateTime.Now.Month;
        public static int ano = DateTime.Now.Year;
        public static int hora = DateTime.Now.Hour;
        public static int minuto = DateTime.Now.Minute;
        public static int segundo = DateTime.Now.Second;

        public DateTime dataToBeExecuted = new DateTime(ano, mes, dia, hora, minuto, segundo);

        public ContagemDeVida()
        {
            bool IsTheDateTime = (dataToBeExecuted == DateTime.Now);
            
            //_timer = new System.Timers.Timer(2592000) { AutoReset = true };
            _timer = new System.Timers.Timer(86400) { AutoReset = true };

            if (IsTheDateTime == true)
            {
                _timer.Elapsed += Timer_Elapsed;
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Carregando a tabela Empresa_SocNet.");
            //var listaEmpresaTabela = ContagemDeVidaEmpresaSocNet_.Carregar_Colecao("true");

            Console.WriteLine("Atualizando a tabela Funcionario_Socnet.");
            //ContagemDeVidaFuncionarioSocNet_.Gravar_ColecaoFuncionarios_Exportadados(listaEmpresaTabela, true);

            Console.WriteLine("Atualizando campos que foram adiconados a tabela Funcionario_Socnet.");
            //ContagemDeVidaFuncionarioSocNet_.Atualizar_TodosCampos_TabelaFuncionarios(listaEmpresaTabela);

            Console.WriteLine("Atualizando a tabela Funcionario_Socnet.");
            //ContagemDeVidaFuncionarioMantris_.Gravar_ColecaoFuncionarios_Exportadados(listaEmpresaTabela, mes, ano, true);

        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
