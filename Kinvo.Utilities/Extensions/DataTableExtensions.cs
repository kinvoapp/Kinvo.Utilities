using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Kinvo.Utilities.Extensions
{
    public static class DataTableExtensions
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> collection, string tableName)
        {
            var tbl = ToDataTable(collection);

            tbl.TableName = tableName;

            return tbl;
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> collection)
        {
            var dt = new DataTable();
            var t = typeof(T);
            var pia = t.GetProperties();

            //Create the columns in the DataTable
            foreach (PropertyInfo pi in pia)
            {
                if (Nullable.GetUnderlyingType(pi.PropertyType) != null)
                {
                    dt.Columns.Add(pi.Name, Nullable.GetUnderlyingType(pi.PropertyType));
                    continue;
                }

                dt.Columns.Add(pi.Name, pi.PropertyType);
            }

            //Populate the table
            foreach (T item in collection)
            {
                var dr = dt.NewRow();
                dr.BeginEdit();
                foreach (PropertyInfo pi in pia)
                {
                    var value = pi.GetValue(item, null);

                    dr[pi.Name] = value ?? DBNull.Value;
                }

                dr.EndEdit();

                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static DataTable ToDataTable<TMainTable, TTempTable>(this IEnumerable<TMainTable> collection)
        {
            var dt = new DataTable();
            var t = typeof(TTempTable);
            var pia = t.GetProperties();

            //Create the columns in the DataTable
            foreach (PropertyInfo pi in pia)
            {
                if (Nullable.GetUnderlyingType(pi.PropertyType) != null)
                {
                    dt.Columns.Add(pi.Name, Nullable.GetUnderlyingType(pi.PropertyType));
                    continue;
                }

                dt.Columns.Add(pi.Name, pi.PropertyType);
            }

            t = typeof(TMainTable);
            pia = t.GetProperties();


            //Populate the table
            foreach (TMainTable item in collection)
            {
                var dr = dt.NewRow();
                dr.BeginEdit();
                foreach (PropertyInfo pi in pia)
                {
                    if (!dt.Columns.Contains(pi.Name))
                        continue;

                    var value = pi.GetValue(item, null);

                    dr[pi.Name] = value ?? DBNull.Value;
                }

                dr.EndEdit();

                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
