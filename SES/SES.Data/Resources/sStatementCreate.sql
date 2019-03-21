--#########################################################
-- DESCRIPTION
-- This stored proc enables to create a statement.
--#########################################################

create procedure SES.sStatementCreate (
	-- Parameters listing.
	@ActorId int,
	@Level int,
	@LanguageCode int,
	@Status int,
	@Text nvarchar(max),
	@StatementIdResult int output
)
as
begin;-- Procedure engagement.
	insert into SES.tStatement ([Level], LanguageCode, [Status], [Text])
	values (@Level, @LanguageCode, @Status, @Text);

	set @StatementIdResult = scope_identity();
end;