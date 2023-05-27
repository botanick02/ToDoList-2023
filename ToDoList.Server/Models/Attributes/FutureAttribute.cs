using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Server.Models.Attributes
{
    public class FutureAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime? dateValue = value as DateTime?;
            if (dateValue.HasValue)
            {
                return dateValue.Value >= DateTime.Today;
            }

            return true;
        }
    }
}
