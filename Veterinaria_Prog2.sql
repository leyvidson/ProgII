drop database Veteriniaria_Prog2
create database [Veteriniaria_Prog2]
USE [Veteriniaria_Prog2]
GO
/****** Object:  Table [dbo].[Atencion]    Script Date: 24/08/2022 15:40:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Atencion](
	[id_atencion] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NULL,
	[importe] [money] NULL,
	[id_mascota] [int] NULL,
 CONSTRAINT [pk_id_atencion] PRIMARY KEY CLUSTERED 
(
	[id_atencion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 24/08/2022 15:40:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NULL,
	[sexo] [int] NULL,
 CONSTRAINT [pk_cod_cliente] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mascotas]    Script Date: 24/08/2022 15:40:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mascotas](
	[id_mascota] [int] NOT NULL,
	[nombre] [varchar](30) NULL,
	[edad] [int] NULL,
	[id_tipo] [int] NULL,
	[codigo] [int] NULL,
 CONSTRAINT [pk_id_mascota] PRIMARY KEY CLUSTERED 
(
	[id_mascota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipos]    Script Date: 24/08/2022 15:40:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipos](
	[id_tipo] [int] NOT NULL,
	[nombre] [varchar](30) NULL,
 CONSTRAINT [pk_id_tipo] PRIMARY KEY CLUSTERED 
(
	[id_tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Atencion]  WITH CHECK ADD  CONSTRAINT [fk_mascota_atencion] FOREIGN KEY([id_mascota])
REFERENCES [dbo].[Mascotas] ([id_mascota])
GO
ALTER TABLE [dbo].[Atencion] CHECK CONSTRAINT [fk_mascota_atencion]
GO
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [fk_cliente_mascota] FOREIGN KEY([codigo])
REFERENCES [dbo].[clientes] ([codigo])
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [fk_cliente_mascota]
GO
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [fk_tipo_mascota] FOREIGN KEY([id_tipo])
REFERENCES [dbo].[tipos] ([id_tipo])
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [fk_tipo_mascota]
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_CLIENTE]    Script Date: 24/08/2022 15:40:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_CONSULTAR_CLIENTE]	
	as
	select * from clientes c left join Mascotas m on m.codigo = c.codigo;
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_CLIENTE]    Script Date: 24/08/2022 15:40:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc SP_CONSULTAR_TIPO_MASCOTA
as
select * from tipos

create proc [dbo].[SP_INSERTAR_CLIENTE]
	@nombre varchar(30),
	@sexo int
	as
		insert into clientes (nombre, sexo)
		values (@nombre,@sexo)
GO

create proc SP_INSERTAR_MASCOTA
@nombre varchar (30),
@edad int,
@id_tipo int
as
insert into Mascotas(nombre, edad, id_tipo)
values(@nombre,@edad,@id_tipo)

create proc SP_ELIMINAR_CLIENTE
@codigo int
as
delete from clientes where codigo = @codigo

create proc SP_ELIMINAR_MASCOTA
@id_mascota int
as
delete from Mascotas where id_mascota = @id_mascota



select * from clientes
select * from mascotas
select * from tipos


insert into clientes (nombre,sexo)
values('Agustin',1)
insert into clientes (nombre,sexo)
values('Carla',2)
insert into clientes (nombre,sexo)
values('Joaquin',1)


insert into tipos(id_tipo,nombre)
values(1,'Perro')
insert into tipos(id_tipo,nombre)
values(2,'Gato')


insert into mascotas (id_mascota,nombre, edad, id_tipo,codigo)
values (1,'Pichu',5,1,1)
insert into mascotas (id_mascota,nombre, edad, id_tipo,codigo)
values (2,'Micha',2,2,2)
insert into mascotas (id_mascota,nombre, edad, id_tipo,codigo)
values (3,'Paris',1,2,3)

exec SP_ELIMINAR_MASCOTA 1

create proc SP_INSERTAR_ATENCION
@fecha datetime,
@importe float,
@id_mascota int
as
insert into Atencion (fecha, importe,id_mascota)
values(@fecha,@importe,@id_mascota)

alter table atencion
drop column importe

alter table atencion
add importe float

insert into Atencion (fecha,importe,id_mascota)
values ('25/08/2022',3500,2)

select * from Atencion
 
