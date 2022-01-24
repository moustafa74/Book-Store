using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class BookModel
    {
        public int ISBN { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }
        public string Language { get; set; }
        public Nullable<float> Price { get; set; }
        public string Year { get; set; }
        public Nullable<int> Stock { get; set; }
       public HttpPostedFileBase Image_file { get; set; }
        public string Image { get; set; }
        public string Conclution { get; set; }
        public string Author_name { get; set; }
        public int Author_id { get; set; }
        public string Publisher_name { get; set; }
        public int Publisher_id { get; set; }
        public string P_E_Mail { get; set; }
        public string P_Phone { get; set; }
        public string p_Adress { get; set; }
        public string A_E_Mail { get; set; }
        public string A_Phone { get; set; }
    }
}