using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace CoucheAccesDonnees
{
    public class Passerelle
    {
        // Connexion
        private static MySqlConnection connexion = null;

        /// <summary>
        /// Se connecte à la base de données
        /// </summary>
        /// <returns></returns>
        private static MySqlConnection GetConnexion()
        {
            //Est-ce qu'une connexion existe déjà ?
            if (connexion != null)
                return connexion;

            else
            {
                //Connexion à la base bdTest
                string chConnxion = "SERVER=localhost;DATABASE=bdTest;UID=root;";
                connexion = new MySqlConnection(chConnxion);
                connexion.Open();
                return connexion;
            }
        }

        /// <summary>
        /// Ajoute une liste de réponse dans une base de données
        /// </summary>
        /// <param name="id">L'id du questionnaire</param>
        /// <param name="lesReponses">La liste des réponses du formulaire</param>
        public static void AjouterReponses(string id, List<string> lesReponses)
        {
            //On récupère la date au moment de l'insertion des données
            DateTime dateVal = DateTime.Now;

            //On initialise le rang de chaque réponse
            int rang = 0;

            //Connexion à la base bdTest
            GetConnexion();

            //Pour chaque réponse de la liste
            foreach (string laReponse in lesReponses)
            {
                //Incrémentation du rang de la question
                rang++;

                //Requête d'insertion de l'id du questionnaire, du rang de la réponse, de la date d'insertion des données & la réponse
                string req = "Insert Into Reponses (cle_questionnaire, rang, dateCreation, reponse) Values ('" + id + "', '" + rang + "', @date, '" + laReponse + "')";

                //Ajout de la date dans un format adapté au langage SQL
                MySqlCommand cmd = new MySqlCommand(req, connexion);
                cmd.Parameters.Add("@date", MySqlDbType.DateTime);
                cmd.Parameters["@date"].Value = dateVal;

                //Execution de la requête; la question est inséré dans la base de données
                int res = cmd.ExecuteNonQuery();
            }
        }
    }
}
