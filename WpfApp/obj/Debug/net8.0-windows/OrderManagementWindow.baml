   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	   "    WpfApp.OrderManagementWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	     � Title$  Quản lý đơn hàng��5   	   $	��600��6"   $
��1000��6/    � WindowStartupLocation$ CenterScreen=�6<   .��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��Quản lý đơn hàng��6!   $��18(�69   $
��Bold"�6G   $��0,0,0,20q�6Y   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��0,0,0,20q�6;   .+�5      �� -   5        $��Tạo đơn hàng mới��5      $��0,0,10,0q�6H   $
��15,8q�6Z   �� 5      -   5        $��Xem chi tiết��5      $��0,0,10,0q�6F   $
��15,8q�6X   �� 5      -   5        $��Xóa đơn hàng��5      $
��15,8q�6A   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	OrderGrid��5       $��2��6      AutoGenerateColumns$ False��5         SelectionMode$ Single=�5         CanUserAddRows$ False��5         CanUserDeleteRows$ False��5      	   GridLinesVisibility$	 
Horizontal=�5      
   HeadersVisibility$
 Column=�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$ 	Mã đơn��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *	OrderID+6Q     5!      $ Ngày đặt��6%   $	 120 6n    67   �� *	OrderDate+ �� StringFormat$ 
dd/MM/yyyy��6n     5"      $ Khách hàng��6%   $	 200 6Z    69   �� *CustomerName+6Z     5#      $ Nhân viên��6%   $	 150 6Y    68   �� *EmployeeName+6Y     5$      $ Tổng tiền��6%   $	 120 6m    68   �� *Total+$ {0:N0} VNĐ��6m   5&      5'      5(      