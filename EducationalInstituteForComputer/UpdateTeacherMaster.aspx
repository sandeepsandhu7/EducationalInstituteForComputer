﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateTeacherMaster.aspx.cs" Inherits="EducationalInstituteForComputer.UpdateTeacherMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content" class="col-lg-10 col-sm-10">
        <!-- content starts -->
        <div>
            <ul class="breadcrumb">
                <li>
                    <a runat="server" href="~/">Home</a>
                </li>
                <li>
                    <a runat="server" href="~/CourseMaster">Edit Teachers</a>
                </li>
            </ul>
        </div>
        <div class="row">
            <div class="box col-md-12" style="left: 0px; top: 0px">
                <div class="box-inner">
                    <div class="box-header well" data-original-title="">
                        <h2><i class="glyphicon glyphicon-edit"></i>Form Elements</h2>

                        <div class="box-icon">
                            <a href="#" class="btn btn-minimize btn-round btn-default"><i
                                class="glyphicon glyphicon-chevron-up"></i></a>
                        </div>
                    </div>
                    <div class="box-content">
                        <div class="form-group">
                            <asp:DropDownList ID="ddl_Teacher" Style="text-align: center;" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_Teacher_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputName">Teacher Name<span style="color: red;">*</span></label>
                            <asp:TextBox ID="txtTeacherName" class="form-control" runat="server" placeholder="Teacher Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTeacherName" ValidationGroup="Save" runat="server" ControlToValidate="txtTeacherName" ErrorMessage="Please enter teacher name" ForeColor="#993333"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputName">Father Name<span style="color: red;">*</span></label>
                            <asp:TextBox ID="txtFatherName" class="form-control" runat="server" placeholder="Father Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFatherName" ValidationGroup="Save" runat="server" ControlToValidate="txtFatherName" ErrorMessage="Please enter father name" ForeColor="#993333"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputName">Address<span style="color: red;">*</span></label>
                            <asp:TextBox ID="txtAddress" class="form-control" runat="server" placeholder="Address"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" ValidationGroup="Save" runat="server" ControlToValidate="txtAddress" ErrorMessage="Please enter address" ForeColor="#993333"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputName">Email<span style="color: red;">*</span></label>
                            <asp:TextBox ID="txtEmail" class="form-control" runat="server" placeholder="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" ValidationGroup="Save" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter email" ForeColor="#993333"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputName">Mobile<span style="color: red;">*</span></label>
                            <asp:TextBox ID="txtMobile" class="form-control" runat="server" placeholder="Mobile"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorMobile" ValidationGroup="Save" runat="server" ControlToValidate="txtMobile" ErrorMessage="Please enter mobile no" ForeColor="#993333"></asp:RequiredFieldValidator>
                        </div>

                        <asp:Button ID="Submit" ValidationGroup="Save" runat="server" class="btn btn-success pull-right" Text="Update" OnClick="Submit_Click" />
                        <asp:Button ID="Delete" runat="server" class="btn btn-danger pull-right" Text="Delete" OnClick="Delete_Click" />
                    </div>
                </div>
                <!--/span-->

            </div>
        </div>
        <div class="row">
            <div class="box col-md-12">
                <div class="box-inner">
                    <div class="box-header well" data-original-title="">
                        <h2><i class="glyphicon glyphicon-user"></i>List </h2>

                        <div class="box-icon">
                            <a href="#" class="btn btn-minimize btn-round btn-default"><i
                                class="glyphicon glyphicon-chevron-up"></i></a>
                        </div>
                    </div>
                    <div class="box-content">
                        <div class="box-body">
                            <div id="datatable-responsive_wrapper" class="dataTables_wrapper form-inline dt-bootstrap no-footer">
                                <asp:GridView ID="grd" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" CaptionAlign="Top" AllowPaging="True"
                    EnableSortingAndPagingCallbacks="True" PageSize="5" HorizontalAlign="Left" AllowSorting="True">
                    <AlternatingRowStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Name" HeaderText="Teacher Name" />
                        <asp:BoundField DataField="FatherName" HeaderText="Father Name" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                    </Columns>
                    <EditRowStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <EmptyDataRowStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="Black" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <SortedAscendingCellStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <SortedAscendingHeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <SortedDescendingCellStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <SortedDescendingHeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--/span-->

        </div>
    </div>
</asp:Content>
