﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrack.Models
{
    [Table("ExpenseGroup")]
    public partial class ExpenseGroup
    {
        public ExpenseGroup()
        {
            ExpenseItems = new HashSet<ExpenseItem>();
            ExpenseLogs = new HashSet<ExpenseLog>();
        }

        [Key]
        public Guid ExpenseGroupId { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string ExpenseGroupCode { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string ApplicationCode { get; set; }
        /// <summary>
        /// ปีการศึกษา
        /// </summary>
        [StringLength(4)]
        [Unicode(false)]
        public string SchoolYear { get; set; }
        /// <summary>
        /// id สาขา
        /// </summary>
        public int? BranchId { get; set; }
        /// <summary>
        /// สาขา
        /// </summary>
        [StringLength(255)]
        public string BranchName { get; set; }
        /// <summary>
        /// สถานศึกษา
        /// </summary>
        [StringLength(255)]
        public string ShcoolName { get; set; }
        /// <summary>
        /// Id ธนาคารผู้รับเงิน
        /// </summary>
        public int? PayeeBankId { get; set; }
        /// <summary>
        /// ธนาคารผู้รับเงิน
        /// </summary>
        [StringLength(255)]
        public string PayeeBankName { get; set; }
        /// <summary>
        /// เลขบัญชีผู้รับเงิน
        /// </summary>
        [StringLength(20)]
        [Unicode(false)]
        public string PayeeAccountNumber { get; set; }
        /// <summary>
        /// ชื่อบัญชีผู้รับเงิน
        /// </summary>
        [StringLength(255)]
        public string PayeeAccountName { get; set; }
        /// <summary>
        /// id สาขาบริการ
        /// </summary>
        public int? ServicedBranchId { get; set; }
        /// <summary>
        /// สาขาบริการ
        /// </summary>
        [StringLength(255)]
        public string ServicedBranchName { get; set; }
        /// <summary>
        /// UserId ผู้ให้บริการ
        /// </summary>
        public int? ServicedByUserId { get; set; }
        /// <summary>
        /// Code ผู้ให้บริการ
        /// </summary>
        [StringLength(10)]
        [Unicode(false)]
        public string ServicedByCode { get; set; }
        /// <summary>
        /// ผู้ให้บริการ
        /// </summary>
        [StringLength(255)]
        public string ServicedByName { get; set; }
        public int? ItemCount { get; set; }
        [Column(TypeName = "decimal(16, 2)")]
        public decimal? TotalAmount { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string DocumentCode { get; set; }
        public Guid? DocumentId { get; set; }
        /// <summary>
        /// ยอดเงินโอน
        /// </summary>
        [Column(TypeName = "decimal(16, 2)")]
        public decimal? TransferAmount { get; set; }
        /// <summary>
        /// วันที่โอน
        /// </summary>
        public DateTime? TransferDate { get; set; }
        /// <summary>
        /// หมายเหตุการโอน
        /// </summary>
        public string TransfeRemark { get; set; }
        /// <summary>
        /// วันที่พิจารณา
        /// </summary>
        public DateTime? ApproveDate { get; set; }
        /// <summary>
        /// UserId ผู้พิจารณา
        /// </summary>
        public int? ApproveByUserId { get; set; }
        /// <summary>
        /// Code ผู้พิจารณา
        /// </summary>
        [StringLength(10)]
        [Unicode(false)]
        public string ApproveByCode { get; set; }
        /// <summary>
        /// ผู้พิจารณา
        /// </summary>
        [StringLength(255)]
        public string ApproveByName { get; set; }
        /// <summary>
        /// หมายเหตุยกเลิก
        /// </summary>
        public string CancelledRemark { get; set; }
        /// <summary>
        /// วันที่ยกเลิก
        /// </summary>
        public DateTime? CancelledDate { get; set; }
        /// <summary>
        /// UserId ผู้ยกเลิก
        /// </summary>
        public int? CancelledByUserId { get; set; }
        /// <summary>
        /// Code ผู้ยกเลิก
        /// </summary>
        [StringLength(10)]
        [Unicode(false)]
        public string CancelledByCode { get; set; }
        /// <summary>
        /// ผู้ยกเลิก
        /// </summary>
        [StringLength(255)]
        public string CancelledByName { get; set; }
        public int? ExpenseStatusId { get; set; }
        public bool? IsActive { get; set; }
        /// <summary>
        /// วันที่สร้างรายการ
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// UserId ผู้สร้างรายการ
        /// </summary>
        public int? CreatedByUserId { get; set; }
        /// <summary>
        /// Code ผู้สร้างรายการ
        /// </summary>
        [StringLength(10)]
        [Unicode(false)]
        public string CreatedByCode { get; set; }
        /// <summary>
        /// ผู้สร้างรายการ
        /// </summary>
        [StringLength(255)]
        public string CreatedByName { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedByUserId { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string UpdatedByCode { get; set; }
        [StringLength(255)]
        public string UpdatedByName { get; set; }

        [ForeignKey("ExpenseStatusId")]
        [InverseProperty("ExpenseGroups")]
        public virtual ExpenseStatus ExpenseStatus { get; set; }
        [InverseProperty("ExpenseGroup")]
        public virtual ICollection<ExpenseItem> ExpenseItems { get; set; }
        [InverseProperty("ExpenseGroup")]
        public virtual ICollection<ExpenseLog> ExpenseLogs { get; set; }
    }
}