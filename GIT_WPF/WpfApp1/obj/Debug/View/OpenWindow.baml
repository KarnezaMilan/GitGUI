   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfApp1.ViewWpfApp1.View  5   	   ;"clr-namespace:WpfApp1.UserControlsWpfApp1.UserControls  5   	       WpfApp1.View.OpenWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WpfApp1.View     5   	   7controls"clr-namespace:WpfApp1.UserControls     5   	     � Icon$  ../Resource/Logo.ico��5	   	    � Title$ M-Git��5
   	   $
��1152��6   $	��546��6$    � WindowStartupLocation$ CenterScreen=�61    � WindowStyle$
 None=�6V   .��5      � ��5   
   �� 5       �� ImageSource$  ../Resource/background.jpg��6    j� Stretch$ UniformToFill=�6B    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��3* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��1* �6   �� 5      $
��0.1* �6   �� 5      $��1* �6   �� 5      $��* �6   .+�5   
   �� $��2��6   .+�5       #   WpfApp1.UserControls.MainMenu  $��Right=�6    $��0,10,5,0q�67   5"      �� 5$   
   $��1��6   $��1��6%   .+�5%      �� ���#727272$��10q�6*   $	��450��66   ._�5&      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $
��Auto��6O   ���#FFF$��5q�6n   .+�5'      �� -   5        $��OpenRepo��5'   %   $��5q�6   $
��10,5q�6L   .��5(      � .+�5)      �� $��../Resource/open_icon.png��6    $
��None=�6C   $��0,0,4,0q�6R   �� 5*      $��Center=�6(   $��Open repository��6C   5+      5,      �� 5.      -   5        $��
CreateRepo��5.   (   $��5q�6   $
��10,5q�6S   .��5/      � .+�50      �� $!��../Resource/create_icon.png��6    $
��None=�6E   $��0,0,4,0q�6T   �� 51      $��Center=�6(   $��Create repository��6C   52      53      �� 54      -   5        $��	CloneRepo��54   (   $��5q�6   $
��10,5q�6Q   .��55      � .+�56      �� $ ��../Resource/clone_icon.png��6    $
��None=�6D   $��0,0,4,0q�6S   �� 57      $��Center=�6(   $��Clone repositor��6C   58      59      5:      5;      5<      � 5>   
   $��1��6   $��3��6   $��Center=�6,   .+�5?      �� -   5        $��CloneRepoPanel��5?   *   ���#727272._�5@      �� $��5q�6      BackGroundStyle#��[  6%   .+�5B      �� $ 
Horizontal=�6"   $��5q�6;   .+�5C      �� $��URL : ��6    $
��50px��61   $��Bottom=�6>   �� 5D      -   5        $��
UrlTextbox��5D   0   $��400px��6"   $��Stretch=�6B   $��Bottom=�6e   $��0,0,0,2q�6�   ��6�   �� 	 �� Path$	 CloneUrl��� 5E      -   5        $��CloneRepoPaste��5E   Q   $��Paste��6!   $��100px��61   $��10,0,0,4q�6?   $��Bottom=�6�   5F      �� 5H      $ 
Horizontal=�6!   $��5q�6:   .+�5I      �� $��Local: ��6    $
��50px��62   $��Bottom=�6?   �� 5J      -   5        $��LocalTextbox��5J   0   $��400px��6"   $��Bottom=�6D   $��0,0,0,2q�6_   
 �� 
IsReadOnly
 . ��6p   �� $	 CloneLocalPath�6�   �� 5K      -   5        $��CloneRepoSerch��5K   S   $��Search��6!   $��100px��62   $��10,0,0,4q�6A   $��Bottom=�6�   5L      �� 5M      $ 
Horizontal=�6!   $��5q�6:   $��Right=�6E   .+�5N      �� -	   5        $��CloneRepoClone��5N   M   $��Clone��6!   $��100px��61   $
��30px��6?   $��Center=�6�   $��Center=�6�   5O      5P      5Q      5S      5X      5Y      