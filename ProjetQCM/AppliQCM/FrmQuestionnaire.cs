using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AppliQCM
{
    public partial class FrmQuestionnaire : Form
    {

        //**********
        // ATTRIBUTS
        //**********

        private string id;

        // Constantes
        private const int LARGEUR_CONTROLES = 300;
        private const int CARACTERES_PAR_LIGNE = 30;
        private const int HAUTEUR_PAR_LIGNE = 19;

        // Va permettre de définir l'emplacement :
        // 		a) Des contrôles créés dans la feuille
        // 		b) D'une nouvelle feuille en fonction du nombre et 
        // 		de la taille des contrôles qui seront créés dynamiquement
        //
        // Remarque : la structure "Point" représente une paire 
        // ordonnée de coordonnées x et y entières qui définit 
        // un point dans un plan à deux dimensions.
        private Point emplacement = new Point(10, 10);

        // Document XML associé
        private XmlDocument xr;

        // Titre de la feuille
        private string titre;


        //*************
        // CONSTRUCTEUR
        //*************
        public FrmQuestionnaire(string docXML, Form fenMere)
        {
            InitializeComponent();
            // Associer cette feuille fille à la fenêtre mère
            this.MdiParent = fenMere;

            // Remplir le questionnaire à partir du document XML
            CreerAPartirXML(docXML);
        }

        //***********
        // ACCESSEURS
        //***********

        // Retourne ou modifie la propriété "Height" de la feuille
        private int LaHauteur
        {
            get { return this.Height; }
            set { this.Height = value; }
        }

        // Retourne ou modifie la propriété "Width" de la feuille
        private int Largeur
        {
            get { return this.Width; }
            set { this.Width = value; }
        }

        // Retourne une COLLECTION des CONTROLES graphiques figurant sur la feuille
        private Control.ControlCollection TousLesControles
        {
            get { return this.Controls; }
        }

        // Retourne ou modifie la propriété privée "Titre", et dans ce dernier cas, 
        // la propriété "Text" de la feuille est renseignée.
        private string LeTitre
        {
            get { return titre; }

            set
            {
                titre = value;
                this.Text = titre;
            }
        }

        //**********
        //  METHODES
        //**********

        //---------------------------------------------------------
        // Création dynamique des contrôles sur la feuille à partir
        //  du contenu d'un document XML représentant un QCM
        //---------------------------------------------------------
        private void CreerAPartirXML(string doc)
        {
            // Accesseur
            this.LeTitre = "Questionnaire";

            // Appel de l'accesseur 'TousLesControles' pour récupérer la collection de  
            // contrôles sur la feuille
            Control.ControlCollection lesControles = this.TousLesControles;

            // Initialisation de l'emplacement
            emplacement = new Point(10, 10);

            // Creation d'un document XML qui servira à remplir la nouvelle feuille
            xr = new XmlDocument();
            xr.Load(doc);

            // Sélectionne le premier noeud (ici : <questionnaire>) et récupère la valeur
            // de son attribut "name" 

            if (xr.SelectSingleNode("questionnaire") == null || xr.GetElementsByTagName("question") == null)
                ShowXmlError();

            else
            {
                string premierNoeud = xr.SelectSingleNode("questionnaire").Attributes["name"].Value;
                id = xr.SelectSingleNode("questionnaire").Attributes["cle"].Value;

                // Initialise la propriété "Titre" de la nouvelle feuille à partir de la valeur
                // de l'attribut "displayName" 
                this.LeTitre = xr.SelectSingleNode("questionnaire").Attributes["displayName"].Value;

                // Création d'une collection ordonnée de noeuds <question>
                XmlNodeList lesNoeuds;
                lesNoeuds = xr.GetElementsByTagName("question");

                // Parcours de l'ensemble des noeuds <question> présents dans la collection
                foreach (XmlNode unNoeud in lesNoeuds)
                {
                    if (unNoeud.Attributes != null)
                    {
                        // Détermine le type du contrôle à créer.
                        // Le type est spécifié dans l'attribut "type" : <question type= ... >
                        // Suivant le type de contrôle, une procédure "Add..." est
                        // appelée. Les paramètres sont les suivants :
                        // 		a) L'objet noeud <question> en cours
                        // 		b) La collection de contrôles de la feuille
                        // 		c) L'emplacement (coordonnées X et Y)
                        //		d) L'objet premier noeud du document XML (<questionnaire>)
                        switch (unNoeud.Attributes["type"].Value)
                        {
                            case "text":
                                emplacement = AddTextBox(unNoeud, lesControles, emplacement, premierNoeud);
                                break;

                            case "combo":
                                emplacement = AddComboBox(unNoeud, lesControles, emplacement, premierNoeud);
                                break;

                            case "liste":
                                emplacement = AddListBox(unNoeud, lesControles, emplacement, premierNoeud);
                                break;

                            default:
                                ShowXmlError();
                                break;

                        }
                    }
                }

                // On spécifie la largeur et la hauteur de la feuille créée dynamiquement.
                // En effet, sa dimension dépend du nombre de contrôles à placer, et par
                // conséquent du contenu du document XML.
                // Un ajustement (de 40) s'avère cependant nécessaire...
                this.Largeur = emplacement.X + LARGEUR_CONTROLES + 40;
                this.LaHauteur = emplacement.Y + 40;

                // Affichage du questionnaire
                this.Show();
            }
        }

        //-----------------------------------------------------------------------------------------
        // Ensemble des méthodes qui, suivant le cas vont ajouter une ComboBox, une ListBox ou 
        // une TextBox à la collection passée en paramètre. 
        //
        // Retournent des coordonnées (X,Y) permettant de définir la dimension de la feuille 
        // qui va contenir ces contrôles...
        //
        // Ces méthodes sont appelées par la méthode "creerAPartirXML" qui crée d'abord
        // dynamiquement une feuille, puis l'ensemble de ses contrôles, et ceci à partir des 
        // données d'un document XML (un contrôle par noeud <question>)
        //
        // Les paramètres sont les suivants :
        // 	a) L'objet noeud <question> en cours
        // 	b) La collection de contrôles de la feuille
        //	c) L'emplacement (coordonnées X et Y) en cours (permet de placer les nouveaux contrôles)
        //	d) L'objet premier noeud du document XML (<questionnaire>)
        //------------------------------------------------------------------------------------------


        private Point AddTextBox(XmlNode unNoeud, Control.ControlCollection desControles, Point unEmplacement, string tag)
        {
            // Création d'un contrôle TextBox.
            TextBox maTextBox = new TextBox();

            // Il y a-t-il une réponse par défaut ? 
            if (unNoeud.SelectSingleNode("defaultreponse") != null)
                maTextBox.Text = unNoeud.SelectSingleNode("defaultreponse").InnerText;

            // Valeur de l'attribut "name" de la balise <question> en cours
            if (unNoeud.Attributes["name"] != null)
                maTextBox.Name = unNoeud.Attributes["name"].Value;

            maTextBox.Tag = tag;
            maTextBox.Width = LARGEUR_CONTROLES;

            // Il y a-t-il un nombre maximal de caractères ? 
            if (unNoeud.SelectSingleNode("maxCharacters") != null)
                maTextBox.MaxLength = int.Parse(unNoeud.SelectSingleNode("maxCharacters").InnerText);

            // Calculer le nombre de lignes qui devront être affichées
            if (maTextBox.MaxLength > 0)
            {
                int numLines = (maTextBox.MaxLength / CARACTERES_PAR_LIGNE) + 1;

                // Calculer la largeur de la TextBox, et par conséquent s'il y a lieu
                // d'avoir des barres de défilement
                if (numLines == 1)
                    maTextBox.Multiline = false;
                else
                {
                    if (numLines >= 4)
                    {
                        maTextBox.Multiline = true;
                        maTextBox.Height = 4 * HAUTEUR_PAR_LIGNE;
                        maTextBox.ScrollBars = ScrollBars.Vertical;
                    }
                    else
                    {
                        maTextBox.Multiline = true;
                        maTextBox.Height = numLines * HAUTEUR_PAR_LIGNE;
                        maTextBox.ScrollBars = ScrollBars.None;
                    }
                }
            }

            // Création d'un Label
            Label monLabel = new Label();
            monLabel.Name = maTextBox.Name + "Label";
            if (unNoeud.SelectSingleNode("text") != null)
                monLabel.Text = unNoeud.SelectSingleNode("text").InnerText;

            monLabel.Width = LARGEUR_CONTROLES;

            // Ajout à la collection
            monLabel.Location = unEmplacement;
            desControles.Add(monLabel);
            unEmplacement.Y += monLabel.Height;

            maTextBox.Location = unEmplacement;
            desControles.Add(maTextBox);
            unEmplacement.Y += maTextBox.Height + 10;

            return unEmplacement;
        }

        /// <summary>
        /// Crée une liste déroulante à partir de données XML et l'ajoute aux contrôles du formulaire
        /// </summary>
        /// <param name="unNoeud">Le noeud contenant les données de la liste</param>
        /// <param name="desControles">La liste des contrôles du fomrulaire</param>
        /// <param name="unEmplacement">La position de la liste déroulante</param>
        /// <param name="tag">L'attribut name du premier noeud du fichier XML</param>
        /// <returns></returns>
        private Point AddComboBox(XmlNode unNoeud, Control.ControlCollection desControles, Point unEmplacement, string tag)
        {
            //Création un objet ComboBox et on lui donne le nom de l'attriut name du noeud
            ComboBox unComboBox = new ComboBox();
            if (unNoeud.Attributes["name"] != null)
                unComboBox.Name = unNoeud.Attributes["name"].Value;

            unComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            unComboBox.Tag = tag;
            unComboBox.Width = LARGEUR_CONTROLES;

            //Création d'un objet Label
            Label unLabel = new Label();
            unLabel.Name = unComboBox.Text + "Label";

            //Il y a t-il une question à poser ?
            string question = unNoeud.SelectSingleNode("text").InnerText;
            unLabel.Text = question != null ? question : "";
            unLabel.Width = LARGEUR_CONTROLES;

            //Remplissage du ComboBox
            XmlNodeList lesReponses = unNoeud.SelectSingleNode("reponses").SelectNodes("reponse");
            foreach (XmlNode laReponse in lesReponses)
            {
                unComboBox.Items.Add(laReponse.InnerText);
                //Est-ce que la réponse est la réponse par défaut ?
                if (laReponse.Attributes["default"].Value == "true")
                    unComboBox.SelectedItem = laReponse.InnerText;
            }

            //Positionnement du Label
            unLabel.Location = unEmplacement;
            desControles.Add(unLabel);
            unEmplacement.Y += unLabel.Height;

            //Positionnement du ComboBox
            unComboBox.Location = unEmplacement;
            desControles.Add(unComboBox);
            unEmplacement.Y += unComboBox.Height + 10;

            //Retourne la position du prochain Contrôle du formulaire
            return unEmplacement;
        }

        /// <summary>
        /// Crée une liste à choix multiples à partir de données XML et l'ajoute aux contrôles du formulaire
        /// </summary>
        /// <param name="unNoeud">Le noeud contenant les données de la liste</param>
        /// <param name="desControles">La liste des contrôles du fomrulaire</param>
        /// <param name="unEmplacement">La position de la liste déroulante</param>
        /// <param name="tag">L'attribut name du premier noeud du fichier XML</param>
        /// <returns></returns>
        private Point AddListBox(XmlNode unNoeud, Control.ControlCollection desControles, Point unEmplacement, string tag)
        {
            //Création un objet ListBox et on lui donne le nom de l'attriut name du noeud
            ListBox uneListBox = new ListBox();
            if (unNoeud.Attributes["name"] != null)
                uneListBox.Name = unNoeud.Attributes["name"].Value;

            uneListBox.SelectionMode = SelectionMode.MultiSimple;
            uneListBox.Tag = tag;
            uneListBox.Width = LARGEUR_CONTROLES;

            //Création d'un objet Label
            Label unLabel = new Label();
            unLabel.Name = uneListBox.Text + "Label";

            //Il y a t-il une question à poser ?
            string question = unNoeud.SelectSingleNode("text").InnerText;
            unLabel.Text = question != null ? question : "";
            unLabel.Width = LARGEUR_CONTROLES;

            //Remplissage du ListBox
            XmlNodeList lesReponses = unNoeud.SelectSingleNode("reponses").SelectNodes("reponse");
            foreach (XmlNode laReponse in lesReponses)
            {
                uneListBox.Items.Add(laReponse.InnerText);
                //Est-ce que la réponse est validée par défaut ?
                if (laReponse.Attributes["default"].Value == "true")
                    uneListBox.SelectedItem = laReponse.InnerText;
            }

            //Positionnement du Label
            unLabel.Location = unEmplacement;
            desControles.Add(unLabel);
            unEmplacement.Y += unLabel.Height;

            //Positionnement du ListBox
            uneListBox.Location = unEmplacement;
            desControles.Add(uneListBox);
            unEmplacement.Y += uneListBox.Height + 10;

            //Retourne la position du prochain Contrôle du formulaire
            return unEmplacement;
        }

        private void ShowXmlError()
        {
            MessageBox.Show("Le fichier XML n'est pas compatible avec l'application", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }

        public List<string> GetContent()
        {
            List<string> lesReponses = new List<string>();

            lesReponses.Add(id);

            foreach (Control leControle in this.Controls)
            {
                if (leControle is TextBox)
                    lesReponses.Add($"{leControle.Name} -  {leControle.Text}");

                if (leControle is ComboBox)
                {
                    ComboBox leComboBox = (ComboBox)leControle;
                    lesReponses.Add($"{leControle.Name} - {leComboBox.SelectedItem}");
                }

                if (leControle is ListBox)
                {
                    ListBox laListBox = (ListBox)leControle;
                    foreach (var unObjet in laListBox.SelectedItems)
                        lesReponses.Add($"{leControle.Name} - {unObjet}");
                }
            }
            return lesReponses;
        }
    }
}
