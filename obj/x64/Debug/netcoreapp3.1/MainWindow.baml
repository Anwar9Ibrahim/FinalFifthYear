   M S B A M L   `   `   `  ����I  EFinalFifthYear, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:FinalFifthYearFinalFifthYear  5          FinalFifthYear.MainWindow   5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5
      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .localclr-namespace:FinalFifthYear     5         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5	       � Title$ Traffic Monitor��5      $	��600��6   $
��1024��6+   $��
2147483639��69    � WindowStartupLocation$ CenterScreen=�6O    � WindowStyle$
 None=�6t    � 
ResizeMode$ NoResize=�6�   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��31* �6   �� 5      $	��97* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $	��97* �6   .+�5   
   � $��2��6   ���	#FF203457.+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5      �� -   5        	 ��Name$	 BMinus��5       0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6)   $��25��6o   $��25��6z   
���������6�   Z� ��6�   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 Minus=�6.   5      �� 5       -   5        $	 BPower��5       #��[ 6)   $��25��6o   $��25��6z   
���������6�   Z� ��6�   Z� .��5!        $
 Power=�6.   5"      5#      5$      � 5&   
   $��1��6   $��4��6   ��5'      �� 5(       �� EndPoint$	 5,5&�6&   .��5)      �  � Color$ 	#ffc5c5c5��6#    � Offset$	 0.2Q�65   � 5*      $ 	#FFFBFBFB��6#   5+       5-      �� 5.      $	��100 �6    �� 5/      $��* �6    .+�5<      � ���	#FF3B60A2.+�5=      �� $��Car Counter��6   $��Center=�6/   $��Center=�6L   $��Vivaldi)�6g   $��48(�6|   $��Normal"�6�   $��Italic$�6�   ���	#FF84A9EA6�   5>      �� 5?      $��1��6   .+�5@      �� -   5        $��15q�5@      ���	#FF203457���	#FF203457.��5A      � $	��150��6   .+�5B        $
��Left=�62   $
 Search=�6M   �� 5C      $��Right=�6$   $��Center=�6@   Select Input Video6o   5D      5E      �� 5F      -   5        $��15q�5F      ���	#FF203457���	#FF203457.��5G      � $	��150��6   .+�5H        $
��Left=�62   $
 Target=�6M   �� 5I      $��Right=�6$   $��Center=�6@   Start Detections6m   5K      5L      �� 5M      -   5        $��CurrVehicles��5M      $��15q�6/   ���	#FF203457���	#FF203457.��5N      � $	��150��6   .+�5O        $
��Left=�62   $	
 Cab=�6M   �� 5P      $��Right=�6$   $��Center=�6@   detected Vehicles6n   5R      5S      �� 5T      -   5        $��BDatabaseVehicles��5T      $��15q�62   ���	#FF203457���	#FF203457.��5U      � $	��150��6   .+�5V        $
 Database=�62   �� 5W      $��Right=�6$   $��Center=�6@   All database Vehicles6r   5Y      5Z      �� 5[      -   5        $��15q�5[      ���	#FF203457���	#FF203457.��5\      � $	��150��6   .+�5]        $
 DatabaseAdd=�62   �� 5^      $��Right=�6$   $��Center=�6@   Add to DataBase6l   5`      5a      5m      5o      r� 5q   
   -   5         r�Name$ avPlayer��5q   Y   $��1��6   $��1��6'   $��3��64   $��2��6E    r� Stretch$
 Fill=�6k   #  MaterialDesignThemes.Wpf.Card  5}   
   -	   5          Name$ Lpath��5}      $��10q�6-   $��1��69   $��1��6I   .��5~      ��    MaterialDesignTitleTextBlock#���  6   $��Oblique$�6Q   $
��Bold"�6e   $��15(�6w   $��Center=�6�   $��Center=�6�   No video is selected yet6�   5      &   System.Windows.Controls.DataGrid  5�   
   -
   5        $��DGVehiclesFromDB��5�         AutoGenerateColumns$
 True��6+      EnableRowVirtualization$
 True��6F   $��1��6�   $��1��6�   $y�Hidden=�6�   ��6f   �� *
dTVehicles+   Columns 5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ Image��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 68      
IsReadOnly$
 True��6M      CellTemplate 5�      �� 5�      .R�5�      �� ��6$   �� *Image+5�      5�      5�      5�      5�      