using System;
using System.Collections.Generic;
using System.Linq;

namespace dxExample {
    public class TestData {
        public string Column1 { get;
            set; }
        public string Column2 { get;
            set; }

        public TestData() {
            Column1 = string.Empty;
            Column2 = string.Empty;
        }

        public TestData(string col1, string col2) {
            Column1 = col1;
            Column2 = col2;
        }
    }
}
