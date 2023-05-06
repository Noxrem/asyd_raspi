# First stage: compile the .NET program in the SDK image
FROM mcr.microsoft.com/dotnet/sdk:7.0 as builder

# Copy .NET source files into the image
WORKDIR /app
COPY src/ /app/src

# Build the .NET program
RUN dotnet publish -c Release -o ./out ./src

# Second stage: run the .NET program in the runtime image
FROM mcr.microsoft.com/dotnet/runtime:7.0

# Copy the compiled program into the new image
WORKDIR /app
COPY --from=builder /app/out /app

# Run the .NET program
CMD ["dotnet", "/app/out/ASYD_Demo.dll"]
