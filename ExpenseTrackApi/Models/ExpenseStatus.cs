﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackApi.Models
{
    [Table("ExpenseStatus")]
    public partial class ExpenseStatus
    {
        public ExpenseStatus()
        {
            ExpenseGroups = new HashSet<ExpenseGroup>();
        }

        [Key]
        public int ExpenseStatusId { get; set; }
        [StringLength(255)]
        public string ExpenseStatusName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedByUserId { get; set; }

        [InverseProperty("ExpenseStatus")]
        public virtual ICollection<ExpenseGroup> ExpenseGroups { get; set; }
    }
}