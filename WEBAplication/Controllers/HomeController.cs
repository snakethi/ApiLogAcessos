using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using WEBAplication.Models;
using System.Net.Http.Json;
using Services;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Web;
using System.Configuration;

namespace WEBAplication.Controllers
{
    public class HomeController : Controller
    {
        //Limite de Registros por Pagina da Grid
        private static int limiteGrid = 6;
        //Numeros de Paginação que a Grid vai ter
        private static int numeroMarcadores = 0;
        //Qual o Primeiro Registro da Grid na Pagina
        private static int ComeçoGrid = 0;
        //Qual o Ultimo Registro da Grid na Pagina
        private static int FimGrid = 0;
        //Qual a Pagina que o Usuario está
        private static int PaginaAtual = 0;
        //Total Registros LogAcesso , Controla Botoes de XML e Grafico
        private static int TotalLogAcesso = 0;

        //URL da API 
        string Baseurl = ConfigurationSettings.AppSettings["02"].ToString();

        public async Task<ActionResult> Index()
        {

            //Variaveis responsaveis por:
            //Fazer botão circular com a primeira Letra do nome
            //Pegar o nome do Usuario Logado
            //Pegar o login do usuario logado
            //Pegar a Id do usuario logado
            ViewBag.Letra = HttpContext.Session[0].ToString().Substring(0, 1);
            ViewBag.Nome = HttpContext.Session[0].ToString();
            ViewBag.Login = HttpContext.Session[1].ToString();
            ViewBag.ID = HttpContext.Session[2].ToString();
            ViewBag.ADM = Convert.ToBoolean(HttpContext.Session[3]);


            //Pega todos os usuarios cadastrados para preencher o combo para pesquisa
            //E set os ViewBag com valores para os Partiais de Controle de Usuarios e LogAcesso
            List<DadosUsuario> dadosUsuario = new List<DadosUsuario>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{Baseurl}GetAllUser"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    dadosUsuario = JsonConvert.DeserializeObject<List<DadosUsuario>>(apiResponse);
                }

                //Carrega a Grid da View de Controle de Usuarios e Combo de usuarios da Pagina Controle de Usuarios
                ViewBag.ADMGrid = dadosUsuario;
                //Função que calcula a paginação da Grid
                CalculaPagGrid(dadosUsuario.Count, 1);
                //Variavel para o Numero de Paginas que vai ter a Paginação do Controle de Usuarios
                ViewBag.NumeroMarcadoresUser = 0;
                //Qual o Primeiro Registro da Grid Paginada do Controle de Usuarios
                ViewBag.ComeçoGridUser = 0;
                //Qual o Ultimo Registro que vai ser mostrado na Grid Paginada do Controle de Usuarios
                ViewBag.FimGridUser = 0;
                //Qual a Pagina que esta selecionada do Controle de Usuarios
                ViewBag.PaginaUser = 0;

            }

            List<DadosLogAcesso> dadosLogAcesso = new List<DadosLogAcesso>();
            //Carrega a Grid da View de LogAcesso 
            ViewBag.LogAcessoGrid = dadosLogAcesso;
            //Função que calcula a paginação da Grid
            CalculaPagGrid(dadosLogAcesso.Count, 1);
            //Variavel para o Numero de Paginas que vai ter a Paginação do LogAcesso
            ViewBag.NumeroMarcadores = 0;
            //Qual o Primeiro Registro da Grid Paginada do LogAcesso
            ViewBag.ComeçoGridLogAcesso = 0;
            //Qual o Ultimo Registro que vai ser mostrado na Grid Paginada do LogAcesso
            ViewBag.FimGridLogAcesso = 0;
            //Qual a Pagina que esta selecionada do LogAcesso
            ViewBag.Pagina = 0;


            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult _Login()
        {
            return View();
        }

        public ActionResult _Cadastro()
        {
            return View();
        }

