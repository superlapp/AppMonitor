//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppMonitorWCFService
{
    using System;
    using System.Collections.Generic;
    
    public partial class dbUser
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public Nullable<int> HostId { get; set; }
    
        public virtual dbHost dbHost { get; set; }
    }
}
