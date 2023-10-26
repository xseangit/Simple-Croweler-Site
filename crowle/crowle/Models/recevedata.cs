using System.Collections.Generic;
using static crowle.Models.recevedata;

namespace crowle.Models
{
    public class recevedata
    {

        public class receved
        {
            public long id { get; set; }
            public string site { get; set; }
            public int itemco { get; set; }
            public List<receveitem>? item { get; set; }
            public receveop? op { get; set; }
        }
        public class receveitem
        {
            public string? name { get; set; } // بریزم تو چی
            public List<string>? by { get; set; } // با استفاده از چی انتخاب کنم
            public List<string>? selector { get; set; } //اگه هرچی هست مشخصه اش چیه
            public List<string>? next { get; set; } // بعدش چی بزنم
            public List<string>? back { get; set; } //قبلش چی بزنم 
            public List<bool>? all { get; set; } // همه شو بدم ؟؟؟؟
            public List<int>? itemnum { get; set; } // اگه همورو نمی خوای کدومو میخوای
            public List<string>? itemdatapart { get; set; } //اتریبیوت باشه یا تکست یا 
            public List<string>? itematrebute { get; set; } //اگر اتریبیوته کدومشون
            
        }


        public class receveop
        {
            public bool next { get; set; }
            public string nexturl { get; set; }
            public string nnexturl { get; set; }
            public string bnexturl { get; set; }
            public string api { get; set; }
            public string domain { get; set; }

        }





    }
}
