IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Salas] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(100) NOT NULL,
    [Unidade] int NOT NULL,
    CONSTRAINT [PK_Salas] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Reunioes] (
    [Id] uniqueidentifier NOT NULL,
    [SalaId] uniqueidentifier NOT NULL,
    [DataInicio] datetime2 NOT NULL,
    [DataFim] datetime2 NOT NULL,
    [Assunto] varchar(250) NOT NULL,
    CONSTRAINT [PK_Reunioes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Reunioes_Salas_SalaId] FOREIGN KEY ([SalaId]) REFERENCES [Salas] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Reunioes_SalaId] ON [Reunioes] ([SalaId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200803221128_Initial', N'3.1.6');

GO

