using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class HostelContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
    
    }
}