// Decompiled with JetBrains decompiler
// Type: MARKETPLACE_API.WeatherForecast
// Assembly: MKT_MARKETPLACE_API, Version=1.0.2021.1123, Culture=neutral, PublicKeyToken=null
// MVID: 93D50DA4-6CA8-48FC-BB2E-094D58575827
// Assembly location: C:\Users\Darma\Downloads\Object Deployment\Object Deployment\PCR\API\Maindealer-Api\MKT_MARKETPLACE_API.dll

using System;

namespace MARKETPLACE_API
{
  public class WeatherForecast
  {
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int) ((double) this.TemperatureC / 0.5556);

    public string Summary { get; set; }
  }
}
