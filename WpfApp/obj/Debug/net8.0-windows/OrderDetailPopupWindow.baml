   M S B A M L   `   `   `  ����
  WpfApp#    WpfApp.OrderDetailPopupWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Chi tiết đơn hàng��5   	   $	��400��6#   $	��650��60    � WindowStartupLocation$ CenterOwner=�6<   .��5      �� $��15q�6   .+�5      �� $��Chi tiết sản phẩm��6   $
��Bold"�6'   $��16(�69   $��0,0,0,15q�6G   &   System.Windows.Controls.DataGrid  5      -   5          Name$ OrderDetailGrid��5         AutoGenerateColumns$ False��5      $	��280��5	         
IsReadOnly$
 True��5
         CanUserAddRows$ False��5         CanUserDeleteRows$ False��5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã SP��6   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 80 6F   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6(   �� *	ProductID+6F     5      $ Tên sản phẩm��6   $		 200 6O   
 6/   �� *ProductName+6O     5      $ 
Đơn giá��6   $		 100 6X   
 6*   �� *	UnitPrice+ �� StringFormat$ C��6X     5      $ Số lượng��6   $	 80 6H   
 6+   �� *
Quantity+6H     5      $ Giảm giá��6   $	 80 6X   
 6+   �� *
Discount+$ P��6X     5      $ Thành tiền��6   $		 120 6W   
 6-   �� *Total+$ C��6W   5      �� 5      -   5        $��Đóng��5      $��80��6   $��0,15,0,0q�6%   $��Right=�67   6S   5      5      