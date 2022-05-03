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
using Microsoft.Win32;
using System.IO;


namespace Raminagrobis.WPF
{
    /// <summary>
    /// Logique d'interaction pour PaniersInsert.xaml
    /// </summary>
    public partial class PaniersInsert : Page
    {
        public string[] files;
        public PaniersInsert()
        {
            InitializeComponent();
        }

        #region LoadPage
        private async void LoadPage(object sender, RoutedEventArgs e)
        {
            var apiclient = new PaniersClient("https://localhost:44345", new HttpClient());
            var panier = await apiclient.AllAsync();

            var apiclientFourni = new AdherentsClient("https://localhost:44345", new HttpClient());
            
            var adherent = await apiclientFourni.AllAsync();

            lvAdherents.ItemsSource = adherent;
        }
        #endregion
        
        #region BtnInsert
        private void BtnInsert(object sender, RoutedEventArgs e)
        {
            /*
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var Adherent = lvAdherents.SelectedItem as Raminagrobis.API.Client.Adherent_DTO;
                var AllLine = File.ReadAllLines(openFileDialog.FileName);
                var length = AllLine.Length;
                for (int i = 1; i < length; i++)
                {
                    var ligne = AllLine[i].Split(';');

                    var apiclient = new CommandeAdherentsClient("https://localhost:44345", new HttpClient());
                    Raminagrobis.API.Client.CommandeAdherent_DTO CommandeAdherent_DTO = new Raminagrobis.API.Client.CommandeAdherent_DTO();
                    CommandeAdherent_DTO.ID_adherent = (int)Adherent.Id;
                    CommandeAdherent_DTO.ID_panier = 1;
                    CommandeAdherent_DTO = apiclient.POSTAsync(CommandeAdherent_DTO).Result;

                    var apiclient2 = new LiaisonClient("https://localhost:44345", new HttpClient());
                    Raminagrobis.API.Client.Liaison_DTO liaison_DTO = new Raminagrobis.API.Client.Liaison_DTO();
                    
                    liaison_DTO.ID_produit = (int)produits_DTO.Id;
                    apiclient2.Liaison_Async(liaison_DTO);

                }

            }
            */
        }
        #endregion
        
        }

}