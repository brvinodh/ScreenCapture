   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   H DScreenCapture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ScreenCaptureScreenCapture 5   	      ScreenCapture.MainWindow   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ScreenCapture     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	     � Topmost  .  � Title$ Screen Capture��5
   	   $	��450��6    $	��600��6-    � SizeToContent$ WidthAndHeight=�69    � WindowStartupLocation$ Manual=�6X   
 � Top$ 5��6w    � 
ResizeMode$ NoResize=�6   (   "MahApps.Metro.Controls.MetroWindow   ShowMinButton .     ShowMaxRestoreButton .  y�6�   �� *IsApplicationVisible+ �� Mode$ TwoWay=�	 �� NotifyOnSourceUpdated	 .     BooleanToVisibilityConverter
 �� 	Converter#
 [   � 	Resources 5        	BoolToVis��%   &	       �� 5   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��60��6.   $	��2,0q�6:   .+�5      �� -   5        $��captureButton��5   j   $��0��6     SquareButtonStyle#���  6%   $��10q�6Q   $��40��6]   $
��20,0q�6�   ��6   �� *CaptureImageCommand+.��5      �� $ 
Horizontal=�6   .+�5      !  FontAwesome.WPF.FontAwesome     Icon$ Camera=�6%   $��30(�63   $��	0, 3,10,0q�6A   5      �� 5      $��Center=�6    	Capture6D   5      5      �� 5      -   5        $��captureButtonArea��5   j   $��0��6   #���  6%   $��10q�6Q   $��40��6]   $
��20,0q�6�   ��6�   �� *CaptureAreaCommand+.��5      �� $ 
Horizontal=�6   .+�5        $ CameraRetro=�6%   $��30(�68   $��	0, 3,10,0q�6F   5       �� 5!      $��Center=�6    Capture Area6I   5"      5#      (   "MahApps.Metro.Controls.SplitButton  5%      $
��20,0q�6#   $
��10,0q�62   $	��100��6@   $��40��6P   $	��100��6\    �� DisplayMemberPath$ 
OptionName��5&   #    �� SelectedIndex$ 0��6�   ��5%   h   �� *ExportOptions+   Command 5&   B   �� *OnExportButtonClicked+   CommandParameter 6l   ��  �� RelativeSource �� *Self+ �� Path$ SelectedItem�5'      d� 5(      -   5        $��showAdvanced��5(   6   $��40��6   $
��10,0q�6(    d� 	IsChecked 6J   �� *ShowAdvanced+.��5)        $ Wrench=�6!   $��26(�6/   6@   5*      5+      �� 5-   
   $��1��6   $ 
Horizontal=�6"   $��50��6;   $	��Top=�6G   $��2,0,0,0q�6_   y�5.      ��  �� ElementName$ showAdvanced��$ 	IsChecked�#
 [ .+�5/      �� $��Center=�6   $��10, 0q�63   Select Process:6S   �� 50       �� 
IsEditable .  �� IsTextSearchEnabled . $��40��6D   $	��200��6P   $ ProcessName��6�   ��6\   �� *ProcessItems+ �� SelectedItem 51      �� *SelectedProcessItem+6F   �� 52      $
��10,0q�6   $��40��6#   $��40��6/   ��6:   �� *GetAllProcessesCommand+.��53        $ Refresh=�6!   $��26(�60   6@   54      55      �� 56   
   $��2��6   .+�57      �� �� 58       �� CommandParameter 6   �� .�69   .�59      �� ��6    �� $ 
SnapStatus�5:      5;      5<      5=      5>      