<!-- default file list -->
*Files to look at*:

* [MyGridControl.cs](./CS/dxExample/Custom Grid Control (Grid View)/MyGridControl.cs) (VB: [MyGridControl.vb](./VB/dxExample/Custom Grid Control (Grid View)/MyGridControl.vb))
* [MyGridRegistration.cs](./CS/dxExample/Custom Grid Control (Grid View)/MyGridRegistration.cs) (VB: [MyGridRegistration.vb](./VB/dxExample/Custom Grid Control (Grid View)/MyGridRegistration.vb))
* [MyGridView.cs](./CS/dxExample/Custom Grid Control (Grid View)/MyGridView.cs) (VB: [MyGridView.vb](./VB/dxExample/Custom Grid Control (Grid View)/MyGridView.vb))
* **[CustomCriteriaHelper.cs](./CS/dxExample/FilterHelper/CustomCriteriaHelper.cs) (VB: [CustomCriteriaHelper.vb](./VB/dxExample/FilterHelper/CustomCriteriaHelper.vb))**
* [Form1.cs](./CS/dxExample/Form1.cs) (VB: [Form1.vb](./VB/dxExample/Form1.vb))
* [Program.cs](./CS/dxExample/Program.cs) (VB: [Program.vb](./VB/dxExample/Program.vb))
* [TestData.cs](./CS/dxExample/TestData.cs) (VB: [TestData.vb](./VB/dxExample/TestData.vb))
<!-- default file list end -->
# GridView - FindPanel - How to override the default exclude logic


By default, the '-' and '+' signs are special. For example, a string preceded with a dash "-" is excluded from the result set. If you want to override this logic and use these signs not as special symbols but as regular ones, create a custom grid (<a href="https://www.devexpress.com/Support/Center/p/E900">How to create a GridView descendant class and register it for design-time use</a>) and override the GridView.ConvertGridFilterToDataFilter method. In this example, the '+' and '-' signs are recognized as regular ones (i.e., not as special symbols).<br /><br />See also:<br /><a href="https://documentation.devexpress.com/#WindowsForms/CustomDocument8869">Find Panel</a>

<br/>


