/* =========================================================
   MyStoreDb - Seed (até 10 itens por tabela)
   Tabelas: dbo.Users, dbo.Orders, dbo.Products, dbo.ProductOrders
   ========================================================= */

BEGIN TRAN;

------------------------------------------------------------
-- 1) USERS (6)
------------------------------------------------------------
INSERT INTO dbo.Users (Name, Email, CreateDate)
VALUES
('Admin MyStore',     'admin@mystore.local',     SYSDATETIME()),
('Jorge Borges',      'jorge@mystore.local',     SYSDATETIME()),
('Maria Oliveira',    'maria@mystore.local',     SYSDATETIME()),
('Carlos Souza',      'carlos@mystore.local',    SYSDATETIME()),
('Ana Pereira',       'ana@mystore.local',       SYSDATETIME()),
('Fernanda Lima',     'fernanda@mystore.local',  SYSDATETIME());

DECLARE @uAdmin INT = (SELECT TOP 1 Id FROM dbo.Users WHERE Email = 'admin@mystore.local');
DECLARE @uJorge INT = (SELECT TOP 1 Id FROM dbo.Users WHERE Email = 'jorge@mystore.local');
DECLARE @uMaria INT = (SELECT TOP 1 Id FROM dbo.Users WHERE Email = 'maria@mystore.local');
DECLARE @uCarlos INT = (SELECT TOP 1 Id FROM dbo.Users WHERE Email = 'carlos@mystore.local');

------------------------------------------------------------
-- 2) ORDERS (6)
------------------------------------------------------------
DECLARE @o1 UNIQUEIDENTIFIER = NEWID();
DECLARE @o2 UNIQUEIDENTIFIER = NEWID();
DECLARE @o3 UNIQUEIDENTIFIER = NEWID();
DECLARE @o4 UNIQUEIDENTIFIER = NEWID();
DECLARE @o5 UNIQUEIDENTIFIER = NEWID();
DECLARE @o6 UNIQUEIDENTIFIER = NEWID();

INSERT INTO dbo.Orders (Id, CreateDate, UpdateDate, Description, CreateByUserId)
VALUES
(@o1, SYSDATETIME(), SYSDATETIME(), N'Pedido de boas-vindas (kit inicial)', @uAdmin),
(@o2, SYSDATETIME(), SYSDATETIME(), N'Pedido do Jorge - eletrônicos e acessórios', @uJorge),
(@o3, SYSDATETIME(), SYSDATETIME(), N'Pedido da Maria - escritório', @uMaria),
(@o4, SYSDATETIME(), SYSDATETIME(), N'Pedido do Carlos - livros', @uCarlos),
(@o5, SYSDATETIME(), SYSDATETIME(), N'Pedido extra - reposição de estoque', @uAdmin),
(@o6, SYSDATETIME(), SYSDATETIME(), N'Pedido promocional - combos', @uAdmin);

------------------------------------------------------------
-- 3) PRODUCTS (10)
------------------------------------------------------------
INSERT INTO dbo.Products (SKU, Name, Description, Price, CreateDate, OrderId)
VALUES
(NEWID(), N'Teclado Mecânico',        N'Teclado ABNT2, switch tátil.',           349.90, SYSDATETIME(), @o2),
(NEWID(), N'Mouse Gamer',            N'RGB, 8 botões programáveis.',            159.90, SYSDATETIME(), @o2),
(NEWID(), N'Headset',                N'Stereo com microfone destacável.',       199.90, SYSDATETIME(), @o2),
(NEWID(), N'Cadeira Escritório',     N'Ergonômica, ajuste lombar.',             899.00, SYSDATETIME(), @o3),
(NEWID(), N'Monitor 24"',            N'IPS, 75Hz, Full HD.',                    749.90, SYSDATETIME(), @o1),
(NEWID(), N'Notebook Stand',         N'Suporte metálico ajustável.',             89.90, SYSDATETIME(), @o3),
(NEWID(), N'Livro: Clean Code',      N'Edição em português.',                   139.90, SYSDATETIME(), @o4),
(NEWID(), N'Livro: DDD',             N'Domain-Driven Design (capa dura).',      249.90, SYSDATETIME(), @o4),
(NEWID(), N'Pen Drive 64GB',         N'USB 3.0.',                                49.90, SYSDATETIME(), @o5),
(NEWID(), N'Cabo USB-C',             N'1m, reforçado.',                          29.90, SYSDATETIME(), @o6);

-- Pega os IDs gerados (por nome)
DECLARE @pTeclado INT = (SELECT TOP 1 Id FROM dbo.Products WHERE Name = N'Teclado Mecânico'    ORDER BY Id DESC);
DECLARE @pMouse   INT = (SELECT TOP 1 Id FROM dbo.Products WHERE Name = N'Mouse Gamer'        ORDER BY Id DESC);
DECLARE @pHeadset INT = (SELECT TOP 1 Id FROM dbo.Products WHERE Name = N'Headset'            ORDER BY Id DESC);
DECLARE @pCadeira INT = (SELECT TOP 1 Id FROM dbo.Products WHERE Name = N'Cadeira Escritório' ORDER BY Id DESC);
DECLARE @pMonitor INT = (SELECT TOP 1 Id FROM dbo.Products WHERE Name = N'Monitor 24"'        ORDER BY Id DESC);
DECLARE @pStand   INT = (SELECT TOP 1 Id FROM dbo.Products WHERE Name = N'Notebook Stand'     ORDER BY Id DESC);
DECLARE @pClean   INT = (SELECT TOP 1 Id FROM dbo.Products WHERE Name = N'Livro: Clean Code'  ORDER BY Id DESC);
DECLARE @pDDD     INT = (SELECT TOP 1 Id FROM dbo.Products WHERE Name = N'Livro: DDD'         ORDER BY Id DESC);
DECLARE @pPen     INT = (SELECT TOP 1 Id FROM dbo.Products WHERE Name = N'Pen Drive 64GB'     ORDER BY Id DESC);
DECLARE @pCabo    INT = (SELECT TOP 1 Id FROM dbo.Products WHERE Name = N'Cabo USB-C'         ORDER BY Id DESC);

------------------------------------------------------------
-- 4) PRODUCTORDERS (até 10)
-- dbo.ProductOrders(ProductId, OrderId)
------------------------------------------------------------
INSERT INTO dbo.ProductOrders (ProductId, OrderId)
VALUES
(@pTeclado, @o2),
(@pMouse,   @o2),
(@pHeadset, @o2),
(@pCadeira, @o3),
(@pMonitor, @o1),
(@pStand,   @o3),
(@pClean,   @o4),
(@pDDD,     @o4),
(@pPen,     @o5),
(@pCabo,    @o6);

COMMIT;
