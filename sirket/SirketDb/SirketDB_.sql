USE [sirket]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 17.10.2021 17:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[admin_id] [int] IDENTITY(1,1) NOT NULL,
	[admin_ad] [nvarchar](15) NOT NULL,
	[admin_sifre] [nvarchar](15) NULL,
 CONSTRAINT [PK_dbo.admin] PRIMARY KEY CLUSTERED 
(
	[admin_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cihaz]    Script Date: 17.10.2021 17:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cihaz](
	[cihaz_id] [int] IDENTITY(1,1) NOT NULL,
	[cihaz_ad] [varchar](15) NOT NULL,
	[cihaz_tür] [varchar](15) NULL,
	[cihaz_konum] [varchar](15) NULL,
	[cihaz_durum] [varchar](15) NOT NULL,
	[cihaz_zimmet_tarih] [datetime] NOT NULL,
	[marka_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[cihaz_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kullanici]    Script Date: 17.10.2021 17:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kullanici](
	[kullanici_id] [int] IDENTITY(1,1) NOT NULL,
	[kullanici_adi] [varchar](25) NOT NULL,
	[kullanici_sifre] [varchar](8) NULL,
	[kullanici_departman] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[kullanici_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[marka_kategori]    Script Date: 17.10.2021 17:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[marka_kategori](
	[marka_ad] [varchar](25) NOT NULL,
	[marka_id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[marka_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tel_marka]    Script Date: 17.10.2021 17:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tel_marka](
	[telmarka_id] [int] IDENTITY(1,1) NOT NULL,
	[telmarka_adi] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[telmarka_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[zimmet]    Script Date: 17.10.2021 17:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zimmet](
	[cihaz_id] [int] NOT NULL,
	[kullanici_id] [int] NOT NULL,
	[zimmet_tarih] [datetime] NOT NULL,
	[zimmet_id] [int] IDENTITY(1,1) NOT NULL,
	[telmarka_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[zimmet_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[cihaz]  WITH CHECK ADD  CONSTRAINT [FK_cihaz_marka_kategori] FOREIGN KEY([marka_id])
REFERENCES [dbo].[marka_kategori] ([marka_id])
GO
ALTER TABLE [dbo].[cihaz] CHECK CONSTRAINT [FK_cihaz_marka_kategori]
GO
ALTER TABLE [dbo].[zimmet]  WITH CHECK ADD  CONSTRAINT [FK_zimmet_cihaz] FOREIGN KEY([cihaz_id])
REFERENCES [dbo].[cihaz] ([cihaz_id])
GO
ALTER TABLE [dbo].[zimmet] CHECK CONSTRAINT [FK_zimmet_cihaz]
GO
ALTER TABLE [dbo].[zimmet]  WITH CHECK ADD  CONSTRAINT [FK_zimmet_kullanici] FOREIGN KEY([kullanici_id])
REFERENCES [dbo].[kullanici] ([kullanici_id])
GO
ALTER TABLE [dbo].[zimmet] CHECK CONSTRAINT [FK_zimmet_kullanici]
GO
ALTER TABLE [dbo].[zimmet]  WITH CHECK ADD  CONSTRAINT [FK_zimmet_tel_marka] FOREIGN KEY([telmarka_id])
REFERENCES [dbo].[tel_marka] ([telmarka_id])
GO
ALTER TABLE [dbo].[zimmet] CHECK CONSTRAINT [FK_zimmet_tel_marka]
GO
