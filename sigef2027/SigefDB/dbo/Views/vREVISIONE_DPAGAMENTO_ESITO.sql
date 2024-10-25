/*  
  Autore     : 
  Creazione  : 11/08/2017
  Modifica   : 22/09/2017
  Descrizione: Creazione vista vRevisione_DPagamento_Esito
*/

CREATE VIEW dbo.vREVISIONE_DPAGAMENTO_ESITO
AS
SELECT rdp.ID,
       rdp.ID_LOTTO,
       rdp.ID_DOMANDA_PAGAMENTO,
       rdp.ID_VLD_STEP,
       rdp.COD_ESITO,
       rdp.DATA,
       rdp.OPERATORE,
       rdp.NOTE,
       rdp.ESCLUDI_DA_COMUNICAZIONE,
       s.DESCRIZIONE,
       s.AUTOMATICO,
       e.ESITO_POSITIVO,
       cls.Ordine
FROM Revisione_DPagamento_Esito rdp
      INNER JOIN
      Vld_Step s ON rdp.Id_Vld_Step = s.Id
      LEFT JOIN
      Esiti_Step e ON rdp.Cod_Esito = e.Cod_Esito
      LEFT JOIN
      Vld_Check_List_Step cls ON rdp.Id_Vld_Step = cls.Id_Vld_Step
        INNER JOIN
        Vld_Check_List cl ON cls.Id_Vld_Check_list = cl.Id;