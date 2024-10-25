CREATE PROCEDURE [dbo].[ZDomandaPagamentoAllegatiGetById]
(
	@IdAllegato INT
)
AS
	SELECT *
	FROM vDOMANDA_PAGAMENTO_ALLEGATI
	WHERE 
		(ID_ALLEGATO = @IdAllegato)

GO

declare @old_ZDomandaPagamentoAllegatiGetById varchar(8000);
select @old_ZDomandaPagamentoAllegatiGetById = ROUTINE_DEFINITION from ##old_ZDomandaPagamentoAllegatiGetById;
exec sp_addextendedproperty 'backup',@old_ZDomandaPagamentoAllegatiGetById,'user',dbo,'procedure','ZDomandaPagamentoAllegatiGetById';
drop table ##old_ZDomandaPagamentoAllegatiGetById
GO