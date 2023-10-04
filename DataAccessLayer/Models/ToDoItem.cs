using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class ToDoItem
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public DateTime? DateCreated { get; set; }

        public TimeSpan TimeCreated
        {
            get {
                return new TimeSpan(DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second);
                    }
            set
            {
                value = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            }
        }
        public bool IsCompleted { get; set; }
    }
}