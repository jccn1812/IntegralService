﻿using System.ComponentModel.DataAnnotations;

namespace PlatformService.Dtos
{
    public class PlatformReadDTO
    {
     
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        public string? SecondName { get; set; }


        [Required]
        public string? Publisher { get; set; }

        [Required]
        public string? Cost { get; set; }
    }
}
