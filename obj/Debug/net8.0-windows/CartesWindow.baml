   M S B A M L   `   `   `  ����  WpfApp1    WpfApp1.CartesWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Gestion des Cartes��5   	   $	��450��6$   $	��600��61   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��10q�6.   .+�5      �� $
��Nom:��6   $��Center=�6$   $��5q�6?   �� 5      -   5         ��Name$ 
NomTextBox��5      $	��150��6*   $��5q�66   �� 5      $��Rareté:��6   $��Center=�6'   $��5q�6B   �� 5      -   5        $ RaretéTextBox��5      $	��150��6-   $��5q�69   �� 5      -   5        $��Ajouter��5      $��5q�6B   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ CartesDataGrid��5      $��1��6+      AutoGenerateColumns$ False��68   $��10q�6T      SelectionMode$ Single=�5         
IsReadOnly$
 True��6*      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 50 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     5      $		 Nom��6%   $
 * 6J    62   �� *Nom+6J     5      $	 Rareté��6%   $	
 100 6P    65   �� *	Rareté+6P   5      �� 5   
   $ 
Horizontal=�6   $��2��6.   $��10q�6;   .+�5      �� -   5        $��Modifier��5      $��5q�6D   �� 5      -   5        $��	Supprimer��5      $��5q�6F   5       5!      5"      