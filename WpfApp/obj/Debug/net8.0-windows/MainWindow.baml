   M S B A M L   `   `   `  ����
  WpfApp    WpfApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Order Details��5   	   $	��450��6   $	��800��6,   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5
   
   ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�6.   .+�5      �� -   5         ��Name$ 
OrderIdBox��5      $��60��6*   $��0,0,5,0q�65    � ToolTip$ OrderID��6F   �� 5      -   5        $ ProductIdBox��5      $��60��6,   $��0,0,5,0q�67   $ 	ProductID��6H   �� 5      -   5        $ UnitPriceBox��5      $��80��6,   $��0,0,5,0q�67   $ 	UnitPrice��6H   �� 5      -   5        $ QuantityBox��5      $��60��6+   $��0,0,5,0q�66   $ Quantity��6G   �� 5      -   5        $ DiscountBox��5      $��60��6+   $��0,0,5,0q�66   $ Discount��6G   �� 5      -   5        $	��Add��5      $��60��6#   6.   �� 5      -   5        $��Delete��5      $��60��6&   $��5,0,0,0q�61   6B   �� 5      -   5        $��Update��5      $��60��6&   $��5,0,0,0q�61   6B   5      &   System.Windows.Controls.DataGrid  5   
   -	   5          Name$ OrderDetailGrid��5      $��1��5         AutoGenerateColumns$
 True��5         
IsReadOnly$
 True��5         SelectionMode$ Single=�5      ��5      �� *OrderDetails+5      5      5      