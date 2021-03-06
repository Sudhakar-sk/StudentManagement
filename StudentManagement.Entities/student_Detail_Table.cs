// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace StudentManagement.Entities
{
    public partial class student_Detail_Table
    {
        [Key]
        public int Student_Id { get; set; }
        [StringLength(50)]
        public string First_Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Last_Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date_of_Birth { get; set; }
        public int Age { get; set; }
        [Required]
        [StringLength(50)]
        public string Favorite_Subject { get; set; }
        [StringLength(50)]
        public string Intersted_Course { get; set; }
        public int Maths_Mark { get; set; }
        public int Chemistry_Mark { get; set; }
        public int Computer_Science_Mark { get; set; }
        public bool Is_Deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Create_Time_Stamp { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Update_Time_stamp { get; set; }
    }
}