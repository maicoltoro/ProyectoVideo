using ApiVideo.Clases;
using ApiVideo.Models.STI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Videos video = new Videos();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/TraerVideos", () =>
{
    var data = video.traerVideo();
    return data;
});

app.MapPost("/Guardar", (GuardarVideo data) => {

    var response = video.Guardar(data);
    return response;
});


app.Run();
