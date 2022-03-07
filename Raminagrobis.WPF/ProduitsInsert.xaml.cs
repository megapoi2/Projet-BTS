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
            /*
            var apiclient = new ProduitsClient("https://localhost:44345", new HttpClient());
            Raminagrobis.API.Client.Produits_DTO produits_DTO = new Raminagrobis.API.Client.Produits_DTO();
            produits_DTO.Reference = InputReference.Text;
            produits_DTO.Libelle = InputLibelle.Text;
            produits_DTO.Marque = InputMarque.Text;
            produits_DTO.Actif = Boolean.Parse(InputActif.Text);

            apiclient.POSTAsync(produits_DTO);


            //Enlever ce qui est dans le input
            InputReference.Text = null;
            InputLibelle.Text = null;
            InputMarque.Text = null;
            InputActif.Text = null;
            */


            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                txtEditor.Text = File.ReadAllText(openFileDialog.FileName);
        }
        #endregion
    }
}
