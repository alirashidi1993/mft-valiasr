//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MFT.Training.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shahr
    {
        
        public Shahr()
        {
            this.Customers = new List<Customer>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int OstanId { get; set; }
        public  List<Customer> Customers { get; set; }
        public  Ostan Ostan { get; set; }
    }
}