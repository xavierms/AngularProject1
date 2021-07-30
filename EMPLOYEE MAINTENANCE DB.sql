CREATE DATABASE EMPLOYEEMANAG

CREATE TABLE TRABAJADORES
(
ID INT PRIMARY KEY IDENTITY(1,1),
TrabajadorNum   varchar(5),
TrabajadorNomb  varchar(15),
TrabajadorTarif varchar(6),
Oficio          varchar(25),
TrabajadorSuper varchar(5),

)

CREATE TABLE EDIFICIOS
(
ID INT PRIMARY KEY IDENTITY(1,1),
EdificioNum       varchar(4),
EdificioDireccion varchar(max),
TipoEdif          varchar(12),
NivelCal          char(1),
Categor           char(1)
)


CREATE TABLE ASIGNACIONES
(
ID INT PRIMARY KEY IDENTITY(1,1),
AsigNum          varchar(3),
EdificioNum_fk   int,
TrabajadorNum_fk int,
AsigFechIni      date,
AsigNumDias      varchar(3),

CONSTRAINT FK_EdificioNum FOREIGN KEY (EdificioNum_fk) REFERENCES EDIFICIOS(ID),
CONSTRAINT FK_TRABAJADORES FOREIGN KEY (TrabajadorNum_fk) REFERENCES TRABAJADORES(ID),
)

------------------------------------------
--INSERTS EMPLOYEE
------------------------------------------

INSERT INTO TRABAJADORES(TrabajadorNum,TrabajadorNomb,TrabajadorTarif,Oficio,TrabajadorSuper) VALUES (1235, 'PAULO MEJIA',       12.5, 'ELECTRICISTA',      1311)
INSERT INTO TRABAJADORES(TrabajadorNum,TrabajadorNomb,TrabajadorTarif,Oficio,TrabajadorSuper) VALUES (1311, 'YOANNY ACOSTA',     15.5, 'ENC. ELECTRICISTA', 4221)
INSERT INTO TRABAJADORES(TrabajadorNum,TrabajadorNomb,TrabajadorTarif,Oficio,TrabajadorSuper) VALUES (1412, 'RAUL PEREZ',        13.75,'ENC. FONTANERO',    4221)
INSERT INTO TRABAJADORES(TrabajadorNum,TrabajadorNomb,TrabajadorTarif,Oficio,TrabajadorSuper) VALUES (1520, 'JUANA MENDEZ',      11.75,'FONTANERO',         1412)
INSERT INTO TRABAJADORES(TrabajadorNum,TrabajadorNomb,TrabajadorTarif,Oficio,TrabajadorSuper) VALUES (2920, 'JAZMINE PERZ',      10,   'ALBAÑIL',           2920)
INSERT INTO TRABAJADORES(TrabajadorNum,TrabajadorNomb,TrabajadorTarif,Oficio,TrabajadorSuper) VALUES (4221, 'AMBIORIX GUZMAN',   50.5, 'INGENIERO',         4223)
INSERT INTO TRABAJADORES(TrabajadorNum,TrabajadorNomb,TrabajadorTarif,Oficio,TrabajadorSuper) VALUES (3001, 'BRAULIO ALCANTARA', 8.2,  'CARPINTERO',        4221)

------------------------------------------
--INSERTS BUILDINGS
------------------------------------------

INSERT INTO EDIFICIOS(EdificioNum,EdificioDireccion,TipoEdif,NivelCal,Categor) VALUES (111, '1213 OVANDO',      'OFICINA', 4, 1)
INSERT INTO EDIFICIOS(EdificioNum,EdificioDireccion,TipoEdif,NivelCal,Categor) VALUES (210, '1011 VENEZUELA',   'OFICINA', 3, 1)
INSERT INTO EDIFICIOS(EdificioNum,EdificioDireccion,TipoEdif,NivelCal,Categor) VALUES (312, '123 ENS. LUPERON', 'OFICINA', 2, 2)
INSERT INTO EDIFICIOS(EdificioNum,EdificioDireccion,TipoEdif,NivelCal,Categor) VALUES (435, 'LOS GIRASOLES',    'COMERCIO',1, 1)

