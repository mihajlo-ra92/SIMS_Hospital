   M S B A M L   `   `   `  ����H  DSims-Hospital, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Sims_Hospital.View.PagesSims_Hospital.View.Pages  5      0    *Sims_Hospital.View.Pages.DoctorPageAccount   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:Sims_Hospital.View.Pages     5        N� Title$  DoctorPageAccount��5	       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /StringResources.en.xaml?�6%   �� 5      $ /StringResources.sr.xaml?�6%   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5       $��30 �6   �� 5!      $��30 �6   �� 5"      $��30 �6   �� 5#      $��30 �6   �� 5$      $��30 �6   �� 5%      $��30 �6   �� 5&      $��30 �6   �� 5'      $��30 �6   �� 5(      $��30 �6   �� 5)      $��30 �6   �� 5*      $��30 �6   �� 5+      $��30 �6   �� 5,      $��30 �6    � ColumnDefinitions 5.   
   �� 5/      $��50 �6   �� 50      $	��100 �6   �� 51      $	��100 �6   �� 52      $	��100 �6   �� 53      $	��150 �6   �� 54      $��30 �6   �� 55      $��70 �6   �� 56      $	��125 �6   �� 57      $	��100 �6   .+�5:   
   ��  	  Label#���   6     
StrAccount#���  60   $
��Bold"�6W   $��50(�6i   $��Sylfaen)�6w   $
��Left=�6�   $��Bottom=�6�   $��0��6�   $��3��6�   $��3��6�   $��0 0 0 0q�6�   �� 5<   
     	TextBlock#���  6     StrUsername#���  68   $��2��6]   $��3��6j   $��
5, 5, 5, 5q�6z   6�   �� 5=   
   -   5         ��Name$ UsernameBlock��5=   8   #���  6   $��2��6O   $��4��6\   $��
5, 5, 5, 5q�6l   6�   �� 5>   
   -   5         ��Name$ UsernameBox��5>   4     TextBox#���  6   $��2��6I   $��4��6V   $��
5, 5, 5, 5q�6f   6|   �� 5@   
   #���  6     StrPassword#���  68   $��3��6]   $��3��6j   $��
5, 5, 5, 5q�6z   6�   �� 5A   
   -   5        $ PasswordBlock��5A   8   #���  6   $	��???��6O   $��3��6Z   $��4��6g   $��
5, 5, 5, 5q�6w   6�   G� 5B   
   -   5         G�Name$ PasswordBox��5B   <     PasswordBox#���  6   $��3��6   $��4��6�   $��
5, 5, 5, 5q�6�   6�   �� 5C   
   -   5        $ PasswordTextBox��5C   4   #���  6   $��3��6w   $��4��6�   $��
5, 5, 5, 5q�6�   6�   �� 5D   
   -   5        	 ��Name$	 showPassword��5D   2    
 Button#���  6   $��3��6c   $��5��6p   $��
5, 5, 5, 5q�6�   .��5E      �� 
 �� Orientation$
 
Horizontal=�6   .+�5F      �� -   5         ��Name$ showPasswordIcon��5F   5   $��Center=�6   $��Center=�6O   $ ��/Resources/Images/view.png��6j   $��15��6�   $��15��6�   6�   5G      5H      �� 5J   
   #���  6   $��4��68   $��3��6E   $��
5, 5, 5, 5q�6U   Email:6q   �� 5K   
   -   5        $ 
EmailBlock��5K   8   #���  6   $��4��6M   $��4��6Z   $��
5, 5, 5, 5q�6j   6�   �� 5L   
   -	   5        $ EmailBox��5L   4   #���  6   $��4��6G   $��4��6T   $��
5, 5, 5, 5q�6d   6z   �� 5N   
   #���  6     StrName#���  68   $��5��6Y   $��3��6f   $��
5, 5, 5, 5q�6v   6�   �� 5O   
   -
   5        $ FirstNameBlock��5O   8   #���  6   $��5��6Q   $��4��6^   $��
5, 5, 5, 5q�6n   6�   �� 5P   
   -   5        $ FirstNameBox��5P   4   #���  6   $��5��6K   $��4��6X   $��
5, 5, 5, 5q�6h   6~   �� 5R   
   #���  6    	 StrLastName#��� 	 68   $��6��6]   $��3��6j   $��
5, 5, 5, 5q�6z   6�   �� 5S   
   -   5        $ LastNameBlock��5S   8   #���  6   $��6��6O   $��4��6\   $��
5, 5, 5, 5q�6l   6�   �� 5T   
   -   5        $ LastNameBox��5T   4   #���  6   $��6��6I   $��4��6V   $��
5, 5, 5, 5q�6f   6|   �� 5V   
   #���  6    
 StrBirthDate#��� 
 68   $��7��6^   $��3��6k   $��
5, 5, 5, 5q�6{   6�   �� 5W   
   -   5        $ BrithDateBlock��5W   8   #���  6   $��7��6P   $��4��6]   $��
5, 5, 5, 5q�6m   6�   (  "System.Windows.Controls.DatePicker  5X   
   -   5          Name$ datePickerBirth��5X      $��9(�6.   $��7��6<   $��4��6I   $��
5, 5, 5, 5q�6Y   �� 5]   
   #���  6     	StrGender#���  68   $��8��6[   $��3��6h   $��
5, 5, 5, 5q�6x   6�   �� 5^   
   -   5         ��Name$ sexTypeComboBox��5^      $��4��6,   $��8��6<   $��
5, 5, 5, 5q�6I   ��6]   �� *SexTypeCollection+�� 5_   
   -   5        $ GenderBlock��5_   8   #���  6   $��8��6M   $��4��6Z   $��
5, 5, 5, 5q�6j   6�   �� 5b   
   -   5        $	 editAccount��5b   2   #���  6   $��
5, 5, 5, 5q�6a   $��10��6u   $��2��6�   $��3��6�   $��2��6�   .��5c      �� $
 
Horizontal=�6   .+�5d      �� $��Right=�6   $��
1, 1, 1, 1q�64   $ ��/Resources/Images/edit.png��6H   $��20��6l   $��20��6x   6�   �� 5e        StrEdit#���  6   $
��Left=�6=   $��
1, 1, 1, 1q�6X   6n   5f      5g      5o      5p      