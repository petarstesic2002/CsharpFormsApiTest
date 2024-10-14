using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Dto
{
    public class CategoryCheckboxItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public override string ToString()
        {
            return Name;
        }
    }
}
