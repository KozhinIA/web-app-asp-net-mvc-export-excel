using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Common.Extensions
{
    public class XlsxRender
    {
        public List<object> Items { get; set; }
        public List<XlsxColumn> Columns { get; set; }

        public static Func<PropertyInfo, bool> ValidTypePredicate { get; } =
           x => (!x.Name.EndsWith("Id") || x.Name == "Id")
           && x.PropertyType.IsPublic
           && x.GetCustomAttribute(typeof(NotMappedAttribute)) == null

           && (x.PropertyType.IsPrimitive
           || x.PropertyType.IsEnum
           || x.PropertyType == typeof(string)
           || x.PropertyType == typeof(decimal)
           || x.PropertyType == typeof(DateTime)
           || x.PropertyType == typeof(Guid)          

           ||
           (x.PropertyType.IsGenericType && x.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) 
           && (
             (Nullable.GetUnderlyingType(x.PropertyType).IsPrimitive 
              && Nullable.GetUnderlyingType(x.PropertyType) != typeof(bool))
           //|| Nullable.GetUnderlyingType(x.PropertyType).IsEnum
           || Nullable.GetUnderlyingType(x.PropertyType) == typeof(string)
           || Nullable.GetUnderlyingType(x.PropertyType) == typeof(decimal)
           || Nullable.GetUnderlyingType(x.PropertyType) == typeof(DateTime)
           || Nullable.GetUnderlyingType(x.PropertyType) == typeof(Guid)
           ))          
           );
    }
}