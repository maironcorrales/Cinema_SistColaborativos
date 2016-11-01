<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginWithGoogle1.aspx.cs" Inherits="CinemaColaborativos.LoginWithGoogle1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>
        <script type="text/javascript" language=javascript>
            try {
                // First, parse the query string
                var params = {}, queryString = location.hash.substring(1),
    regex = /([^&=]+)=([^&]*)/g, m;
                while (m = regex.exec(queryString)) {
                    params[decodeURIComponent(m[1])] = decodeURIComponent(m[2]);
                }
                var ss = queryString.split("&")
          
                window.location = "Login.aspx?" + ss[1];
                

            } catch (exp) {
                alert(exp.message + " here 1");
            }
        </script>
    </div>
    </div>
    </form>
</body>
</html>
