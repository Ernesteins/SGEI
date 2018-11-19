

create database SGEI
use SGEI
/*==============================================================*/
/* Table: ASISTENCIA                                            */
/*==============================================================*/
create table ASISTENCIA (
   IDASISTENCIA         int                  not null IDENTITY (1, 1),
   IDEMPLEADO           int                  null,
   FECHAREGISTRO        datetime             not null,
   HORAENTRADA          datetime             null,
   HORASALIDA           datetime             null,
   constraint PK_ASISTENCIA primary key nonclustered (IDASISTENCIA)
)
go

/*==============================================================*/
/* Index: TIENE_FK                                              */
/*==============================================================*/
create index TIENE_FK on ASISTENCIA (
IDEMPLEADO ASC
)
go
use SGEI;
/*==============================================================*/
/* Table: CLIENTE                                               */
/*==============================================================*/
create table CLIENTE (
   IDCLIENTE            int                  not null IDENTITY (1, 1),
   RUC                  varchar(13)          not null,
   NOMBRE_CLIENTE       varchar(20)          not null,
   APELLIDO_CLIENTE     varchar(20)          not null,
   TELEFONOMOVIL_CLIENTE numeric(15)          not null,
   DIRECCION_CLIENTE    varchar(100)         not null,
   CORREO_CLIENTE       varchar(50)          not null,
   ESTADO_CLIENTE       varchar(10)          not null,
   constraint PK_CLIENTE primary key nonclustered (IDCLIENTE)
)
go

/*==============================================================*/
/* Table: FACTURA                                               */
/*==============================================================*/
create table FACTURA (
   IDFACTURA            int                  not null IDENTITY (1, 1),
   IDVENTA              int                  null,
   FECHAEMISION         datetime             not null,
   ESTADOFACTURA        varchar(10)          not null,
   PRECIOSUBTOTAL       money                not null,
   IMPORTEIVA           money                not null,
   PRECIOTOTALAPAGAR    money                not null,
   constraint PK_FACTURA primary key nonclustered (IDFACTURA)
)
go

/*==============================================================*/
/* Index: FACTURADA2_FK                                         */
/*==============================================================*/
create index FACTURADA2_FK on FACTURA (
IDVENTA ASC
)
go

/*==============================================================*/
/* Table: DETALLEVENTA                                          */
/*==============================================================*/
create table DETALLEVENTA (
   IDDETALLEVENTA       int                  not null IDENTITY (1, 1),
   IDSERVICIO           int                  null,
   IDVENTA              int                  null,
   CANTIDAD             int                  not null,
   TOTAL                money                not null,
   IDFACTURA INT FOREIGN KEY REFERENCES FACTURA(IDFACTURA)
	CONSTRAINT cod_dventa PRIMARY KEY(IDFACTURA,IDDETALLEVENTA))
 

go

/*==============================================================*/
/* Index: TENER_FK                                              */
/*==============================================================*/
create index TENER_FK on DETALLEVENTA (
IDVENTA ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_7_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_7_FK on DETALLEVENTA (
IDSERVICIO ASC
)
go

/*==============================================================*/
/* Table: EMPLEADO                                              */
/*==============================================================*/
create table EMPLEADO (
   IDEMPLEADO           int                  not null IDENTITY (1, 1),
   CEDULA               varchar(10)          not null,
   NOMBRE_EMPLEADO      varchar(20)          not null,
   APELLIDO_EMPLEADO    varchar(20)          not null,
   TELEFONOMOVIL_EMPLEADO numeric              not null,
   DIRECCION_EMPLEADO   varchar(100)         not null,
   CARGO                varchar(15)          not null,
   SALARIO              money                not null,
   ESTADO_EMPLEADO      varchar(10)          not null,
   constraint PK_EMPLEADO primary key nonclustered (IDEMPLEADO)
)
go



/*==============================================================*/
/* Table: SERVICIO                                              */
/*==============================================================*/
create table SERVICIO (
   IDSERVICIO           int                not null IDENTITY (1, 1),
   NOMBRESERVICIO       varchar(20)          not null,
   DESCRIPCIONSERVICIO  varchar(100)         not null,
   PRECIOSERVICIO       money                not null,
   constraint PK_SERVICIO primary key nonclustered (IDSERVICIO)
)
go

/*==============================================================*/
/* Table: SOPORTE                                               */
/*==============================================================*/
create table SOPORTE (
   IDSOPORTE            int                  not null IDENTITY (1, 1),
   IDSERVICIO           int                  null,
   PRECIOSOPORTE        money                not null,
   DESCRIPCIONSOPORTE   varchar(100)         not null,
   NOMBRESOPORTE        varchar(50)          not null,
   constraint PK_SOPORTE primary key nonclustered (IDSOPORTE)
)
go

/*==============================================================*/
/* Index: TIENE1_FK                                             */
/*==============================================================*/
create index TIENE1_FK on SOPORTE (
IDSERVICIO ASC
)
go

/*==============================================================*/
/* Table: VENTA                                                 */
/*==============================================================*/
create table VENTA (
   IDVENTA              int                not null IDENTITY (1, 1),
   IDCLIENTE            int                  null,
   IDEMPLEADO           int                  null,
   FECHAVENTA           datetime             not null,
   ESTADOVENTA          varchar(10)          not null,
   PRECIOTOTALVENTA     money                not null,
   constraint PK_VENTA primary key nonclustered (IDVENTA)
)
go

/*==============================================================*/
/* Index: REALIZA_FK                                            */
/*==============================================================*/
create index REALIZA_FK on VENTA (
IDEMPLEADO ASC
)
go

/*==============================================================*/
/* Index: PARTICIPA_FK                                          */
/*==============================================================*/
create index PARTICIPA_FK on VENTA (
IDCLIENTE ASC
)
go

alter table ASISTENCIA
   add constraint FK_ASISTENC_TIENE_EMPLEADO foreign key (IDEMPLEADO)
      references EMPLEADO (IDEMPLEADO)
go

alter table DETALLEVENTA
   add constraint FK_DETALLEV_RELATIONS_SERVICIO foreign key (IDSERVICIO)
      references SERVICIO (IDSERVICIO)
go


alter table FACTURA
   add constraint FK_FACTURA_RELATIONS_VENTA foreign key (IDVENTA)
      references VENTA (IDVENTA)
go

alter table SOPORTE
   add constraint FK_SOPORTE_TIENE1_SERVICIO foreign key (IDSERVICIO)
      references SERVICIO (IDSERVICIO)
go

alter table VENTA
   add constraint FK_VENTA_PARTICIPA_CLIENTE foreign key (IDCLIENTE)
      references CLIENTE (IDCLIENTE)
go

alter table VENTA
   add constraint FK_VENTA_REALIZA_EMPLEADO foreign key (IDEMPLEADO)
      references EMPLEADO (IDEMPLEADO)
go
