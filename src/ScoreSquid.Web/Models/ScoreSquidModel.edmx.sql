
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 09/29/2011 21:02:29
-- Generated from EDMX file: C:\Users\Andrew\Score-Squid\src\ScoreSquid.Web\Models\ScoreSquidModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ScoreSquid];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MiniLeague_Chairman]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MiniLeagues] DROP CONSTRAINT [FK_MiniLeague_Chairman];
GO
IF OBJECT_ID(N'[dbo].[FK_MiniLeague_Players]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Players] DROP CONSTRAINT [FK_MiniLeague_Players];
GO
IF OBJECT_ID(N'[dbo].[FK_Player_Score]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Players] DROP CONSTRAINT [FK_Player_Score];
GO
IF OBJECT_ID(N'[dbo].[FK_DivisionTeam]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Teams] DROP CONSTRAINT [FK_DivisionTeam];
GO
IF OBJECT_ID(N'[dbo].[FK_HomeTeamFixture]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fixtures] DROP CONSTRAINT [FK_HomeTeamFixture];
GO
IF OBJECT_ID(N'[dbo].[FK_AwayTeamFixture]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fixtures] DROP CONSTRAINT [FK_AwayTeamFixture];
GO
IF OBJECT_ID(N'[dbo].[FK_FixtureResult]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fixtures] DROP CONSTRAINT [FK_FixtureResult];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Divisions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Divisions];
GO
IF OBJECT_ID(N'[dbo].[Fixtures]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fixtures];
GO
IF OBJECT_ID(N'[dbo].[MiniLeagues]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MiniLeagues];
GO
IF OBJECT_ID(N'[dbo].[Players]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Players];
GO
IF OBJECT_ID(N'[dbo].[Results]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Results];
GO
IF OBJECT_ID(N'[dbo].[Scores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Scores];
GO
IF OBJECT_ID(N'[dbo].[Seasons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Seasons];
GO
IF OBJECT_ID(N'[dbo].[Teams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Teams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Divisions'
CREATE TABLE [dbo].[Divisions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [DivisionIdentifier] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Fixtures'
CREATE TABLE [dbo].[Fixtures] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [HomeTeamId] int  NOT NULL,
    [AwayTeamId] int  NOT NULL,
    [Result_Id] int  NOT NULL
);
GO

-- Creating table 'MiniLeagues'
CREATE TABLE [dbo].[MiniLeagues] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Pin] nvarchar(max)  NULL,
    [Chairman_Id] int  NULL
);
GO

-- Creating table 'Players'
CREATE TABLE [dbo].[Players] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(60)  NOT NULL,
    [Password] nvarchar(20)  NOT NULL,
    [Forename] nvarchar(40)  NOT NULL,
    [Surname] nvarchar(40)  NOT NULL,
    [Score_Id] int  NULL,
    [MiniLeague_Id] int  NULL
);
GO

-- Creating table 'Results'
CREATE TABLE [dbo].[Results] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FullTimeResult] nvarchar(max)  NULL,
    [HalfTimeResult] nvarchar(max)  NULL,
    [HomeTeam_FullTimeTeamGoals] int  NOT NULL,
    [HomeTeam_HalfTimeTeamGoals] int  NOT NULL,
    [HomeTeam_TotalShots] int  NOT NULL,
    [HomeTeam_ShotsOnTarget] int  NOT NULL,
    [HomeTeam_ShotsHitPost] int  NOT NULL,
    [HomeTeam_Corners] int  NOT NULL,
    [HomeTeam_FoulsCommitted] int  NOT NULL,
    [HomeTeam_Offsides] int  NOT NULL,
    [HomeTeam_YellowCards] int  NOT NULL,
    [HomeTeam_RedCards] int  NOT NULL,
    [AwayTeam_FullTimeTeamGoals] int  NOT NULL,
    [AwayTeam_HalfTimeTeamGoals] int  NOT NULL,
    [AwayTeam_TotalShots] int  NOT NULL,
    [AwayTeam_ShotsOnTarget] int  NOT NULL,
    [AwayTeam_ShotsHitPost] int  NOT NULL,
    [AwayTeam_Corners] int  NOT NULL,
    [AwayTeam_FoulsCommitted] int  NOT NULL,
    [AwayTeam_Offsides] int  NOT NULL,
    [AwayTeam_YellowCards] int  NOT NULL,
    [AwayTeam_RedCards] int  NOT NULL
);
GO

-- Creating table 'Scores'
CREATE TABLE [dbo].[Scores] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [WeekScore] int  NOT NULL,
    [MonthScore] int  NOT NULL,
    [TotalScore] int  NOT NULL
);
GO

-- Creating table 'Seasons'
CREATE TABLE [dbo].[Seasons] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StartYear] int  NOT NULL,
    [EndYear] int  NOT NULL
);
GO

-- Creating table 'Teams'
CREATE TABLE [dbo].[Teams] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [DivisionId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Divisions'
ALTER TABLE [dbo].[Divisions]
ADD CONSTRAINT [PK_Divisions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Fixtures'
ALTER TABLE [dbo].[Fixtures]
ADD CONSTRAINT [PK_Fixtures]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MiniLeagues'
ALTER TABLE [dbo].[MiniLeagues]
ADD CONSTRAINT [PK_MiniLeagues]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Players'
ALTER TABLE [dbo].[Players]
ADD CONSTRAINT [PK_Players]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [PK_Results]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Scores'
ALTER TABLE [dbo].[Scores]
ADD CONSTRAINT [PK_Scores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Seasons'
ALTER TABLE [dbo].[Seasons]
ADD CONSTRAINT [PK_Seasons]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [PK_Teams]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Chairman_Id] in table 'MiniLeagues'
ALTER TABLE [dbo].[MiniLeagues]
ADD CONSTRAINT [FK_MiniLeague_Chairman]
    FOREIGN KEY ([Chairman_Id])
    REFERENCES [dbo].[Players]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MiniLeague_Chairman'
CREATE INDEX [IX_FK_MiniLeague_Chairman]
ON [dbo].[MiniLeagues]
    ([Chairman_Id]);
GO

-- Creating foreign key on [MiniLeague_Id] in table 'Players'
ALTER TABLE [dbo].[Players]
ADD CONSTRAINT [FK_MiniLeague_Players]
    FOREIGN KEY ([MiniLeague_Id])
    REFERENCES [dbo].[MiniLeagues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MiniLeague_Players'
CREATE INDEX [IX_FK_MiniLeague_Players]
ON [dbo].[Players]
    ([MiniLeague_Id]);
GO

-- Creating foreign key on [Score_Id] in table 'Players'
ALTER TABLE [dbo].[Players]
ADD CONSTRAINT [FK_Player_Score]
    FOREIGN KEY ([Score_Id])
    REFERENCES [dbo].[Scores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Player_Score'
CREATE INDEX [IX_FK_Player_Score]
ON [dbo].[Players]
    ([Score_Id]);
GO

-- Creating foreign key on [DivisionId] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [FK_DivisionTeam]
    FOREIGN KEY ([DivisionId])
    REFERENCES [dbo].[Divisions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DivisionTeam'
CREATE INDEX [IX_FK_DivisionTeam]
ON [dbo].[Teams]
    ([DivisionId]);
GO

-- Creating foreign key on [HomeTeamId] in table 'Fixtures'
ALTER TABLE [dbo].[Fixtures]
ADD CONSTRAINT [FK_HomeTeamFixture]
    FOREIGN KEY ([HomeTeamId])
    REFERENCES [dbo].[Teams]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HomeTeamFixture'
CREATE INDEX [IX_FK_HomeTeamFixture]
ON [dbo].[Fixtures]
    ([HomeTeamId]);
GO

-- Creating foreign key on [AwayTeamId] in table 'Fixtures'
ALTER TABLE [dbo].[Fixtures]
ADD CONSTRAINT [FK_AwayTeamFixture]
    FOREIGN KEY ([AwayTeamId])
    REFERENCES [dbo].[Teams]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AwayTeamFixture'
CREATE INDEX [IX_FK_AwayTeamFixture]
ON [dbo].[Fixtures]
    ([AwayTeamId]);
GO

-- Creating foreign key on [Result_Id] in table 'Fixtures'
ALTER TABLE [dbo].[Fixtures]
ADD CONSTRAINT [FK_FixtureResult]
    FOREIGN KEY ([Result_Id])
    REFERENCES [dbo].[Results]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FixtureResult'
CREATE INDEX [IX_FK_FixtureResult]
ON [dbo].[Fixtures]
    ([Result_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------