   M S B A M L   `   `   `  ����H  DSims-Hospital, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Sims_Hospital.ViewSims_Hospital.View  5   	   &     Sims_Hospital.View.MedicalRecord   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Sims_Hospital.View     5   	     � Title$  MedicalRecord��5   	   $	��450��6   $	��800��6,    � WindowStartupLocation$ CenterScreen=�68   .��5	      �  � RowDefinitions 5
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
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       $
��auto �6   �� 5!      $��* �6   .+�5&   
   �� $��1��6   $��2��6!   $��2��61   $
��0 10q�6E   $��Center=�6S   $��30(�6p   Zdravstveni karton5(      �� 5*   
   $��2��6   $��2��6!   $��0 20 5 0q�61   Umcn6J   �� 5,   
   -   5         ��Name$ umcnText��5,      $��2��6$   $��3��61   $	��200��5-      $	��300��6!   $��0 20 0 0q�60   �� 5/   
   $��3��6   $��2��6!   $��0 20 5 0q�61   Ime roditelja6S   �� 51   
   -   5        $ parentNameText��51      $��3��6*   $��3��67   $	��200��52      $	��300��6!   $��0 20 0 0q�60   �� 55   
   $��4��6   $��2��6!   $��0 20 5 0q�61   Krvna grupa6P   �� 57   
   -   5         ��Name$ bloodTypeComboBox��57      $��3��6.   $
��Left=�6>   $��0 20 0 0q�6Y   $��4��6k   $	��Top=�58      $	��120��6+   ��67   �� *BloodTypeCollection+�� 5;   
   $��6��6   $��2��6!   $��0 20 5 0q�61   
Alergeni6M   �� 5=   
   -   5         ��Name$ addAllergiesButton��5=      $��3��6-   $��6��6=   $��20q�6J   .��6w   Dodaj alergije6�   �� 5?   
   $��7��6   $��2��6!   $��0 20 5 0q�61   Adresa6K   �� 5A   
   -   5        $ addAddressButton��5A      $��3��6+   $��7��6;   $��20q�6H   .��6s   Dodaj Adresu6�   �� 5D   
   -   5        $ savePatientButton��5D      $��2��6,   $��2��6<   $��8��6P   $��20q�5E      $
��0 10q�6   .��6L   	Potvrdi6U   �� 5G   
   $��Bolnica "Zdravo"��6   $
��Left=�65   $��40, 0, 0, 0q�6P   $��0��6f   $��0��6s   $��Center=�6�   5H      5I      