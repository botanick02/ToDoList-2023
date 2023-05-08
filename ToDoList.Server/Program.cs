using AutoMapper;
using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using ToDoList;
using ToDoList.DAL;
using ToDoList.Server.GraphQL.Tasks;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

DALConfiguration.ConfigureDALServices(builder.Services, builder.Configuration);

builder.Services.AddSingleton<ISchema, TasksSchema>(services => new TasksSchema(new SelfActivatingServiceProvider(services)));
builder.Services.AddGraphQL(b => b
    .AddSchema<TasksSchema>()
    .AddAutoClrMappings()
    .AddSystemTextJson());

var config = AutoMapperConfig.Configure();
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton<IMapper>(mapper);

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
