//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iplogger.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class datum
    {
        public int uniqueid { get; set; }
        public string id { get; set; }
        public string ipaddress { get; set; }
        public string browser { get; set; }
        public string os { get; set; }
        public string devicetype { get; set; }
        public Nullable<System.DateTime> time { get; set; }
    }
}