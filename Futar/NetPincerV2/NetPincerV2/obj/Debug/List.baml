   M S B A M L   `   `   `  ����F  BNetPincerV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:NetPincerV2NetPincerV2  5   	       NetPincerV2.List   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:NetPincerV2     5   	     � Title$
  List��5   	   $	��650��6   $
��1000��6#   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��30* �6   �� 5      $
��300* �6   �� 5      $	��30* �6    � RowDefinitions 5   
   �� 5      $��6* �6   �� 5      $	��30* �6   .+�5   
   �� 
���   �6+   �� 5   
   $��3��6   
���   �6;   �� 5   
   
�������$��1��6'   .+�5      �� $��0,25,0,0q�6   $��Center=�6&   $��Rendelések��6C   $��25(�6X   $��1��6g   6z   5      �� 5   
   $��1��6   $��3��6"   ��5      �� 5       �� ImageSource$ background.jpg��6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ rendeles��5      $	��650��6)   $	��223��65   $��
89,30,89,0q�6B   6�   �� 5       -   5        $��289,40,289,0q�5       $��18(�6+   $	��250��69   $��40��6E   $��Leadás��6Q   6b   �� 5!      -   5        $��289,20,289,0q�5!      $��18(�6+   $	��250��69   $��40��6E   $��Étel kiszállítva��6Q   6l   5"      �� 5#   
   -   5        $��18(�5#      $	��250��6    $��40��6,   $��Vissza��68   $��1��6I   $��	0,350,0,0q�6Y   $��1��6l   6y   5&      5'      