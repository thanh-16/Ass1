   M S B A M L   `   `   `  ����
  WpfApp%    WpfApp.CustomerManagementWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Quản lý khách hàng��5   	   $	��600��6$   $	��900��61    � WindowStartupLocation$ CenterScreen=�6=   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $��* �6   .+�5   
   �� $��0��6   $��Quản lý khách hàng��6!   $��18(�6;   $
��Bold"�6I   $��0,0,0,20q�6[   � 5   
   $��1��6   $��0,0,0,20q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� -   5         ��Name$ 	SearchBox��5   &   $��0��6   $��0,0,10,0q�5      $��5q�6(   $��Center=�5      $��14(�5      5      �� 5      -   5        $��1��5      $��Thêm mới��6%   $��0,0,10,0q�5      $
��15,8q�6'   �� 5      -   5        $��2��5      $��Sửa��6%   $��0,0,10,0q�5       $
��15,8q�6'   �� 5!      -   5        $��3��5!      $
��Xóa��6%   $
��15,8q�5"      5#      &   System.Windows.Controls.DataGrid  5%   
   -   5          Name$ CustomerGrid��5%       $��2��6      AutoGenerateColumns$ False��5&         SelectionMode$ Single=�5'         CanUserAddRows$ False��5(      	   CanUserDeleteRows$	 False��5)      
   GridLinesVisibility$
 
Horizontal=�5*         HeadersVisibility$ Column=�5+         Columns 5,      0  *System.Windows.Controls.DataGridTextColumn  5-      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6P      
IsReadOnly$
 True��6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
CustomerID+6[     5.      $ Tên công ty��6%   $	 200 6Z    6:   �� *CompanyName+6Z     5/      $ Người liên hệ��6%   $	 150 6\    6<   �� *ContactName+6\     50      $ Chức vụ��6%   $	 120 6W    66   �� *ContactTitle+6W     51      $ Địa chỉ��6%   $	 250 6R    66   �� *	Address+6R     52      $ Số điện thoại��6%   $	 120 6V    6<   �� *Phone+6V   54      55      56      