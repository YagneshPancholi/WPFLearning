   M S B A M L   `   `   `  ����D  @Reservoom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Reservoom.ViewReservoom.View  5      $    Reservoom.View.MakeReservation   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Reservoom.View     5      .��5	      � $��Center=�6   $��0 40 0 0q�6(     � IsSharedSizeScope$
  True��6:    � RowDefinitions 5
   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   .+�5   
   �� $��Make Reservation��6   $��25(�6,   $��0��6:   � 5   
   $��1��6   $��0 25 0 0q�6    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��0��6   $
��Name��6%   �� 5      $��1��6   $��0 5 0 0q�6#   $	��245��6r   $
��Left=�6~   ��64   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�6~   5      � 5   
   $��2��6   $��0 5 0 0 q�6    5      �� 5       $
��Auto �6    �� 5!      $
��Auto �6     � ColumnDefinitions 5#      �� 5$      $
��Auto �6#    z� SharedSizeGroup$ FirstColumn��60   6P   �� 5%      $
��auto �6#   $ SecondColumn��60   6Q   .+�5(      �� $��0��6   $��0��6%   $��	Floor No.��65   �� 5)      $��1��6   $��0��6#   $��0 5 0 0q�63   ��6D   �� *FloorNumber+$ PropertyChanged=��� 5+      $��0��6   $��1��6%   $��Room No.��65   $��20 0 0 0q�6E   �� 5,      $��1��6   $��1��6#   $��20 5 5 0q�64   ��6F   �� *
RoomNumber+$ PropertyChanged=�5-      � 5/   
   $��3��6   $��0 5 0 0q�6    51      �� 52      $
��Auto �6    �� 53      $
��Auto �6     55      �� 56      $
��Auto �6#   $ FirstColumn��60   6P   �� 57      $
��auto �6#   $ SecondColumn��60   6Q   .+�5:      �� $��0��6   $��0��6%   $��
Start Date��65   (  "System.Windows.Controls.DatePicker  5;      $��1��6   $��0��6'   $��0 5 0 0q�67      SelectedDate 6H   �� *	StartDate+$ PropertyChanged=��� 5=      $��0��6   $��1��6%   $��End Date��65   $��20 0 0 0q�6E     5>      $��1��6   $��1��6&   $��20 5 5 0q�66    6H   �� *	EndDate+$ PropertyChanged=�5?      �� 5@   
    �� Orientation$ 
Horizontal=�6   $��4��6.   $��	0 30 0 0 q�6;   .+�5A      �� $��Submit��6   ��6&   �� *SubmitCommand+6J   �� 5B      $��Cancel��6   $��5 0 0 0 q�6&   ��68   �� *CancelCommand+6\   5C      5D      5E      