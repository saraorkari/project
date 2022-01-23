using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DTO
{
    public class CategoryDTO : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CompareTo(object obj)
        {
            if (obj is CategoryDTO)
            {
                return Id.CompareTo((obj as CategoryDTO).Id);
            }
            return -1;
        }
        public override bool Equals(object obj)
        {
            if (obj is CategoryDTO)
            {
                return Id.Equals((obj as CategoryDTO).Id);
            }
            return false;
        }
    }
}