using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using ToDoList.BLL;
using ToDoList.DAL;
using ToDoList.Server;
using ToDoList.Server.GraphQL.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

builder.Services.RegisterDALDependencies(builder.Configuration);
builder.Services.RegisterBLLDependencies();

builder.Services.AddSingleton<ISchema, TasksSchema>(services => new TasksSchema(new SelfActivatingServiceProvider(services)));
builder.Services.AddGraphQL(b => b
    .AddSchema<TasksSchema>()
    .AddAutoClrMappings()
    .AddSystemTextJson());

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

app.UseGraphQL("/graphql");
app.UseGraphQLAltair();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Task}/{action=Index}/{id?}");

app.Run();