------------------------------------------
--INSERTS ASSIGNMENTS   YYYY-MM-DD
------------------------------------------

INSERT INTO ASIGNACIONES (AsigNum,EdificioNum_fk,TrabajadorNum_fk,AsigFechIni,AsigNumDias) VALUES (1, 1, 1, '2008/01/10', 5)
INSERT INTO ASIGNACIONES (AsigNum,EdificioNum_fk,TrabajadorNum_fk,AsigFechIni,AsigNumDias) VALUES (2, 2, 2, '2008/01/10', 22)
INSERT INTO ASIGNACIONES (AsigNum,EdificioNum_fk,TrabajadorNum_fk,AsigFechIni,AsigNumDias) VALUES (3, 3, 3, '2007/05/22', 4)
INSERT INTO ASIGNACIONES (AsigNum,EdificioNum_fk,TrabajadorNum_fk,AsigFechIni,AsigNumDias) VALUES (4, 4, 4, '2007/05/22', 12)
INSERT INTO ASIGNACIONES (AsigNum,EdificioNum_fk,TrabajadorNum_fk,AsigFechIni,AsigNumDias) VALUES (5, 3, 1, '2008/01/30', 5)
INSERT INTO ASIGNACIONES (AsigNum,EdificioNum_fk,TrabajadorNum_fk,AsigFechIni,AsigNumDias) VALUES (6, 4, 2, '2008/01/30', 2)
INSERT INTO ASIGNACIONES (AsigNum,EdificioNum_fk,TrabajadorNum_fk,AsigFechIni,AsigNumDias) VALUES (7, 3, 4, '2008/01/30', 12)
INSERT INTO ASIGNACIONES (AsigNum,EdificioNum_fk,TrabajadorNum_fk,AsigFechIni,AsigNumDias) VALUES (8, 4, 5, '2008/01/30', 12)
INSERT INTO ASIGNACIONES (AsigNum,EdificioNum_fk,TrabajadorNum_fk,AsigFechIni,AsigNumDias) VALUES (9, 2, 4, '2008/01/30', 25)
INSERT INTO ASIGNACIONES (AsigNum,EdificioNum_fk,TrabajadorNum_fk,AsigFechIni,AsigNumDias) VALUES (10,3, 3, '2008/01/30', 10)

-----------------------------------------
----PROCEDURES TRABAJADORES
-----------------------------------------
go
create procedure insertarTrabajador(

@id int ='',
@TrabajadorNum   varchar(5)='',
@TrabajadorNomb  varchar(15)='',
@TrabajadorTarif varchar(6)='',
@Oficio          varchar(25)='',
@TrabajadorSuper varchar(5)=''
)
as
Begin

insert into TRABAJADORES(TrabajadorNum,TrabajadorNomb,TrabajadorTarif,Oficio,TrabajadorSuper)
			values(@TrabajadorNum,@TrabajadorNomb,@TrabajadorTarif,@Oficio,@TrabajadorSuper);
END;

------Tolist---------
go
CREATE PROCEDURE ListadoTrabajador
as
Begin

select * from TRABAJADORES

END;

-----ToListForid-----
go
create procedure trabajadorPorId(
@id int =''
)
as
Begin
select * from TRABAJADORES where id= @id;
END;

------Remove------
go
create procedure borrarTrabajador(
@id int =''
)
as
Begin
delete from TRABAJADORES where id=@id;
END;
------Update-------
go
create procedure actualizarTrabajador(
@id int ='',
@TrabajadorNum   varchar(5)='',
@TrabajadorNomb  varchar(15)='',
@TrabajadorTarif varchar(6)='',
@Oficio          varchar(25)='',
@TrabajadorSuper varchar(5)=''
)
as
Begin

