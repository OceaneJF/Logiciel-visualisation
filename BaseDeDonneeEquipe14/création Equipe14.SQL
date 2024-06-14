/*
 ----------------------------------------------------------------------------
             Génération d'une base de données pour
                        SQL Server 2005
                       (9/6/2024 11:26:03)
 ----------------------------------------------------------------------------
     Nom de la base : BDEquipe14
     Projet : Espace de travail
     Auteur : CRIIUT
     Date de dernière modification : 9/6/2024 11:25:21
 ----------------------------------------------------------------------------
*/

drop database BDEquipe14
go

/* -----------------------------------------------------------------------------
      OUVERTURE DE LA BASE BDEquipe14
----------------------------------------------------------------------------- */

create database BDEquipe14
go

use BDEquipe14
go



/* -----------------------------------------------------------------------------
      TABLE : T_COUNTRY_CTR
----------------------------------------------------------------------------- */

create table T_COUNTRY_CTR
  (
     CTR_ID char(3)  not null  ,
     CTR_NAME char(32)  not null
	 constraint C_UNI_CTR_NAME unique(CTR_NAME)
     ,
     constraint PK_T_COUNTRY_CTR primary key (CTR_ID)
  ) 
go



/* -----------------------------------------------------------------------------
      TABLE : T_REGION_REG
----------------------------------------------------------------------------- */

create table T_REGION_REG
  (
     REG_ID int identity (1, 1)   ,
     REG_NAME char(255)  not null
	 constraint C_UNI_REG_NAME unique(REG_NAME)
     ,
     constraint PK_T_REGION_REG primary key (REG_ID)
  ) 
go



/* -----------------------------------------------------------------------------
      TABLE : T_ENERGYSOURCE_ENS
----------------------------------------------------------------------------- */

create table T_ENERGYSOURCE_ENS
  (
     ENS_ID int identity (1, 1)   ,
     ENS_NAME char(32)  not null 
	 constraint C_UNI_ENS_NAME unique(ENS_NAME),
     ENS_ISFOSSIL bit  null  
     ,
     constraint PK_T_ENERGYSOURCE_ENS primary key (ENS_ID)
  ) 
go



/* -----------------------------------------------------------------------------
      TABLE : T_SECTOR_SCT
----------------------------------------------------------------------------- */

create table T_SECTOR_SCT
  (
     SCT_ID int identity (1, 1)   ,
     SCT_NAME char(32)  not null  
     constraint C_UNI_SCT_NAME unique(SCT_NAME),
     constraint PK_T_SECTOR_SCT primary key (SCT_ID)
  ) 
go



/* -----------------------------------------------------------------------------
      TABLE : T_GEOGRAPHICALDATA_GEO
----------------------------------------------------------------------------- */

create table T_GEOGRAPHICALDATA_GEO
  (
     GEO_ID bigint identity (1, 1)   ,
     CTR_ID char(3)  null  ,
     GEO_CRS char(10)  not null  ,
     GEO_MEANTEMP real  null  ,
     GEO_TX35 real  null  ,
     GEO_SEALVL real  null  ,
     GEO_MEANTEMPCHANGE real  null  ,
     GEO_TOTALPRECIPIT real  null  ,
     GEO_LAT real  not null  ,
     GEO_LON real  not null  
     ,
     constraint PK_T_GEOGRAPHICALDATA_GEO primary key (GEO_ID)
  ) 
go



/*      INDEX DE T_GEOGRAPHICALDATA_GEO      */



/* -----------------------------------------------------------------------------
      TABLE : T_INDICATOR_IND
----------------------------------------------------------------------------- */

create table T_INDICATOR_IND
  (
     IND_ID int identity (1, 1)   ,
     CTR_ID char(3)  not null  ,
     IND_GDP real  null  ,
     IND_GHG real  null  ,
     IND_POPULATION bigint  null  ,
     IND_YEAR int  null  
     ,
     constraint PK_T_INDICATOR_IND primary key (IND_ID)
  ) 
go



