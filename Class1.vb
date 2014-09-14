'
'      ===  RedditSmartie LCDSmatie Plugin by Marice Lamain (2014)  ===
'
'

Imports System.Net
Imports System.IO
Imports System.Linq
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq



' There must be a public Class that's named LCDSmartie
Public Class LCDSmartie

    'gets users link karma
    Public Function function1(ByVal param1 As String, ByVal param2 As String) As String

        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim henk As String = 0
        Dim URL As String = "https://www.reddit.com/user/" + param1 + "/about/.json"
        Try

            request = DirectCast(WebRequest.Create(URL), HttpWebRequest)
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            reader = New StreamReader(response.GetResponseStream())

            Dim rawresp As String
            rawresp = reader.ReadToEnd()

            Dim jResults As JObject = JObject.Parse(rawresp)
            Dim results As Generic.List(Of JToken) = jResults.Children().ToList()

            For Each item As JProperty In results
                Select Case item.Name

                    Case "data"
                        If item.Name = "data" Then
                            henk = item.Value("link_karma")
                        End If
                End Select
            Next

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            If Not response Is Nothing Then response.Close()
        End Try
        Return henk.ToString()
    End Function






    'get comment karma from user
    Public Function function2(ByVal param1 As String, ByVal param2 As String) As String

        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim henk As String = 0
        Dim URL As String = "https://www.reddit.com/user/" + param1 + "/about/.json"
        Try

            request = DirectCast(WebRequest.Create(URL), HttpWebRequest)
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            reader = New StreamReader(response.GetResponseStream())

            Dim rawresp As String
            rawresp = reader.ReadToEnd()

            Dim jResults As JObject = JObject.Parse(rawresp)
            Dim results As Generic.List(Of JToken) = jResults.Children().ToList()

            For Each item As JProperty In results
                Select Case item.Name

                    Case "data"
                        If item.Name = "data" Then
                            henk = item.Value("comment_karma")
                        End If
                End Select
            Next

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            If Not response Is Nothing Then response.Close()
        End Try
        Return henk.ToString()
    End Function




    'refresh data rate
    Public Function GetMinRefreshInterval() As Integer

        Return 300002 '  (5min interval for refresh of data)

    End Function


End Class

