   M S B A M L   `   `   `  ����
  WpfApp    WpfApp.CustomerWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Thông tin khách hàng��5   	   $	��500��6&   $	��800��63   .��5      �� $��20q�6   .+�5   
   �� $��Thông tin cá nhân��6   $
��Bold"�6-   $��16(�6?   $��0,0,0,10q�6M   �� 5   
    �� Orientation$ 
Horizontal=�6   $��0,0,0,5q�6.   .+�5      �� $��Tên công ty: ��6   $
��Bold"�6-   $	��120��6?   �� 5	      ��6   �� *Customer.CompanyName+5
      �� 5   
   $ 
Horizontal=�6   $��0,0,0,5q�6.   .+�5      �� $��Tên liên hệ: ��6   $
��Bold"�6-   $	��120��6?   �� 5      ��6   �� *Customer.ContactName+5      �� 5   
   $ 
Horizontal=�6   $��0,0,0,5q�6.   .+�5      �� $��Chức vụ: ��6   $
��Bold"�6)   $	��120��6;   �� 5      ��6   �� *Customer.ContactTitle+5      �� 5   
   $ 
Horizontal=�6   $��0,0,0,5q�6.   .+�5      �� $��Địa chỉ: ��6   $
��Bold"�6)   $	��120��6;   �� 5      ��6   �� *Customer.Address+5      �� 5   
   $ 
Horizontal=�6   $��0,0,0,15q�6.   .+�5      �� $��Số điện thoại: ��6   $
��Bold"�6/   $	��120��6A   �� 5      ��6   �� *Customer.Phone+5      �� 5   
   -   5        $��Chỉnh sửa thông tin��5      $	��150��6/   $��0,0,0,20q�6;   6M   �� 5   
   $��Lịch sử đơn hàng��6   $
��Bold"�6,   $��16(�6>   $��	0,10,0,10q�6L   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	OrderGrid��5         AutoGenerateColumns$ False��5       $	��200��5!      $	��472��5"         SelectionMode$ Single=�5#         CanUserAddRows$ False��5$         CanUserDeleteRows$ False��5%         GridLinesVisibility$ 
Horizontal=�5&         HeadersVisibility$ Column=�5'      ��5      �� *Orders+	   Columns	 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn
   Header$
 	Mã đơn��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *	OrderID+6Q     5*      $
 Ngày đặt��6%   $	 150 6n    67   �� *	OrderDate+ �� StringFormat$ 
dd/MM/yyyy��6n     5+      $
 Nhân viên��6%   $	 100 6W    68   �� *
EmployeeID+6W   4  .System.Windows.Controls.DataGridTemplateColumn  5,      $
 Xem chi tiết��6)   $	 120 6?      CellTemplate 5-      �� 5.      .R�5/      �� -   5        $��Xem chi tiết��5/   %   $��2q�52   %   
 � Tag 51   %   �� *	OrderID+52   %   53      55      57      58      59      