using RetailInventoryAPI.DTOs;
using RetailInventoryAPI.Models;

namespace RetailInventoryAPI.Mappings
{
	public static class ProductMappings
	{
		public static ProductReadDto ToReadDto(this Product product)
		{
			return new ProductReadDto
			{
				Id = product.Id,
				Name = product.Name,
				Quantity = product.Quantity
			};
		}
		public static Product ToEntity(this ProductCreateDto dto)
		{
			return new Product
			{
				Name = dto.Name,
				Quantity = dto.Quantity
			};
		} 
		public static void UpdateEntity(this ProductUpdateDto dto, Product product)
		{
			product.Name = dto.Name;
			product.Quantity = dto.Quantity;
		}
	}
}
