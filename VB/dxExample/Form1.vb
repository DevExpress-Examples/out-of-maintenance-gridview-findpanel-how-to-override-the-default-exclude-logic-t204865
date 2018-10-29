Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace dxExample
    Partial Public Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

        Public Sub New()
            InitializeComponent()
            InitGrid()
        End Sub
        Private Sub InitGrid()
            myGridControl1.DataSource = GetData()
            myGridView1.OptionsFind.AlwaysVisible = True
        End Sub
        Private Function GetData() As Object
            Dim records As New List(Of TestData)()
            records.Add(New TestData("AAA", "BBB"))
            records.Add(New TestData("A-AA", "-a-a"))
            records.Add(New TestData("AA-AA", "ABC"))
            records.Add(New TestData("-AAA", "a -a -b"))
            records.Add(New TestData("BBBB", "-A"))
            records.Add(New TestData("-A", "-B"))
            Return records
        End Function
    End Class
End Namespace
