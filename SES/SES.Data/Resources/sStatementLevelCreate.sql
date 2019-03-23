--#########################################################
-- DESCRIPTION
-- This stored proc enables to create a statement level.
--#########################################################

create procedure SES.sStatementLevelCreate (
	-- Parameters listing.
	@ActorId int,
	@Level int,
	@StatementLevelIdResult int output
)
as
begin;-- Procedure engagement.
	insert into SES.tStatementLevel ([Level])
	values (@Level);

	set @StatementLevelIdResult = scope_identity();
end;