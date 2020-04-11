using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace OrienteeringAPI.Data
{
    public static class DataTableConverter
    {
        public static DataTable ConvertToDataTable<T>(this T data) where T : class
        {
            DataTable convertedTable = new DataTable();
            PropertyInfo[] propertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in propertyInfo)
            {
                convertedTable.Columns.Add(prop.Name);
            }
            var row = convertedTable.NewRow();
            var values = new object[propertyInfo.Length];
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                var test = propertyInfo[i].GetValue(data, null);
                row[i] = test ?? DBNull.Value;
            }
            convertedTable.Rows.Add(row);
            return convertedTable;
        }
    }
}
