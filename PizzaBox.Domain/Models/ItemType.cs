using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaBox.Domain.Models
{
    [Table("ItemType")]
    public class ItemType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TypeID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public ItemType()
        {
            
        }
        public ItemType(string n)
        {
            Name = n;
        }
    }
}