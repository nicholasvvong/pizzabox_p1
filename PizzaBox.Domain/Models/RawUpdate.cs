using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class RawUpdate
    {
        public Guid ID { get; set; }
        public List<RawComp> CrustList { get; set; }
        public List<RawComp> SizeList { get; set; }
        public List<RawComp> ToppingList { get; set; }

    }
}