namespace UniClub.Domain.Common
{
    public abstract class RequestPaginationQuery<T>
    {
        public string? SearchValue { get; set; }
        public abstract T OrderBy { get; set; }
        public bool IsAscending { get; set; } = true;
        public int PageNumber { get; set; } = 1;
        public bool IsDeleted { get; set; } = false;
        public int PageSize { get; set; } = 10;

    }
}
