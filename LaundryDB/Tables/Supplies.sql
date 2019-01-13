CREATE TABLE [dbo].[Supplies]
(
	[SupplyId] INT NOT NULL PRIMARY KEY, 
    [UnitId] INT NOT NULL, 
    [SupplyTypeId] INT NOT NULL, 
    [EstimatedAmountRemaining] INT NOT NULL, 
    CONSTRAINT [FK_Supplies_ToUnit] FOREIGN KEY (UnitId) REFERENCES [Unit](UnitId), 
    CONSTRAINT [FK_Supplies_ToSupplyType] FOREIGN KEY (SupplyTypeId) REFERENCES [SupplyType](SupplyTypeId)
)
