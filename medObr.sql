USE [medObr]
GO
/****** Object:  Database [med_obr]    Script Date: 02.12.2022 14:41:31 ******/
ALTER DATABASE [med_obr] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [medObr].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [med_obr] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [med_obr] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [med_obr] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [med_obr] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [med_obr] SET ARITHABORT OFF 
GO
ALTER DATABASE [med_obr] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [med_obr] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [med_obr] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [med_obr] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [med_obr] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [med_obr] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [med_obr] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [med_obr] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [med_obr] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [med_obr] SET  DISABLE_BROKER 
GO
ALTER DATABASE [med_obr] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [med_obr] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [med_obr] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [med_obr] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [med_obr] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [med_obr] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [med_obr] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [med_obr] SET RECOVERY FULL 
GO
ALTER DATABASE [med_obr] SET  MULTI_USER 
GO
ALTER DATABASE [med_obr] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [med_obr] SET DB_CHAINING OFF 
GO
ALTER DATABASE [med_obr] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [med_obr] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [med_obr] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [med_obr] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'med_obr', N'ON'
GO
ALTER DATABASE [med_obr] SET QUERY_STORE = OFF
GO
USE [medObr]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 02.12.2022 14:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 02.12.2022 14:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oborudovanie]    Script Date: 02.12.2022 14:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oborudovanie](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[weight] [float] NOT NULL,
	[price] [int] NOT NULL,
	[photo] [image] NULL,
	[description] [nvarchar](max) NOT NULL,
	[id_proizvoditel] [int] NOT NULL,
	[id_color] [int] NOT NULL,
	[id_type] [int] NOT NULL,
 CONSTRAINT [PK_oborudovanie] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 02.12.2022 14:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sum] [int] NOT NULL,
	[id_user] [int] NOT NULL,
	[id_oborudovanie] [int] NOT NULL,
	[count] [int] NOT NULL,
	[date] [date] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proizvoditel]    Script Date: 02.12.2022 14:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proizvoditel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[id_country] [int] NOT NULL,
 CONSTRAINT [PK_Proizvoditel] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 02.12.2022 14:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type]    Script Date: 02.12.2022 14:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 02.12.2022 14:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[surname] [nvarchar](50) NOT NULL,
	[lastname] [nvarchar](50) NOT NULL,
	[login] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[phone] [nvarchar](50) NOT NULL,
	[birthDay] [date] NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[id_role] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Color] ON 

INSERT [dbo].[Color] ([id], [name]) VALUES (1, N'Белый')
INSERT [dbo].[Color] ([id], [name]) VALUES (2, N'Серый')
INSERT [dbo].[Color] ([id], [name]) VALUES (3, N'Черный')
INSERT [dbo].[Color] ([id], [name]) VALUES (4, N'Желтый')
INSERT [dbo].[Color] ([id], [name]) VALUES (5, N'Красный')
INSERT [dbo].[Color] ([id], [name]) VALUES (6, N'Оранжевый')
INSERT [dbo].[Color] ([id], [name]) VALUES (7, N'Желтый')
SET IDENTITY_INSERT [dbo].[Color] OFF
GO
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([id], [name]) VALUES (1, N'Россия')
INSERT [dbo].[Country] ([id], [name]) VALUES (2, N'Китай')
INSERT [dbo].[Country] ([id], [name]) VALUES (3, N'США')
INSERT [dbo].[Country] ([id], [name]) VALUES (4, N'Япония')
INSERT [dbo].[Country] ([id], [name]) VALUES (5, N'Германия')
INSERT [dbo].[Country] ([id], [name]) VALUES (6, N'Швейцария')
INSERT [dbo].[Country] ([id], [name]) VALUES (7, N'Англия')
INSERT [dbo].[Country] ([id], [name]) VALUES (8, N'Швеция')
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
SET IDENTITY_INSERT [dbo].[Oborudovanie] ON 

