   M S B A M L   `   `   `  ����H  DSims-Hospital, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Sims_Hospital.ViewSims_Hospital.View  5      +    %Sims_Hospital.View.DoctorPageFreeDays   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Sims_Hospital.View     5        N� Title$  DoctorPageFreeDays��5	       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /StringResources.en.xaml?�6%   �� 5      $ /StringResources.sr.xaml?�6%   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5       $��30 �6   �� 5!      $��30 �6   �� 5"      $��30 �6   �� 5#      $��30 �6   �� 5$      $��30 �6   �� 5%      $��30 �6   �� 5&      $��30 �6   �� 5'      $��30 �6   �� 5(      $��30 �6    � ColumnDefinitions 5*   
   �� 5+      $��0 �6   �� 5,      $��0 �6   �� 5-      $��50 �6   �� 5.      $��50 �6   �� 5/      $��50 �6   �� 50      $��50 �6   �� 51      $��50 �6   �� 52      $��50 �6   �� 53      $��50 �6   �� 54      $��50 �6   �� 55      $��50 �6   �� 56      $��50 �6   �� 57      $��50 �6   �� 58      $��50 �6   �� 59      $��50 �6   �� 5:      $��50 �6   �� 5;      $��50 �6   �� 5<      $��50 �6   .+�5?   
   ��    	TextBlock#���   6     StrSentFreeDayRequests#���  68   $��1��6h   $��4��6u   $��4��6�   $��
5, 5, 5, 5q�6�   $
��Bold"�6�   6�   &   System.Windows.Controls.DataGrid  5A   
   -   5        $��FreeDayGrid��5A   6     DataGrid#���  6      
IsReadOnly$
 True��6a      AutoGenerateColumns$ False��6s   $��2��6�   $��5��6�   $��4��6�   $��6��6�    �� AlternationCount$ 2��6�   $��5,5,5,5q�6�   ��6I   �� 	   Columns	 5B      0  *System.Windows.Controls.DataGridTextColumn  5C      ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 100 6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   ��  �� Path$ 	StartDate�   Header 5D      �� 5E        StrStart#���  6$   5G        5H      $	
 100 6%    61   �� $ EndDate� 5I      �� 5J       
 StrEnd#���  6$   5L        5M      $ Status��6%   $
 * 65    6?   �� $ RequestStateString�5O      �� 5R   
   #���   6     StrDecisionNote#���  68   $��1��6a   $��13��6n   $��3��6   $��
5, 5, 5, 5q�6�   6�   �� 5T   
   -   5         ��Name$! selectedFreeDayDecisionNote��5T   4     TextBox#���  6    �� 
IsReadOnly$
 True��6Y   $��2��6k   $��5��6x   $��13��6�   $��3��6�   $��
5, 5, 5, 5q�6�   6�   �� 5V   
   #���   6     StrRequestNote#���  68   $��1��6`   $��10��6m   $��2��6~   $��
5, 5, 5, 5q�6�   6�   �� 5X   
   -   5        $ selectedFreeDayNote��5X   4   #���  6   $
 True��6Q   $��2��6c   $��5��6p   $��10��6�   $��3��6�   $��
5, 5, 5, 5q�6�   6�   �� 5Z   
   #���   6     StrNewRequest#���  68   $��8��6_   $��6��6l   $��2��6|   $��
5, 5, 5, 5q�6�   $
��Bold"�6�   6�   �� 5[   
   #���   6    	 StrFrom#��� 	 68   $��9��6Y   $��6��6f   $��
5, 5, 5, 5q�6v   6�   �� 5\   
   #���   6    	
 StrTo#��� 
 68   $��9��6W   $��10��6d   $��10, 5, 5, 5q�6u   6�   (  "System.Windows.Controls.DatePicker  5]   
   -   5          Name$ datePickerStart��5]      $��9��6/   $��7��6<   $��3��6L   $��
5, 2, 5, 2q�6`     5^   
   -   5        $ datePickerEnd��5^      $��9��6.   $��11��6;   $��3��6L   $��
5, 2, 5, 2q�6`   �� 5`   
   #���   6     StrFreeDayNote#���  68   $��10��6`   $��6��6n   $��2��6~   $��
5, 5, 5, 5q�6�   6�   �� 5a   
   -   5        $ requestNote��5a   4   #���  6   $��11��6I   $��4��6W   $��6��6h   $��8��6x   $��
5, 5, 5, 5q�6�   6�   �� 5c   
   -   5         ��Name$ isEmergency��5c   _     CheckBox#���  6     StrEmergency#���  66   $��15��6t   $��12��6�   $��2��6�   $��
5, 5, 5, 5q�6�   6�   �� 5d   
   -   5         ��Name$ ConfirmButton��5d   2    
 Button#���  6   $��17��6I   $��2��6W   $��8��6h   $��4��6x   $��
5, 5, 5, 5q�6�   .��5f      ��  �� Orientation$ 
Horizontal=�6   .+�5g      �� $��Center=�6   $��
1, 1, 1, 1q�65   $#��/Resources/Images/confirm.png��6I   $��20��6p   $��20��6|   6�   �� 5h        
StrConfirm#���  6   $
��Left=�6@   $��
1, 1, 1, 1q�6[   6q   5i      5j      5k      5l      