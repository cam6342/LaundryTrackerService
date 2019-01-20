IF NOT EXISTS (SELECT 1 FROM [LaundryStatus] WHERE [LaundryStatusId]=0)
BEGIN
	INSERT INTO [LaundryStatus]
	VALUES
	(0,'UNKNOWN')
END

IF NOT EXISTS (SELECT 1 FROM [LaundryStatus] WHERE [LaundryStatusId]=1)
BEGIN
	INSERT INTO [LaundryStatus]
	VALUES
	(1,'Running')
END

IF NOT EXISTS (SELECT 1 FROM [LaundryStatus] WHERE [LaundryStatusId]=2)
BEGIN
	INSERT INTO [LaundryStatus]
	VALUES
	(2,'Stopped')
END
