﻿DECLARE @CurrentMigration [nvarchar](max)

IF object_id('[dbo].[__MigrationHistory]') IS NOT NULL
    SELECT @CurrentMigration =
        (SELECT TOP (1) 
        [Project1].[MigrationId] AS [MigrationId]
        FROM ( SELECT 
        [Extent1].[MigrationId] AS [MigrationId]
        FROM [dbo].[__MigrationHistory] AS [Extent1]
        WHERE [Extent1].[ContextKey] = N'MyBlog.Migrations.Configuration'
        )  AS [Project1]
        ORDER BY [Project1].[MigrationId] DESC)

IF @CurrentMigration IS NULL
    SET @CurrentMigration = '0'

IF @CurrentMigration < '201703111403423_First'
BEGIN
    CREATE TABLE [dbo].[Aboutus] (
        [Id] [int] NOT NULL IDENTITY,
        [Title] [nvarchar](max),
        [TitleEnglish] [nvarchar](max),
        [Content] [nvarchar](max),
        [EnglishContent] [nvarchar](max),
        CONSTRAINT [PK_dbo.Aboutus] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[Answers] (
        [ID] [int] NOT NULL IDENTITY,
        [QuestionID] [int] NOT NULL,
        [Answer] [nvarchar](max) NOT NULL,
        [UserID] [nvarchar](max),
        [Date] [nvarchar](max),
        CONSTRAINT [PK_dbo.Answers] PRIMARY KEY ([ID])
    )
    CREATE TABLE [dbo].[Blogs] (
        [Id] [int] NOT NULL IDENTITY,
        [Title] [nvarchar](max) NOT NULL,
        [TitleEnglish] [nvarchar](max) NOT NULL,
        [Content] [nvarchar](max) NOT NULL,
        [ContentEnglish] [nvarchar](max) NOT NULL,
        [UserId] [nvarchar](max),
        [Date] [nvarchar](max),
        CONSTRAINT [PK_dbo.Blogs] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[Questions] (
        [ID] [int] NOT NULL IDENTITY,
        [Title] [nvarchar](max) NOT NULL,
        [Question] [nvarchar](500) NOT NULL,
        [Name] [nvarchar](max) NOT NULL,
        [Surname] [nvarchar](max) NOT NULL,
        [EMail] [nvarchar](max),
        [IsConfirmed] [bit] NOT NULL,
        [Date] [nvarchar](max),
        CONSTRAINT [PK_dbo.Questions] PRIMARY KEY ([ID])
    )
    CREATE TABLE [dbo].[AspNetRoles] (
        [Id] [nvarchar](128) NOT NULL,
        [Name] [nvarchar](256) NOT NULL,
        CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY ([Id])
    )
    CREATE UNIQUE INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]([Name])
    CREATE TABLE [dbo].[AspNetUserRoles] (
        [UserId] [nvarchar](128) NOT NULL,
        [RoleId] [nvarchar](128) NOT NULL,
        CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId])
    )
    CREATE INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]([UserId])
    CREATE INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]([RoleId])
    CREATE TABLE [dbo].[AspNetUsers] (
        [Id] [nvarchar](128) NOT NULL,
        [Email] [nvarchar](256),
        [EmailConfirmed] [bit] NOT NULL,
        [PasswordHash] [nvarchar](max),
        [SecurityStamp] [nvarchar](max),
        [PhoneNumber] [nvarchar](max),
        [PhoneNumberConfirmed] [bit] NOT NULL,
        [TwoFactorEnabled] [bit] NOT NULL,
        [LockoutEndDateUtc] [datetime],
        [LockoutEnabled] [bit] NOT NULL,
        [AccessFailedCount] [int] NOT NULL,
        [UserName] [nvarchar](256) NOT NULL,
        CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY ([Id])
    )
    CREATE UNIQUE INDEX [UserNameIndex] ON [dbo].[AspNetUsers]([UserName])
    CREATE TABLE [dbo].[AspNetUserClaims] (
        [Id] [int] NOT NULL IDENTITY,
        [UserId] [nvarchar](128) NOT NULL,
        [ClaimType] [nvarchar](max),
        [ClaimValue] [nvarchar](max),
        CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY ([Id])
    )
    CREATE INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]([UserId])
    CREATE TABLE [dbo].[AspNetUserLogins] (
        [LoginProvider] [nvarchar](128) NOT NULL,
        [ProviderKey] [nvarchar](128) NOT NULL,
        [UserId] [nvarchar](128) NOT NULL,
        CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey], [UserId])
    )
    CREATE INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]([UserId])
    ALTER TABLE [dbo].[AspNetUserRoles] ADD CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE
    ALTER TABLE [dbo].[AspNetUserRoles] ADD CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
    ALTER TABLE [dbo].[AspNetUserClaims] ADD CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
    ALTER TABLE [dbo].[AspNetUserLogins] ADD CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
    CREATE TABLE [dbo].[__MigrationHistory] (
        [MigrationId] [nvarchar](150) NOT NULL,
        [ContextKey] [nvarchar](300) NOT NULL,
        [Model] [varbinary](max) NOT NULL,
        [ProductVersion] [nvarchar](32) NOT NULL,
        CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
    )
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'201703111403423_First', N'MyBlog.Migrations.Configuration',  0x1F8B0800000000000400ED5D5B6FDCBA117E2FD0FF20EC535BF8ECFAD204A9B13E078E2FAD51DF9A750EFA1670257A2D44973D12E5D828FACBFAD09FD4BF50522225F12689BAACE42008106429F29BE170861C0EC9C9FFFEF3DFE52F2FBE673DC32876C3E0647630DF9F5930B043C70D3627B3043DFEF461F6CBCFBFFFDDF2C2F15FAC5F59BD23520FB70CE293D91342DBE3C522B69FA00FE2B9EFDA5118878F686E87FE0238E1E2707FFF2F8B838305C410338C6559CB4F49805C1FA63FF0CFB330B0E11625C0BB091DE8C5B41C7F59A5A8D62DF061BC05363C99DDBC7EF4C2CD3CAB38B34E3D17602656D07B9C59200842041066F1F8730C57280A83CD6A8B0B80F7F0BA85B8DE23F06248593F2EAA37EDC5FE21E9C5A268C8A0EC2446A16F08787044C5B2109BB712EE2C171B16DC0516307A25BD4E8577323B5D87094AB0C4445AC7675E44EA09A29DD3067B5656BC978F3E5612F267CF3A4B3C9444F02480098A80B767DD276BCFB5FF0E5F1FC2AF30380912CF2B3385D9C2DFB8025C741F855B18A1D74FF091B27AE5CCAC05DF6E2136CC9B95DA64BDB80AD0D1E1CCBAC5C4C1DA83F998977ABC426104FF0A031801049D7B80108C02820153A949D4055A0F2EF2202387B50CDBCACCBA012FD730D8A0272C47F032B32EDD17E8B012CAC2E7C0C5A6851BA128818DA85C041BCF8D9F0627862D10E1CE0F4E87F6671872CB45A1F5D5B610C4DFB0321BD842D6600C5B386F610BE7BBB3857F24302638F534AB713209F7A0108674F13A1115BC0FA6F7E758B863693BD158035D4FABFF98F5079BF50D15B4E765C0907A7F13753BC2A3753C9D179CEF7A5E6053B7C1DC9037F9B1124E657E60435241F9DDFEFE1094C9DFBBEFEF2A898251085FDC00D71B7C42B88AF1CCF7E8463ECC279F8F61E8411018333CE6DCC28CE653486CA2627AC937B4A7F1F616A2396B38CF202F230CF72D8CBECECB8878F669DAAE98A00E9B4E504707EBC7A30FEFDE03E7E8FD9FE1D1BBDD3B338AD13A38FC30820D1FBE7BDF0BD55BF0EC6ED2A1572CB378FDF904BDF46BFCE46EB3600E37DE5F68B5CB28F4C96F5EBFB2AF5F566112D9A433A1B6CA0388361075546902D5BF5A33D4E9AB36F38C16F5554987DA5842ADF3359035307E87A5DB3C4CB1DDE2C14B558B48C4205CC1377C739BB9DD8DF8855FBDA8379D001B50E96D5DBF07718CEDDFF91BD841607005ED24C26AB942C0DF0E4EEDFE290CE06DE2AF7B090535A6D5DBD03C7C0B2F818DF711170169D519EF3AB4BF8609DE053BC499FB8C6C06487E3EB87E73805ED839B56D18C7975899A1731626455CA05DCC8FCC4D633B20671E707DB50722CCA25F58D5C20B51D7903C114D35953752C5EA75B8718366ACB2AA7A56B31AB5ACD26AA6AC12B0669CD29A7A46D30AB57C66B57AF3EFD211EADFC14B61A7EFE14D3D123B967B980E1F213AFC711CA1F42BF092D137F044D6E924D0BF35A4B0D3B786944D5CFCEC3AC42B69B0ED6195317CA3FAEA1D55BDCD099CEDDA1CB86EEE9AF86EE6009DB99CC67168BBA91528025E345CC1F38F7D38AB3E7691F5468C7FE08E614577C992874B70DF66A252DD05E7D083085AA77676FDE40CC436706431E20E39068CB11555C1581107E199FB9344136B3A8C482340364131B6543740B259B881ED6E81572B25A165C3258CF43DA7217E39875B181082B59268425C1DF6200CE4748441A993D07251D2B86A45D478ADBA31AF73618B7197A2113BD1C91ADF59A397D47F1B4431AB25B603E5AC16491306B421BC311494EE559A2A80B871999A820A3B268D8252976A270ACA4B6C0405E545F2E61434DBA2361D7F61BF3A35F5E437CABB5FD62BC535826E72F298986A66BE27B909835BC04856CFF3757A4DE605293667984FBA3F8BA9AB2BAA08015F41C4DF0F3E8D906B93D12F1C5FA6BFEC02F1A20628BDC977EDC64805C26E5ED681646CC42BA842A137DA6A30D8CD080D2BA5EB2F354034462521F02E7A0D88685F5580850DD680D2735159CCE25C63C01C0B735672471D2C03581692AC84A5CBA2005B320F19BB7C3E5CAAA83F4516EDB6D1C62CEF59AE0D92FD37DA479570140A21CEEB7CC71B084517B29605D3649B60B25128758C0E4685806A9C7A8D9058677A971253CD7A29A97C55136FB5939404CF522325D699DEA54475B45E480A7FC9C063EA2422DEBBE9C9D85810285F88F36FCB45F63E89162C179A874CCB1BB0DDBAC1A6F4B0899658ABEC55D3D94F2BF3373F7E86B1B063C5D39F9CDB9C120A23B081C25772D3D681976E14A37380C01A9010D899E34BD5946E8766FA6724959E853C9A6C4160CDC8BFB3A6CA17490A378DB6BCC41DF489AF971E3094865FDBD2224FCC800722C571C659E8257EA0F73AF5ADE955D032002D32C4C8AF3F4B50F997E688F95DEE32585ED81C477CC3538613BFC9A8CB853058921F2D2984B4DBE1D5AC9912165E690705A4DE6B0B05D4B5D42AE0B9A080D2EDE7AAD6E55739659472797334F636A78CC4CA9AA3B09736651456D61C25BBD45AC6C84AA6A368A59D4B7B4DCB7638E67AA669F7639A339FE6C417280AB816DCB1F081640546929FBC15707BEFF66650ECD1CD4DA1A2ED30936E1FE650BCE6504DDB2648D9C5AA324A56D21C217F695106C90B0DFC85ECE104E7266445CD31B86711DC10953F7C4706A4DB4435B51C2E36656E3CD5CD87594E9A6BEC4863226F22BB8F4F1EEA6B3F467A8861172176CC5D46D11D7D8F3666BA985F63975F88A4B670FDEB1086B1267AB39D9B757DC35957BCB72E81B59A7BF9FBEB654CFE8BC14AC55F52E7D62BFE930197E5ABE81C93E50FADF0341255D730F03FA4CBE79C2B227D6D8EACB8865E86567C6E81ADE059FC66B065956FAA73BB57F9B3990B2FAF5545E964E63E45F0BC9F052B3BFDE9B662693086990CFB59F04AF77FB9CD60516C88456FF84A60B47C928AA43D0269A348D9795F3745D260E8E71BEED22C3FDD54DEF4D563723761B929BDEA26B01ECF4C5D07550AE9F043AC9253CF0F4184C38E253D78A84FED269D446455661613235ECE5F6304FD39A9305FFDE69D796E1AD561156E40E03EE2BD7276FB7B76B87F7028A4889B4EBAB6451C3B9EE2E04691B38D1FAE1DBCE17089506B5F69B4C964C32804CF20B29F40F4071FBCFCB10CD536355A274021CD4D272C758A330348E334666DD4A353329541D443CE249692E994474C2BF516B9C13A29453917C710AAA088FB7FE7F344EBE459DD109B9A758724573D28ADF326945613A17FB333588F8A2B66756268725EA70E095FBAB1282462EA06C62557EAA4B48A044A6BD77C1D195AF7F501F65DCCDB4A754A5FCCF5A04E8ACBC85781035F4E66FF4A5B1DA797B7C8BFD2E23DEB2AFE1CB8BF25F8C30316A8F56F3903403FF954AA03E613CD7ED35CAA57FFFC9235DDB3EE22BC193AB6F60559B619613E278E113759D30EDCB4CE94F3760D8A4B48A344150CA27DFE9936D3A22AF74CA7E95A995FA613A222874C5F78BD88509723A60D96363F8C837FA2343F8C5967D5F962DAB0A6CD15D3665727668A693E0DB196232E358A48F79BDD9B4D6B6D921272740B024949378674FC34A1EBEF3227456FABA322E5446FD863AAF6E07926A6925AA278D9366E46895D2691A8B8E2F35DE58E98C06B67C513C5F13344EC5AD774A7F3137F666F96076262CA461FAE8E9FED61D7CAA63BC19FB8B219E5749898AE8DB57E8EAC698D97D0D13334C82F2AC561A5D72D8463FE8A9C0BD94D08BCAF5F8778E8333FD22C2183129E7D51C2374CD540933148E0B45C056D96BF41055EFAA622D03CB703EF0B4B74F8CF4A31A5490BD56F8A75C40A43D5122CAAE889EA1F334B2A204E5AB22A8835AAC99AF5953A5B959DA575AAC96A520054D1A66B6F256D5AA79AB6E661FD18C929944FDB5509436AD610CD8D3A65EA912927A3E07A5293FBA46EBF50795DB57FA10C977BA217A170D6A3B97AD9BF50864A35D18B48FA341D83D412F22D4AECB794FE1B5DEC3BC5EEA68020FFA96E006DCE63C9EB5C058F21739C048E5815213A76031170B03B439E373F021BE1CF24BE9F665D4D63A6E494690D9DABE02E41DB04E12E437FED71C146E28055D14FF367F03C2FEFB6E93ADE4717309B2E3917B90B3E26AEE7E47C5F2AE2711A08E2D9D1683A194B44A2EA9BD71CE9360C1A0251F1E50EE903F4B71E068BEF821578866D78C3EA770D37C07E2DA2AF3A90FA81E0C5BE3C77C126027E4C318AF6F827D661C77FF9F9FF163F2BE14D7A0000 , N'6.1.3-40302')
END

