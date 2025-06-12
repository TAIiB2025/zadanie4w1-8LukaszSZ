using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IKsiazkaService, KsiazkaService>();

builder.Services.AddCors(corsBuilder => corsBuilder.AddPolicy("domyœlna", policyBuilder => policyBuilder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().Build()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("domyœlna");
app.UseAuthorization();

app.MapControllers();

app.Run();
