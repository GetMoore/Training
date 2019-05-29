Module Module1

    Sub Main()

        'RunModuleTwo()
        RunModuleThree()
        Console.ReadLine()



    End Sub

    Sub DisplayArrayValues(array() As Integer)
        Console.WriteLine("Printing out the arry of " + array.Length.ToString + " items")
        For Each item In array
            Console.WriteLine(item)
        Next

    End Sub

    Sub PrintPersons(List As List(Of Person))

        For index = 0 To List.Count - 1
            Console.WriteLine(index.ToString + ": " + List(0).ReturnName)
        Next

        'For Each person In List
        '    Console.WriteLine(person.ReturnName())
        'Next

    End Sub

    Sub RunModuleTwo()

        Dim test = 1

        If test = 1 Or test = 2 Then
            Console.WriteLine("Yeah")
        ElseIf test = 2 Or test = 3 Then
            Console.WriteLine("No")
        End If

        Select Case test
            Case Is = 1
                Console.WriteLine("Test is 1")
            Case Is = 2
                Console.WriteLine("Test is 2")
        End Select

        Dim arrayTest() = {1, 2, 3, 4, 5}

        For Each arrayItem In arrayTest
            Console.WriteLine(arrayItem)
        Next

        For index = 0 To arrayTest.Length - 1
            Console.WriteLine(arrayTest(index))
        Next

        Try

            DisplayArrayValues(arrayTest)
            Throw New Exception("yeah it's fucked")

        Catch ex As Exception

            Console.WriteLine("yo you failed fam: " + ex?.Message)

        End Try

    End Sub

    Sub RunModuleThree()
        Dim persons As New List(Of Person)

        Dim person = New Person

        PrintPersons(persons)
        'person.Name = "Jonathan"

        persons.Add(person)

        persons.Add(New Person() With {.Name = "Robert"})

        persons.Add(New Employee("Debbie"))

        PrintPersons(persons)
    End Sub

End Module
