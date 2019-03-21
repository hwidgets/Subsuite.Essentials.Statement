--#########################################################
-- DESCRIPTION
-- This table centralizes statements.
--#########################################################

create table SES.tStatement (
	-- Fields listing.
	StatementId int not null identity(0, 1),
	[Level] int not null,
	LanguageCode int not null,
	[Status] int not null,
	[Text] nvarchar(512) not null

	-- Constraints listing.
	constraint PK_tStatement_StatementId primary key (StatementId),
	constraint FK_tStatement_Level foreign key ([Level]) references SES.tStatementLevel ([Level]),
	constraint FK_tStatement_Language foreign key (LanguageCode) references SEC.tCulture (LanguageCode),
);

-- Insertion of the Default profile.
insert into SES.tStatement ([Level], LanguageCode, [Status], [Text])
values (0, 0, 0, N'');

insert into SES.tStatement ([Level], LanguageCode, [Status], [Text])
values (1, 1, 1, 'Success');

insert into SES.tStatement ([Level], LanguageCode, [Status], [Text])
values (4, 1, 2, 'No Statement was found with mentionned status.');

insert into SES.tStatement ([Level], LanguageCode, [Status], [Text])
values (4, 1, 3, 'Not a single Statement was found.');