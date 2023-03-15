using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using StageCoderWeb;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".gif"] = "image/gif";

builder.Services.Configure<StaticFileOptions>(options => {
    options.ContentTypeProvider = provider;
});
await builder.Build().RunAsync();

