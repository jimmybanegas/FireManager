USE [tbd2]
GO

/****** Object:  Table [dbo].[Clientes_emp1]    Script Date: 25/06/2015 03:27:44 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Clientes_af](
	[numero] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[edad] [tinyint] NULL,
	[fecha_nac] [datetime] NULL,
	[salario] [money] NULL,
	[credito_disponible] [bigint] NULL,
	[demandado] [bit] NULL,
	[saldo_actual] [real] NULL,
	[saldo_anterior] [float] NULL,
	[sexo] [char](1) NULL,
	[fecha_demanda] [smalldatetime] NULL,
 CONSTRAINT [PK_Clientes_af] PRIMARY KEY CLUSTERED 
(
	[numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


