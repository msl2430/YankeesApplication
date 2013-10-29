using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace YankeesCodeChallenge.Configuration.Helpers
{
    public class DataTableHelper<T>
    {
        private const string _nameKeyName = "name";
        private const string _valueKeyName = "value";
        private const string _echo = "sEcho";
        private const string _sortKeyPrefix = "iSortCol_";
        private const string _sortDirectionKeyPrefix = "sSortDir_";
        private const string _searchKey = "sSearch";
        private const string _displayStart = "iDisplayStart";
        private const string _displayLength = "iDisplayLength";
        private Type _type;
        private PropertyInfo[] _properties;
        private List<aoData> _tableOptions;
        public IQueryable<T> Data;

        public int SortColumnIndex
        {
            get { return Convert.ToInt32(GetTableOptionValue(_sortKeyPrefix)); }
        }

        public string SortDirection
        {
            get { return GetTableOptionValue(_sortDirectionKeyPrefix); }
        }

        public string SearchKey
        {
            get { return GetTableOptionValue(_searchKey); }
        }

        public int DisplayStart
        {
            get { return Convert.ToInt32(GetTableOptionValue(_displayStart)); }
        }

        public int DisplayLength
        {
            get { return Convert.ToInt32(GetTableOptionValue(_displayLength)); }
        }

        public int TotalItemCount { get; private set; }

        public int TotalFilteredItemCount { get; private set; }

        public DataTableHelper()
        {
            _type = typeof(T);
            _properties = _type.GetProperties();
        }

        public DataTableHelper(List<aoData> tableOptions)
        {
            _type = typeof(T);
            _properties = _type.GetProperties();
            Initialize(tableOptions);
        }

        private Expression<Func<T, List<string>>> SelectProperties
        {
            get
            {
                return value => _properties.Select(prop => (prop.GetValue(value, new object[0]) ?? string.Empty).ToString()).ToList();
            }
        }

        public void Initialize(object[] tableOptions)
        {
            tableOptions.ToList().ForEach(x => _tableOptions.Add(new aoData() { Name = ((aoData)x).Name, Value = ((aoData)x).Value }));
        }

        public void Initialize(List<aoData> tableOptions)
        {
            _tableOptions = tableOptions;
        }

        public void SetResults(IQueryable<T> iQueryable, int resultCount)
        {
            Data = iQueryable;
            TotalItemCount = resultCount;
            TotalFilteredItemCount = resultCount;
        }

        public void SetResults(IQueryable<T> iQueryable, int resultCount, int totalFilteredItemCount)
        {
            Data = iQueryable;
            TotalItemCount = resultCount;
            TotalFilteredItemCount = totalFilteredItemCount;
        }

        public string GetTableOptionValue(string optionName)
        {
            var firstOrDefault = _tableOptions.FirstOrDefault(x => x.Name.StartsWith(optionName));

            if (firstOrDefault != null && firstOrDefault.Value != null)
                return firstOrDefault.Value;

            return string.Empty;
        }

        public void SetTableOptionValue(string optionName, object optionValue)
        {
            _tableOptions.FirstOrDefault(x => x.Name.StartsWith(optionName)).Value = optionValue.ToString();
        }

        public FormattedList Parse()
        {
            var list = new FormattedList();

            list.Import(_properties.Select(x => x.Name).ToArray());
            list.sEcho = int.Parse(GetTableOptionValue(_echo));
            list.iTotalDisplayRecords = TotalFilteredItemCount;
            list.aaData = Data.Select(SelectProperties).ToList();
            list.iTotalRecords = TotalItemCount;

            return list;
        }
    }

    public abstract class BasicFormattedList
    {
        public int sEcho { get; set; }
        public int iTotalRecords { get; set; }
        public int iTotalDisplayRecords { get; set; }
        public string sColumns { get; set; }

        public void Import(string[] properties)
        {
            sColumns = string.Empty;

            for (int i = 0; i <= properties.Length - 1; i++)
            {
                sColumns += properties[i];
                if (i < properties.Length - 1)
                {
                    sColumns += ",";
                }
            }
        }
    }

    public class FormattedList : BasicFormattedList
    {
        public List<List<string>> aaData { get; set; }
    }

    public class FormattedListJson<T> : BasicFormattedList
    {
        public List<T> aaData { get; set; }
    }

    public class aoData
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class ResultsWithCount<T>
    {
        public IList<T> Results { get; set; }
        public int ResultCount { get; set; }
        public int FilteredResultCount { get; set; }
    }
}