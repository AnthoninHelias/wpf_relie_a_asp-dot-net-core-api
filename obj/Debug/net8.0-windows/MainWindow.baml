   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5
      � .+�5   
   A� -   5         A�Name$ animatedCircle��5      $��50��6*   $��50��65   
���  ��$��Right=�5      $	��Top=�6.   $��20q�5       J� Opacity$ 0Q�6   � 5   
   $��Center=�6   $��Center=�6*    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $	��100 �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� -   5        $��1��5      $	��200��6%   $��80��61   $��26(�6=   $��Cartes��6K   z�5      �� 5      -   5        scaleCartes�� �� ScaleX$ 1Q�5   :    �� ScaleY$ 1Q�6E    � Triggers 5      :� 5       :� RoutedEvent$ Button.MouseEnter��6#   .[�5       �� .��5!      �� .��5"   "   W�  �� 
TargetName$ scaleCartes��62   	 �� TargetProperty$	 ScaleX�6V   	
 W� To
 1.56y    g� Duration$ 0:0:4D�6�   W� 5#   "   $ scaleCartes��62   $	 ScaleY�6V   
 1.56y   $ 0:0:4D�6�   W� 5%   "   $ animatedCircle��62   $	 Opacity�6Y   
 16}   $ 0:0:4D�6�   5&      5'      5(      :� 5)      $ Button.MouseLeave��6#   .[�5*      �� .��5+      �� .��5,   "   W� $ scaleCartes��62   $	 ScaleX�6V   
 16y   $ 0:0:1D�6�   W� 5-   "   $ scaleCartes��62   $	 ScaleY�6V   
 16y   $ 0:0:1D�6�   W� 5/   "   $ animatedCircle��62   $	 Opacity�6Y   
 06}   $ 0:0:1D�6�   50      51      52      54      �� 57      -   5        $��3��57      $	��200��6%   $��80��61   $��26(�6=   $��	Ban Liste��6K   z�58      �� 59      -   5        scaleBanListe��$ 1Q�59   <   $ 1Q�6G    5;      :� 5<      $ Button.MouseEnter��6#   .[�5=      �� .��5>      �� .��5?   "   W� $ scaleBanListe��62   $	 ScaleX�6X   
 1.56{   $ 0:0:4D�6�   W� 5@   "   $ scaleBanListe��62   $	 ScaleY�6X   
 1.56{   $ 0:0:4D�6�   W� 5B   "   $ animatedCircle��62   $	 Opacity�6Y   
 16}   $ 0:0:4D�6�   5C      5D      5E      :� 5F      $ Button.MouseLeave��6#   .[�5G      �� .��5H      �� .��5I   "   W� $ scaleBanListe��62   $	 ScaleX�6X   
 16{   $ 0:0:1D�6�   W� 5J   "   $ scaleBanListe��62   $	 ScaleY�6X   
 16{   $ 0:0:1D�6�   W� 5L   "   $ animatedCircle��62   $	 Opacity�6Y   
 06}   $ 0:0:1D�6�   5M      5N      5O      5Q      5R       � 5U   
   -   5          �Name$ 	MainFrame��5U      $	��600��6#   $	��300��6/   $��Bottom=�6<   $��Center=�6W   5V      5W      