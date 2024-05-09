using CoucheLogiqueMetier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppliQCM
{
    public partial class FrmAccueil : Form
    {
        //---------------------------------------------
        // Propriétés : fenêtres pouvant être affichées
        //---------------------------------------------
        FrmQuestionnaire fenQuestionnaire;

        public FrmAccueil()
        {
            InitializeComponent();
        }

        private void mnuOuvrir_Click(object sender, EventArgs e)
        {
            try
            {
                // Paramétrage des propriétés de la boîte de dialogue
                openFileDialog1.FileName = "";
                openFileDialog1.InitialDirectory = "d:\\";
                openFileDialog1.Filter = "xml files (*.xml)|*.xml";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                // Ouverture et test du bouton cliqué. Si oui, récupérer le nom du fichier
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string documentXML = openFileDialog1.FileName;
                    // Création et affichage d'un objet de classe "questionnaire"
                    fenQuestionnaire = new FrmQuestionnaire(documentXML, this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Questionnaire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuFermer_Click(object sender, EventArgs e)
        {
            // On recupère la fenêtre fille active
            Form fenFille = this.ActiveMdiChild;
            if (fenFille != null)
                fenFille.Close();
        }

        private void mnuQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuFichier_Click(object sender, EventArgs e)
        {
            if (MdiChildren.Any())
            {
                mnuSeparator.Visible = true;
                mnuValider.Visible = true;
            }

            else
            {
                mnuSeparator.Visible = false;
                mnuValider.Visible = false;
            }
        }

        private void mnuCascade_Click(object sender, EventArgs e) { this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade); }

        private void mnuHorizontale_Click(object sender, EventArgs e) { this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal); }

        private void mnuVerticale_Click(object sender, EventArgs e) { this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical); }

        private void mnuValider_Click(object sender, EventArgs e)
        {
            FrmQuestionnaire activeMdiChild = (FrmQuestionnaire)this.ActiveMdiChild;
            List<string> leContenu = activeMdiChild.GetContent();
            string txt = "";

            string id = leContenu[0].ToString();
            leContenu.RemoveAt(0);

            foreach (string uneReponse in leContenu)
                txt += uneReponse + "\n";

            DialogResult leChoix = MessageBox.Show($"Êtes-vous sûr de vos réponses?\n{txt}", "Confirmation des réponses", MessageBoxButtons.YesNo);

            if (leChoix == DialogResult.Yes)
            {
                activeMdiChild.Close();
                Manager.AddReponses(id, leContenu);
            }

        }
    }
}
