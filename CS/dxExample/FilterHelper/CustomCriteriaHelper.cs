using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Data.Helpers;
using DevExpress.Data.Filtering;
using System.Threading;
using DevExpress.Data.Summary;

namespace MyXtraGrid {
    public class CustomCriteriaHelper {
        public static CriteriaOperator Create(FindSearchParserResults parseResult, FilterCondition defaultCondition, bool isServerMode) {
            CriteriaOperator rv = null;
            rv = CreateFilter(parseResult.SearchTexts, parseResult.ColumnNames, defaultCondition, isServerMode);
            foreach (FindSearchField f in parseResult.Fields) {
                CriteriaOperator columnFilter = null;
                columnFilter = CreateFilter(f.Values, new FindColumnInfo[] { f.Column }, defaultCondition, isServerMode);
                rv &= columnFilter;
            }
            return rv;
        }
        private static CriteriaOperator CreateFilter(string[] values, FindColumnInfo[] properties, FilterCondition filterCondition, bool isServerMode) {
            CriteriaOperator stAnd = null, stOr = null;
            foreach (string stext in values) {
                //if (stext.StartsWith("+")) {
                //    stAnd &= DoFilterCondition(stext.Substring(1), properties, filterCondition, isServerMode);
                //    continue;
                //}
                //if (stext.StartsWith("-")) {
                //    stAnd &= !DoFilterCondition(stext.Substring(1), properties, filterCondition, isServerMode);
                //    continue;
                //}
                stOr |= DoFilterCondition(stext, properties, filterCondition, isServerMode);
            }
            return stAnd & stOr;
        }
        private static CriteriaOperator DoFilterCondition(string originalValue, FindColumnInfo[] columns, FilterCondition defaultCondition, bool isServerMode) {
            CriteriaOperator rv = null;
            CriteriaOperator op;
            foreach (FindColumnInfo column in columns) {
                FilterCondition filterCondition = defaultCondition;
                object value = originalValue;
                if (isServerMode) {
                    if (!AllowColumn(column, ref value, ref filterCondition)) {
                        continue;
                    }
                }
                OperandProperty property = new OperandProperty(column.PropertyName);
                switch (filterCondition) {
                    case FilterCondition.StartsWith:
                        op = new FunctionOperator(FunctionOperatorType.StartsWith, property, new OperandValue(value));
                        break;
                    case FilterCondition.Contains:
                        op = new FunctionOperator(FunctionOperatorType.Contains, property, new OperandValue(value));
                        break;
                    case FilterCondition.Equals:
                        op = FilterHelper.CalcColumnFilterCriteriaByValue(column.PropertyName, column.Column.FieldType, value, true, Thread.CurrentThread.CurrentCulture);
                        break;
                    default:
                        op = value.ToString().Contains("%") ?
                            (CriteriaOperator)new BinaryOperator(property, new OperandValue(value), BinaryOperatorType.Like) :
                            new FunctionOperator(FunctionOperatorType.Contains, property, new OperandValue(value));
                        break;
                }
                rv |= op;
            }
            return rv;
        }
        private static bool AllowColumn(FindColumnInfo column, ref object value, ref FilterCondition filterCondition) {
            if (column.Column == null) {
                return false;
            }
            Type type = column.Column.FieldType;
            if (Nullable.GetUnderlyingType(type) != null) {
                type = Nullable.GetUnderlyingType(type);
            }
            string val = value == null ? null : value.ToString();
            if (SummaryItemTypeHelper.IsNumericalType(type)) {
                filterCondition = FilterCondition.Equals;
                object numVal;
                try {
#if !SL
                    numVal = Convert.ChangeType(val, type);
#else
					numVal = Convert.ChangeType(val, type, CultureInfo.CurrentCulture);
#endif
                } catch {
                    return false;
                }
                value = numVal;
                return true;
            }
            if (SummaryItemTypeHelper.IsDateTime(type)) {
                filterCondition = FilterCondition.Equals;
                object date;
                try {
#if !SL
                    date = Convert.ChangeType(val, type);
#else
					date = Convert.ChangeType(val, type, CultureInfo.CurrentCulture);
#endif
                } catch {
                    return false;
                }
                value = date;
                return true;
            }
            if (SummaryItemTypeHelper.IsBool(type)) {
                filterCondition = FilterCondition.Equals;
                bool res;
                if (!bool.TryParse(val, out res)) {
                    return false;
                }
                value = res;
                return true;
            }
#if SL
			if(type.Equals(typeof(TimeSpan)) || type.Equals(typeof(TimeSpan?))) {
				filterCondition = FilterCondition.Equals;
				TimeSpan res;
				if(!TimeSpan.TryParse(val, out res)) return false;
				value = res;
				return true;
			}
#endif
            return true;
        }
        public static class FilterCriteriaHelper {
            public static CriteriaOperator ReplaceFilterCriteria(CriteriaOperator source, CriteriaOperator prevOperand, CriteriaOperator newOperand) {
                GroupOperator groupOperand = source as GroupOperator;
                if (ReferenceEquals(groupOperand, null)) {
                    return newOperand;
                }
                GroupOperator clone = groupOperand.Clone();
                clone.Operands.Remove(prevOperand);
                if (clone.Equals(source)) {
                    return newOperand;
                }
                clone.Operands.Add(newOperand);
                return clone;
            }
        }
    }
}
