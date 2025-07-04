USE [escuelamusica]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 29/06/2025 11:07:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alumnos]    Script Date: 29/06/2025 11:07:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumnos](
	[id_Alumno] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Amaterno] [varchar](50) NULL,
	[Apaterno] [varchar](50) NULL,
 CONSTRAINT [PK_Alumnos] PRIMARY KEY CLUSTERED 
(
	[id_Alumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alumnosescuela]    Script Date: 29/06/2025 11:07:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumnosescuela](
	[IdEscuela] [int] NOT NULL,
	[IdAlumno] [int] NOT NULL,
 CONSTRAINT [PK_Alumnosescuela] PRIMARY KEY CLUSTERED 
(
	[IdEscuela] ASC,
	[IdAlumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alumnosprofesores]    Script Date: 29/06/2025 11:07:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumnosprofesores](
	[idAlumno] [int] NULL,
	[IdProfesor] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Escuela]    Script Date: 29/06/2025 11:07:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Escuela](
	[idEscuela] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Descripcion] [varchar](150) NULL,
 CONSTRAINT [PK_Escuela] PRIMARY KEY CLUSTERED 
(
	[idEscuela] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesores]    Script Date: 29/06/2025 11:07:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesores](
	[idProfesor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
 CONSTRAINT [PK_Profesores] PRIMARY KEY CLUSTERED 
(
	[idProfesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesorescuela]    Script Date: 29/06/2025 11:07:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesorescuela](
	[idprofesor] [int] NOT NULL,
	[idEscuela] [int] NOT NULL,
 CONSTRAINT [PK_Profesorescuela] PRIMARY KEY CLUSTERED 
(
	[idprofesor] ASC,
	[idEscuela] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Alumnosescuela]  WITH CHECK ADD  CONSTRAINT [FK_Alumnosescuela_Alumnos] FOREIGN KEY([IdAlumno])
REFERENCES [dbo].[Alumnos] ([id_Alumno])
GO
ALTER TABLE [dbo].[Alumnosescuela] CHECK CONSTRAINT [FK_Alumnosescuela_Alumnos]
GO
ALTER TABLE [dbo].[Alumnosescuela]  WITH CHECK ADD  CONSTRAINT [FK_Alumnosescuela_Escuela] FOREIGN KEY([IdEscuela])
REFERENCES [dbo].[Escuela] ([idEscuela])
GO
ALTER TABLE [dbo].[Alumnosescuela] CHECK CONSTRAINT [FK_Alumnosescuela_Escuela]
GO
ALTER TABLE [dbo].[Alumnosprofesores]  WITH NOCHECK ADD  CONSTRAINT [FK_Alumnosprofesores_Alumnos] FOREIGN KEY([idAlumno])
REFERENCES [dbo].[Alumnos] ([id_Alumno])
GO
ALTER TABLE [dbo].[Alumnosprofesores] NOCHECK CONSTRAINT [FK_Alumnosprofesores_Alumnos]
GO
ALTER TABLE [dbo].[Alumnosprofesores]  WITH NOCHECK ADD  CONSTRAINT [FK_Alumnosprofesores_Profesores] FOREIGN KEY([IdProfesor])
REFERENCES [dbo].[Profesores] ([idProfesor])
GO
ALTER TABLE [dbo].[Alumnosprofesores] NOCHECK CONSTRAINT [FK_Alumnosprofesores_Profesores]
GO
ALTER TABLE [dbo].[Profesorescuela]  WITH CHECK ADD  CONSTRAINT [FK_Profesorescuela_Escuela] FOREIGN KEY([idEscuela])
REFERENCES [dbo].[Escuela] ([idEscuela])
GO
ALTER TABLE [dbo].[Profesorescuela] CHECK CONSTRAINT [FK_Profesorescuela_Escuela]
GO
ALTER TABLE [dbo].[Profesorescuela]  WITH CHECK ADD  CONSTRAINT [FK_Profesorescuela_Profesores] FOREIGN KEY([idprofesor])
REFERENCES [dbo].[Profesores] ([idProfesor])
GO
ALTER TABLE [dbo].[Profesorescuela] CHECK CONSTRAINT [FK_Profesorescuela_Profesores]
GO
/****** Object:  StoredProcedure [dbo].[GetAlumnosInscritosXProfesor]    Script Date: 29/06/2025 11:07:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAlumnosInscritosXProfesor](
	@IdProfesor int    
	) as
	Begin
 
select Profesor =  P.Nombre + ' '+ p.Apellido, Alumno=  a.Nombre + ' ' + A.Amaterno, Escuela = E.Nombre from Alumnos A
	inner join Alumnosprofesores AP on A.id_Alumno = AP.idAlumno
	inner join Alumnosescuela AE on AE.IdAlumno = A.id_Alumno
	inner join Profesores P on P.idProfesor = AP.IdProfesor
	inner join Escuela E on E.idEscuela = AE.IdEscuela
	where p.idProfesor = @idProfesor
	 
 end
GO
/****** Object:  StoredProcedure [dbo].[GetEscuelasProfesor]    Script Date: 29/06/2025 11:07:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEscuelasProfesor](
	@IdProfesor int    
	) as
	Begin
 
	select  Escuela = E.Nombre, Profesor =  P.Nombre + ' '+ p.Apellido, a.Nombre, A.Amaterno from Alumnos A
	inner join Alumnosprofesores AP on A.id_Alumno = AP.idAlumno
	inner join Profesores P on P.idProfesor = AP.IdProfesor
	inner join Profesorescuela PE on PE.idprofesor = P.idProfesor
	inner join Escuela E on E.idEscuela = PE.IdEscuela
	where P.idProfesor = 1
	order by E.idEscuela

	 
 end
GO
/****** Object:  StoredProcedure [dbo].[RegistraAlumno]    Script Date: 29/06/2025 11:07:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistraAlumno](
	 @Nombre varchar(50),
	  @Apaterno varchar(50),
     @Amaterno varchar(50)
	) as
	Begin
		INSERT INTO [dbo].[Alumnos]
				   ([Nombre]
				   ,[Amaterno]
				   ,[Apaterno])
			 VALUES
				   (@Nombre
				   ,@Amaterno
				   ,@Apaterno);

	Select * from dbo.Alumnos where id_Alumno =SCOPE_IDENTITY();
	End;
GO
/****** Object:  StoredProcedure [dbo].[RegistraAlumnosEscuela]    Script Date: 29/06/2025 11:07:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistraAlumnosEscuela](
	 @IdEscuela int,
     @IdAlumno int
	) as
	Begin
 
 if	 exists(select * from Alumnosescuela where IdAlumno = @IdAlumno and IdEscuela = @IdEscuela)  
 RETURN
 else 
		INSERT INTO [dbo].[Alumnosescuela]
			   ([IdEscuela]
			   ,[IdAlumno])
		 VALUES
			   (@IdEscuela
			   ,@IdAlumno)

 end
GO
/****** Object:  StoredProcedure [dbo].[RegistraAlumnosprofesores]    Script Date: 29/06/2025 11:07:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistraAlumnosprofesores](
	 @IdAlumno int,
	@IdProfesor int    
	) as
	Begin
 
 if	 exists(select * from [Alumnosprofesores] where IdAlumno = @IdAlumno and IdProfesor = @IdProfesor)  
 RETURN
 else 
	INSERT INTO [dbo].[Alumnosprofesores]
			   ([idAlumno]
			   ,[IdProfesor])
		 VALUES
			   (@IdAlumno
			   ,@IdProfesor)
 
 end
GO
/****** Object:  StoredProcedure [dbo].[RegistraEscuela]    Script Date: 29/06/2025 11:07:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistraEscuela](
	 @Nombre varchar(100),
     @Descripcion varchar(50)
	) as
	Begin
 

		INSERT INTO [dbo].[Escuela]
				   ([Nombre]
				   ,[Descripcion])
			 VALUES
				   (@Nombre
				   ,@Descripcion)
	End
GO
/****** Object:  StoredProcedure [dbo].[RegistraProfesor]    Script Date: 29/06/2025 11:07:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistraProfesor](
	 @Nombre varchar(50),
     @Apellido varchar(50)
	) as
	Begin
 
INSERT INTO [dbo].[Profesores]
           ([Nombre]
           ,[Apellido])
     VALUES
           (@Nombre
           ,@Apellido)
 end
GO
/****** Object:  StoredProcedure [dbo].[RegistraprofesoresEscuela]    Script Date: 29/06/2025 11:07:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistraprofesoresEscuela](
	 @idEscuela int,
	@IdProfesor int    
	) as
	Begin
 
 if	 exists(select * from [Profesorescuela] where Idprofesor = @IdProfesor and idEscuela = @idEscuela)  
 RETURN
 else 
 
INSERT INTO [dbo].[Profesorescuela]
           ([idprofesor]
           ,[idEscuela])
     VALUES
           (@IdProfesor
           ,@idEscuela)
 end
GO
