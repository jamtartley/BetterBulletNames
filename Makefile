default: help

.PHONY: build
build: # Generate the release build artifacts
	dotnet build -c Release

.PHONY: clean
clean: # Remove build artifacts
	dotnet clean

.PHONY: help
help: # Print available targets and descriptions
	@awk 'BEGIN {FS = ":.*?#"} /^[a-zA-Z0-9_-]+:.*?#/ {printf "\033[36m%-20s\033[0m %s\n", $$1, $$2}' $(MAKEFILE_LIST)
