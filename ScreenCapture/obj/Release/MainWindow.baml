   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  H DScreenCapture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ScreenCaptureScreenCapture    ScreenCapture.MainWindow   HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:ScreenCapture     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/    � Topmost  .  � Title$ Screen Capture��$	��450��$	��600�� � SizeToContent$ WidthAndHeight=� � WindowStartupLocation$ Manual=�
 � Top$ 5�� � 
ResizeMode$ NoResize=�(   "MahApps.Metro.Controls.MetroWindow   ShowMinButton .     ShowMaxRestoreButton .  y��� *IsApplicationVisible+ �� Mode$ TwoWay=�	 �� NotifyOnSourceUpdated	 .     BooleanToVisibilityConverter
 �� 	Converter#
 [   � 	Resources   	BoolToVis��%   &	       �� .���  � RowDefinitions �� $��* ��� $��* ��� $��* �.+���  �� Orientation$ 
Horizontal=�$��60��$	��2,0q�.+��� -   $��captureButton��$��0��  SquareButtonStyle#���  $��10q�$��40��$
��20,0q����� *CaptureImageCommand+.���� $ 
Horizontal=�.+�!  FontAwesome.WPF.FontAwesome     Icon$ Camera=�$��30(�$��	0, 3,10,0q��� $��Center=�	Capture�� -   $��captureButtonArea��$��0��#���  $��10q�$��40��$
��20,0q����� *CaptureAreaCommand+.���� $ 
Horizontal=�.+�  $ CameraRetro=�$��30(�$��	0, 3,10,0q��� $��Center=�Capture Area(   "MahApps.Metro.Controls.SplitButton  $
��20,0q�$
��10,0q�$	��100��$��40��$	��100�� �� DisplayMemberPath$ 
OptionName�� �� SelectedIndex$ 0������ *ExportOptions+   Command �� *OnExportButtonClicked+   CommandParameter ��  �� RelativeSource �� *Self+ �� Path$ SelectedItem�d� -   $��showAdvanced��$��40��$
��10,0q� d� 	IsChecked �� *ShowAdvanced+.��  $ Wrench=�$��26(��� $��1��$ 
Horizontal=�$��50��$	��Top=�$��2,0,0,0q�y���  �� ElementName$ showAdvanced��$ 	IsChecked�#
 [ .+��� $��Center=�$��10, 0q�Select Process:��  �� 
IsEditable .  �� IsTextSearchEnabled . $��40��$	��200��$ ProcessName������ *ProcessItems+ �� SelectedItem �� *SelectedProcessItem+�� $
��10,0q�$��40��$��40������ *GetAllProcessesCommand+.��  $ Refresh=�$��26(��� $��2��.+��� ��  �� CommandParameter �� .�.��� ���� $ 
SnapStatus