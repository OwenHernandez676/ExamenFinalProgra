using FinalExamn;
using FinalExamn.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// 1. Agregar controladores con vistas (MVC)
builder.Services.AddControllersWithViews();

// 2. Registrar el DbContext con conexión a Supabase (cadena en appsettings.json)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SupabaseDB")));

// 3. Registrar servicios de negocio
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<TareaService>();

// 4. Configurar Swagger para la documentación interactiva de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 5. Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    // En entorno de desarrollo, habilitar Swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// 6. Definir la ruta principal de controladores MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
