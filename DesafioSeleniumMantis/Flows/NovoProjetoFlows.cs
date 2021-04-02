using DesafioSeleniumMantis.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Flows
{
    public class NovoProjetoFlows
    {
        #region Page Object and Constructor
        MainPage mainPage;
        GerenciarProjetosPage gerenciarProjetosPage;

        public NovoProjetoFlows()
        {
            mainPage = new MainPage();
            gerenciarProjetosPage = new GerenciarProjetosPage();
        }
        #endregion

        public void IncluirProjeto(string nomeProjeto, string estado,string visibilidade,string descricao)
        {
            mainPage.ClicarEmGerenciar();
            gerenciarProjetosPage.ClicarEmGerenciarProjetos();
            gerenciarProjetosPage.ClicarEmCriarUmNovoProjeto();
            gerenciarProjetosPage.PreencherNomeProjeto(nomeProjeto);
            gerenciarProjetosPage.SelecionarStatus(estado);
            gerenciarProjetosPage.SelecionarVisibilidade(visibilidade);
            gerenciarProjetosPage.PreencherDescricao(descricao);
            gerenciarProjetosPage.ClicarEmAdicionarProjeto();
        }
    }
}
