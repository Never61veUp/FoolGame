var builder = DistributedApplication.CreateBuilder(args);

Console.WriteLine($"VITE_PORT: {Environment.GetEnvironmentVariable("VITE_PORT")}");

builder.AddNpmApp("reactvite", "./../../foolgamereact")
    .WithEnvironment("BROWSER", "none")
    .WithHttpEndpoint(env: "VITE_PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.AddProject<Projects.FoolGame_Host>("foolgame-host");

builder.Build().Run();
