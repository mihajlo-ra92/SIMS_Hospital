   M S B A M L   `   `   `  ����H  DSims-Hospital, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Sims_Hospital.ViewSims_Hospital.View  5      /    )Sims_Hospital.View.DoctorPageMedicineList   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Sims_Hospital.View     5        N� Title$  DoctorPageMedicineList��5	       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /StringResources.en.xaml?�6%   �� 5      $ /StringResources.sr.xaml?�6%   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5       $��30 �6   �� 5!      $��30 �6   �� 5"      $��30 �6   �� 5#      $��30 �6   �� 5$      $��30 �6   �� 5%      $��30 �6   �� 5&      $��30 �6   �� 5'      $��30 �6   �� 5(      $��30 �6   �� 5)      $��30 �6   �� 5*      $��30 �6   �� 5+      $��30 �6    � ColumnDefinitions 5-   
   �� 5.      $��50 �6   �� 5/      $��50 �6   �� 50      $��50 �6   �� 51      $��50 �6   �� 52      $��50 �6   �� 53      $��50 �6   �� 54      $��50 �6   �� 55      $��50 �6   �� 56      $��50 �6   �� 57      $��50 �6   �� 58      $��50 �6   �� 59      $��50 �6   �� 5:      $��50 �6   �� 5;      $��50 �6   �� 5<      $��50 �6   �� 5=      $��50 �6   .+�5@   
   ��    	TextBlock#���   6     StrMedicineControl#���  68   $��1��6d   $��3��6q   $��3��6�   $
��Bold"�6�   $��
5, 5, 5, 5q�6�   6�   �� 5A   
   -   5         ��Name$ SearchMedicine��5A   4     TextBox#���  6   $��1��6u   $��11��6�   $��2��6�   $��
5, 5, 0, 5q�6�   6�   �� 5B   
    J� IsHitTestVisible$ False��6     StrSearchMedicine#���  6-   $��Center=�6X   $��1��6s   $��11��6�   $��2��6�   $
��Left=�6�   $��10,0,0,0q�6�     OppositeColor#���  6�   ��5C      �� 5D       �� 
TargetType" ��6   .�5E      �� 	 �� Property	 � y�
 �� Value$
 	Collapsed=�63    �� Triggers 5F      �� 5G       �� Binding 6&   �� *Text+ �� ElementName$ SearchMedicine�� �� Value  6[   .a�5H      �� 	 � y�$
 Visible=�6;   5I      5K      5M      &   System.Windows.Controls.DataGrid  5O   
   -   5        $��MedicineGrid��5O   6     DataGrid#���  6      
IsReadOnly$
 True��6b      AutoGenerateColumns$ False��6t   $��2��6�   $��5��6�   $��3��6�   $��10��6�    �� AlternationCount$ 2��6�   $��9,5,1,5q�6�   ��6J   ��    Columns 5P      0  *System.Windows.Controls.DataGridTextColumn  5Q      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6&   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   ��  �� Path$
 Name�   Header 5R      �� 5S        StrMedicineName#���  6$   5U        5V      $	 150 6%    61   �� $
 Code� 5W      �� 5X        StrCode#���  6$   5Z        5[      $ * 6%    6/   �� $ IsValidString� 5\      �� 5]        StrValidity#���  6$   5_      5a      �� 5b   
   #���   6    	 StrIngredients#��� 	 68   $��7��6`   $��3��6m   $��2��6}   $��
5, 5, 5, 5q�6�   6�   �� 5c   
   -   5        $��IngredientsList��5c   4    
 ListBox#��� 
 6   $��8��6c   $��3��6p   $��3��6�   $��5��6�   $��
5, 5, 5, 5q�6�   ��6K   �� 6�   �� 5e   
   #���   6     StrNote#���  68   $��12��6Y   $��3��6g   $��2��6w   $��
5, 5, 5, 5q�6�   6�   �� 5f   
   -   5        $ InvalidationNote��5f   4   #���  6    �� 
IsReadOnly$
 True��6N   $��13��6`   $��4��6n   $��3��6   $��5��6�   $��
5, 5, 5, 5q�6�   6�   �� 5g   
   -   5         ��Name$ InvalidateMedicine��5g   2    
 Button#���  6   $��18��6o   $��2��6}   $��6��6�   $��4��6�   $��
5, 5, 5, 5q�6�   .��5h      ��  �� Orientation$ 
Horizontal=�6   .+�5i      �� $��Center=�6   $��
1, 1, 1, 1q�65   $"��/Resources/Images/cancel.png��6I   $��20��6o   $��20��6{   6�   �� 5j        StrInvalidateMedicine#���  6   $
��Left=�6K   $��
1, 1, 1, 1q�6f   6|   5k      5l      5m      5n      