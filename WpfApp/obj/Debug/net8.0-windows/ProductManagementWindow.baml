   M S B A M L   `   `   `  ����
  WpfApp$    WpfApp.ProductManagementWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Quản lý sản phẩm��5   	   $	��600��6"   $
��1000��6/    � WindowStartupLocation$ CenterScreen=�6<   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $��* �6   .+�5   
   �� $��0��6   $��Quản lý sản phẩm��6!   $��18(�69   $
��Bold"�6G   $��0,0,0,20q�6Y   � 5   
   $��1��6   $��0,0,0,20q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� -   5         ��Name$ 	SearchBox��5   &   $��0��6   $��0,0,10,0q�5      $��5q�6(   $��Center=�5      $��14(�5      5      �� 5      -   5        $��1��5      $��Thêm mới��6%   $��0,0,10,0q�5      $
��15,8q�6'   �� 5      -   5        $��2��5      $��Sửa��6%   $��0,0,10,0q�5      $
��15,8q�6'   �� 5       -   5        $��3��5       $
��Xóa��6%   $
��15,8q�5!      5"      &   System.Windows.Controls.DataGrid  5$   
   -   5          Name$ ProductGrid��5$       $��2��6      AutoGenerateColumns$ False��5%         SelectionMode$ Single=�5&         CanUserAddRows$ False��5'      	   CanUserDeleteRows$	 False��5(      
   GridLinesVisibility$
 
Horizontal=�5)         HeadersVisibility$ Column=�5*         Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6O      
IsReadOnly$
 True��6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	ProductID+6Z     5-      $ Tên sản phẩm��6%   $	 200 6[    6;   �� *ProductName+6[     5.      $ 
Danh mục��6%   $	 100 6V    67   �� *
CategoryID+6V     5/      $ 	Giá bán��6%   $	 120 6o    66   �� *	UnitPrice+ �� StringFormat$ {0:N0} VNĐ��6o     50      $ 	Tồn kho��6%   $	 100 6W    66   �� *UnitsInStock+6W     51      $ Mô tả��6%   $	 300 6T    64   �� *Description+6T   53      54      55      