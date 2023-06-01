<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Default.aspx.vb" Inherits="_Default" Title="Home" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4>
        &nbsp;</h4>
    <h4>
        Seja bem-vindo ao nosso site.<br />
    </h4>
    <p>
    
        <cc1:Accordion ID="MyAccordion" runat="Server" 
                AutoSize="Fill"
                Height="200"
                FadeTransitions="true" 
                TransitionDuration="250"
                FramesPerSecond="40" 
                RequireOpenedPane="false" 
                SuppressHeaderPostbacks="true"
                HeaderCssClass="accordionHeader" 
                ContentCssClass="accordionContent" 
                HeaderSelectedCssClass="accordionHeaderSelected">
            <Panes>
                <cc1:AccordionPane runat="server" ID="web01">
                    <Header>
                       <a href="">WEB01 - Fundamentos da Programação em ASP.NET 2.0</a>
                    </Header>
                    <Content>
                        O objetivo deste treinamento é ensinar os fundamentos do .NET Framework,
                        da linguagem de programação VB.NET e os recursos fundamentais do ASP.NET 2.0
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane runat="server" ID="web02" ContentCssClass="" HeaderCssClass="">
                    <Header>
                        <a href="">WEB02 - Acesso à Banco de Dados em ASP.NET 2.0</a>
                    </Header>
                    <Content>
                        O objetivo deste treinamento é ensinar as várias técnicas de acesso a dados com
                        o ASP.NET 2.0: DataSources, ADO.NET, DataSet Tipado com TableAdapters e Classes
                        de Negócio com Enterprise Library 3.1 - DAAB
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane runat="server" ID="web03" ContentCssClass="" HeaderCssClass="">
                    <Header>
                        <a href="">WEB03 - AJAX e Relatórios em ASP.NET 2.0</a>
                    </Header>
                    <Content>
                        O objetivo deste treinamento é ensinar a acrescentar alguns recursos importantes
                        em seus aplicativos ASP.NET 2.0 como utilizar a tecnologia AJAX, com AJAX Extensions
                        e AJAX Toolkit e a criar relatórios avançados usando o Report Viewer.
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane runat="server" ID="web04" ContentCssClass="" HeaderCssClass="">
                    <Header>
                        <a href="">WEB04 - Controle de Acesso em ASP.NET 2.0</a>
                    </Header>
                    <Content>
                        O objetivo deste treinamento é ensinar como criar um Controle de Acesso para seu
                        aplicativo ASP.NET 2.0 com níveis de permissão por usuário.
                    </Content>
                </cc1:AccordionPane>
            </Panes>
        </cc1:Accordion>
        
        &nbsp;</p>
        
         <cc1:TabContainer runat="server" ID="Tabs" 
            Height="150px" 
            ActiveTabIndex="0" 
            Width="402px" 
            ScrollBars="Vertical">
            
            <cc1:TabPanel runat="server" ID="aba1" HeaderText="Dados Residenciais">
                <ContentTemplate>
                   <table align="center">
                        <tr>
                            <td align="left">Nome</td>
                            <td align="left"><asp:TextBox ID="txtNome" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left">CPF</td>
                            <td align="left"><asp:TextBox ID="txtCPF" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left">E-mail</td>
                            <td align="left"><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                        </tr>
                    </table>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel runat="server" ID="aba2" HeaderText="Dados Comerciais">
                <ContentTemplate>
                   <table align="center">
                        <tr>
                            <td align="left">Empresa</td>
                            <td align="left"><asp:TextBox ID="txtEmpresa" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left">Cargo</td>
                            <td align="left"><asp:TextBox ID="txtCargo" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">Admissão</td>
                            <td align="left"><asp:TextBox ID="txtAdmissao" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left"></td>
                            <td align="left">&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left"></td>
                            <td align="left"><asp:Button ID="btnSalvar" runat="server" OnClick="btnSalvar_Click1" Text="Salvar" /></td>
                        </tr>
                    </table>
                </ContentTemplate>
            </cc1:TabPanel>
             <cc1:TabPanel runat="server" ID="aba3" HeaderText="Resumo">
                <ContentTemplate>
                   <table align="center">
                        <tr>
                            <td align="center"> <asp:Label ID="lblResumo" runat="server"></asp:Label></td>
                        </tr>
                            <tr>
                                <td align="center">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center"><asp:Button ID="btnLimpar" runat="server" OnClick="btnLimpar_Click" Text="Limpar" /></td>
                            </tr>
                    </table>
                </ContentTemplate>
            </cc1:TabPanel>   
        </cc1:TabContainer>
        
        
</asp:Content>
