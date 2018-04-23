Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace dxExample
    Public Class TestData
        Public Property Column1() As String
        Public Property Column2() As String

        Public Sub New()
            Column1 = String.Empty
            Column2 = String.Empty
        End Sub

        Public Sub New(ByVal col1 As String, ByVal col2 As String)
            Column1 = col1
            Column2 = col2
        End Sub
    End Class
End Namespace
