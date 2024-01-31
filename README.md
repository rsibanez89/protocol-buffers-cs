# Example project that uses Protocol Buffers in dotnet

### Introduction
- gRPC: Google's open source RPC (Remote Procedure Call) framework.
- It uses HTTP/2 protocol to transport binary messages between client and server.
- It uses Protocol Buffers (Protobuf) for describing both the service interface and the structure of the payload messages.
- It supports multiple programming languages.

### Creating the sample project
```
dotnet new sln --name Grpc
dotnet new grpc --name Grpc.HostApp --output src/Grpc.HostApp
dotnet sln add src/Grpc.HostApp
```

