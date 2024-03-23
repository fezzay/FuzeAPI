using Fuze.Domain;
using Fuze.Kube.Adapter;
using Fuze.Kube.Adapter.ConfigMap;

var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot kubeConfig = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IKubernetesService, KubernetesService>();

builder.Services.Configure<KubeHost>(kubeConfig.GetSection("KubeHost"));

builder.Services.AddKube();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
