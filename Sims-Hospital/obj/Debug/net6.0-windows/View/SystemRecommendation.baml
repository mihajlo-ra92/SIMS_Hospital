   M S B A M L   `   `   `  ����H  DSims-Hospital, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Sims_Hospital.ViewSims_Hospital.View  5   	   -    'Sims_Hospital.View.SystemRecommendation   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Sims_Hospital.View     5   	     � Title$  SystemRecommendation��5   	   $	��450��6&   $	��800��63    � WindowStartupLocation$ CenterScreen=�6?   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       $��* �6   .+�5#   
   �� $��1��6   $��1��6"   $��2��62   $��Center=�6F   $��20(�6c   Preporuka sistema5%      �� 5'   
   -   5         ��Name$ 
logoutUser��5'      $��4��6%   $��0��65   $	��100��6B   .��6j   Odjava6r   �� 5)   
   $��2��6   $��1��6!   $��0 20 5 0q�61   Od kad zelite pregled6Z   (  "System.Windows.Controls.DatePicker  5+   
   -   5          Name$ datePickerStart��5+      $��2��6.   $��2��6;   $	��200��5,      $	��300��6$   $��0 20 5 0q�63   �� 5/   
   $��3��6   $��1��6!   $��0 20 5 0q�61   Do kad zelite pregled6Z     51   
   -   5        $ datePickerEnd��51      $��3��6,   $��2��69   $	��200��52      $	��300��6$   $��0 20 5 0q�63   �� 54   
   $��4��6   $��1��6!   $��0 20 5 0q�61   Lekar6J   �� 56   
   -   5         ��Name$ doctorComboBox��56      $��2��6+   $
��Left=�6;   $��4��6V   $	��120��6c   $��0 20 5 0q�57      ��6&   �� *doctorCollection+�� 59   
   $��5��6   $��1��6!   $��0 20 5 0q�61   	Prioritet6N   �� 5;   
   -   5        $ priorityComboBox��5;      $��2��6-   $
��Left=�6=   $��5��6X   $��0 20 5 0q�6e   $	��Top=�5<      $	��120��6+   $��22��6b   ��67   �� *PriorityCollection+6b   �� 5>   
   -   5        $ saveAppointmentButton��5>      $��1��60   $��2��6@   $��6��6T   $��20q�5?      $
��0 10q�6   .��6Z   
Predlozi6d   �� 5A   
   $��Bolnica "Zdravo"��6   $
��Left=�65   $��40,0,0,49.2q�6P   $��0��6f   $��0��6s   $��Center=�6�   $��26��6�   $��2��6�   $��98��6�   5D      5E      