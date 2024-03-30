USE languamania

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'TTranslationItem')
BEGIN
	CREATE Table TTranslationItem
	(
		[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
		[Text] [nvarchar](100) NOT NULL,
		[Language] [varchar](10) NOT NULL
	)
END
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'TTranslation')
BEGIN
	CREATE TABLE TTranslation
	(
		[TranslationItemId1] [int] NOT NULL FOREIGN KEY REFERENCES TTranslationItem(Id),
		[TranslationItemId2] [int] NOT NULL FOREIGN KEY REFERENCES TTranslationItem(Id),
		PRIMARY KEY ([TranslationItemId1], [TranslationItemId2])
	)
END