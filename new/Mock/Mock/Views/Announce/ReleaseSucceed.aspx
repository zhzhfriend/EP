<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReleaseSucceed.aspx.cs" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Mock.Models.Entities" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <% AnnounceInfo announce = ViewData["Announce"] as AnnounceInfo; %>
    <div>
        <h1>MVC公告发布系统——发布公告成功</h1>
        <dl>
            <dt>ID：</dt>
            <dd><%= announce.ID %></dd>
            <dt>标题：</dt>
            <dd><%= announce.Title %></dd>
            <dt>类别ID：</dt>
            <dd><%= announce.Category %></dd>
            <dt>内容：</dt>
            <dd><%= announce.Content %></dd>
        </dl>
    </div>
</body>
</html>

