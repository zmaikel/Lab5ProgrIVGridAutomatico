<%@ Page Title="Lab5" Language="C#" MasterPageFile="~/MasterPageLab5.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Lab5_6_PrograIV_MaikelZamora.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cuerpoHTML" runat="server">
    
    <div>
    <asp:GridView id="gridCarro"
        runat="server"          
        BackColor="White" 
        BorderColor="#CCCCCC" 
        BorderStyle="None" 
        BorderWidth="1px" 
        CellPadding="3"
        DatakeyNames="IdCarro"
        OnRowCommand="gridCarro_RowCommand"
        OnRowEditing="gridCarro_RowEditing"
        OnRowCancelingEdit ="gridCarro_RowCancelingEdit"
        OnRowUpdating = "gridCarro_RowUpdating"
        OnRowDeleting ="gridCarro_RowDeleting"
        ShowHeaderWhenEmpty ="false"
        AutoGenerateColumns="false"
        ShowFooter="true">

        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />

        <Columns>
            <asp:TemplateField HeaderText="Marca">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Marca")  %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtMarca" Text='<%# Eval("Marca")  %>' runat="server"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtMarcaPie" Text='<%# Eval("Marca")  %>' runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Modelo">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Modelo")  %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtModelo" Text='<%# Eval("Modelo")  %>' runat="server"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtModeloPie" Text='<%# Eval("Modelo")  %>' runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="País">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Pais")  %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPais" Text='<%# Eval("Pais")  %>' runat="server"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtPaisPie" Text='<%# Eval("Pais")  %>' runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Costo">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Costo")  %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCosto" Text='<%# Eval("Costo")  %>' runat="server"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtCostoPie" Text='<%# Eval("Costo")  %>' runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ImageUrl="~/Imagenes/editar.png" runat="server" CommandName="Edit" ToolTip="Editar" Width="20px" Height="20px" />
                    <asp:ImageButton ImageUrl="~/Imagenes/eliminar.png" runat="server" CommandName="Delete" ToolTip="Borrar" Width="20px" Height="20px" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ImageUrl="~/Imagenes/guardar.png" runat="server" CommandName="Update" ToolTip="Guardar" Width="20px" Height="20px" />
                    <asp:ImageButton ImageUrl="~/Imagenes/cancelar.png"   runat="server" CommandName="Delete" ToolTip="Cancelar" Width="20px" Height="20px" />                           
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:ImageButton ImageUrl="~/Imagenes/nuevo.png"   runat="server" CommandName="AddNew" ToolTip="Nuevo" Width="20px" Height="20px" />                           
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
            <br/>
            <br/>
            <asp:Label runat="server" ID="lblExito" ForeColor="Green"></asp:Label>
            <asp:Label runat="server" ID="lblError" ForeColor="Red"></asp:Label>
        </div>
</asp:Content>
