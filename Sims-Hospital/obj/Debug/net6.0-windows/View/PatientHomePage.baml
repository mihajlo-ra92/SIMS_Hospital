   M S B A M L   `   `   `  ����H  DSims-Hospital, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Sims_Hospital.ViewSims_Hospital.View  5   	   (    "Sims_Hospital.View.PatientHomePage   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Sims_Hospital.View     5   	   -   5          � Title$  PatientHomePage��5	   	   $	��450��6!   $	��800��6.    � WindowStartupLocation$ CenterScreen=�6:   .��5
      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��Bolnica "Zdravo"��6   $��Center=�65   $��
0, 0, 0, 0q�6R   $��0��6g   $��1��6t   $��Center=�6�   �� 5   
   -   5         ��Name$ 
logoutUser��5      $��4��6%   $��0��65   $	��100��6B   .��6j   Odjava6r   �� 5!   
   -   5        $ addAppointmentPatient��5!      $��0, 30, 0, 0q�60   $��3��6E   $��1��6R   .��6�   Zakazivanje pregleda6�   �� 5#   
   -   5        $ RecommendationOfSystem��5#      $��0, 30, 0, 0q�61   $��3��6F   $��2��6S   .��6�   Preporuka sistema6�   �� 5%   
   -   5        $ editAppointmentPatient��5%      $��0, 10, 0, 0q�61   $��4��6F   $��1��6S   .��6�   Izmena pregleda6�   �� 5'   
   -   5        $ evaluateHospital��5'      $��0, 10, 0, 0q�6+   $��4��6@   $��2��6M   .��6|   Oceni bolnicu6�   �� 5)   
   -   5        $ deleteAppointmentPatient��5)      $��0, 10, 0, 0q�63   $��5��6H   $��1��6U   .��6�   Brisanje pregleda6�   �� 5+   
   -   5        $ EvaluateAppointment��5+      $��0, 10, 0, 0q�6.   $��5��6C   $��2��6P   .��6�   Oceni pregled6�   �� 5-   
   -	   5         ��Name$ appointmentList��5-      $��6��6D   $��1��6Q   $��2��6a   $��0 10 0 0q�6u   ��6+   �� ��5.      �� 5/      .R�50      ��  �� Orientation$ Vertical=�6!   .+�51      �� ��6$   ��  �� Path$ 	StartTime��� 52      ��6$   �� $ Doctor.NameLastName�53      54      56      58      59      