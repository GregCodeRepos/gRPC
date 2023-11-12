﻿using Grpc.Net.Client;
using gRPC.Client;

Console.WriteLine("Please provide the gRPC url:");
var url = Console.ReadLine();

if (string.IsNullOrWhiteSpace(url))
{
  Console.WriteLine("Please provide a value.");
  Environment.Exit(-1);
}

if(!url.StartsWith("https://"))
{
    url = $"https://{url}";
}

using var channel = GrpcChannel.ForAddress(url);

var client = new Greeter.GreeterClient(channel);
var reply = await client.SayHelloAsync(
         new HelloRequest { Name = "Azure Container Apps Community" });

Console.WriteLine("Greeting: " + reply.Message);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();