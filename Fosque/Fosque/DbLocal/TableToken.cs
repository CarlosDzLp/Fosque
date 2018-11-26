using System;
using SQLite;

namespace Fosque.DbLocal
{
    public class TableToken
    {
        [PrimaryKey]
        public string Token { get; set; }
        public string PlayerID { get; set; }
    }
}
