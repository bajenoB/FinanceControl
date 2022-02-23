using System;

namespace WebApplication2
{
    public class Info
    {
        public int Count { get; set; }
        public DateTime Date { get; set; }
        public int CategoryID { get; set; }
       
        public Info(int count, DateTime dateTime, int categoryID)
        {
            Count = count;
            Date = dateTime;
            CategoryID = categoryID;
        }
    }
}
