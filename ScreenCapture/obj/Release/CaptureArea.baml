   M S B A M L   `   `   `  ���� H  DScreenCapture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ScreenCaptureScreenCapture      ScreenCapture.CaptureArea   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:ScreenCapture     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  -   $��captureAreaWindow��  � Title$  CaptureArea�� � AllowsTransparency .  � WindowStyle$
 None=� � WindowState$ 	Maximized=����	#01000000y��� *	IsVisible+   	BoolToVis �� 	Converter# [   � 	Resources   SemitransparentColor �� 
TargetType �� Property �� Value  StackpanelKey��%j   &	       &	 +     �� " ��.���  � �� �	#8F000000�� " ��.���  � �� �	#8F000000.���� -   	 ��Name$	 
mainCanvas��$��Stretch=�$��Stretch=�.+��� -   
 ��Name$
 	canvasTop��#��[ 
 �� Top$ 0��$��Stretch=�����  �� ElementName$ 
mainCanvas�� �� Path$ ActualWidth��� -   $	 canvasDrawPane1�� �� Orientation$ 
Horizontal=�.+��� -   $
 canvasDrawPaneLeft��#��[ �� -   $
 canvasDrawPane�����	#01000000.+��� -    ��Name$ canvasBorder��
���  ��$��1q�$
��Left=�$	��Top=����� $ canvasDrawPane��$ ActualHeight����� $ canvasDrawPane��$ ActualWidth��� -   $
 canvasPanelRight��#��[ �� -	   $
 canvasBottom��#��[ $��30��$��Stretch=�$��Stretch=�.+��� -
   $��controlsPanel��$
��Left=�$��Stretch=�$ 
Horizontal=�#��[ .+��� $��10,0,0,0q�$��30��
������ ���� *CapturAreaCommand+ .   (ScreenCapture.GraphicsDimesionsConverter  screenToRectangeConverter��%   &	         ��`�  `� 	Converter# [ 1��� $ canvasDrawPane��$ ActualWidth��� $ canvasDrawPane��$ ActualHeight��� $ canvasDrawPaneLeft��$ ActualWidth��� $ 	canvasTop��$ ActualHeight��� $ captureAreaWindow��$ .�.���� $ 
Horizontal=�.+�!  FontAwesome.WPF.FontAwesome     Icon$ FloppyOutline=�$��20(�
��������� -   $��10,0,0,0q�
������ $��30��.���� $ 
Horizontal=�.+�  $ PencilSquare=�$��20(�
�������