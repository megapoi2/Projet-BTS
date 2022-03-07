﻿using System;
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
            var apiclient = new Client("https://localhost:/44345", new HttpClient());
            var adherent = await apiclient.AdherentAllAsync();
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
            var apiclient = new Client("https://localhost:/44345", new HttpClient());
            Produits_DTO produits_DTO = new Produits_DTO();
            produits_DTO.Reference = InputReference.Text;
            produits_DTO.Libelle = InputLibelle.Text;
            produits_DTO.Marque = InputMarque.Text;
            produits_DTO.Actif = Boolean.Parse(InputActif.Text);

            //apiclient.ProduitsPOSTAsync(produits_DTO, files[0]);
        }
        #endregion
    }
}
