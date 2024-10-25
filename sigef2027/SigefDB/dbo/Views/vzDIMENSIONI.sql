CREATE VIEW [dbo].[vzDIMENSIONI]
AS
SELECT dim.ID, 
       dim.CODICE, 
       dim.COD_DIM, 
       dim.DESCRIZIONE, 
       dim.METODO, 
       dim.VALORE, 
       dim.RICHIEDIBILE, 
       dim.UM, 
       dim.PROCEDURA_CALCOLO, 
       dim.ORDINE,
       dim.VALORE_BASE,
       tdm.DESCRIZIONE AS DES_DIM
FROM dbo.zDIMENSIONI AS dim 
     INNER JOIN
     dbo.zTIPO_DIMENSIONE AS tdm ON dim.COD_DIM = tdm.COD_DIM
