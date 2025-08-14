using BrowserGames;
using BrowserGames.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("customPolicy", b =>
    {
        b.WithOrigins("http://localhost:5173").AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseFileServer();

app.UseRouting();
app.UseCors("customPolicy");
app.UseAuthorization();

app.MapControllers();
app.MapHub<TestHub>("/testHub");
app.MapHub<PretenderHub>("/pretenderHub", options =>
{
    options.AllowStatefulReconnects = true;
});

app.Run();