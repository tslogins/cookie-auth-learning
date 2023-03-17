var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/username", (HttpContext ctx) => 
{
    var authCookie = ctx.Request.Headers.Cookie.FirstOrDefault(x => x.StartsWith("auth"));
    var payload = authCookie.Split("=").Last();
    var parts = payload.Split(":");
    var key = parts[0];
    var value = parts[1];
    return authCookie;
    // return "anton";
});

app.MapGet("/login", (HttpContext ctx) => 
{
    ctx.Response.Headers["set-cookie"] = "auth=usr:anton";
    return "ok";
});

app.Run();
