using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Raminagrobis.API.Client;
using Raminagrobis.DTO.DTO;

namespace Raminagrobis.WPF
{
    /// <summary>
    /// Logique d'interaction pour Adherents.xaml
    /// </summary>
    public partial class AdherentDelete : Page
    {
        #region InitializeComponent
        public AdherentDelete(Raminagrobis.API.Client.Adherent_DTO adherent)
        {
            InitializeComponent();
            this.UpdateSociete.Text = adherent.Societe;
            this.UpdateCivilite.Text = adherent.Civilite.ToString();
            this.UpdateNom.Text = adherent.Nom;
            this.UpdatePrenom.Text = adherent.Prenom;
            this.UpdateEmail.Text = adherent.Email;
            this.UpdateActif.Text = adherent.Actif.ToString();
            this.ID.Text = adherent.ID.ToString();
            this.UpdateDate.Text = adherent.Date_adhesion.ToString();
        }
        #endregion


        #region BtnAdherentDelete
        public void BtnSupprimer(object sender, RoutedEventArgs e)
        {
   
            var apiclient = new AdherentsClient("https://localhost:44345", new HttpClient());

            apiclient.DELETEAsync(Int32.Parse(this.ID.Text));
       
        }
        #endregion
    }
}