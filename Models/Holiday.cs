using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace holidays_web_api.Models
{
    public class Root {
    public int version {  get; set; }
    public Billing billing { get; set; }
    public List < Holiday > holidays { get; set; }

  }
    public class Billing {
    public int credits { get; set; }
  }

  public class Holiday {
    public int id { get; set; }
    public string urlid { get; set; }
    public string url { get; set; }
    public Country country { get; set; }
    public List < Name > name { get; set; }
    public List < Oneliner > oneliner { get; set; }
    public List < string > types { get; set; }
    public object subtype { get; set; }
    public Date date { get; set; }
    public string uid { get; set; }
  }
  public class Country {
    public string id { get; set; }
    public string name { get; set; }
  }

  public class Name {
    public string lang { get; set; }
    public string text { get; set;
    }
  }

  public class Oneliner {
    public string lang { get; set; }
    public string text { get; set;
    }
  }

  public class Datetime {
    public int year { get; set; }
    public int month { get; set; }
    public int day { get; set; }
  }

  public class Date {
    public string iso { get; set; }
    public Datetime datetime { get; set;
    }
  }

}