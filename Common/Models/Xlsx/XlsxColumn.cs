using System;

namespace Common.Extensions
{
    public class XlsxColumn
    {
        public string DisplayName { get; set; }
        public Type ColumnType { get; set; }
        public int? Order { get; set; }
    }
}