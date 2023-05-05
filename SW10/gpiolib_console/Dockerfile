FROM mcr.microsoft.com/dotnet/sdk:7.0

# Install gpiod libraries
RUN apt-get -y update && apt-get install -y libgpiod2 libgpiod-dev gpiod

WORKDIR /app
COPY src/ /app/src

# Build the .Net program
RUN dotnet publish -c Release -o ./out ./src

# Run the .Net program
CMD ["dotnet", "/app/out/ASYD_JoystickLeds.dll"]
