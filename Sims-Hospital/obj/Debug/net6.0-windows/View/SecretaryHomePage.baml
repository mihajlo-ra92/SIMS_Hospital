   M S B A M L   `   `   `  ����H  DSims-Hospital, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Sims_Hospital.ViewSims_Hospital.View  5   	   *    $Sims_Hospital.View.SecretaryHomePage   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Sims_Hospital.View     5   	     � Title$  SecretaryHomePage��5   	   $	��500��6#   $	��800��60    � WindowStartupLocation$ CenterScreen=�6<   .��5	      �  � RowDefinitions 5
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
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��Bolnica "Zdravo"��6   $��Center=�65   $��
0, 0, 0, 0q�6R   $��0��6g   $��1��6t   $��Center=�6�   �� 5   
   -   5         ��Name$ 
logoutUser��5      $��4��6%   $��0��65   $	��100��6B   .��6j   Odjava6r   �� 5!   
   -   5        $ 
addPatient��5!      $��20q�6%   $��3��61   $��1��6>   $	��200��6g   .��6v   Registracija pacijenta6�   �� 5#   
   -   5        $ editPatient��5#      $��20q�6&   $��4��62   $��1��6?   $	��200��6O   .��6x   Izmena pacijenta6�   �� 5%   
   -   5        $ deletePatient��5%      $��20q�6(   $��5��64   $��1��6A   $��Center=�6Q   $	��200��6l   .��6�   Brisanje pacijenta6�   �� 5'   
   -   5        $ editAllergies��5'      $��20q�6(   $��6��64   $��1��6A   $��Center=�6Q   $	��200��6l   .��6�   Alergije pacijenta6�   �� 5)   
   -   5        $ editAppointments��5)      $��20q�6+   $��7��67   $��1��6D   $��Center=�6T   $	��200��6o   .��6�   Termini pacijenta6�   �� 5+   
   -   5         ��Name$ patientsList��5+      $��8��6(   $��1��65   $��0 10 0 0q�6E   $	��300��6W   $	��100��6f   ��5,      �� 5-      .R�5.      ��  �� Orientation$ Vertical=�6!   .+�5/      �� ��6$   ��  �� Path$
 Name��� 50      ��6$   �� $ LastName�51      52      54      56      57      