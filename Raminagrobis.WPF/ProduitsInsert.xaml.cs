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
    /// Logique d'interaction pour FournisseurDelete.xaml
    /// </summary>
    public partial class ProduitsInsert : Page
    {
        public string[] files;
        public ProduitsInsert()
        {
            InitializeComponent();
        }
        #region LoadPage
        private async void LoadPage(object sender, RoutedEventArgs e)
        {
            var apiclient = new ProduitsClient("https://localhost:44345", new HttpClient());
            var adherent = await apiclient.AllAsync();
        }
        #endregion

        private void ImagePanel_Drop(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                files = (string[])e.Data.GetData(DataFormats.FileDrop);

            }
        }


        #region BtnInsert
        private void BtnInsert(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var AllLine = File.ReadAllLines(openFileDialog.FileName);
                var length = AllLine.Length;
                for (int i = 1; i < length; i++)
                {
                    var ligne = AllLine[i].Split(';');

                    var apiclient = new ProduitsClient("https://localhost:44345", new HttpClient());
                    Raminagrobis.API.Client.Produits_DTO produits_DTO = new Raminagrobis.API.Client.Produits_DTO();
                    produits_DTO.Reference = ligne[0];
                    produits_DTO.Libelle = ligne[1];
                    produits_DTO.Marque = ligne[2];
                    produits_DTO.Actif = true;
                    apiclient.POSTAsync(produits_DTO);

                }
                txtEditor.Text = "CSV envoyé avec succès ! ( " + length + " ligne(s) ajoutée(s) )";
            }
        }
        #endregion
    }
}
