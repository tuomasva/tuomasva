Data = encoding.GetBytes(postParameter)
Dim request As Net.HttpWebRequest = Net.WebRequest.Create(postUrl) ' Login location taken from the form action

With request
    .KeepAlive = True
    .UserAgent = "Mozilla"
    .Method = "POST"
    .AllowAutoRedirect = True
    .ContentType = "application/x-www-form-urlencoded; charset=UTF-8"
    .UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.14; rv:65.0) Gecko/20100101 Firefox/65.0"
    .Headers.Add("X-Requested-With", "XMLHttpRequest")
    If csrfToken <> "" Then
        .Headers.Add("X-Csrf-Token", csrfToken)
    End If
    If xsrfToken <> "" Then
        .Headers.Add("X-xsrf-Token", xsrfToken)
    End If
    .ContentLength = Data.Length
    .CookieContainer = cookies
End With

Dim SendReq As IO.Stream = request.GetRequestStream
SendReq.Write(Data, 0, Data.Length)
SendReq.Close()
