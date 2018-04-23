Imports System
Imports DevExpress.Data.Filtering
Imports DevExpress.Data.Helpers

Namespace MyXtraGrid
    Public Class MyGridView
        Inherits DevExpress.XtraGrid.Views.Grid.GridView

        Public Sub New()
            Me.New(Nothing)
        End Sub
        Public Sub New(ByVal grid As DevExpress.XtraGrid.GridControl)
            MyBase.New(grid)
        End Sub
        Protected Overrides ReadOnly Property ViewName() As String
            Get
                Return "MyGridView"
            End Get
        End Property

        Protected Overrides Function ConvertGridFilterToDataFilter(ByVal criteria As DevExpress.Data.Filtering.CriteriaOperator) As CriteriaOperator
            If Not String.IsNullOrEmpty(FindFilterText) Then
                Dim lastParserResults As FindSearchParserResults = (New FindSearchParser()).Parse(FindFilterText, GetFindToColumnsCollection())
                Dim findCriteria As CriteriaOperator = CustomCriteriaHelper.Create(lastParserResults, FilterCondition.Contains, IsServerMode)
                Return criteria And findCriteria
            End If
            Return criteria
        End Function
    End Class
End Namespace
