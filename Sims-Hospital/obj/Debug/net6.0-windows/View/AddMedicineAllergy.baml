   M S B A M L   `   `   `  ����H  DSims-Hospital, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Sims_Hospital.ViewSims_Hospital.View  5   	   +    %Sims_Hospital.View.AddMedicineAllergy   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Sims_Hospital.View     5   	     � Title$  AddMedicineAllergy��5   	   $	��450��6$   $	��800��61    � WindowStartupLocation$ CenterScreen=�6=   .��5	      �  � RowDefinitions 5
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
��auto �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridMedicines��5   0   $��0��6   $��1��6       
IsReadOnly$
 True��6{      SelectionMode$ Single=�5         AutoGenerateColumns$ False��6*   $
��Left=�6F   $	��Top=�5      ��5   K   ��  �� Path$ RemainingMedicines�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Sifra��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Code+  5       $
 Naziv��6%    64   �� *Name+5"      �� 5#   
   $��3��6   $��1��6   $��0 20 0 0q�6-   .��6?   
Alergije6I     5%   
   -   5        $ dataGridAddedMedicines��5%   0   $��4��6   $��1��6    $
 True��6|   $ Single=�5&      $ False��6*   $
��Left=�6F   $	��Top=�5'      ��5%   P   �� $ AddedMedicines�	 5(        5)      $
 Sifra��6%    64   �� *Code+  5*      $
 Naziv��6%    64   �� *Name+5,      �� 5-   
   -   5         ��Name$ buttonAddMedicine��5-      $��1��6,   $��1��6<   $��Dodaj alergiju��5.      $
��Left=�6*   $��0 20 0 0q�6e   �� 50   
   -   5        $ buttonDeleteMedicine��50      $��1��6/   $��2��6?   $��Obrisi alergiju��51      $
��Left=�6+   $��0 20 0 0q�6F   6X   52      53      