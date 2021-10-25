using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LogRequisicoesApis
    {
        /*Função que Grava Log das Ações Requisitadas pelo Usuario em Qualquer API*/
        public static void GravaLogAcoes(string Path, string Url, string HttpMethod)
        {
            try
            {
                DateTime dt = DateTime.Now;
                string NomeApi = new DirectoryInfo(Path).Parent.Name;
                string Data = dt.Date.ToString().Replace("/", "_").Replace("00:00:00", "");
                string NomeArquivo = $"LOG_{NomeApi}_{Data}.txt";
                Path += NomeArquivo;
                string texto = HttpMethod + " " + Url + " " + dt.ToString();

                StreamWriter Arquivo = new StreamWriter(Path, true, Encoding.ASCII);
                Arquivo.WriteLine(texto);
                Arquivo.Close();
            }
            catch(Exception ex)
            {

            }


        }

    }
}