        public async Task<ActionResult> Logar(string Login, string Senha)
        {

            //Pega o IP da Pessoa que Logar no Site
            string userip = Request.UserHostAddress;
            if (Request.UserHostAddress != null)
            {
                Int64 macinfo = new Int64();
                string macSrc = macinfo.ToString("X");
                //Verificar se o Usuario é Local
                if (macSrc == "0")
                {
                    if (userip == "127.0.0.1")
                    {
                        userip = "localhost";
                    }
                    else
                    {
                        userip = "localhost";
                    }
                }
            }

            //Muda os pontos para traço para mandar o Ip para API
            userip = userip.Replace(".", "-");

            //Criptografa a senha do Usuario para mandar para API
            Senha = Cry.sha256(Senha);

            bool resposta;

            //Processo responsavel por verificar se a Senha e o Usuario estão cadastrados no Banco
            //E retornar verdadeiro ou falso para o função javascript
            List<DadosUsuario> Dados = new List<DadosUsuario>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{Baseurl}LoginSis/{Login},{Senha},{userip}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Dados = JsonConvert.DeserializeObject<List<DadosUsuario>>(apiResponse);
                }

                if (Dados.Count != 0)
                {
                    //Adiciona na Seção os dados do Usuario para poder ser suados pelo site
                    HttpContext.Session.Add("Nome", Dados[0].Nome);
                    HttpContext.Session.Add("Login", Login);
                    HttpContext.Session.Add("ID", Dados[0].Usuarioid.ToString());
                    HttpContext.Session.Add("ADM", Dados[0].IsAdmin.ToString());
                    resposta = true;
                }
                else
                {
                    resposta = false;
                }


