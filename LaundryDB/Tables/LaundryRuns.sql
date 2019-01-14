CREATE TABLE [dbo].[LaundryRuns]
(
	[LaundryRunId] INT NOT NULL , 
    [UnitId] INT NOT NULL, 
    [RunStart] DATETIME NOT NULL, 
    [RunEnd] DATETIME NULL, 
    [Duration] INT NULL, 
    [Status] INT NOT NULL, 
    CONSTRAINT [FK_LaundryRuns_ToUnit] FOREIGN KEY (UnitId) REFERENCES [Unit](UnitId), 
    CONSTRAINT [PK_LaundryRuns] PRIMARY KEY ([LaundryRunId]) 
)
