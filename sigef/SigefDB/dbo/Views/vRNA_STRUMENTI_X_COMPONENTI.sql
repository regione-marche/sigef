﻿CREATE VIEW vRNA_STRUMENTI_X_COMPONENTI 
AS
	SELECT
		CC.ID_CODIFICA_INVESTIMENTO,
		CC.ID_COMPONENTI_X_CODIFICA,
		CC.ID_RNA_OBIETTIVO,
		CC.ID_RNA_PROCEDIMENTI_E_REGOLAMENTI,
		SC.COD_TIPO_STRUMENTO_AIUTO,
		SC.ID_STRUMENTI_X_COMPONENTI,
		S.STRUMENTO,
		SC.INTENSITA_STRUMENTO,
		O.OBIETTIVO,
		PR.CODICE_REGOLAMENTO,
		PR.SETTORE,
		CI.DESCRIZIONE AS INVESTIMENTO
	FROM 
		RNA_STRUMENTI_X_COMPONENTI SC INNER JOIN 
		RNA_STRUMENTI_DI_AIUTO S ON SC.COD_TIPO_STRUMENTO_AIUTO = S.COD_TIPO_STRUMENTO_AIUTO INNER JOIN
		RNA_COMPONENTI_X_CODIFICA CC ON SC.ID_COMPONENTI_X_CODIFICA = CC.ID_COMPONENTI_X_CODIFICA INNER JOIN
		RNA_PROCEDIMENTI_E_REGOLAMENTI PR ON CC.ID_RNA_PROCEDIMENTI_E_REGOLAMENTI = PR.ID_PROCEDIMENTI_REGOLAMENTI INNER JOIN
		RNA_OBIETTIVI O ON O.ID_OBIETTIVO = CC.ID_RNA_OBIETTIVO INNER JOIN 
		CODIFICA_INVESTIMENTO CI ON CI.ID_CODIFICA_INVESTIMENTO = CC.ID_CODIFICA_INVESTIMENTO