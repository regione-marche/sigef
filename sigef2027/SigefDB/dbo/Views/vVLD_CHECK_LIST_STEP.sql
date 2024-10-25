
CREATE VIEW [dbo].[vVLD_CHECK_LIST_STEP]
AS
SELECT cls.ID_VLD_CHECK_LIST,
       cls.ID_VLD_STEP,
       cls.Ordine,
       cls.OBBLIGATORIO,
       cls.INCLUDI_VERBALE_VIS,
       s.DESCRIZIONE,
       s.AUTOMATICO
FROM Vld_Check_List_Step cls
     LEFT JOIN
     Vld_Step s ON cls.Id_Vld_Step = s.Id
