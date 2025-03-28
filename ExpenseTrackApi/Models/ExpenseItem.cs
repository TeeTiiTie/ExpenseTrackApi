﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackApi.Models
{
    [Table("ExpenseItem")]
    public partial class ExpenseItem
    {
        [Key]
        public Guid ExpenseItemId { get; set; }
        public Guid? ExpenseGroupId { get; set; }
        /// <summary>
        /// เลขที่ผู้เอา
        /// </summary>
        [StringLength(20)]
        [Unicode(false)]
        public string CustomerDetailCode { get; set; }
        /// <summary>
        /// ชื่อผู้เอาประกัน
        /// </summary>
        [StringLength(255)]
        public string CustomerName { get; set; }
        /// <summary>
        /// ระดับชั้น
        /// </summary>
        [StringLength(255)]
        public string LevelRoom { get; set; }
        /// <summary>
        /// เลขบัตรประชาชน/Passport
        /// </summary>
        [StringLength(50)]
        [Unicode(false)]
        public string IdentificationNo { get; set; }
        /// <summary>
        /// Id ประเภทผู้เอาประกัน
        /// </summary>
        [StringLength(10)]
        [Unicode(false)]
        public string CustomerTypeId { get; set; }
        /// <summary>
        /// ประเภทผู้เอาประกัน
        /// </summary>
        [StringLength(255)]
        public string CustomerTypeName { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string StatusId { get; set; }
        [StringLength(255)]
        public string StatusName { get; set; }
        /// <summary>
        /// ยอดเบิก
        /// </summary>
        [Column(TypeName = "decimal(16, 2)")]
        public decimal? Amount { get; set; }
        /// <summary>
        /// ยอดอนุมัติโอน
        /// </summary>
        [Column(TypeName = "decimal(16, 2)")]
        public decimal? ApproveAmount { get; set; }
        /// <summary>
        /// หมายเหตุ
        /// </summary>
        public string Remark { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [ForeignKey("ExpenseGroupId")]
        [InverseProperty("ExpenseItems")]
        public virtual ExpenseGroup ExpenseGroup { get; set; }
    }
}