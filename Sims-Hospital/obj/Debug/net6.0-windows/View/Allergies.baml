   M S B A M L   `   `   `  ����H  DSims-Hospital, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Sims_Hospital.ViewSims_Hospital.View  5   	   "    Sims_Hospital.View.Allergies   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Sims_Hospital.View     5   	   -   5          � Title$  	Allergies��5   	   $	��450��6   $	��800��6(    � WindowStartupLocation$ CenterScreen=�64   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��1��6.   $��0��6>   $��	0 20 0 10q�6K   .+�5      �� $��0 0 5 0q�6   	Alergija:64   �� 5      -   5         ��Name$ allergieText��5      $	��200��6,   $	��300��6;    �� TextWrapping$
 Wrap=�6J   5      �� 5   
   -   5         ��Name$ addAllergie��5      $��1��6&   $��1��63   $	��0 5q�6C   .��5   +   Dodaj alergiju6;   �� 5    
   -   5        $ deleteAllergie��5       $��2��6)   $��1��66   $	��0 5q�6F   $��0 20 0 0q�6T   .��5!   .   Obrisi alergiju6?   �� 5#   
   -   5         ��Name$ allergiesList��5#      $��3��6)   $��1��66   $��0 20 0 0q�6F   ��5$      �� 5%      .R�5&      �� ��6    �� 5'      5)      �� 5+   
   -   5        $ addMedicine��5+      $��4��6&   $��1��63   $	��0 5q�6C   $��0 20 0 0q�6Q   .��6}   Alergije na lek6�   5-      5.      