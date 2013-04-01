<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Release.aspx.cs" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Mock.Models.Entities" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <% SelectList categories = ViewData["Categories"] as SelectList; %>
    <div>
        <h1>MVC公告发布系统——发布公告</h1>
        <% Html.BeginForm("DoRelease","Announce",FormMethod.Post); %>
        <dl>
            <dt>标题：</dt>
            <dd><%= Html.TextBox("Title") %></dd>
            <dt>分类：</dt>
            <dd><%= Html.DropDownList("Category",categories) %></dd>
            <dt>内容：</dt>
            <dd><%= Html.TextArea("Content") %></dd>
        </dl>
        <input type="submit" value="发布" />
        <% Html.EndForm(); %>
    </div>
</body>

   <body>
    <div>
        <dl>
            <legend>Account Information</legend>
          <% Html.BeginForm("DoRelease","Announce",FormMethod.Post); %>
            <dt>登录名</dt>
            <dt><%= Html.TextBox("Name") %></dt>
            <dt>密码</dt>
            <dt><%= Html.TextBox("Pwd")%></dt>
       
         </dl>
                <input type="submit" value="Log On" />
            </p>
            <% Html.EndForm(); %>
    </div>
</body>
</html>