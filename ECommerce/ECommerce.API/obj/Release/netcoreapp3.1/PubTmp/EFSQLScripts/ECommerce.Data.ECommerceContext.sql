IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211018012723_ECommerceDB')
BEGIN
    CREATE TABLE [ProdutoModel] (
        [Id] int NOT NULL IDENTITY,
        [Nome] nvarchar(max) NULL,
        [Categoria] nvarchar(max) NULL,
        [Preço] real NOT NULL,
        [UriBlob] nvarchar(max) NULL,
        CONSTRAINT [PK_ProdutoModel] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211018012723_ECommerceDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211018012723_ECommerceDB', N'3.1.20');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211018023930_AddVendedor')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProdutoModel]') AND [c].[name] = N'Preço');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [ProdutoModel] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [ProdutoModel] DROP COLUMN [Preço];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211018023930_AddVendedor')
BEGIN
    ALTER TABLE [ProdutoModel] ADD [Preco] real NOT NULL DEFAULT CAST(0 AS real);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211018023930_AddVendedor')
BEGIN
    ALTER TABLE [ProdutoModel] ADD [Vendedor] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211018023930_AddVendedor')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211018023930_AddVendedor', N'3.1.20');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211020003404_AddCompraTable')
BEGIN
    CREATE TABLE [CompraModel] (
        [Id] int NOT NULL IDENTITY,
        [ProdutoId] int NOT NULL,
        [ProdutoNome] nvarchar(max) NULL,
        [ProdutoImagem] nvarchar(max) NULL,
        [Preço] real NOT NULL,
        [Comprador] nvarchar(max) NULL,
        CONSTRAINT [PK_CompraModel] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211020003404_AddCompraTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211020003404_AddCompraTable', N'3.1.20');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211020032252_addPagamento')
BEGIN
    ALTER TABLE [CompraModel] ADD [FormaDePagamento] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211020032252_addPagamento')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211020032252_addPagamento', N'3.1.20');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211020233003_changePrecoType')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProdutoModel]') AND [c].[name] = N'Preco');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [ProdutoModel] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [ProdutoModel] ALTER COLUMN [Preco] float NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211020233003_changePrecoType')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CompraModel]') AND [c].[name] = N'Preço');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [CompraModel] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [CompraModel] ALTER COLUMN [Preço] float NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211020233003_changePrecoType')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211020233003_changePrecoType', N'3.1.20');
END;

GO

