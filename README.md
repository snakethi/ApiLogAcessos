# ApiLogAcessos
Aplicação de Controle de Acessos ao Site e Cadastro de Usuários para Acesso

O Projeto esta separado a seguint forma :
--ApiLogAcessos (API que faz as requisições que o site pede)
--DnConnection(Biblioteca que faz a conexão com o Banco de Dados SQL Server)
--LocalDb(Projeto que é replica do Banco de Dados, e pode ser usado para criar o Bando no SQL Server)
--LocalDBInterfaces(Contem as Inferfaces do Banco LocalDb)
--LocalDBModels(Contem as Classes que representam as Tabelas do Banco de Dados, e Retornos de Procedures)
--Services(Biblioteca com Classes de Crypitografia, e Criação de Log da Requisições a API)
--WEBAplication(Site para Controlar os Usuarios, e Ver os Logs de Acesso ao mesmo)

Para rodar o projeto sera necessario fazer :

1- Usar o LocalDb para poder migrar o banco para seu SQL Server.
2- No Projeto ApiLogAcessos no arquivo Web.config deve ser mudadas as keys 01(servidor SQL server), 03(Usuario do Banco de Dados), 
e 04(Senha do Usuario), as tres Keys estão criptografadas , rodando o proprio projeto ApiLogAcessos, e usando o Swagger você pode usar 
os EndPoints Cry, GET CryString, para criptografar, e alterar as Keys de conexao com o banco.
3- No WEBAplication no arquivo Web.congif a key 01, deve ser coloca do o caminho do servidor que vai ficar o arquivo XML para ser 
feito o download pelo usuario do site.
4- No WEBAplication no arquivo Web.congif a key 02, deve ser coloca a URL da ApiLogAcessos para fazer a comunicação com a API.
5- Para funcionar o site deve ser rodado primeiro o Projeto ApiLogAcessos, para a Api estar disponivel para acesso, e depois rodar
o site pelo Projeto WEBAplocation.
6- Logo na tela inicial foi colocado um botão de cadastro para facilitar entrar no site para teste.

Qualquer duvida so entrar em contado que ajudo.
Abraço Thiago

