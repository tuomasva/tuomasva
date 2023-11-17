Imports System.Text
Imports System.Net
Imports System.IO

' Your JSON data
Dim jsonData As String = "{""username"":""username@example.fi"",""password"":""password""}"
' Convert JSON data to a byte array
Dim byteArray As Byte() = Encoding.UTF8.GetBytes(jsonData)

' Create request
Dim request As Net.HttpWebRequest = Net.WebRequest.Create(postUrl) ' URL

With request
    .KeepAlive = True
    .UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.14; rv:65.0) Gecko/20100101 Firefox/65.0"
    .Method = "POST"
    .AllowAutoRedirect = True
    .ContentType = "application/json" ' Changed to application/json
    .Headers.Add("X-Requested-With", "XMLHttpRequest")
    If Not String.IsNullOrEmpty(csrfToken) Then
        .Headers.Add("X-Csrf-Token", csrfToken)
    End If
    If Not String.IsNullOrEmpty(xsrfToken) Then
        .Headers.Add("X-xsrf-Token", xsrfToken)
    End If
    .ContentLength = byteArray.Length
    .CookieContainer = cookies
End With

' Write data to request stream
Using sendReq As IO.Stream = request.GetRequestStream()
    sendReq.Write(byteArray, 0, byteArray.Length)
End Using
