//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DEMO2020GameShop.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class friends
    {
        public long ID { get; set; }
        public long user { get; set; }
        public long frend { get; set; }
    
        public virtual user user1 { get; set; }
        public virtual user user2 { get; set; }
    }
}
