DECLARE @start int = 1
DECLARE @count int = (select Count(*) from Permissions)
WHILE( @start <= @count)
BEGIN
  insert into RolesPermissions(RoleId, PermissionId)
	values ((select Id from Roles where [Name] = 'Administrator'), @start)
	set @start = @start + 1 
END
