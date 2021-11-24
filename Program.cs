// Decompiled with JetBrains decompiler
// Type: MARKETPLACE_API.Program
// Assembly: MKT_MARKETPLACE_API, Version=1.0.2021.1123, Culture=neutral, PublicKeyToken=null
// MVID: 93D50DA4-6CA8-48FC-BB2E-094D58575827
// Assembly location: C:\Users\Darma\Downloads\Object Deployment\Object Deployment\PCR\API\Maindealer-Api\MKT_MARKETPLACE_API.dll

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace MARKETPLACE_API
{
  public class Program
  {
    public static void Main(string[] args) => HostingAbstractionsHostExtensions.Run(Program.CreateHostBuilder(args).Build());

    public static IHostBuilder CreateHostBuilder(string[] args) => GenericHostBuilderExtensions.ConfigureWebHostDefaults(Host.CreateDefaultBuilder(args), (Action<IWebHostBuilder>) (webBuilder => WebHostBuilderExtensions.UseStartup<Startup>(webBuilder)));
  }
}
