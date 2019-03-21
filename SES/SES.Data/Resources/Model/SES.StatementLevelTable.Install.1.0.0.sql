--#########################################################
-- DESCRIPTION
-- This table centralizes statement levels.
--#########################################################

create table SES.tStatementLevel (
	-- Fields listing.
	StatementLevelId int not null identity(0, 1),
	[Level] int not null,

	-- Constraints listing.
	constraint PK_tStatementLevel_StatementLevelId primary key (StatementLevelId),
	constraint UK_tStatementLevel_Level unique ([Level])
);

-- Insertion of the Default profile.
insert into SES.tStatementLevel ([Level])
values (0), (1), (2), (3), (4);
