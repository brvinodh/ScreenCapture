   M S B A M L   `   `   `  ����H  DScreenCapture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ScreenCaptureScreenCapture  5   	       ScreenCapture.CaptureArea   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ScreenCapture     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   -   5        $��captureAreaWindow��5   f     � Title$  CaptureArea��5	   	    � AllowsTransparency .  � WindowStyle$
 None=�5   	    � WindowState$ 	Maximized=�6   ���	#01000000y�5      �� *	IsVisible+   	BoolToVis �� 	Converter# [   � 	Resources 5        SemitransparentColor �� 
TargetType �� Property �� Value  StackpanelKey��%�   &	       &	 T     �� 5   
   " ��6-   .�5      ��  � �� �	#8F0000005      5      �� 5   
   " ��6&   .�5      ��  � �� �	#8F0000005      5      5      .��5      �� -   5        	 ��Name$	 
mainCanvas��5      $��Stretch=�5      $��Stretch=�6+   .+�5   
   �� -   5        
 ��Name$
 	canvasTop��5      #��[ 6$   
 �� Top$ 0��6_   $��Stretch=�6�   ��6o   ��  �� ElementName$ 
mainCanvas�� �� Path$ ActualWidth�6�   �� 5   
   -   5        $	 canvasDrawPane1��5   .    �� Orientation$ 
Horizontal=�6   .+�5      �� -   5        $
 canvasDrawPaneLeft��5      #��[ 61   5       �� 5"      -   5        $
 canvasDrawPane��5"      ���	#01000000.+�5#      �� -   5         ��Name$ canvasBorder��5#      
���  ��$��1q�5%   1   $
��Left=�6F   $	��Top=�6a   ��5#   /   �� $ canvasDrawPane��$ ActualHeight���5$      �� $ canvasDrawPane��$ ActualWidth�5&      5'      �� 5(      -   5        $
 canvasPanelRight��5(      #��[ 6/   5)      5*      �� 5+   
   -	   5        $
 canvasBottom��5+      #��[ 6'   $��30��6c   $��Stretch=�6r   $��Stretch=�6�   .+�5,      �� -
   5        $��controlsPanel��5,      $
��Left=�6.   $��Stretch=�6I   $ 
Horizontal=�6g   #��[ 6�   .+�5-      �� $��10,0,0,0q�6   $��30��6+   
������ ��6P   �� *CapturAreaCommand+ 5.      .   (ScreenCapture.GraphicsDimesionsConverter  screenToRectangeConverter��%   &	         5/      6;   50      ��51      `� 52       `� 	Converter# [ 6'   1�53      �� 54   "   $ canvasDrawPane��6*   $ ActualWidth�6G   �� 55   "   $ canvasDrawPane��6*   $ ActualHeight�6G   �� 56   "   $ canvasDrawPaneLeft��6*   $ ActualWidth�6K   �� 57   "   $ 	canvasTop��6*   $ ActualHeight�6B   �� 58   "   $ captureAreaWindow��6*   $ .�6J   5:      .��5=      �� $ 
Horizontal=�6!   .+�5>      !  FontAwesome.WPF.FontAwesome     Icon$ FloppyOutline=�6)   $��20(�6>   
�������5?      5B      5C      �� 5D      -   5        $��10,0,0,0q�5D      
������ $��30��6E   .��5E      �� $ 
Horizontal=�6!   .+�5F        $ PencilSquare=�6)   $��20(�6=   
�������5G      5H      5I      5J      5K      5L      5M      