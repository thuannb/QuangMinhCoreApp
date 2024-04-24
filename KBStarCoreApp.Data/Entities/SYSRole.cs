using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KBStarCoreApp.Data.Entities
{
    [Table("SYSRoles")]
    public class SYSRole : IdentityRole<string>
    {
        public SYSRole() : base()
        {
        }

        public SYSRole(string name, string description) : base(name)
        {
            this.Description = description;
        }

        [StringLength(250)]
        public string Description { get; set; }
    }
}