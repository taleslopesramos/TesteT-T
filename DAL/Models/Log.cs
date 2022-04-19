using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string EntityName { get; set; }
        public LogType Type { get; set; }
        public string? oldProperties { get; set; }
        public string? newProperties { get; set; }
        public string? Exception { get; set; }
    }
}
