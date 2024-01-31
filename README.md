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

-- Add the client project
dotnet new console --name Grpc.Client --output src/Grpc.Client
dotnet sln add src/Grpc.Client
dotnet add src/Grpc.Client package Grpc.Net.Client
dotnet add src/Grpc.Client package Google.Protobuf
dotnet add src/Grpc.Client package Grpc.Tools         # required to compile the .proto file into C# code
```

Note:
```
<Protobuf Include="Protos\greet.proto" GrpcServices="Server" />

vs 

<Protobuf Include="..\Grpc.HostApp\Protos\greet.proto" GrpcServices="Client" />
```

The `option csharp_namespace = "AnyNamespace";` in the .proto file is used to specify the namespace of the generated C# code.