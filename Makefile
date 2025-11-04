default: help

DUCKOV_LOG_DIR := ~/.local/share/Steam/steamapps/compatdata/3167020/pfx/drive_c/users/steamuser/AppData/LocalLow/TeamSoda/Duckov
DUCKOV_MOD_DIR := ~/.local/share/Steam/steamapps/common/Escape\ from\ Duckov/Duckov_Data/Mods
RELEASE_DIR := BetterBulletNames/bin/Release/netstandard2.1

.PHONY: build
build: # Generate the release build artifacts
	dotnet build -c Release

.PHONY: clean
clean: # Remove build artifacts
	dotnet clean -c Release

.PHONY: copy
copy: # Copy the release build artifacts to the Duckov mod directory
	mkdir -p $(DUCKOV_MOD_DIR)/BetterBulletNames
	cp -r $(RELEASE_DIR)/BetterBulletNames.dll $(DUCKOV_MOD_DIR)/BetterBulletNames
	cp -r $(RELEASE_DIR)/0Harmony.dll $(DUCKOV_MOD_DIR)/BetterBulletNames
	cp -r info.ini $(DUCKOV_MOD_DIR)/BetterBulletNames
	cp -r preview.png $(DUCKOV_MOD_DIR)/BetterBulletNames

.PHONY: format
format: # Format the codebase
	dotnet format

.PHONY: help
help: # Print available targets and descriptions
	@awk 'BEGIN {FS = ":.*?#"} /^[a-zA-Z0-9_-]+:.*?#/ {printf "\033[36m%-20s\033[0m %s\n", $$1, $$2}' $(MAKEFILE_LIST)

.PHONY: next
next: clean build copy # Build and copy the release build artifacts

.PHONY: logs
logs: # Tail the Duckov log file for runtime info
	tail -f $(DUCKOV_LOG_DIR)/Player.log
