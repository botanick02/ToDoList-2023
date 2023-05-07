﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Business.DTO_s
{
    public class TaskDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime? DueDate { get; set; }

        public int CategoryId { get; set; }

        public bool IsDone { get; set; }
    }
}
