CREATE TABLE [dbo].[Speakers] (
    [Id]                 INT              IDENTITY (1, 1) NOT NULL,
    [SpeakerName]        VARCHAR (50)     NOT NULL,
    [EmailAddress]       VARCHAR (50)     NULL,
    [City]               VARCHAR (50)     NULL,
    [Office]             VARCHAR (50)     NULL,
    [JobTitle]           VARCHAR (50)     NULL,
    [CoPresenters]       VARCHAR (MAX)    NULL,
    [SessionTitle]       VARCHAR (50)     NOT NULL,
    [SessionNumber]      NCHAR (10)       NULL,
    [SessionDescription] VARCHAR (MAX)    NULL,
    [UserId]             UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

