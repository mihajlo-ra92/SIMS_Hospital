   M S B A M L   `   `   `  ����H  DSims-Hospital, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Sims_Hospital.ViewSims_Hospital.View  5   	   )    #Sims_Hospital.View.DirectorHomePage   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Sims_Hospital.View     5   	     � Title$  DirectorHomePage��5   	   $	��450��6"   $	��800��6/    � WindowStartupLocation$ CenterScreen=�6;   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��Bolnica "Zdravo"��6   $��Center=�65   $��
0, 0, 0, 0q�6R   $��0��6g   $��1��6t   $��Center=�6�   �� 5   
   -   5         ��Name$ addRoom��5      $��0, 30, 0, 0q�6"   $��3��67   $��1��6D   .��6T   Kreiranje prostorije6j   �� 5   
   -   5        $ editRoom��5      $��0, 10, 0, 0q�6#   $��4��68   $��1��6E   .��6U   Izmena prostorije6h   �� 5!   
   -   5        $ 
deleteRoom��5!      $��0, 10, 0, 0q�6%   $��5��6:   $��1��6G   .��6W   Brisanje prostorije6l   �� 5#   
   -   5         ��Name$ ListOfRooms��5#      $��6��6'   $��1��64   $��2��6D   $��0 10 0 0q�6X   ��5$      �� 5%      .R�5&      ��  �� Orientation$ Vertical=�6!   .+�5'      �� ��6$   ��  �� Path$ RoomName��� 5(      ��6$   �� $ RoomType��� 5)      ��6$   �� $ 	RoomFloor�5*      5+      5-      5/      50      