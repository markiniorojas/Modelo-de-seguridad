using Web.Service;

var builder = WebApplication.CreateBuilder(args);

// ✅ Registrar los servicios ANTES de Build()
builder.Services.AddApplicationServices();
builder.Services.AddDatabase(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Migraciones
MigrationManager.MigrateAllDatabases(app.Services, builder.Configuration);
app.Run();
