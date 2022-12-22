namespace UNI.WebApi.Models
{
    public class Pager
    {
        public int TotalItem { get;private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }

        public Pager()
        {

        }
        public Pager(int totalItem, int page, int pageSize=10)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItem/(decimal)pageSize);
            int currentPage = page;

            int startPage = currentPage - 5;
            int endPage = currentPage + 4;

            if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }

            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItem = totalItem;
            CurrentPage = currentPage;
            PageSize = pageSize;
            StartPage = startPage;
            EndPage = endPage;
            TotalPages = totalPages;
        }



        public static T IEnumerable<T> (IEnumerable<T> list, int pg = 1)
        {
            const int pageSize = 10;
            if (pg < 1)
            { pg = 1; }

            int recsCount = list.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            IEnumerable<T> data = list.Skip(recSkip).Take(pageSize).ToList();

            return (T)data;
        }
    }
}
