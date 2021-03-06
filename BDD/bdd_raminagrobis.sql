USE [Raminagrobis]
GO
/****** Object:  Table [dbo].[Adherents]    Script Date: 13/02/2022 14:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adherents](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[societe] [varchar](50) NOT NULL,
	[civilite] [bit] NOT NULL,
	[nom] [varchar](50) NOT NULL,
	[prenom] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[date_adhesion] [date] NOT NULL,
	[actif] [bit] NOT NULL,
 CONSTRAINT [PK_Adherents] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Commandes]    Script Date: 13/02/2022 14:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Commandes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_adherent] [int] NOT NULL,
	[id_panier] [int] NOT NULL,
 CONSTRAINT [PK_Commandes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fournisseurs]    Script Date: 13/02/2022 14:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fournisseurs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[societe] [varchar](50) NOT NULL,
	[civilite] [bit] NOT NULL,
	[nom] [varchar](50) NOT NULL,
	[prenom] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[adresse] [text] NOT NULL,
	[actif] [bit] NOT NULL,
 CONSTRAINT [PK_Fournisseurs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Liaison]    Script Date: 13/02/2022 14:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Liaison](
	[id_produit] [int] NOT NULL,
	[id_fournisseur] [int] NOT NULL,
 CONSTRAINT [PK_Liaison] PRIMARY KEY CLUSTERED 
(
	[id_produit] ASC,
	[id_fournisseur] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LignesAdherent]    Script Date: 13/02/2022 14:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LignesAdherent](
	[id_produit] [int] NOT NULL,
	[id_commande] [int] NOT NULL,
	[id_ligne_global] [int] NOT NULL,
	[quantite] [int] NOT NULL,
 CONSTRAINT [PK_LignesAdherent] PRIMARY KEY CLUSTERED 
(
	[id_produit] ASC,
	[id_commande] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LignesGlobal]    Script Date: 13/02/2022 14:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LignesGlobal](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_panier] [int] NOT NULL,
	[quantite] [int] NOT NULL,
	[id_produit] [int] NOT NULL,
 CONSTRAINT [PK_LignesGlobal] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paniers]    Script Date: 13/02/2022 14:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paniers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[libelle] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Paniers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produits]    Script Date: 13/02/2022 14:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produits](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[reference] [varchar](50) NOT NULL,
	[libelle] [varchar](50) NOT NULL,
	[marque] [varchar](50) NOT NULL,
	[actif] [bit] NOT NULL,
 CONSTRAINT [PK_Produits] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Propositions]    Script Date: 13/02/2022 14:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Propositions](
	[id_ligne_global] [int] NOT NULL,
	[id_fournisseur] [int] NOT NULL,
	[prix] [int] NOT NULL,
 CONSTRAINT [PK_Propositions] PRIMARY KEY CLUSTERED 
(
	[id_ligne_global] ASC,
	[id_fournisseur] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Commandes]  WITH CHECK ADD  CONSTRAINT [FK_Commandes_Adherents] FOREIGN KEY([id_adherent])
REFERENCES [dbo].[Adherents] ([id])
GO
ALTER TABLE [dbo].[Commandes] CHECK CONSTRAINT [FK_Commandes_Adherents]
GO
ALTER TABLE [dbo].[Commandes]  WITH CHECK ADD  CONSTRAINT [FK_Commandes_Paniers1] FOREIGN KEY([id_panier])
REFERENCES [dbo].[Paniers] ([id])
GO
ALTER TABLE [dbo].[Commandes] CHECK CONSTRAINT [FK_Commandes_Paniers1]
GO
ALTER TABLE [dbo].[Liaison]  WITH CHECK ADD  CONSTRAINT [FK_Liaison_Fournisseurs] FOREIGN KEY([id_fournisseur])
REFERENCES [dbo].[Fournisseurs] ([id])
GO
ALTER TABLE [dbo].[Liaison] CHECK CONSTRAINT [FK_Liaison_Fournisseurs]
GO
ALTER TABLE [dbo].[Liaison]  WITH CHECK ADD  CONSTRAINT [FK_Liaison_Produits] FOREIGN KEY([id_produit])
REFERENCES [dbo].[Produits] ([id])
GO
ALTER TABLE [dbo].[Liaison] CHECK CONSTRAINT [FK_Liaison_Produits]
GO
ALTER TABLE [dbo].[LignesAdherent]  WITH CHECK ADD  CONSTRAINT [FK_LignesAdherent_Commandes] FOREIGN KEY([id_commande])
REFERENCES [dbo].[Commandes] ([id])
GO
ALTER TABLE [dbo].[LignesAdherent] CHECK CONSTRAINT [FK_LignesAdherent_Commandes]
GO
ALTER TABLE [dbo].[LignesAdherent]  WITH CHECK ADD  CONSTRAINT [FK_LignesAdherent_LignesGlobal] FOREIGN KEY([id_ligne_global])
REFERENCES [dbo].[LignesGlobal] ([id])
GO
ALTER TABLE [dbo].[LignesAdherent] CHECK CONSTRAINT [FK_LignesAdherent_LignesGlobal]
GO
ALTER TABLE [dbo].[LignesAdherent]  WITH CHECK ADD  CONSTRAINT [FK_LignesAdherent_Produits] FOREIGN KEY([id_produit])
REFERENCES [dbo].[Produits] ([id])
GO
ALTER TABLE [dbo].[LignesAdherent] CHECK CONSTRAINT [FK_LignesAdherent_Produits]
GO
ALTER TABLE [dbo].[LignesGlobal]  WITH CHECK ADD  CONSTRAINT [FK_LignesGlobal_Paniers] FOREIGN KEY([id_panier])
REFERENCES [dbo].[Paniers] ([id])
GO
ALTER TABLE [dbo].[LignesGlobal] CHECK CONSTRAINT [FK_LignesGlobal_Paniers]
GO
ALTER TABLE [dbo].[LignesGlobal]  WITH CHECK ADD  CONSTRAINT [FK_LignesGlobal_Produits] FOREIGN KEY([id_produit])
REFERENCES [dbo].[Produits] ([id])
GO
ALTER TABLE [dbo].[LignesGlobal] CHECK CONSTRAINT [FK_LignesGlobal_Produits]
GO
ALTER TABLE [dbo].[Propositions]  WITH CHECK ADD  CONSTRAINT [FK_Propositions_Fournisseurs] FOREIGN KEY([id_ligne_global])
REFERENCES [dbo].[LignesGlobal] ([id])
GO
ALTER TABLE [dbo].[Propositions] CHECK CONSTRAINT [FK_Propositions_Fournisseurs]
GO
ALTER TABLE [dbo].[Propositions]  WITH CHECK ADD  CONSTRAINT [FK_Propositions_Fournisseurs1] FOREIGN KEY([id_fournisseur])
REFERENCES [dbo].[Fournisseurs] ([id])
GO
ALTER TABLE [dbo].[Propositions] CHECK CONSTRAINT [FK_Propositions_Fournisseurs1]
GO
