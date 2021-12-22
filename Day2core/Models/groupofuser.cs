﻿using Day2core.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Day2core.Models
{
    public class groupofuser
    {

        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }
        public virtual group Group { get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser{ get; set; }
        public bool IsAccept { get; set; }
    }
}
