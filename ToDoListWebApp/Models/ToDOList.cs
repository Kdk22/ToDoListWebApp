using System;

using System.ComponentModel.DataAnnotations;
using ToDoListWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListWebApp.Models
{
    public class ToDOList
    {


        [Key]
        [HiddenInput]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Required]
        public bool Done { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DoneDate { get; set; }


        public ToDOList()
        {
        }
    }
}
