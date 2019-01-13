CREATE TABLE [dbo].[Unit]
(
	[UnitId] INT NOT NULL PRIMARY KEY, 
    [UnitTypeId] INT NOT NULL, 
    [Name] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Unit_ToUnitType] FOREIGN KEY (UnitTypeId) REFERENCES [UnitType](UnitTypeId), 
)
