using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Core.Entities;

namespace Catalog.Application.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }
        [BsonElement("Name")]
        public required string Name { get; set; }
        public string Summary { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageFile { get; set; }
        public decimal Price { get; set; }
        public ProductBrand? Brands { get; set; }
        public ProductType? Types { get; set; }
    }
}
