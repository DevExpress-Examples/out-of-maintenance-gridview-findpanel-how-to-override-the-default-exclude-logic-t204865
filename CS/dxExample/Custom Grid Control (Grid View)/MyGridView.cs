using System;
using DevExpress.Data.Filtering;
using DevExpress.Data.Helpers;

namespace MyXtraGrid {
    public class MyGridView : DevExpress.XtraGrid.Views.Grid.GridView {
        public MyGridView()
            : this(null) {
        }
        public MyGridView(DevExpress.XtraGrid.GridControl grid)
            : base(grid) {
        }
        protected override string ViewName {
            get {
                return "MyGridView";
            }
        }
        protected override CriteriaOperator ConvertGridFilterToDataFilter(CriteriaOperator criteria, bool forceFindFilter = false) {
            if (!string.IsNullOrEmpty(FindFilterText)) {
                FindSearchParserResults lastParserResults = new FindSearchParser().Parse(FindFilterText, GetFindToColumnsCollection());
                CriteriaOperator findCriteria = CustomCriteriaHelper.Create(lastParserResults, FilterCondition.Contains, IsServerMode);
                return criteria & findCriteria;
            }
            return criteria;
        }
    }
}
