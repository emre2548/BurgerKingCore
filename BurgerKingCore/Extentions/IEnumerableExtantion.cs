using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerKingCore.Extentions
{
    //extantion method static olmalı
    public static class IEnumerableExtantion
    {
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> items, int selectValue)
        {
            return from item in items
                   select new SelectListItem()
                   {
                       Text = item.GetPropertyValue("Name"),
                       Value = item.GetPropertyValue("Id"),
                       Selected = item.GetPropertyValue("Id").Equals(selectValue.ToString())
                   };
        }
    }
}
