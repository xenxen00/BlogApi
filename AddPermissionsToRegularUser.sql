DECLARE @start int = 1
DECLARE @count int = (select Count(*) from Permissions 
					Where Name like '%Post%' or Name like '%Comment%' 
					or Name like 'Tag' or Name like 'Tag/Create')
WHILE( @start <= @count)
BEGIN
  insert into RolesPermissions(RoleId, PermissionId)
	values ((select Id from Roles where [Name] = 'User'), @start)
	set @start = @start + 1 
END
