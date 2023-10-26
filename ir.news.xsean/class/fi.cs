namespace ir.news.xsean
{
    public class fi
    {

        public static IEnumerable<newss> find(IEnumerable<newsfi> items, dbcontext dbcontext, IEnumerable<newss> newsses)
        {
            try
            {
                List<newss> list = new List<newss>();
                List<long> listid = new List<long>();
                foreach (var i in items)
                {
                    listid.Add(i.Id);
                }
                list = newsses.Where(p => listid.Contains(p.Id)).ToList();
                return list;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                List<newss> list = new List<newss>();
                List<long> listid = new List<long>();
                foreach (var i in items)
                {
                    listid.Add(i.Id);
                }
                list = newsses.Where(p => listid.Contains(p.Id)).ToList();
                return list;
            }

        }
    }
}
