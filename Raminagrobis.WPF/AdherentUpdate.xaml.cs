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
    /// Logique d'interaction pour AdherentUpdate.xaml
    /// </summary>
    public partial class AdherentUpdate : Page
    {
        #region AdherentUpdate
        public AdherentUpdate(Raminagrobis.API.Client.Adherent_DTO adherent)
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

        #region BtnUpdate
        public void BtnUpdate(object sender, RoutedEventArgs e)
        {
            var apiclient = new AdherentsClient("https://localhost:44345", new HttpClient());
            Raminagrobis.API.Client.Adherent_DTO adherent = new Raminagrobis.API.Client.Adherent_DTO()
            {
                Societe = this.UpdateSociete.Text,
                Civilite = Boolean.Parse(this.UpdateCivilite.Text),
                Nom = this.UpdateNom.Text,
                Prenom = this.UpdatePrenom.Text,
                Email = this.UpdateEmail.Text,
                Date_adhesion = DateTimeOffset.Parse(this.UpdateDate.Text),
                Actif = Boolean.Parse(this.UpdateActif.Text)
               

            };

            apiclient.PUTAsync(Int32.Parse(this.ID.Text), adherent);
        }
        #endregion

        private void UpdateDate_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
