CREATE PROCEDURE [dbo].[ZPartecipantiIndirettiFatturatoGetById]
(
	@Id INT
)
AS
	SELECT *
	FROM vPARECIPANTI_INDIRETTI_FATTURATO
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZPartecipantiIndirettiFatturatoGetById]
(
	@Id INT
)
AS
	SELECT *
	FROM vPARECIPANTI_INDIRETTI_FATTURATO
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPartecipantiIndirettiFatturatoGetById';

