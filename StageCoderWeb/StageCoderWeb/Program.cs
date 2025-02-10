using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StageCoderWeb;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Builder;

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

