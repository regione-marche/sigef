
CREATE VIEW [dbo].[vzDIMENSIONI_X_PROGRAMMAZIONE]
AS
SELECT dxp.ID_PROGRAMMAZIONE, 
       dxp.ID_DIMENSIONE, 
       dxp.ID_DIM_X_PROGRAMMAZIONE, 
       dim.COD_DIM, 
       pro.CODICE             AS COD_PROGRAMMAZIONE, 
       pro.DESCRIZIONE        AS DES_PROGRAMMAZIONE,
       psr.DESCRIZIONE        AS LIVELLO_PROGRAMMAZIONE,
       dim.CODICE             AS COD_DIMENSIONE, 
       dim.DESCRIZIONE        AS DES_DIMENSIONE, 
       dim.UM
FROM dbo.zDIMENSIONI_X_PROGRAMMAZIONE dxp
     LEFT JOIN
     dbo.zDIMENSIONI dim ON dxp.ID_DIMENSIONE = dim.ID 
     LEFT JOIN
     dbo.zPROGRAMMAZIONE pro ON dxp.ID_PROGRAMMAZIONE = pro.ID
     LEFT JOIN
        dbo.zPsr_Albero psr ON pro.COD_TIPO = psr.CODICE

