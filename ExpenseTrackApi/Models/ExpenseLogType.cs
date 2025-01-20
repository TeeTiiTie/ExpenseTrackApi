﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrack.Models
{
    [Table("ExpenseLogType")]
    public partial class ExpenseLogType
    {
        public ExpenseLogType()
        {
            ExpenseLogs = new HashSet<ExpenseLog>();
        }

        [Key]
        public int ExpenseLogTypeId { get; set; }
        [StringLength(255)]
        public string ExpenseLogTypeName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedByUserId { get; set; }

        [InverseProperty("ExpenseType")]
        public virtual ICollection<ExpenseLog> ExpenseLogs { get; set; }
    }
}