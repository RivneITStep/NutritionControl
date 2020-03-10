namespace NutritionControl.DTO.DtoResults
{
	public class PaginationResultDto<T> : CollectionResultDto<T>
	{
		public int PageIndex { get; set; }
		public int PageSize { get; set; }
	}
}