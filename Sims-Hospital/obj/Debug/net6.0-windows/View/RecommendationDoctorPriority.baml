   M S B A M L   `   `   `  ����H  DSims-Hospital, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Sims_Hospital.ViewSims_Hospital.View  5   	   5    /Sims_Hospital.View.RecommendationDoctorPriority   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Sims_Hospital.View     5   	     � Title$"  RecommendationDoctorPriority��5   	   $	��300��6.   $	��600��6;    � WindowStartupLocation$ CenterScreen=�6G   .��5	      �  � RowDefinitions 5
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
   -   5         ��Name$ 
logoutUser��5      $��4��6%   $��0��65   $	��100��6B   .��6j   Odjava6r   �� 5   
   -   5        $��stack1��5      $	��200��6#   $	��200��6/   .+�5      �  5       �� 5!      $��2* �6$   62   �� 5"      $��* �6$   61   .+�5$      �� .��5%      �� -   5         ��Name$ appointmentList��5%      $��6��67   $��1��6D   $��2��6T   $	��200��6h   $	��200��6u   $��0 10 0 0q�6�   ��5&      �� 5'      .R�5(   "   ��  �� Orientation$ Vertical=�6-   .+�5)   &   �� ��60   ��  �� Path$ 	StartTime�5*   #   5+      5-      5.      5/      50      51      52      