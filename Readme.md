# GridView - FindPanel - How to override the default exclude logic


By default, the '-' and '+' signs are special. For example, a string preceded with a dash "-" is excluded from the result set. If you want to override this logic and use these signs not as special symbols but as regular ones, create a custom grid (<a href="https://www.devexpress.com/Support/Center/p/E900">How to create a GridView descendant class and register it for design-time use</a>) and override the GridView.ConvertGridFilterToDataFilter method. In this example, the '+' and '-' signs are recognized as regular ones (i.e., not as special symbols).<br /><br />See also:<br /><a href="https://documentation.devexpress.com/#WindowsForms/CustomDocument8869">Find Panel</a>

<br/>


