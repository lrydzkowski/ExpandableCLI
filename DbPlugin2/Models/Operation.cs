using System;

namespace DbPlugin2.Models
{
    class Operation
    {
        public long RecId { get; set; }

        public string OperationKey { get; set; } = "";

        public DateTime StartDateTimeUTC { get; set; }

        public DateTime EndDateTimeUTC { get; set; }
    }
}
