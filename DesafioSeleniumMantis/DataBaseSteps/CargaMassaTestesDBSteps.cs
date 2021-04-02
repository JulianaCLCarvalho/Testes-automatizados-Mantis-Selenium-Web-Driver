using DesafioSeleniumMantis.Helpers;
using DesafioSeleniumMantis.Queries;
using System.IO;
using System.Text;

namespace DesafioSeleniumMantis.DataBaseSteps
{
    public class CargaTestesDBSteps
    {

        public static void InsereMassaDeTestesDB()
        {
            string query = File.ReadAllText(GeneralHelpers.GetProjectPath() + "Queries/InsereMassaTestes.sql", Encoding.UTF8);
            ExtentReportHelpers.AddTestInfo(2, "Insere massas para inciar testes");
            DataBaseHelpers.ExecuteQuery(query);
        }
        public static void deletaProjetosDB()
        {
            string query = File.ReadAllText(GeneralHelpers.GetProjectPath() + "Queries/deletaProjetos.sql", Encoding.UTF8);
            ExtentReportHelpers.AddTestInfo(2, "Deleta registros para inciar testes");
            DataBaseHelpers.ExecuteQuery(query);
        }
    }
}
