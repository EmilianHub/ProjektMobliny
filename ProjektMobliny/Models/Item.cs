using SQLite;
using System;

namespace ProjektMobliny.Models
{
    public class Item
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public DateTime FinishedDate { get; set; }
    }
}