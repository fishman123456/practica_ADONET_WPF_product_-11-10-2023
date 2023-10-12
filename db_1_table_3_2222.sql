USE [things_db]
GO
/****** Object:  Table [dbo].[product_t]    Script Date: 12.10.2023 12:32:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_t](
	[id_f] [int] IDENTITY(1,1) NOT NULL,
	[name_f] [nvarchar](50) NOT NULL,
	[self_cost_f] [nvarchar](50) NOT NULL,
	[date_f] [date] NOT NULL,
	[type_id_f] [int] NOT NULL,
	[supplier_id_f] [int] NOT NULL,
	[count_f] [int] NOT NULL,
 CONSTRAINT [PK_product_t] PRIMARY KEY CLUSTERED 
(
	[id_f] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[supplier_t]    Script Date: 12.10.2023 12:32:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[supplier_t](
	[id_f] [int] IDENTITY(1,1) NOT NULL,
	[supplier_f] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_supplier_t] PRIMARY KEY CLUSTERED 
(
	[id_f] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[type_t]    Script Date: 12.10.2023 12:32:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[type_t](
	[id_f] [int] IDENTITY(1,1) NOT NULL,
	[type_f] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_type_t] PRIMARY KEY CLUSTERED 
(
	[id_f] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[product_t] ADD  DEFAULT (getdate()) FOR [date_f]
GO
ALTER TABLE [dbo].[product_t]  WITH CHECK ADD  CONSTRAINT [FK_product_t_supplier_t] FOREIGN KEY([supplier_id_f])
REFERENCES [dbo].[supplier_t] ([id_f])
GO
ALTER TABLE [dbo].[product_t] CHECK CONSTRAINT [FK_product_t_supplier_t]
GO
ALTER TABLE [dbo].[product_t]  WITH CHECK ADD  CONSTRAINT [FK_product_t_type_t] FOREIGN KEY([type_id_f])
REFERENCES [dbo].[type_t] ([id_f])
GO
ALTER TABLE [dbo].[product_t] CHECK CONSTRAINT [FK_product_t_type_t]
GO
