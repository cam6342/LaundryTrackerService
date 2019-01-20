CREATE TABLE [dbo].[LaundryRuns]
(
	[LaundryRunId] INT IDENTITY NOT NULL , 
    [UnitId] INT NOT NULL, 
    [RunStart] DATETIME NOT NULL, 
    [RunEnd] DATETIME NULL, 
    [DurationInSeconds] INT NULL, 
    [LaundryStatusId] INT NOT NULL, 
    CONSTRAINT [FK_LaundryRuns_ToUnit] FOREIGN KEY (UnitId) REFERENCES [Unit](UnitId), 
    CONSTRAINT [PK_LaundryRuns] PRIMARY KEY ([LaundryRunId]), 
    CONSTRAINT [FK_LaundryRuns_ToLaundryStatus] FOREIGN KEY (LaundryStatusId) REFERENCES LaundryStatus(LaundryStatusId) 
)