INSERT [dbo].[Oborudovanie] ([id], [name], [weight], [price], [photo], [description], [id_proizvoditel], [id_color], [id_type]) VALUES (1, N'Адъютор ИАД-01-1', 0.5, 1240, NULL, N'Металлический анероидный манометр. Нагнетатель из латекса, металлический игольчатый клапан сброса воздуха (боковой винт). Удобная и гигиеничная манжета из нейлона с металлическим кольцом. Цельнолитая 2-трубочная пневмокамера из латекса. Металлический стетофонендоскоп «Адъютор» СФ-01 с односторонней головкой и логотипом. Индивидуальная упаковка – нейлоновая сумочка с логотипом и коробка из микрогофрокартона с полноцветной печатью.', 4, 1, 1)
INSERT [dbo].[Oborudovanie] ([id], [name], [weight], [price], [photo], [description], [id_proizvoditel], [id_color], [id_type]) VALUES (3, N'Medcaptain HP-60', 2.5, 35000, NULL, N'HP-60 предназначен для клинической непрерывной микроинфузии раствора или жидкого лекарственного средства (например, химиотерапевтического средства, сердечно-сосудистого средства, противоопухолевого препарата, антибиотика, антикоагулянта, анестетика, компонентов крови и парентерального питания) в сосудистую систему и полости пациента под высокоточным контролем.', 1, 2, 3)
INSERT [dbo].[Oborudovanie] ([id], [name], [weight], [price], [photo], [description], [id_proizvoditel], [id_color], [id_type]) VALUES (5, N'Apogee 5300V Neo', 15, 2000000, NULL, N'19-дюймовый монитор высокой четкости, 10,4'''' сенсорный экран
Передовые технологии обработки изображений, такие как MFI, Nanoview, Xbeam и Fusion THI обеспечивают улучшенное разрешение изображения и глубину проникновения
', 3, 3, 2)
INSERT [dbo].[Oborudovanie] ([id], [name], [weight], [price], [photo], [description], [id_proizvoditel], [id_color], [id_type]) VALUES (6, N'Rapport', 0.5, 1500, NULL, N'Стетоскоп Раппорт с двойной головкой, имеющий отличную акустику, зарекомендовал себя в течение многих лет. Этот стетоскоп доступен в различных цветовых вариантах, особенно популярен у студентов. К каждому стетоскопу прилагается большой набор запасных частей.', 5, 4, 4)
INSERT [dbo].[Oborudovanie] ([id], [name], [weight], [price], [photo], [description], [id_proizvoditel], [id_color], [id_type]) VALUES (7, N'PFM20', 0.2, 1850, NULL, N'Измерение Пиковой Скорости Выдоха проводятся как правило, утром и вечером. Все показатели ПСВ необходимо отмечать в специальном дневнике самоконтроля, который прилагается в комплекте вместе с пикфлоуметром.

Использование пикфлоуметра - самый простой и эффективный метод контроля бронхо-легочных заболеваний, таких как астма, хроническая обструктивная болезнь легких (ХОБЛ), эмфизема, хронические бронхиты и др.', 6, 5, 5)
INSERT [dbo].[Oborudovanie] ([id], [name], [weight], [price], [photo], [description], [id_proizvoditel], [id_color], [id_type]) VALUES (8, N'Ультрасоник', 2, 150000, NULL, N'Эхоэнцефалоскоп оснащен программно-управляемой временной амплитудной регулировкой усиления (ВАРУ), что обеспечивает высокое качество эхосигналов.

Глубина зондирования 230 мм при величине «мертвой» зоны не более 15 мм позволяет идентифицировать патологические образования в околокостном черепном пространстве.', 4, 6, 6)
INSERT [dbo].[Oborudovanie] ([id], [name], [weight], [price], [photo], [description], [id_proizvoditel], [id_color], [id_type]) VALUES (9, N'WT-03', 0.1, 280, NULL, N'Медицинский термометр B.Well WT-03 — простой и точный прибор, который доступен для каждой семьи. Электронный градусник WT-03 сделан из безопасных материалов, не содержит ртути и стекла. Он удобен для детей и взрослых, имеет хорошо читаемый дисплей, память последнего измерения и скорость измерения от 1 минуты. Благодаря водозащищенной конструкции и заменяемому элементу питания WT-03 прослужит Вам долго!', 7, 7, 7)
SET IDENTITY_INSERT [dbo].[Oborudovanie] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([id], [sum], [id_user], [id_oborudovanie], [count], [date]) VALUES (10, 35000, 5, 3, 1, CAST(N'2002-01-23' AS Date))
INSERT [dbo].[Order] ([id], [sum], [id_user], [id_oborudovanie], [count], [date]) VALUES (12, 1240, 2, 1, 1, CAST(N'2008-05-14' AS Date))
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Proizvoditel] ON 

INSERT [dbo].[Proizvoditel] ([id], [name], [id_country]) VALUES (1, N'Shin Nippon', 4)
INSERT [dbo].[Proizvoditel] ([id], [name], [id_country]) VALUES (3, N'VOLK', 3)
INSERT [dbo].[Proizvoditel] ([id], [name], [id_country]) VALUES (4, N'Изумруд', 1)
INSERT [dbo].[Proizvoditel] ([id], [name], [id_country]) VALUES (5, N'SIUI', 2)
INSERT [dbo].[Proizvoditel] ([id], [name], [id_country]) VALUES (6, N'БФА ', 1)
INSERT [dbo].[Proizvoditel] ([id], [name], [id_country]) VALUES (7, N'RUDOLF RIESTER', 5)
SET IDENTITY_INSERT [dbo].[Proizvoditel] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([id], [name]) VALUES (1, N'Администратор')
INSERT [dbo].[Role] ([id], [name]) VALUES (2, N'Менеджер')
INSERT [dbo].[Role] ([id], [name]) VALUES (3, N'Пользователь')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Type] ON 

INSERT [dbo].[Type] ([id], [name]) VALUES (1, N'Тонометр')
INSERT [dbo].[Type] ([id], [name]) VALUES (2, N'Узи система')
INSERT [dbo].[Type] ([id], [name]) VALUES (3, N'Инфузионный насос')
INSERT [dbo].[Type] ([id], [name]) VALUES (4, N'Стетоскоп')
INSERT [dbo].[Type] ([id], [name]) VALUES (5, N'Пикфлоуметр')
INSERT [dbo].[Type] ([id], [name]) VALUES (6, N'Эхоэнцефалограф ')
INSERT [dbo].[Type] ([id], [name]) VALUES (7, N'Термометр')
INSERT [dbo].[Type] ([id], [name]) VALUES (8, N'Небулайзер')
INSERT [dbo].[Type] ([id], [name]) VALUES (9, N'Неврологический молоточек')
SET IDENTITY_INSERT [dbo].[Type] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [name], [surname], [lastname], [login], [password], [phone], [birthDay], [email], [id_role]) VALUES (1, N'Даниил', N'Никифоров', N'Дмитриевич', N'1', N'1', N'8888888888', CAST(N'2002-11-29' AS Date), N'nikiforov@mail.ru', 1)
INSERT [dbo].[User] ([id], [name], [surname], [lastname], [login], [password], [phone], [birthDay], [email], [id_role]) VALUES (2, N'Магомед', N'Магомедов', N'Магомедмуратович', N'2', N'2', N'9999999999', CAST(N'2003-09-09' AS Date), N'magomedov@mail.ru', 2)
INSERT [dbo].[User] ([id], [name], [surname], [lastname], [login], [password], [phone], [birthDay], [email], [id_role]) VALUES (5, N'Роман', N'Антонов', N'Сергеевич', N'3', N'3', N'7777777777', CAST(N'2003-07-07' AS Date), N'antonov@mail.ru', 3)
INSERT [dbo].[User] ([id], [name], [surname], [lastname], [login], [password], [phone], [birthDay], [email], [id_role]) VALUES (6, N'тест', N'тест', N'тест', N'test', N'testtest', N'12345678', CAST(N'0009-11-13' AS Date), N'выфвц@mail.ru', 2)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Oborudovanie]  WITH CHECK ADD  CONSTRAINT [FK_oborudovanie_Color] FOREIGN KEY([id_color])
REFERENCES [dbo].[Color] ([id])
GO
ALTER TABLE [dbo].[Oborudovanie] CHECK CONSTRAINT [FK_oborudovanie_Color]
GO
ALTER TABLE [dbo].[Oborudovanie]  WITH CHECK ADD  CONSTRAINT [FK_oborudovanie_Proizvoditel] FOREIGN KEY([id_proizvoditel])
REFERENCES [dbo].[Proizvoditel] ([id])
GO
ALTER TABLE [dbo].[Oborudovanie] CHECK CONSTRAINT [FK_oborudovanie_Proizvoditel]
GO
ALTER TABLE [dbo].[Oborudovanie]  WITH CHECK ADD  CONSTRAINT [FK_oborudovanie_Type] FOREIGN KEY([id_type])
REFERENCES [dbo].[Type] ([id])
GO
ALTER TABLE [dbo].[Oborudovanie] CHECK CONSTRAINT [FK_oborudovanie_Type]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_oborudovanie] FOREIGN KEY([id_oborudovanie])
REFERENCES [dbo].[Oborudovanie] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_oborudovanie]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([id_user])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[Proizvoditel]  WITH CHECK ADD  CONSTRAINT [FK_Proizvoditel_Country] FOREIGN KEY([id_country])
REFERENCES [dbo].[Country] ([id])
GO
ALTER TABLE [dbo].[Proizvoditel] CHECK CONSTRAINT [FK_Proizvoditel_Country]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([id_role])
REFERENCES [dbo].[Role] ([id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [med_obr] SET  READ_WRITE 
GO
