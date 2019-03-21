--#########################################################
-- DESCRIPTION
-- This stored proc enables to delete a statement.
--#########################################################

create procedure SES.sStatementDelete (
	-- Parameters listing.
	@ActorId int,
	@StatementId int,
	@DeletionResult bit = 0 output
)
as
begin;-- Procedure engagement.
	declare @stillExisting int;

	delete from SES.tStatement where StatementId = @StatementId;
	set @stillExisting = 
		(
			select
				StatementId 
			from
				SES.tStatement
			where
				StatementId = @StatementId
		);

	if (@stillExisting is null)
		set @DeletionResult = 1;
end;