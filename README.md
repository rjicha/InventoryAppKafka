# Inventory APP

Testovací projekt s Apache Kafka & Protobuf schema registry.

## Prereqs

- .NET 5 (https://docs.microsoft.com/cs-cz/dotnet/core/install/linux-ubuntu)
- docker-compse

## Run

### Dependence (kafka, zookeeper, schema registry)
```bash
$ cd _deps  
$ docker-compose up
```

### API
```bash
$ cd src/apps/Api
$ dotnet run
```

### Test consumer
```bash
$ cd src/apps/Consumer
$ dotnet run
```