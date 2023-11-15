<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Registracion.aspx.cs" Inherits="parcial2.Registracion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="Username"></asp:TextBox>    
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Debe completar el campo Username" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
    
    <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="Email"></asp:TextBox>    
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Debe completar el campo Email" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Debe ingresar un email válido" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" Display="None"></asp:RegularExpressionValidator>
    
    <asp:TextBox class="form-control" ID="TextBox3" runat="server" placeholder="Edad" TextMode="Number"></asp:TextBox>    
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Debe completar el campo de Edad" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="La edad debe ser mayor a 15 y menor a 99 años" MinimumValue="15" MaximumValue="99" ForeColor="Red" ControlToValidate="TextBox3" Type="Integer" Display="None"></asp:RangeValidator>
    
    <asp:TextBox class="form-control" ID="TextBox4" runat="server" placeholder="Contraseña" TextMode="Password"></asp:TextBox>    
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="Debe ingresar una contraseña" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
    
    <asp:TextBox class="form-control" ID="TextBox5" runat="server" placeholder="Repita Contraseña" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5" ErrorMessage="Debe ingresar de nuevo la contraseña" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="La contraseña no coincide" ControlToCompare="TextBox4" ControlToValidate="TextBox5" ForeColor="Red" Display="None"></asp:CompareValidator>
    
    <asp:ValidationSummary ID="ValidationSummary1" runat="server"  ForeColor="Red"/>
    <asp:Button class="btn btn-outline-light" ID="Button1" runat="server" Text="Registrar" Font-Bold="True" Font-Size="18px" BorderWidth="3px" OnClick="Button1_Click" />

</asp:Content>