update TRABAJADORES 
set TrabajadorNum=@TrabajadorNum, TrabajadorNomb=@TrabajadorNomb,TrabajadorTarif= @TrabajadorTarif,Oficio = @Oficio, TrabajadorSuper= @TrabajadorSuper
where id =@id;

END;
go
-----------------------------------------
----PROCEDURE EDICIFIO
-----------------------------------------
CREATE PROCEDURE insertarEdificio(

@ID INT ='',
@EdificioNum       varchar(4)  ='',
@EdificioDireccion varchar(max)  ='',
@TipoEdif          varchar(12)  ='',
@NivelCal          char(1)  ='',
@Categor           char(1)  =''
)
as
Begin

insert into EDIFICIOS(EdificioNum,EdificioDireccion,TipoEdif ,NivelCal,Categor)
			values(@EdificioNum,@EdificioDireccion,@TipoEdif ,@NivelCal,@Categor);
END;

------Tolist---------
GO
CREATE PROCEDURE ListadoEdificios
AS
BEGIN

SELECT * FROM EDIFICIOS

END;

-----ToListForid-----
GO
CREATE PROCEDURE edificioPorId(
@ID INT = ''
)
AS
BEGIN

SELECT * FROM EDIFICIOS WHERE ID=@ID;
END;

------Remove------
GO 
CREATE PROCEDURE borrarEdificio(
@ID INT = ''
)
AS 
BEGIN

DELETE FROM EDIFICIOS WHERE ID=@ID;
END;

------Update-------
GO
CREATE PROCEDURE actualizarEdificio(
@ID INT ='',
@EdificioNum       varchar(4)  ='',
@EdificioDireccion varchar(max)  ='',
@TipoEdif          varchar(12)  ='',
@NivelCal          char(1)  ='',
@Categor           char(1)  =''
)
AS 
BEGIN

UPDATE EDIFICIOS
SET EdificioNum=@EdificioNum, EdificioDireccion=@EdificioDireccion, TipoEdif=@TipoEdif, NivelCal= @NivelCal, Categor=@Categor
WHERE ID=@ID;

END;

-----------------------------------------
----PROCEDURE ASIGNACIONES
-----------------------------------------
create procedure insertarAsignacion(

@ID INT ='',
@AsigNum          varchar(3)='',
@EdificioNum_fk   int='',
@TrabajadorNum_fk int='',
@AsigFechIni      date='',
@AsigNumDias      varchar(3)=''
)
as
Begin

insert into ASIGNACIONES(AsigNum ,EdificioNum_fk ,TrabajadorNum_fk ,AsigFechIni ,AsigNumDias)
			values(@AsigNum ,@EdificioNum_fk ,@TrabajadorNum_fk ,@AsigFechIni ,@AsigNumDias);

END;

------Tolist---------
GO
CREATE PROCEDURE ListadoAsignaciones
AS
BEGIN

SELECT * FROM ASIGNACIONES

END;

-----ToListForid-----
GO
CREATE PROCEDURE asignacionPorId(
@ID INT = ''
)
AS
BEGIN

SELECT * FROM ASIGNACIONES WHERE ID=@ID;
END;

------Remove------
GO 
CREATE PROCEDURE borrarAsignacion(
@ID INT = ''
)
AS 
BEGIN

DELETE FROM ASIGNACIONES WHERE ID=@ID;
END;

------Update-------
GO
CREATE PROCEDURE actualizarAsignacion(
@ID INT ='',
@AsigNum          varchar(3)='',
@EdificioNum_fk   int='',
@TrabajadorNum_fk int='',
@AsigFechIni      date='',
@AsigNumDias      varchar(3)=''
)
AS 
BEGIN

UPDATE ASIGNACIONES
SET AsigNum=@AsigNum, EdificioNum_fk=@EdificioNum_fk, TrabajadorNum_fk=@TrabajadorNum_fk, AsigFechIni= @AsigFechIni, AsigNumDias=@AsigNumDias
WHERE ID=@ID;

END;






