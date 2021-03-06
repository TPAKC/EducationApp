﻿using EducationApp.DataAccessLayer.Entities.Enums;
using System;
using System.Collections.Generic;

namespace EducationApp.DataAccessLayer.ResponseModels
{
    public class GetAllItemsEditionResponceModel
    {
        public List<GetAllItemsEditionItemResponseModel> ResponseModels { get; set; }
        public long Count { get; set; }
    }

    public class GetAllItemsEditionItemResponseModel
    {
        public long Id { get; set; }
        public DateTime CreatingDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
        public PrintingEditionType Type { get; set; }
        public string AuthorName { get; set; }
    }
}
