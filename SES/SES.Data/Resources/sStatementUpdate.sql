--#########################################################
-- DESCRIPTION
-- This stored proc enables to update a statement.
--#########################################################

create procedure SES.sStatementUpdate (
	-- Parameters listing.
	@ActorId int,
	@StatementId int,
	@Text nvarchar(512),
	@Status int,
	@UpdateResult bit = 0 output
)
as
begin;-- Procedure engagement.
	declare @prvStatus int;
	declare @prvText nvarchar(512);
	declare @newStatus int;
	declare @newText nvarchar(512);

	if (@Text is not null)
		begin;
		set @prvText = (select [Text] from SES.tStatement where StatementId = @StatementId);
		update SES.tStatement set [Text] = @Text where StatementId = @StatementId;
		set @newText = (select [Text] from SES.tStatement where StatementId = @StatementId);
		end;

	if (@Status is not null)
		begin;
			set @prvStatus = (select [Status] from SES.tStatement where StatementId = @StatementId);
			update SES.tStatement set [Status] = @Status where StatementId = @StatementId;
			set @newStatus = (select [Status] from SES.tStatement where StatementId = @StatementId);
		end;

	if (
		@prvStatus != @newStatus
		or @prvText != @newText
	) set @UpdateResult = 1;
end;