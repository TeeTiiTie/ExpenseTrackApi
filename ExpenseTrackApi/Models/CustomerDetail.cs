﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrack.Models
{
    [Keyless]
    [Table("CustomerDetail", Schema = "ext")]
    public partial class CustomerDetail
    {
        [StringLength(10)]
        [Unicode(false)]
        public string ApplicationCode { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string CustomerDetailCode { get; set; }
        public string CustomerName { get; set; }
        [StringLength(255)]
        public string LevelRoom { get; set; }
        [StringLength(100)]
        public string IdentificationNo { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string CustomerTypeId { get; set; }
        [StringLength(100)]
        public string CustomerTypeName { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string StatusId { get; set; }
        [StringLength(100)]
        public string StatusName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}