   M S B A M L   `   `   `  ����G  COOD_Lab5_Ex2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:OOD_Lab5_Ex2OOD_Lab5_Ex2  5   	       OOD_Lab5_Ex2.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:OOD_Lab5_Ex2     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ShowGridLines .  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6     � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��3* �6   �� 5      $��1* �6   �� 5      $��3* �6   .+�5   
   �� -   5        $��LBXCustomers��5   +   $��1��6   $��10q�6   6?   �� 5   
   -   5        $��	LBXOrders��5   <   $��1��6   $��1��6    $��10q�60    �� SelectedValuePath$ SalesOrderID��6M   6n   &   System.Windows.Controls.DataGrid  5   
   -   5        $��DGOrderDetails��5   @   $��3��6   $��2��6    $��10q�64   6@   �� 5   
   $��	Customers��6   $��0��6$   $��0��61   �� 5   
   $��Order Summary��6   $��0��6(   $��1��65   �� 5   
   $��Order Details��6   $��2��6(   $��0��65   $��2��6E   5      5      