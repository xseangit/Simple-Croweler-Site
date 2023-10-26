namespace crowle.Models
{
    public class senddata
    {

        public class data
        {
            public string site { get; set; }
            public string url { get; set; }
            public List<string> nexts { get; set; }
            public int count { get; set; }
            public List<item> items { get; set; }
        }
        public class item
        {
            public string name { get; set; }
            public string selector { get; set; }
            public string datas { get; set; }
        }





    }
}
