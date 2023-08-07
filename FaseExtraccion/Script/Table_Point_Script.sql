USE [FasesExtraccion]
GO

/****** Object:  Table [dbo].[Point]    Script Date: 8/7/2023 12:30:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Point](
	[IdEmplazamiento] [int] NULL,
	[X] [int] NULL,
	[Y] [int] NULL,
	[Ubicacion] [bit] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Point] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Point]  WITH CHECK ADD  CONSTRAINT [FK_Point_Fase] FOREIGN KEY([IdEmplazamiento])
REFERENCES [dbo].[Fase] ([IdEmplazamiento])
GO

ALTER TABLE [dbo].[Point] CHECK CONSTRAINT [FK_Point_Fase]
GO


