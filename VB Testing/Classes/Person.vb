Public Class Person

    Public Sub New()

        Name = "N/A"

    End Sub

    Public Sub New(inputName As String)
        Name = inputName
    End Sub

    Private _name As String
    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
            Console.WriteLine("Set Name = " + _name)
        End Set
    End Property

    Public Function ReturnName()

        Return _name

    End Function


End Class


Public Class Employee
    Inherits Person

    Public Sub New(inputName)

        MyBase.New(inputName)

    End Sub



End Class