   M S B A M L   `   `   `  ����H  DSims-Hospital, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Sims_Hospital.ViewSims_Hospital.View  5   	   /    )Sims_Hospital.View.AppointmentEditPatient   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Sims_Hospital.View     5   	     � Title$  AppointmentEditPatient��5   	   $	��450��6(   $	��800��65    � WindowStartupLocation$ CenterScreen=�6A   .��5	      � $
��Left=�6   $	��800��6&    � RowDefinitions 5
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
   �� $��1��6   $��1��6"   $��2��62   $��Center=�6F   $��20(�6c   Zakazivanje pregleda5%      �� 5'   
   -   5         ��Name$ 
logoutUser��5'      $��4��6%   $��0��65   $	��100��6B   .��6j   Odjava6r   �� 5)   
   $��2��6   $��1��6!   $��0 20 5 0q�61   Datum pregleda6T   (  "System.Windows.Controls.DatePicker  5+   
   -   5          Name$ 
datePicker��5+      $��2��6)   $��2��66   $	��200��5,      $	��300��6$   $��0 20 5 0q�63   �� 5/   
   $��3��6   $��1��6!   $��0 20 5 0q�61   Vreme pregleda6T   �� 51   
   -   5         ��Name$ timeTextHour��51      $��3��6(   $��2��65   $	��100��52      $	��100��6!   $��0,20,0,0q�60   $
��Left=�6B   $��95��6]   �� 54   
   -   5        $ timeTextMinutes��54      $��3��6+   $��2��68   $	��100��55      $	��100��6!   $��0 20 5 0q�60   $��Right=�6B   �� 57   
   $��4��6   $��1��6!   $��0 20 5 0q�61   Lekar6J   �� 59   
   -   5         ��Name$ doctorComboBox��59      $��2��6+   $
��Left=�6;   $��4��6V   $	��120��6c   $��0 20 5 0q�5:      ��6&   �� *doctorCollection+�� 5<   
   -   5        $ saveAppointmentEditButton��5<      $��1��64   $��2��6D   $��6��6X   $��20q�5=      $
��0 10q�6   .��6T   	Potvrdi6]   �� 5?   
   $��Bolnica "Zdravo"��6   $
��Left=�65   $��40,0,0,49.2q�6P   $��0��6f   $��0��6s   $��Center=�6�   $��26��6�   $��2��6�   $��98��6�   5B      5C      