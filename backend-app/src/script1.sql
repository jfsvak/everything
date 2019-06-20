  IF EXISTS(SELECT 1 FROM information_schema.tables 
  WHERE table_name = '
__EFMigrationsHistory' AND table_schema = DATABASE()) 
BEGIN
CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190615042154_InitialCreate')
BEGIN
    CREATE TABLE `Accounts` (
        `ID` varbinary(16) NOT NULL,
        `Name` text NOT NULL,
        PRIMARY KEY (`ID`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190615042154_InitialCreate')
BEGIN
    CREATE TABLE `Characters` (
        `ID` varchar(767) NOT NULL,
        `Name` text NOT NULL,
        `CharacterSetID` varbinary(16) NOT NULL,
        `AccountID` varbinary(16) NULL,
        PRIMARY KEY (`ID`),
        CONSTRAINT `FK_Characters_Accounts_AccountID` FOREIGN KEY (`AccountID`) REFERENCES `Accounts` (`ID`) ON DELETE RESTRICT
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190615042154_InitialCreate')
BEGIN
    CREATE TABLE `CharacterSets` (
        `ID` varbinary(16) NOT NULL,
        `MainCharacterID` varchar(767) NULL,
        PRIMARY KEY (`ID`),
        CONSTRAINT `FK_CharacterSets_Characters_MainCharacterID` FOREIGN KEY (`MainCharacterID`) REFERENCES `Characters` (`ID`) ON DELETE RESTRICT
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190615042154_InitialCreate')
BEGIN
    CREATE TABLE `ESIDataCaches` (
        `ID` varbinary(16) NOT NULL,
        `CharacterID` varchar(767) NOT NULL,
        `ESISource` text NOT NULL,
        `ESIRoute` text NOT NULL,
        `LastUpdateTimestamp` datetime NOT NULL,
        `Data` text NULL,
        PRIMARY KEY (`ID`),
        CONSTRAINT `FK_ESIDataCaches_Characters_CharacterID` FOREIGN KEY (`CharacterID`) REFERENCES `Characters` (`ID`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190615042154_InitialCreate')
BEGIN
    CREATE TABLE `Tokens` (
        `CharacterID` varchar(767) NOT NULL,
        `RefreshToken` text NOT NULL,
        `AccessToken` text NOT NULL,
        `TokenType` text NOT NULL,
        `ExpiresIn` int NULL,
        PRIMARY KEY (`CharacterID`),
        CONSTRAINT `FK_Tokens_Characters_CharacterID` FOREIGN KEY (`CharacterID`) REFERENCES `Characters` (`ID`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190615042154_InitialCreate')
BEGIN
    CREATE INDEX `IX_Characters_AccountID` ON `Characters` (`AccountID`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190615042154_InitialCreate')
BEGIN
    CREATE INDEX `IX_Characters_CharacterSetID` ON `Characters` (`CharacterSetID`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190615042154_InitialCreate')
BEGIN
    CREATE INDEX `IX_CharacterSets_MainCharacterID` ON `CharacterSets` (`MainCharacterID`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190615042154_InitialCreate')
BEGIN
    CREATE INDEX `IX_ESIDataCaches_CharacterID` ON `ESIDataCaches` (`CharacterID`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190615042154_InitialCreate')
BEGIN
    ALTER TABLE `Characters` ADD CONSTRAINT `FK_Characters_CharacterSets_CharacterSetID` FOREIGN KEY (`CharacterSetID`) REFERENCES `CharacterSets` (`ID`) ON DELETE CASCADE;
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190615042154_InitialCreate')
BEGIN
    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20190615042154_InitialCreate', '2.2.3-servicing-35854');
END;

