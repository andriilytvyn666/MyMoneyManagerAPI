main:
	@ASPNETCORE_ENVIRONMENT=Development \
	DOTNET_WATCH_RESTART_ON_RUDE_EDIT=true \
	DOTNET_WATCH_SUPPRESS_EMOJIS=true \
	dotnet watch --project MyMoneyManager.Api

ef:
	@rm -rf MyMoneyManager.Api/Migrations
	@dotnet ef migrations add "Test Migration" --project MyMoneyManager.Api
	@dotnet ef database drop --project MyMoneyManager.Api
	@dotnet ef database update --project MyMoneyManager.Api

test:
	dotnet test MyMoneyManager.Api.Tests
