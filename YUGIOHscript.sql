CREATE DATABASE [userDB]
USE [userDB]
GO
/****** Object:  Table [dbo].[Armadilha]    Script Date: 08/12/2022 21:35:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Armadilha](
	[IdArmadilha] [int] IDENTITY(1,1) NOT NULL,
	[NomeArmadilha] [varchar](255) NOT NULL,
	[TipoCartaId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdArmadilha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Atributo]    Script Date: 08/12/2022 21:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Atributo](
	[IdAtributo] [int] IDENTITY(1,1) NOT NULL,
	[NomeAtributo] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAtributo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carta]    Script Date: 08/12/2022 21:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carta](
	[IdCarta] [int] IDENTITY(1,1) NOT NULL,
	[NomeCarta] [varchar](255) NOT NULL,
	[Nivel] [int] NULL,
	[NumeroCarta] [varchar](10) NULL,
	[Ataque] [int] NULL,
	[Defesa] [int] NULL,
	[DescricaoCarta] [varchar](255) NOT NULL,
	[TipoCartaId] [int] NULL,
	[AtributoId] [int] NULL,
	[IconeId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCarta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deck]    Script Date: 08/12/2022 21:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deck](
	[IdDeck] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NULL,
	[CartaId] [int] NULL,
	[TipoDeckId] [int] NULL,
	[Descricao] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDeck] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Icone]    Script Date: 08/12/2022 21:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Icone](
	[IdIcone] [int] IDENTITY(1,1) NOT NULL,
	[NomeIcone] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdIcone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogAcesso]    Script Date: 08/12/2022 21:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogAcesso](
	[IdLogAcesso] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NULL,
	[DataHoraAcesso] [datetime] NOT NULL,
	[DataHoraLogoff] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdLogAcesso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Magia]    Script Date: 08/12/2022 21:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Magia](
	[IdMagia] [int] IDENTITY(1,1) NOT NULL,
	[NomeMagia] [varchar](255) NOT NULL,
	[TipoCartaId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMagia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Monstro]    Script Date: 08/12/2022 21:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Monstro](
	[IdMonstro] [int] IDENTITY(1,1) NOT NULL,
	[NomeMonstro] [varchar](255) NOT NULL,
	[TipoCartaId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMonstro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonstroEfeito]    Script Date: 08/12/2022 21:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonstroEfeito](
	[IdMonstroEfeito] [int] IDENTITY(1,1) NOT NULL,
	[NomeMonstroEfeito] [varchar](255) NOT NULL,
	[MonstroId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMonstroEfeito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonstroPendulo]    Script Date: 08/12/2022 21:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonstroPendulo](
	[IdMonstroPendulo] [int] IDENTITY(1,1) NOT NULL,
	[NomeMonstroPendulo] [varchar](255) NOT NULL,
	[MonstroEfeitoId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMonstroPendulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCarta]    Script Date: 08/12/2022 21:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCarta](
	[IdTipoCarta] [int] IDENTITY(1,1) NOT NULL,
	[NomeTipoCarta] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipoCarta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoDeck]    Script Date: 08/12/2022 21:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDeck](
	[IdTipoDeck] [int] IDENTITY(1,1) NOT NULL,
	[NomeTipoDeck] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipoDeck] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 08/12/2022 21:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](255) NOT NULL,
	[Senha] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Armadilha] ON 

INSERT [dbo].[Armadilha] ([IdArmadilha], [NomeArmadilha], [TipoCartaId]) VALUES (1, N'Normais', NULL)
INSERT [dbo].[Armadilha] ([IdArmadilha], [NomeArmadilha], [TipoCartaId]) VALUES (2, N'Contínua', NULL)
INSERT [dbo].[Armadilha] ([IdArmadilha], [NomeArmadilha], [TipoCartaId]) VALUES (3, N'de Resposta', NULL)
SET IDENTITY_INSERT [dbo].[Armadilha] OFF
GO
SET IDENTITY_INSERT [dbo].[Atributo] ON 

INSERT [dbo].[Atributo] ([IdAtributo], [NomeAtributo]) VALUES (1, N'Terra')
INSERT [dbo].[Atributo] ([IdAtributo], [NomeAtributo]) VALUES (2, N'Fogo')
INSERT [dbo].[Atributo] ([IdAtributo], [NomeAtributo]) VALUES (3, N'Água')
INSERT [dbo].[Atributo] ([IdAtributo], [NomeAtributo]) VALUES (4, N'Vento')
INSERT [dbo].[Atributo] ([IdAtributo], [NomeAtributo]) VALUES (5, N'Luz')
INSERT [dbo].[Atributo] ([IdAtributo], [NomeAtributo]) VALUES (6, N'Trevas')
SET IDENTITY_INSERT [dbo].[Atributo] OFF
GO
SET IDENTITY_INSERT [dbo].[Carta] ON 

INSERT [dbo].[Carta] ([IdCarta], [NomeCarta], [Nivel], [NumeroCarta], [Ataque], [Defesa], [DescricaoCarta], [TipoCartaId], [AtributoId], [IconeId]) VALUES (1, N'Dragão Branco de Olhos Azuis', 8, N'CT13-PT008', 3000, 2500, N'Este dragão lendário é uma poderosa máquina de destruição. [...]', 3, 5, NULL)
INSERT [dbo].[Carta] ([IdCarta], [NomeCarta], [Nivel], [NumeroCarta], [Ataque], [Defesa], [DescricaoCarta], [TipoCartaId], [AtributoId], [IconeId]) VALUES (2, N'Minerva, a Luminosa Exaltada', 4, N'YCSW-EN008', 2000, 800, N'2 monstros de Nível 4. Você pode desassociar 1 matéria deste card [...]', 3, 5, NULL)
INSERT [dbo].[Carta] ([IdCarta], [NomeCarta], [Nivel], [NumeroCarta], [Ataque], [Defesa], [DescricaoCarta], [TipoCartaId], [AtributoId], [IconeId]) VALUES (3, N'Soldado do Lustro Negro', 8, N'YUGD-PTA01', 3000, 2500, N'Você pode Invocar este card por Invocação-Ritual 
com "Ritual do Lustro Negro".', 1, 2, NULL)
INSERT [dbo].[Carta] ([IdCarta], [NomeCarta], [Nivel], [NumeroCarta], [Ataque], [Defesa], [DescricaoCarta], [TipoCartaId], [AtributoId], [IconeId]) VALUES (4, N'Cyber Stein', 2, N'SJC-EN001', 700, 500, N'Invoque por Invocação-Especial 1 Monstro de Fusão do seu 
Deck Adicional em Posição de Ataque.  [...]', 3, 6, NULL)
INSERT [dbo].[Carta] ([IdCarta], [NomeCarta], [Nivel], [NumeroCarta], [Ataque], [Defesa], [DescricaoCarta], [TipoCartaId], [AtributoId], [IconeId]) VALUES (5, N'Slifer, o dragão Celeste', 10, N'YGLD-PTG01', NULL, NULL, N'Requer 3 Tributos para ser Invocado por Invocação-Normal 
(não pode ser Baixado Normalmente).  [...]', 3, NULL, NULL)
INSERT [dbo].[Carta] ([IdCarta], [NomeCarta], [Nivel], [NumeroCarta], [Ataque], [Defesa], [DescricaoCarta], [TipoCartaId], [AtributoId], [IconeId]) VALUES (6, N'Mago Negro', 7, N'YGLD-PTA03', 2500, 2100, N'O mago definitivo em termos de ataque e defesa.', 2, 6, NULL)
INSERT [dbo].[Carta] ([IdCarta], [NomeCarta], [Nivel], [NumeroCarta], [Ataque], [Defesa], [DescricaoCarta], [TipoCartaId], [AtributoId], [IconeId]) VALUES (7, N'Dragão Negro de Olhos Vermelhos', 7, N'LCJW-PT003', 2400, 2000, N'Um dragão feroz com um ataque letal.', 3, 6, NULL)
INSERT [dbo].[Carta] ([IdCarta], [NomeCarta], [Nivel], [NumeroCarta], [Ataque], [Defesa], [DescricaoCarta], [TipoCartaId], [AtributoId], [IconeId]) VALUES (9, N'Raigeki', NULL, N'OP02-EN003', 3000, 2500, N'Destrua todos os monstros que seu oponente controla.', 2, 1, NULL)
INSERT [dbo].[Carta] ([IdCarta], [NomeCarta], [Nivel], [NumeroCarta], [Ataque], [Defesa], [DescricaoCarta], [TipoCartaId], [AtributoId], [IconeId]) VALUES (10, N'Braço Direito de O Proibido', 1, N'YGLD-PTA20', 200, 300, N'Um braço direito, proibido e selado por magia.
Qualquer um que romper este selo obterá poder infinito.', 2, 6, NULL)
INSERT [dbo].[Carta] ([IdCarta], [NomeCarta], [Nivel], [NumeroCarta], [Ataque], [Defesa], [DescricaoCarta], [TipoCartaId], [AtributoId], [IconeId]) VALUES (11, N'Braço Esquerdo de O Proibido', 1, N'YGLD-PTA21', 200, 300, N'Um braço esquerdo, proibido e selado por magia. 
Qualquer um que romper este selo obterá poder infinito', 2, 6, NULL)
INSERT [dbo].[Carta] ([IdCarta], [NomeCarta], [Nivel], [NumeroCarta], [Ataque], [Defesa], [DescricaoCarta], [TipoCartaId], [AtributoId], [IconeId]) VALUES (12, N'Perna Direita de O Proibido', 1, N'YGLD-PTA18', 200, 300, N'Uma perna direita, proibida e selada por magia.
Qualquer um que romper este selo obterá poder infinito.', 2, 6, NULL)
INSERT [dbo].[Carta] ([IdCarta], [NomeCarta], [Nivel], [NumeroCarta], [Ataque], [Defesa], [DescricaoCarta], [TipoCartaId], [AtributoId], [IconeId]) VALUES (13, N'Perna Esquerda de O Proibido', 1, N'YGLD-PTA19', 200, 300, N'Uma perna esquerda, proibida e selada por magia.
Qualquer um que romper este selo obterá poder infinito.', 2, 6, NULL)
INSERT [dbo].[Carta] ([IdCarta], [NomeCarta], [Nivel], [NumeroCarta], [Ataque], [Defesa], [DescricaoCarta], [TipoCartaId], [AtributoId], [IconeId]) VALUES (14, N'Exodia, O Proibido', 3, N'YGLD-PTA17', 1000, 1000, N'Reúna todas as partes do Exódia, incluso esse card, para vencer o Duelo.', 2, 6, NULL)
INSERT [dbo].[Carta] ([IdCarta], [NomeCarta], [Nivel], [NumeroCarta], [Ataque], [Defesa], [DescricaoCarta], [TipoCartaId], [AtributoId], [IconeId]) VALUES (1, N'Tyler-o-grande-guerreiro', 8, N'TLY-EN001', 3000, 1500, N'Este monstro não pode ser Invocado por Invocação-Especial. Quando este card destruir 
um monstro como resultado de uma batalha e enviá-lo para o Cemitério, cause dano aos Pontos de Vida do seu oponente igual ao ATK do monstro destruído.', 3, 5, NULL)
SET IDENTITY_INSERT [dbo].[Carta] OFF
GO
SET IDENTITY_INSERT [dbo].[Icone] ON 

INSERT [dbo].[Icone] ([IdIcone], [NomeIcone]) VALUES (1, N'Equipamento')
INSERT [dbo].[Icone] ([IdIcone], [NomeIcone]) VALUES (2, N'Campos')
INSERT [dbo].[Icone] ([IdIcone], [NomeIcone]) VALUES (3, N'Ritual')
INSERT [dbo].[Icone] ([IdIcone], [NomeIcone]) VALUES (4, N'Contínuo')
INSERT [dbo].[Icone] ([IdIcone], [NomeIcone]) VALUES (5, N'Rápida')
INSERT [dbo].[Icone] ([IdIcone], [NomeIcone]) VALUES (6, N'Resposta')
SET IDENTITY_INSERT [dbo].[Icone] OFF
GO
SET IDENTITY_INSERT [dbo].[Magia] ON 

INSERT [dbo].[Magia] ([IdMagia], [NomeMagia], [TipoCartaId]) VALUES (1, N'Normais', NULL)
INSERT [dbo].[Magia] ([IdMagia], [NomeMagia], [TipoCartaId]) VALUES (2, N'Ritual', NULL)
INSERT [dbo].[Magia] ([IdMagia], [NomeMagia], [TipoCartaId]) VALUES (3, N'Contínua', NULL)
INSERT [dbo].[Magia] ([IdMagia], [NomeMagia], [TipoCartaId]) VALUES (4, N'de Equipamento', NULL)
INSERT [dbo].[Magia] ([IdMagia], [NomeMagia], [TipoCartaId]) VALUES (5, N'de Campo', NULL)
INSERT [dbo].[Magia] ([IdMagia], [NomeMagia], [TipoCartaId]) VALUES (6, N'Rápida', NULL)
SET IDENTITY_INSERT [dbo].[Magia] OFF
GO
SET IDENTITY_INSERT [dbo].[Monstro] ON 

INSERT [dbo].[Monstro] ([IdMonstro], [NomeMonstro], [TipoCartaId]) VALUES (1, N'Normais', NULL)
INSERT [dbo].[Monstro] ([IdMonstro], [NomeMonstro], [TipoCartaId]) VALUES (2, N'de Efeito', NULL)
SET IDENTITY_INSERT [dbo].[Monstro] OFF
GO
SET IDENTITY_INSERT [dbo].[MonstroEfeito] ON 

INSERT [dbo].[MonstroEfeito] ([IdMonstroEfeito], [NomeMonstroEfeito], [MonstroId]) VALUES (1, N'Contínuo', NULL)
INSERT [dbo].[MonstroEfeito] ([IdMonstroEfeito], [NomeMonstroEfeito], [MonstroId]) VALUES (2, N'Ignição', NULL)
INSERT [dbo].[MonstroEfeito] ([IdMonstroEfeito], [NomeMonstroEfeito], [MonstroId]) VALUES (3, N'Rápido', NULL)
INSERT [dbo].[MonstroEfeito] ([IdMonstroEfeito], [NomeMonstroEfeito], [MonstroId]) VALUES (4, N'Gatilho', NULL)
INSERT [dbo].[MonstroEfeito] ([IdMonstroEfeito], [NomeMonstroEfeito], [MonstroId]) VALUES (5, N'Pêndulo', NULL)
SET IDENTITY_INSERT [dbo].[MonstroEfeito] OFF
GO
SET IDENTITY_INSERT [dbo].[MonstroPendulo] ON 

INSERT [dbo].[MonstroPendulo] ([IdMonstroPendulo], [NomeMonstroPendulo], [MonstroEfeitoId]) VALUES (1, N'de Pêndulo', NULL)
INSERT [dbo].[MonstroPendulo] ([IdMonstroPendulo], [NomeMonstroPendulo], [MonstroEfeitoId]) VALUES (2, N'do Monstro', NULL)
INSERT [dbo].[MonstroPendulo] ([IdMonstroPendulo], [NomeMonstroPendulo], [MonstroEfeitoId]) VALUES (3, N'Xyz', NULL)
INSERT [dbo].[MonstroPendulo] ([IdMonstroPendulo], [NomeMonstroPendulo], [MonstroEfeitoId]) VALUES (4, N'Sincro', NULL)
INSERT [dbo].[MonstroPendulo] ([IdMonstroPendulo], [NomeMonstroPendulo], [MonstroEfeitoId]) VALUES (5, N'Reguladores', NULL)
INSERT [dbo].[MonstroPendulo] ([IdMonstroPendulo], [NomeMonstroPendulo], [MonstroEfeitoId]) VALUES (6, N'Fusão', NULL)
INSERT [dbo].[MonstroPendulo] ([IdMonstroPendulo], [NomeMonstroPendulo], [MonstroEfeitoId]) VALUES (7, N'Ritual', NULL)
SET IDENTITY_INSERT [dbo].[MonstroPendulo] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoCarta] ON 

INSERT [dbo].[TipoCarta] ([IdTipoCarta], [NomeTipoCarta]) VALUES (1, N'Armadilha')
INSERT [dbo].[TipoCarta] ([IdTipoCarta], [NomeTipoCarta]) VALUES (2, N'Magia')
INSERT [dbo].[TipoCarta] ([IdTipoCarta], [NomeTipoCarta]) VALUES (3, N'Monstro')
SET IDENTITY_INSERT [dbo].[TipoCarta] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuario__5E55825B54CF1DA5]    Script Date: 08/12/2022 21:35:47 ******/
ALTER TABLE [dbo].[Usuario] ADD UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Armadilha]  WITH CHECK ADD FOREIGN KEY([TipoCartaId])
REFERENCES [dbo].[TipoCarta] ([IdTipoCarta])
GO
ALTER TABLE [dbo].[Carta]  WITH CHECK ADD FOREIGN KEY([AtributoId])
REFERENCES [dbo].[Atributo] ([IdAtributo])
GO
ALTER TABLE [dbo].[Carta]  WITH CHECK ADD FOREIGN KEY([IconeId])
REFERENCES [dbo].[Icone] ([IdIcone])
GO
ALTER TABLE [dbo].[Carta]  WITH CHECK ADD FOREIGN KEY([TipoCartaId])
REFERENCES [dbo].[TipoCarta] ([IdTipoCarta])
GO
ALTER TABLE [dbo].[Deck]  WITH CHECK ADD FOREIGN KEY([CartaId])
REFERENCES [dbo].[Carta] ([IdCarta])
GO
ALTER TABLE [dbo].[Deck]  WITH CHECK ADD FOREIGN KEY([TipoDeckId])
REFERENCES [dbo].[TipoDeck] ([IdTipoDeck])
GO
ALTER TABLE [dbo].[Deck]  WITH CHECK ADD FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[LogAcesso]  WITH CHECK ADD FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Magia]  WITH CHECK ADD FOREIGN KEY([TipoCartaId])
REFERENCES [dbo].[TipoCarta] ([IdTipoCarta])
GO
ALTER TABLE [dbo].[Monstro]  WITH CHECK ADD FOREIGN KEY([TipoCartaId])
REFERENCES [dbo].[TipoCarta] ([IdTipoCarta])
GO
ALTER TABLE [dbo].[MonstroEfeito]  WITH CHECK ADD FOREIGN KEY([MonstroId])
REFERENCES [dbo].[Monstro] ([IdMonstro])
GO
ALTER TABLE [dbo].[MonstroPendulo]  WITH CHECK ADD FOREIGN KEY([MonstroEfeitoId])
REFERENCES [dbo].[MonstroEfeito] ([IdMonstroEfeito])
GO
