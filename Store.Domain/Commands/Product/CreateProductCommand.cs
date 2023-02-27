﻿using Store.Domain.Commands.Common;

namespace Store.Domain.Commands.Product
{
    public class CreateProductCommand : RequestCommand<Models.Product>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string[] PicturesUrls { get; set; }
    }
}