/*      INDEX DE T_INDICATOR_IND      */



/* -----------------------------------------------------------------------------
      TABLE : CAN_USE
----------------------------------------------------------------------------- */

create table CAN_USE
  (
	 ID_CAN_USE int identity (1, 1)  ,
     CTR_ID char(3)  not null  ,
     ENS_ID int  not null  ,
     CO2EMISSION real  null  ,
     ENSCONSUMPTION real  null  ,
     ENSPRODUCTION real  null  ,
     SOURCEYEAR int  null  
     ,
     constraint PK_CAN_USE primary key (ID_CAN_USE, CTR_ID, ENS_ID)
  ) 
go



/*      INDEX DE CAN_USE      */



/* -----------------------------------------------------------------------------
      TABLE : HAVE
----------------------------------------------------------------------------- */

create table HAVE
  (
	 ID_HAVE int identity (1, 1)  ,
     CTR_ID char(3)  not null  ,
     SCT_ID int  not null  ,
     CO2EMISSION real  null  ,
     SECTORYEAR int  null  
     ,
     constraint PK_HAVE primary key (ID_HAVE, CTR_ID, SCT_ID)
  ) 
go



/*      INDEX DE HAVE      */



/* -----------------------------------------------------------------------------
      TABLE : IS_ON
----------------------------------------------------------------------------- */

create table IS_ON
  (
     REG_ID int  not null  ,
     CTR_ID char(3)  not null  
     ,
     constraint PK_IS_ON primary key (REG_ID, CTR_ID)
  ) 
go



/*      INDEX DE IS_ON      */



/* -----------------------------------------------------------------------------
      REFERENCES SUR LES TABLES
----------------------------------------------------------------------------- */



alter table T_GEOGRAPHICALDATA_GEO 
     add constraint FK_T_GEOGRAPHICALDATA_GEO_T_COUNTRY_CTR foreign key (CTR_ID) 
               references T_COUNTRY_CTR (CTR_ID)
go




alter table T_INDICATOR_IND 
     add constraint FK_T_INDICATOR_IND_T_COUNTRY_CTR foreign key (CTR_ID) 
               references T_COUNTRY_CTR (CTR_ID)
go




alter table CAN_USE 
     add constraint FK_CAN_USE_T_COUNTRY_CTR foreign key (CTR_ID) 
               references T_COUNTRY_CTR (CTR_ID)
go




alter table CAN_USE 
     add constraint FK_CAN_USE_T_ENERGYSOURCE_ENS foreign key (ENS_ID) 
               references T_ENERGYSOURCE_ENS (ENS_ID)
go




alter table HAVE 
     add constraint FK_HAVE_T_COUNTRY_CTR foreign key (CTR_ID) 
               references T_COUNTRY_CTR (CTR_ID)
go




alter table HAVE 
     add constraint FK_HAVE_T_SECTOR_SCT foreign key (SCT_ID) 
               references T_SECTOR_SCT (SCT_ID)
go




alter table IS_ON 
     add constraint FK_IS_ON_T_REGION_REG foreign key (REG_ID) 
               references T_REGION_REG (REG_ID)
go




alter table IS_ON 
     add constraint FK_IS_ON_T_COUNTRY_CTR foreign key (CTR_ID) 
               references T_COUNTRY_CTR (CTR_ID)
go

alter table T_GEOGRAPHICALDATA_GEO
      add constraint C_CHK_GEO_TOTALPRECIPIT CHECK(GEO_TOTALPRECIPIT>=0) 
go

alter table T_INDICATOR_IND
      add constraint C_CHK_IND_GDP CHECK(IND_GDP>=0) 
go

alter table T_INDICATOR_IND
      add constraint C_CHK_IND_GHG CHECK(IND_GHG>=0) 
go

alter table T_INDICATOR_IND
      add constraint C_CHK_IND_POPULATION CHECK(IND_POPULATION>=0) 
go


/*
 -----------------------------------------------------------------------------
               FIN DE GENERATION
 -----------------------------------------------------------------------------
*/