                return Json(resposta);
            }

        }

        public ActionResult Logout()
        {
            //Remove os dados do Usuario da Seção quando deslogar do Sistema
            HttpContext.Session.Remove("Nome");
            HttpContext.Session.Remove("Login");
            HttpContext.Session.Remove("ID");

            return Json(true);

        }

        public async Task<ActionResult> Cadastar(string Nome, string Senha, string Login , bool Check = false)
        {
            
            //Variavel com os dados do Usuario a ser cadastrado que vai ser mando para API
            var postUser = new DadosUsuario
            {
                Usuarioid = 0,
                Nome = Nome,
                Login = Login,
                Senha = Cry.sha256(Senha),
                IsAdmin = Check
            };

            //Processo de Cadastro do Usuario na API retornando o StatusCode para poder dar a mensagem de reposta para o Usuario
            var postRequest = new HttpRequestMessage(HttpMethod.Post, $"{Baseurl}AddUser")
            {
                Content = JsonContent.Create(postUser)
            };
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.SendAsync(postRequest))
                    {
                        response.EnsureSuccessStatusCode();
                        return Json(response.StatusCode);
                    }
                }
            }
            catch
            {
                return Json("");
            }

        }

        public ActionResult _UpdUsuario()
        {
            return View();
        }

        public async Task<ActionResult> UpdUsuario(string Nome, string Senha, string Login, int ID, bool Check = false)
        {
            //Variavel com os dados do Usuario a ser cadastrado que vai ser mando para API
            var postUser = new DadosUsuario
            {
                Usuarioid = ID,
                Nome = Nome,
                Login = Login,
                Senha = Cry.sha256(Senha),
                IsAdmin = Check
            };

            //Processo de Atualização do Usuario na API retornando o StatusCode para poder dar a mensagem de reposta para o Usuario
            var postRequest = new HttpRequestMessage(HttpMethod.Put, $"{Baseurl}UpdUser")
            {
                Content = JsonContent.Create(postUser)
            };
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.SendAsync(postRequest))
                    {
                        response.EnsureSuccessStatusCode();
                        return Json(response.StatusCode);
                    }
                }
            }
            catch
            {
                return Json("");
            }

        }

        public ActionResult _ADMUsuarios()
        {

            return View();
        }

        public async Task<ActionResult> _ADMUsuariosGrid(int Pagina = 1)
        {
            //Processo para Carregara os Dados da View de Controle de Usuarios
            List<DadosUsuario> dadosUsuario = new List<DadosUsuario>();

            using (var httpClient = new HttpClient())
            {
                //Função da API para retornar todos os Usuário Cadastrados
                using (var response = await httpClient.GetAsync($"{Baseurl}GetAllUser"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    dadosUsuario = JsonConvert.DeserializeObject<List<DadosUsuario>>(apiResponse);
                }

                //Carrega a Grid da View de Controle de Usuarios e Combo de usuarios da Pagina Controle de Usuarios
                ViewBag.ADMGrid = dadosUsuario;
                //Função que calcula a paginação da Grid
                CalculaPagGrid(dadosUsuario.Count, Pagina);
                //Variavel para o Numero de Paginas que vai ter a Paginação do Controle de Usuarios
                ViewBag.NumeroMarcadores = numeroMarcadores;
                //Qual o Primeiro Registro da Grid Paginada do Controle de Usuarios
                ViewBag.ComeçoGridUser = ComeçoGrid;
                //Qual o Ultimo Registro que vai ser mostrado na Grid Paginada do Controle de Usuarios
                ViewBag.FimGridUser = FimGrid;
                //Qual a Pagina que esta selecionada do Controle de Usuarios
                ViewBag.Pagina = Pagina;
                PaginaAtual = Pagina;

                return View(ViewBag.ADMGrid);
            }

        }

        public void CalculaPagGrid(int TotalRegistros, int Pagina)
        {
            //Cacula a Paginação e as Variaveis para montar elas 
            //Numero de Paginas que vai ter 
            numeroMarcadores = 0;
            //Qual o Primeiro Registro da Pagina
            ComeçoGrid = 0;
            //Qual o Ultimo Registro da Pagina
            FimGrid = 0;

            //Se o Toltal de Redsitros Menor , coloca os Paginas em 0 e Começo e 0 e Fim no Total de Registros
            if (TotalRegistros < limiteGrid)
            {
                numeroMarcadores = 0;
                ComeçoGrid = 0;
                FimGrid = TotalRegistros;
            }
            else
            {
                //Divide o Total de Registros pelo limite para saber quantas Paginas vai ter
                int cont = TotalRegistros / limiteGrid;
                //Verifica se tem sobras de Registros que não vão entrar na Ultima Pagina
                cont = TotalRegistros - (cont * limiteGrid);

                //Se o cont for diferente que 0 quer dizer que tem uma pagina que não contem o total do Limite de Dados da Grid
                if (cont != 0)
                {
                    //Soma +1 para criar esta Pagina com o Resto dos Registros
                    cont = (TotalRegistros / limiteGrid) + 1;
                }
                else
                {
                    //Se não divide pelo limite que acha a quantidade de Paginas
                    cont = (TotalRegistros / limiteGrid);
                }

                //Coloca a quantidade de Paginas na Variavel responsavel por este controle
                numeroMarcadores = cont;

                //Para saber o Primeiro Registro da Grid pelo o Limite da Grid e faço vezes a Pagina que ele esta 
                //é tirado um 1 pois para que ele pege sempre o Primeiro Registro depois do Ultimo Geristro da Ultima Pagina
                ComeçoGrid = (limiteGrid * (Pagina - 1));
                //Para o Calculo do Fim é simple so somamos o Limite ao Primeiro Registro da Grid
                FimGrid = ComeçoGrid + limiteGrid;

                //É feita esta verificação para se a Ultima Pagina não tem o Total de Registros do Limite
                //Assim Vemos a Diferença para colocar o valor certo na variavel FimGrid
                if (FimGrid > TotalRegistros)
                {
                    int diferença = FimGrid - TotalRegistros;
                    FimGrid = FimGrid - diferença;
                }
            }

        }

        public ActionResult _EditUser()
        {
            return View();
        }

        public async Task<ActionResult> ExcluirUsuario(int ID)
        {
            try
            {
                bool Resultado;

                using (var httpClient = new HttpClient())
                {
                    //Processo de Exclusão do Usuario da Api passado o ID do Usuario 
                    //O Retorno é True ou False para a Operação mas o Status Code
                    using (var response = await httpClient.DeleteAsync($"{Baseurl}DeleteUser/{ID}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Resultado = Boolean.Parse(apiResponse);
                    }

                    return Json(Resultado);
                }
            }
            catch
            {
                return Json(false);
            }

        }

        public ActionResult Oops()
        {
            //Pagina de Erro Padrão do Site
            return View();
        }

        public ActionResult _LogAcesso()
        {

            return View();
        }

        public async Task<ActionResult> _LogAcessoGrid(int Pagina = 1, int Id = 1)
        {

            //Processo da API para pegar todos os Logs de Acesso de um Usuario pelo ID
            List<DadosLogAcesso> dadosLogAcesso = new List<DadosLogAcesso>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{Baseurl}GetAllAcessUserDados/{Id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    dadosLogAcesso = JsonConvert.DeserializeObject<List<DadosLogAcesso>>(apiResponse);
                }

                //Carrega a Grid da View de LogAcesso 
                ViewBag.LogAcessoGrid = dadosLogAcesso;
                //Função que calcula a paginação da Grid
                CalculaPagGrid(dadosLogAcesso.Count, Pagina);
                //Variavel para o Numero de Paginas que vai ter a Paginação do LogAcesso
                ViewBag.NumeroMarcadores = numeroMarcadores;
                //Qual o Primeiro Registro da Grid Paginada do LogAcesso
                ViewBag.ComeçoGridLogAcesso = ComeçoGrid;
                //Qual o Ultimo Registro que vai ser mostrado na Grid Paginada do LogAcesso
                ViewBag.FimGridLogAcesso = FimGrid;
                //Qual a Pagina que esta selecionada do LogAcesso
                ViewBag.PaginaLogAcesso = Pagina;
                //Total Registros LogAcesso , Controla Botoes de XML e Grafico
                TotalLogAcesso = dadosLogAcesso.Count;
                ViewBag.TotalLogAcesso = TotalLogAcesso;
                PaginaAtual = Pagina;

            }

            return View(ViewBag.LogAcessoGrid);

        }

        public ActionResult _Pagination()
        {
            //Controla a Paginação da View de LogAcesso
            //Variavel para o Numero de Paginas que vai ter a Paginação do LogAcesso
            ViewBag.NumeroMarcadores = numeroMarcadores;
            //Qual a Pagina que esta selecionada do LogAcesso
            ViewBag.Pagina = PaginaAtual;
            ViewBag.NumeroMarcadores = numeroMarcadores;
            //Total Registros LogAcesso , Controla Botoes de XML e Grafico
            ViewBag.TotalLogAcesso = TotalLogAcesso;

            return View(ViewBag.NumeroMarcadores);
        }

        public ActionResult _PaginationUser()
        {
            //Controla a Paginação da View de Controle de Usuarios
            //Variavel para o Numero de Paginas que vai ter a Paginação do Controle de Usuarios
            ViewBag.NumeroMarcadoresUser = numeroMarcadores;
            //Qual a Pagina que esta selecionada do Controle de Usuarios
            ViewBag.PaginaUser = PaginaAtual;

            return View();
        }

        public async Task<ActionResult> PegarDadosGrafico(int Id)
        {
            //Processo da APi para Pegar todos os Acessos Por Hora do Dias de um Usuario pelo ID dele
            List<DadosGrafico> dadosGrafico = new List<DadosGrafico>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{Baseurl}GetAllAcessUserbyTime/{Id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    dadosGrafico = JsonConvert.DeserializeObject<List<DadosGrafico>>(apiResponse);
                    return Json(dadosGrafico);
                }
            }
        }

        public async Task<ActionResult> GeraXML(int Id)
        {

            try
            {
                //Processo da APi para Pegar todos os Acessos Por Hora do Dias de um Usuario pelo ID dele
                //Depois é Gerado um arquivo XML que pode ser Baixado pelo Usuario.
                List<DadosLogAcesso> dadosLogAcesso2 = new List<DadosLogAcesso>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync($"{Baseurl}GetAllAcessUserDados/{Id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        dadosLogAcesso2 = JsonConvert.DeserializeObject<List<DadosLogAcesso>>(apiResponse);
                        //Converte um Json em XML
                        var xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(Encoding.ASCII.GetBytes(apiResponse), new XmlDictionaryReaderQuotas()));
                        XmlDocument doc = new XmlDocument();
                        //Transfere os dados do XML convertido para o Documento XML
                        doc.LoadXml(xml.ToString());
                        //Salva na Souce para poder ficar disponivel para Download
                        doc.Save(ConfigurationSettings.AppSettings["01"].ToString() + "Log_Acesso.xml");
                    }
                }



                return Json(true);

            }
            catch
            {
                return Json(false);
            }

        }

    }
}