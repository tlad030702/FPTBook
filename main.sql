USE [FPTBook]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 12/24/2022 3:08:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/24/2022 3:08:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/24/2022 3:08:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/24/2022 3:08:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/24/2022 3:08:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/24/2022 3:08:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 12/24/2022 3:08:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 12/24/2022 3:08:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Rate] [int] NOT NULL,
	[Img1] [nvarchar](max) NOT NULL,
	[Img2] [nvarchar](max) NOT NULL,
	[Img3] [nvarchar](max) NOT NULL,
	[Quality] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[RequestCateId] [int] NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/24/2022 3:08:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NOT NULL,
	[CategoryDescription] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestCates]    Script Date: 12/24/2022 3:08:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestCates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_RequestCates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'A', N'Administrator', N'Administrator', N'68d64ffc-a442-4c55-928c-9e78016e0c1b')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'B', N'Customer', N'Customer', N'78386acf-d89c-4c27-936e-30913fed3245')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'C', N'Staff', N'Staff', N'c3840ca3-9180-42ce-8c5a-90f6b5d58f94')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1', N'A')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2', N'B')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3', N'C')
GO
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Address], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'1', N'Tran', N'Duy Duong', N'Ha noi', N'admin@fpt.com', N'admin@fpt.com', N'admin@fpt.com', NULL, 1, N'AQAAAAEAACcQAAAAEGQ29cGluBgb52r5jjlqwTFBWklADRDxCSB7Jidu8vxPjIRmWQ9gphDonX0SkMSsIg==', N'3e7ea121-fcf2-4a1a-ab7b-eaa823c6e237', N'a3c636d0-8e19-4d11-a506-04894fe315f5', NULL, 0, 0, NULL, 0, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Address], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2', N'Pham', N'Bui Minh Duc', N'Ha noi', N'Duc', N'customer@fpt.com', N'Customer@fpt.com', NULL, 1, N'AQAAAAEAACcQAAAAEFywYtgeEIwmSvyNaXn91N4DmAFJ/eT2wS/jo3Dqg2cdZMuxKhYTN1xdsbK+gmioVg==', N'fe3dad86-a982-4603-90e0-b9e51360f697', N'52286d96-7cd3-4469-a21b-71bdaec7a37b', NULL, 0, 0, NULL, 0, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Address], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3', N'Vuong', N'Toan Duc', N'Ha noi', N'customer@fpt.com', N'Staff@fpt.com', N'Staff@fpt.com', NULL, 1, N'AQAAAAEAACcQAAAAEJ1J7aSrlPDtam6ZJcyKerfcsgR4E64Xgl1Gi6S7ATw5eyytMaF6QlSTsFgkTd5VRQ==', N'c637fdd1-b899-4bb5-a929-ccbfeb4fa17e', N'833ea484-75b1-44d0-8991-c03062adb8e6', NULL, 0, 0, NULL, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([BookId], [Title], [Price], [Rate], [Img1], [Img2], [Img3], [Quality], [CategoryId], [RequestCateId]) VALUES (29, N'Jujutsu Kaisen', CAST(1.50 AS Decimal(18, 2)), 5, N'584a6344-7bab-445f-80cd-a839dbdb121d_jujutsu_Kaisen.jpg', N'f5f7e5f9-b48f-42eb-8afa-21d451168eb3_Jjs.jpg', N'431ea7ee-5ef2-4185-8455-c6e97772affe_Juj.jpg', 32432, 8, NULL)
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Rate], [Img1], [Img2], [Img3], [Quality], [CategoryId], [RequestCateId]) VALUES (32, N'One piece', CAST(2.00 AS Decimal(18, 2)), 5, N'68622e3f-39cb-4277-87cd-1a9756e836a8_One_Piece.jpg', N'be977716-ccb2-4916-aaa3-f08b2e29122a_OneP.jpg', N'59550fbf-098b-49b1-a829-673f60c388ab_one-piece-magazine.jpg', 653544, 8, NULL)
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Rate], [Img1], [Img2], [Img3], [Quality], [CategoryId], [RequestCateId]) VALUES (33, N'Mật mã DaVinci', CAST(7.39 AS Decimal(18, 2)), 5, N'326f43b4-3036-432e-8b5f-b29578ec00f8_truyen-trinh-tham-mat-ma-da-vinci.jpg', N'a743b653-39c2-43f5-baf6-b5d761e4ef5a_nghe-doc-truyen-mat-ma-da-vinci-dan-broen.jpg', N'875f8cb5-825e-4ca7-a3e2-3723d76cdbbb_588467fa250f6c99aea71de0ada9352d.jpg', 2131, 9, NULL)
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Rate], [Img1], [Img2], [Img3], [Quality], [CategoryId], [RequestCateId]) VALUES (34, N'Sherlock Holmes', CAST(4.98 AS Decimal(18, 2)), 5, N'de1edd53-b5a7-4ae4-9723-958fd79d244c_trinh-tham-5.jpg', N'1ccfe1e4-ccd5-407a-844a-52ff5a7f8b48_sherlock-holmes-36679.jpg', N'af0e85f7-c9c0-48d5-84d0-15d3b30a2583_sherlock-holmes-800x852.jpg', 1231, 9, NULL)
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Rate], [Img1], [Img2], [Img3], [Quality], [CategoryId], [RequestCateId]) VALUES (35, N'Những người khốn khổ', CAST(9.12 AS Decimal(18, 2)), 4, N'2fc7a697-f43d-4728-9646-9a790279e243_sach-nhung-nguoi-khon-kho-3-1.jpg', N'f5e40aaa-e359-4256-82f7-c5416ec36a23_images.jfif', N'6ae1d6eb-7f28-46e1-81e8-75a8d6d57a4d_images (1).jfif', 12313, 10, NULL)
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Rate], [Img1], [Img2], [Img3], [Quality], [CategoryId], [RequestCateId]) VALUES (36, N'Thiên tài bên trái, kẻ điên bên phải', CAST(3.90 AS Decimal(18, 2)), 4, N'2cd5566c-3319-4f96-abad-aedc70704f72_2311_thientaibentraikedienbenphai_rigo.vn.jpg', N'7cf7c830-51bd-4383-8f15-76a0b0999eb0_review-sach-thien-tai-ben-trai-ke-dien-ben-phai-768x1024.jpg', N'650868a2-58e8-4008-9695-0bc212d403ff_images (2).jfif', 1312, 10, NULL)
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Rate], [Img1], [Img2], [Img3], [Quality], [CategoryId], [RequestCateId]) VALUES (37, N'Classroom Of The Elite', CAST(5.07 AS Decimal(18, 2)), 5, N'98bfc989-f596-45d8-80a3-14e8242eee1c_tải xuống.jfif', N'a15c1913-e6dc-48a9-a378-102268e7daf1_tải xuống (1).jfif', N'70d2ea19-52fa-4a57-8f41-d99b684052fc_images (3).jfif', 12312, 11, NULL)
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Rate], [Img1], [Img2], [Img3], [Quality], [CategoryId], [RequestCateId]) VALUES (38, N'Sword Art Online', CAST(5.07 AS Decimal(18, 2)), 5, N'4fc57191-0361-43c8-b072-52ee8081b71d_images (4).jfif', N'a1e75576-f641-439c-b62f-f10f311857c5_images (6).jfif', N'24ec6517-fa40-4306-9c9c-4053d1646f99_images (5).jfif', 2131, 11, NULL)
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Rate], [Img1], [Img2], [Img3], [Quality], [CategoryId], [RequestCateId]) VALUES (39, N'Chí Phèo', CAST(3.78 AS Decimal(18, 2)), 4, N'714f1619-b30e-4080-a678-5e3cfc620cee_sach-chi-pheo-211x300.png', N'6fa50441-a0a5-48bc-a21b-ecca66879572_sach-chi-pheo-211x300.png', N'804949f0-68d0-4aa5-98cc-acdd2da08ea3_sach-chi-pheo-211x300.png', 212, 12, NULL)
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Rate], [Img1], [Img2], [Img3], [Quality], [CategoryId], [RequestCateId]) VALUES (40, N'Những Ngày Thơ Ấu', CAST(2.40 AS Decimal(18, 2)), 3, N'673431f8-3f57-4efb-a5ee-3df0aabe3221_sach-nhung-ngay-tho-au-2019-210x300.jpg', N'a04bec14-06fb-49e5-a5fa-22a79eccea7b_sach-nhung-ngay-tho-au-2019-210x300.jpg', N'40dcc6af-8659-42c4-ad6f-96bb5e3d93ae_sach-nhung-ngay-tho-au-2019-210x300.jpg', 123, 12, NULL)
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Rate], [Img1], [Img2], [Img3], [Quality], [CategoryId], [RequestCateId]) VALUES (41, N'Hà Nội 36 Phố Phường', CAST(4.20 AS Decimal(18, 2)), 2, N'20c5dd9e-c87a-4e03-991f-421517355a11_sach-ha-noi-36-pho-phuong-192x300.jpg', N'b7e085e3-e618-479e-9e2a-ccb9a44c18cc_sach-ha-noi-36-pho-phuong-192x300.jpg', N'a64ab99d-edf8-4826-9de9-fb335e0e10e7_sach-ha-noi-36-pho-phuong-192x300.jpg', 2131, 13, NULL)
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Rate], [Img1], [Img2], [Img3], [Quality], [CategoryId], [RequestCateId]) VALUES (42, N'Bỉ Vỏ', CAST(1.20 AS Decimal(18, 2)), 1, N'1b613135-f708-4d5f-85fb-2a2d0bbc5e04_sach-bi-vo-247x300.png', N'335f51b1-e9f8-40dd-91c5-823e7988c040_sach-bi-vo-247x300.png', N'0fe37c32-f300-40af-955c-66dbb197db79_sach-bi-vo-247x300.png', 2123, 12, NULL)
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Rate], [Img1], [Img2], [Img3], [Quality], [CategoryId], [RequestCateId]) VALUES (43, N'Số Đỏ', CAST(1.90 AS Decimal(18, 2)), 3, N'3eb29ef2-8ad6-4e9f-9757-fd4601068954_Số Đỏ.jpg', N'8b377826-dc3f-4875-9871-d20bb349b714_Số Đỏ.jpg', N'd692ca2a-fb5d-4aff-965d-5532eae397b5_Số Đỏ.jpg', 213, 13, NULL)
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Rate], [Img1], [Img2], [Img3], [Quality], [CategoryId], [RequestCateId]) VALUES (44, N'Vợ Nhặt', CAST(1.21 AS Decimal(18, 2)), 2, N'a64ea896-2017-4364-95f5-3c9109c8f44e_Vợ Nhặt.jpg', N'1883eb28-61ce-4084-8551-aa73e966ddc2_Vợ Nhặt.jpg', N'b4ecd7db-5f46-4e60-acc8-e561e06c7d2a_Vợ Nhặt.jpg', 1234, 13, NULL)
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Rate], [Img1], [Img2], [Img3], [Quality], [CategoryId], [RequestCateId]) VALUES (45, N'Bến Không Chồng', CAST(1.20 AS Decimal(18, 2)), 3, N'20081f85-2553-4d44-8369-68e2491ce3c9_sach-ben-khong-chong-197x300.jpg', N'fb4b1583-dd04-4989-be51-fe0887a6f6f9_sach-ben-khong-chong-197x300.jpg', N'd1b5ecb3-705b-4c5d-aabd-5a0892d77bd2_sach-ben-khong-chong-197x300.jpg', 214, 13, NULL)
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Rate], [Img1], [Img2], [Img3], [Quality], [CategoryId], [RequestCateId]) VALUES (46, N'Nếu Chỉ Còn Một Ngày Để Sống – Nicola Yoon', CAST(4.10 AS Decimal(18, 2)), 3, N'31d70557-9b29-4f25-89c8-b6d2e1e07843_Nếu Chỉ Còn Một Ngày Để Sống – Nicola Yoon.jpg', N'becec584-1b41-4ca3-988b-8a9986870695_Nếu Chỉ Còn Một Ngày Để Sống – Nicola Yoon.jpg', N'3e87dbd7-c9e9-4c98-956b-2970920e6f2a_Nếu Chỉ Còn Một Ngày Để Sống – Nicola Yoon.jpg', 12323, 14, NULL)
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Rate], [Img1], [Img2], [Img3], [Quality], [CategoryId], [RequestCateId]) VALUES (47, N'Colorful – Mori Eto', CAST(2.00 AS Decimal(18, 2)), 4, N'1c537002-b77d-4b88-a1c1-239fa666c12c_Colorful – Mori Eto.jpg', N'f4c37c95-d7cf-4360-92cc-120d81bf4764_Colorful – Mori Eto.jpg', N'a6d6c26a-f638-43af-9eed-46a72222f3f0_Colorful – Mori Eto.jpg', 123, 14, NULL)
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Rate], [Img1], [Img2], [Img3], [Quality], [CategoryId], [RequestCateId]) VALUES (48, N'Bố Con Cá Gai – Cho Chang–In', CAST(2.67 AS Decimal(18, 2)), 3, N'2b62886d-1a4e-467e-a67d-0133f05c48bb_Bố Con Cá Gai – Cho Chang – In.jpg', N'44acca9c-8835-439a-9b07-e14ca29ebafd_Bố Con Cá Gai – Cho Chang – In.jpg', N'5fa7341f-d030-4bc0-8bee-dc51fb8d46a1_Bố Con Cá Gai – Cho Chang – In.jpg', 123, 14, NULL)
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [Status]) VALUES (8, N'Manga', N'Manga là một cụm từ tiếng Nhật để chỉ các loại truyện tranh và tranh biếm họa của Nhật Bản. Bên ngoài Nhật Bản, Manga ám chỉ tính đặc trưng riêng biệt của truyện tranh Nhật Bản, hoặc như một phong cách truyện tranh phổ biến tại Nhật Bản mà thường được mô tả bởi đồ họa tràn đầy màu sắc, các nhân vật sống động và những chủ đề tuyệt vời.', N'Approve')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [Status]) VALUES (9, N'Trinh thám', N'Truyện trinh thám hay tiểu thuyết trinh thám là một tiểu loại của tiểu thuyết phiêu lưu. Bản thân tên gọi thể loại đã làm nổi bật một vài đặc điểm riêng của nó. Nó nói lên nghề nghiệp của nhân vật chính. ', N'Approve')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [Status]) VALUES (10, N'Văn học kinh điển', N'Văn học kinh điển được gọi là tập hợp các tác phẩm cổ điển là một phần của văn hóa cao. Những tác phẩm này, vì đặc điểm chính thức, tính nguyên bản hoặc chất lượng của chúng, đã vượt qua thời gian và biên giới, trở nên phổ biến và luôn có giá trị.', N'Approve')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [Status]) VALUES (11, N'Light Novel', N'Light novel hay tiểu thuyết ngắn, là một dòng tiểu thuyết có nguồn gốc từ Nhật Bản. "Light" trong "light novel" nghĩa là ngắn, nhẹ về số lượng từ ngữ. Light novel thường được gọi tắt là ranobe hay rainobe', N'Approve')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [Status]) VALUES (12, N'Văn học hiện đại', N'Văn học hiện đại là những tác phẩm được xảy ra vào thời kỳ hiện đại từ cuối thế kỷ 19 và đầu thế kỷ 20. Những tác phẩm trong thời gian này đều hướng đến nội dung hiện thực, tinh thần yêu nước, tình cảm và tinh thần nhân đạo.', N'Approve')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [Status]) VALUES (13, N'Văn học Việt Nam', N'Văn học Việt Nam là khoa học nghiên cứu, phê bình và sáng tác ngữ văn của người Việt Nam, không kể quốc tịch và thời đại.', N'Approve')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [Status]) VALUES (14, N'Văn học nước ngoài', N'Sách ngoại văn là các dòng sách nguyên bản được viết và xuất bản tại nước ngoài. Dòng sách này cũng được phân làm nhiều thể loại khác nhau thường được người dùng quan tâm như sách ngoại văn tiểu thuyết, sách ngoại văn cho trẻ em, sách ngoại văn chuyên ngành hay sách nghiên cứu khoa học bằng tiếng Anh', N'Approve')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_RequestCates_RequestCateId] FOREIGN KEY([RequestCateId])
REFERENCES [dbo].[RequestCates] ([Id])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_RequestCates_RequestCateId]
GO
