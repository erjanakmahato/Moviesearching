IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200204113535_Initial')
BEGIN
    CREATE TABLE [IMDB3] (
        [SN] int NOT NULL,
        [Name] nvarchar(60) NOT NULL,
        [Rating] nvarchar(max) NOT NULL,
        [Duration] nvarchar(max) NULL,
        [Type] nvarchar(30) NOT NULL,
        [ReleaseYear] nvarchar(max) NULL,
        [Director] nvarchar(max) NULL,
        [Stars] nvarchar(max) NULL,
        [Descreption] nvarchar(max) NULL,
        [Image] nvarchar(max) NULL,
        CONSTRAINT [PK_IMDB3] PRIMARY KEY ([SN])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200204113535_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200204113535_Initial', N'3.1.1');
END;

GO

