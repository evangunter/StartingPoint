//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StartingPoint.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class AuthenticationToken
    {
        public System.Guid AuthenticationTokenId { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
        public System.DateTime Added { get; set; }
        public System.DateTime Expires { get; set; }
        public Nullable<System.Guid> ApplicationId { get; set; }
        public string AddedById { get; set; }
    
        public virtual Application Application { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual AspNetUser AspNetUser1 { get; set; }
    }
}
