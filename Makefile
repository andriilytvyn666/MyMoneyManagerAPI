main:
	@ASPNETCORE_ENVIRONMENT=Development \
	DOTNET_WATCH_RESTART_ON_RUDE_EDIT=true \
	DOTNET_WATCH_SUPPRESS_EMOJIS=true \
	dotnet watch --project MyMoneyManager.Api

ef:
	@rm -rf Migrations
	@dotnet ef migrations add "Test Migration"
	@dotnet ef database drop
	@dotnet ef database update
