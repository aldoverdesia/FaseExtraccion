USE [FasesExtraccion]
GO

/****** Object:  Table [dbo].[Fase]    Script Date: 8/7/2023 12:29:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Fase](
	[Nombre] [nchar](50) NOT NULL,
	[Estado] [int] NULL,
	[IdEmplazamiento] [int] NOT NULL,
 CONSTRAINT [PK_Fase] PRIMARY KEY CLUSTERED 
(
	[IdEmplazamiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


