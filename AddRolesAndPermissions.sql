insert into Roles ([Name], Active, CreatedAt)
values ('Administrator', 1, GETDATE());

insert into Roles ([Name], Active, CreatedAt)
values ('User', 1, GETDATE());

--Base use cases
insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Registration', 'User with this permission is allowed to register', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Login', 'User with this permission is allowed to log in', 1,  GETDATE())

--Posts
insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Posts', 'User with this permission is allowed to see all posts', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Post/Create', 'User with this permission is allowed to create a new post', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Post/Delete', 'User with this permission is allowed to deactivate a post', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Post/Edit', 'User with this permission is allowed to edit a post', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Post/Details', 'User with this permission is allowed to see a detailed post', 1,  GETDATE())

--Roles
insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Roles', 'User with this permission is allowed to see all roles', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Role/Create', 'User with this permission is allowed to create a new role', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Role/Edit', 'User with this permission is allowed edit a role', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Role/Delete', 'User with this permission is allowed to deactivate a role', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Role/Details', 'User with this permission is allowed to see a role details', 1,  GETDATE())


--Categories
insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Category', 'User with this permission is allowed to see all Categories', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Category/Create', 'User with this permission is allowed to create a new Category', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Category/Edit', 'User with this permission is allowed edit a Category', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Category/Delete', 'User with this permission is allowed to deactivate a Category', 1,  GETDATE())

--Permissions
insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Permission', 'User with this permission is allowed to see all Permissions', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Permission/Create', 'User with this permission is allowed to create a new Permission', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Permission/Edit', 'User with this permission is allowed edit a Permission', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Permission/Delete', 'User with this permission is allowed to deactivate a Permission', 1,  GETDATE())


--Tags
insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Tag', 'User with this permission is allowed to see all Tags', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Tag/Create', 'User with this permission is allowed to create a new Tag', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Tag/Edit', 'User with this permission is allowed edit a Tag', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Tag/Delete', 'User with this permission is allowed to deactivate a Tag', 1,  GETDATE())

--Reactions
insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Reaction', 'User with this permission is allowed to see all Reactions', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Reaction/Create', 'User with this permission is allowed to create a new Reaction', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Reaction/Edit', 'User with this permission is allowed edit a Reaction', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Reaction/Delete', 'User with this permission is allowed to deactivate a Reaction', 1,  GETDATE())

--Comments
insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Comment/Create', 'User with this permission is allowed to create a new Comment', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Comment/Edit', 'User with this permission is allowed edit a Comment', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Comment/Delete', 'User with this permission is allowed to deactivate a Comment', 1,  GETDATE())


--SavedPosts
insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('SavedPost/Create', 'User with this permission is allowed to create a new SavedPost', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('SavedPosts', 'User with this permission is allowed to fetch Saved Posts', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('SavedPost/Delete', 'User with this permission is allowed to deactivate a SavedPost', 1,  GETDATE())

--RolePermissions
insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('RolePermission/Create', 'User with this permission is allowed to add a certain permission to role', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('RolePermission/Delete', 'User with this permission is allowed to delete Role-Permission record', 1,  GETDATE())

--PostReactions
insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('PostReaction/Create', 'User with this permission is allowed to react to a post', 1,  GETDATE())

insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('PostReaction/Delete', 'User with this permission is allowed to remove reaction to post', 1,  GETDATE())

--Images
insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('Image/Delete', 'User with this permission is allowed remove to deactivate an image', 1,  GETDATE())

--Users
insert into dbo.Permissions ([Name], [Description], Active, CreatedAt)
values ('User/Delete', 'User with this permission is allowed  to deactivate a user', 1,  GETDATE())

