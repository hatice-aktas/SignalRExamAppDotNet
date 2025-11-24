using ExamControlApi;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

//builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapHub<ExamHub>("/examHub");
app.MapPost("/end-exam", async (IHubContext<ExamHub> hubContext) =>
{
    await hubContext.Clients.All.SendAsync("ExamEnded");
    return Results.Ok("Sýnav sonlandýrýldý.");
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.Run();
