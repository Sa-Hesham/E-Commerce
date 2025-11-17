

namespace Shared.Dtos;
public record PaginationREsult <TEntity>(int PageSize , int PageIndex , int TotalCount , IEnumerable<TEntity> Data);

