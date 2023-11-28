USE [Elegis]
GO
INSERT [dbo].[Priority] ([Id], [Describe]) VALUES (1, N'Nízká')
INSERT [dbo].[Priority] ([Id], [Describe]) VALUES (2, N'Střední')
INSERT [dbo].[Priority] ([Id], [Describe]) VALUES (3, N'Vysoká')
GO
INSERT [dbo].[Status] ([Id], [Describe]) VALUES (1, N'Otevřeno')
INSERT [dbo].[Status] ([Id], [Describe]) VALUES (2, N'Storno')
INSERT [dbo].[Status] ([Id], [Describe]) VALUES (3, N'Uzavřeno')
GO
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Checked], [NameSurname]) VALUES (N'78783fba-9189-43ed-a771-42d625a08da1', N'q', N'q', 0, N'q q')
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Checked], [NameSurname]) VALUES (N'23ac8212-0307-4e31-bda6-b013ad1cf1c5', N'e', N'e', 1, N'e e')
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Checked], [NameSurname]) VALUES (N'a338cd04-1157-4385-aa01-c83e39f39449', N'a', N'a', 0, N'a a')
GO
INSERT [dbo].[Labour] ([Id], [Company], [IdUser], [Describe], [DateCreate], [DateDeadline], [DateSolved], [IdPriority], [IdStatus]) VALUES (N'de42d20a-6f4d-4df8-87f3-045cb0e1b0e2', N'', N'a338cd04-1157-4385-aa01-c83e39f39449', N'', CAST(N'2023-11-28T16:44:40.270' AS DateTime), CAST(N'2023-11-28T16:44:40.270' AS DateTime), NULL, 1, 1)
GO
