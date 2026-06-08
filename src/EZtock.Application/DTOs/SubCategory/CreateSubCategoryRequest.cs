using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Application.DTOs.SubCategory
{
    public class CreateSubCategoryRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }

    }
}
