using System;
using System.Collections.Generic;
using System.Linq;

namespace dxExample {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        public Form1() {
            InitializeComponent();
            InitGrid();
        }
        private void InitGrid() {
            myGridControl1.DataSource = GetData();
            myGridView1.OptionsFind.AlwaysVisible = true;
        }
        private object GetData() {
            List<TestData> records = new List<TestData>();
            records.Add(new TestData("AAA", "BBB"));
            records.Add(new TestData("A-AA", "-a-a"));
            records.Add(new TestData("AA-AA", "ABC"));
            records.Add(new TestData("-AAA", "a -a -b"));
            records.Add(new TestData("BBBB", "-A"));
            records.Add(new TestData("-A", "-B"));
            return records;
        }
    }
}
