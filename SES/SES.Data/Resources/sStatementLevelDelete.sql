--#########################################################
-- DESCRIPTION
-- This stored proc enables to delete a stament level.
--#########################################################

create procedure SES.sStatementLevelDelete (
	-- Parameters listing.
	@ActorId int,
	@StatementLevelId int,
	@DeletionResult bit = 0 output
)
as
begin;-- Procedure engagement.
	declare @stillExisting int;

	if (@StatementLevelId != 0)
		begin;
			delete from SES.tStatementLevel where StatementLevelId = @StatementLevelId;
			set @stillExisting = 
				(
					select
						StatementLevelId 
					from
						SES.tStatementLevel 
					where
						StatementLevelId = @StatementLevelId
				);

			if (@stillExisting is null)
				set @DeletionResult = 1;
		end;
end;