 -- Não precisa criar as tabelas o EF criará automaticamente, qunado rodar o update.

    CREATE TABLE `__EFMigrationsHistory` (
          `MigrationId` varchar(150) NOT NULL,
          `ProductVersion` varchar(32) NOT NULL,
          PRIMARY KEY (`MigrationId`)
    );

    CREATE TABLE `AspNetRoles` (
          `Id` varchar(255) NOT NULL,
          `Name` varchar(256) NULL,
          `NormalizedName` varchar(256) NULL,
          `ConcurrencyStamp` longtext NULL,
          PRIMARY KEY (`Id`)
    );

-- Tabela de usuários

    CREATE TABLE `AspNetUsers` (
          `Id` varchar(255) NOT NULL,
          `avatar` longtext NOT NULL,
          `UserName` varchar(256) NULL,
          `NormalizedUserName` varchar(256) NULL,
          `Email` varchar(256) NULL,
          `NormalizedEmail` varchar(256) NULL,
          `EmailConfirmed` tinyint(1) NOT NULL,
          `PasswordHash` longtext NULL,
          `SecurityStamp` longtext NULL,
          `ConcurrencyStamp` longtext NULL,
          `PhoneNumber` longtext NULL,
          `PhoneNumberConfirmed` tinyint(1) NOT NULL,
          `TwoFactorEnabled` tinyint(1) NOT NULL,
          `LockoutEnd` datetime NULL,
          `LockoutEnabled` tinyint(1) NOT NULL,
          `AccessFailedCount` int NOT NULL,
          PRIMARY KEY (`Id`)
      );

      CREATE TABLE `AspNetRoleClaims` (
          `Id` int NOT NULL AUTO_INCREMENT,
          `RoleId` varchar(255) NOT NULL,
          `ClaimType` longtext NULL,
          `ClaimValue` longtext NULL,
          PRIMARY KEY (`Id`),
          CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE
      );

      CREATE TABLE `AspNetUserClaims` (
          `Id` int NOT NULL AUTO_INCREMENT,
          `UserId` varchar(255) NOT NULL,
          `ClaimType` longtext NULL,
          `ClaimValue` longtext NULL,
          PRIMARY KEY (`Id`),
          CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
      );

      CREATE TABLE `AspNetUserLogins` (
          `LoginProvider` varchar(255) NOT NULL,
          `ProviderKey` varchar(255) NOT NULL,
          `ProviderDisplayName` longtext NULL,
          `UserId` varchar(255) NOT NULL,
          PRIMARY KEY (`LoginProvider`, `ProviderKey`),
          CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
      );

      CREATE TABLE `AspNetUserRoles` (
          `UserId` varchar(255) NOT NULL,
          `RoleId` varchar(255) NOT NULL,
          PRIMARY KEY (`UserId`, `RoleId`),
          CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
          CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
      );

      CREATE TABLE `AspNetUserTokens` (
          `UserId` varchar(255) NOT NULL,
          `LoginProvider` varchar(255) NOT NULL,
          `Name` varchar(255) NOT NULL,
          `Value` longtext NULL,
          PRIMARY KEY (`UserId`, `LoginProvider`, `Name`),
          CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
      );

      CREATE INDEX `IX_AspNetRoleClaims_RoleId` ON `AspNetRoleClaims` (`RoleId`);
      CREATE UNIQUE INDEX `RoleNameIndex` ON `AspNetRoles` (`NormalizedName`);
      CREATE INDEX `IX_AspNetUserClaims_UserId` ON `AspNetUserClaims` (`UserId`);
      CREATE INDEX `IX_AspNetUserLogins_UserId` ON `AspNetUserLogins` (`UserId`);
      CREATE INDEX `IX_AspNetUserRoles_RoleId` ON `AspNetUserRoles` (`RoleId`);
      CREATE INDEX `EmailIndex` ON `AspNetUsers` (`NormalizedEmail`);
      CREATE UNIQUE INDEX `UserNameIndex` ON `AspNetUsers` (`NormalizedUserName`);

