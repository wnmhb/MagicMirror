   M S B A M L   `   `   `  ����F  BMagicMirror, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MagicMirrorMagicMirror  5      a ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes 5          MagicMirror.App   5      #localclr-namespace:MagicMirror  5      8d2http://schemas.microsoft.com/expression/blend/2008  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      oMicrosoft_Windows_ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero     5        �� 	Resources  5         semiTransparentBackground  DefaultFamily  
ColorStyle+  %MagicMirror.BoolToVisibilityConverter  boolToVisibilityConverter  MainWinStyle �� 
TargetType �� Property �� Value  btnHideShowStyle �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value  btnCloseStyle	 F�Name
 �� CenterX �� CenterY �� Triggers �� 
TargetName :� RoutedEvent �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value   EasingFunction0  *System.Windows.Media.Animation.QuinticEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode  TabButtonStyle  lbBottomProduces �� Orientation K� IsItemsHost 	 ScrollBarThumb ��Name J� Opacity 
 GralScrollBar �Name J� SnapsToDevicePixels � RowDefinitions �� LineUpCommand J� IsMouseOver+  %Microsoft.Windows.Themes.ScrollChrome   ScrollGlyph ]�Name  ]� DecreaseRepeatButton! �� PageUpCommand" ]� IncreaseRepeatButton# �� PageDownCommand$ ]� Thumb% � Cursor& �� LineDownCommand' � ColumnDefinitions( �� LineLeftCommand) �� PageLeftCommand* �� PageRightCommand+ �� LineRightCommand, ��Name- �� CanContentScroll. �� CanHorizontallyScroll/ �� CanVerticallyScroll0 ��Name4  .System.Windows.Automation.AutomationProperties1   AutomationId2 �� ScrollableHeight3 � Maximum4 � Minimum*5 �� #ComputedVerticalScrollBarVisibility6 �� ViewportHeight7 �� ViewportSize8 � Value9 �� Mode: �� RelativeSource; �� ScrollableWidth< �� Orientation,= �� %ComputedHorizontalScrollBarVisibility> �� ViewportWidth��%�  &	        &	 !     &	 ^     &	 }     &	 �     7   &	 �    7  7  &	     7  &	 
    7  7  &	 }    &		 �    &	
 �    7 	 7 	 '�� >    ��5   
   	#3375787C��6G   *�5   
   )%宋体,Courier New,MS Mincho,DotumChe)�6N   ��5   
   #F9885C��66     5   
   6N   �� 5   
   " �6%   .�5      ��  � ��$	 640��6&   64   �� 5       � ��$	 800��6'   65   �� 5       �@�
ResizeMode$ NoResize=�6+   6>   �� 5       �@�WindowStyle$
 None=�6,   6;   �� 5       �@�AllowsTransparency . 6B   �� 5       � ��8   6`   5      �� 5   
   " d�6)   .�5      ��  � ��$ 90��6&   63   �� 5       � ��$ 50��6'   64   �� 5       � ��$
 0,10q�6'   66   �� 5        � ��$ 5q�6(   64   �� 5!       � ��$ 30(�6)   66   �� 5"       � ��$
 Bold"�6+   6:   �� 5#       � ��8   6T   �� 5$       � �� 5%      �� 5&      " d�6&   .R�5'      �� $��Center=�6"   $��0q�6=   $ 2��6Q   #��z��6b   ._�5(      �� #��z��6/   ��. $��Center=�6n   #��z��5)   /   5*      5+      5-       5/      P� 50       �@d�	IsChecked$
 TrueY�6/   . �51      ��  � ��
 �����6C   �� 52       � ��8  6Y   �� 53       � ��$
 SHOW��60   6?   54      P� 55       �@d�	IsChecked$ FalseY�6/   . �56      ��  � ��$
 HIDE��60   6?   57      59      �� 5;   
   " ��6&   .�5<      ��  � ��$ 50��6&   63   �� 5=       � ��$ 50��6'   64   �� 5>       � ��$ 5q�6'   63   �� 5?       � �� 5@      �� 5A      " ��6&   .R�5B      �� $��Center=�6"   $��0q�6=   
������ ._�5C      F� $	 	CheckMark��6#   $��2��66   
�������+���� z  z � Zb�� z �� Zb z 	z�5D   "   V� 5E   &   .~�5F   *   �� $
 25Q�69   $ 25Q�6F   5G   '   5I      5J       5K      P� 5L       �@J�IsMouseOver . . �5M   "   �� $ 	CheckMark��6)   8    � ��6R   5N      :� 5O      $ Button.MouseEnter��6+   .[�5P   "   �� .��5Q   &   �� .��5R   *   U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6H   $ 	CheckMark��6�   .\�5S   .     $ 0:0:0.2��6C    1.26U     5T   .   $ 0:0:0.4��6C    16U    5U   2     5V   6   $ EaseOut=�6B   5X   /   5Y   +   U� 5Z   *   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6H   $ 	CheckMark��6�   .\�5[   .     $ 0:0:0.2��6C    1.26U     5\   .   $ 0:0:0.4��6C    16U    5]   2     5^   6   $ EaseOut=�6B   5`   /   5a   +   5b   '   5c   #   5d      5f      5h      5i      �� 5k   
   " ��6'   .�5l      ��  � ��$ 18(�6)   66   �� 5m       � ��8   6Q   �� 5n       � �� 5o      �� 5p      " ��6&   .R�5q      �� $��Center=�6"   $��1q�6=   8�� #��z��5r   "   #��z��6D   ._�5s      �� #��z��6/   #��z��5t   /   ��. $��Center=�5u   J   5v      5w      5y      5z      �� 5|   
   " ��6)   .�5}      ��  � �� 5~      �� 5      " ��6&   .R�5�      �� $ 5��6!   #��z��62   ._�5�      �� $
��Auto=�6+   $��Hidden=�6P   .��5�   "   �� $ 
Horizontal=�6-   $��Center=�6F   $��Center=�6a    . 6~   5�      5�      5�      5�      5�      �� 5�   
   " n�6'   .�5�      ��  �@�OverridesDefaultStyle . 66   �� 5�       � �� .  6*   �� 5�       � �� 5�      �� 5�      " n�6&   .R�5�      �� $ 
Background��6$   ���	#FFA8A8A8$��1��6I   
�������$	 0.6Q�6l   5�      5�      5�      �� 5�   
   " ��6&   .�5�      ��  � ��
 ���� 6+   �� 5�       �@��IsPressAndHoldEnabled .  6=   �� 5�       �@��IsFlicksEnabled .  67   �� 5�       � ��# � ��6+   �� 5�       � ��$ 8��6&   �� 5�       � ��$ 8��6)   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      � $ Bg��6   
������  .  5�      �� 5�   "   $
��Auto �60   �� 5�   "   $��0.00001* �60   �� 5�   "   $
��Auto �60   .+�5�      �� #��Z 6+   #{�z 6X   $ UpArrow=�6�   $y�	Collapsed=�6�   ]� 5�      $ 
PART_Track��6$   ��. #{�z 6S   $��1��6}     5�   "   �� 5�   &   #��Z! 63   $ 0Q�6`   " 5�   "   �� 5�   &   #��Z# 63   $ 0Q�6c   $ 5�   "   n� 5�   &   $
% Hand��6,   8��  $ VerticalGripper=�6b   5�      �� 5�      #��Z& 6+   #{�z 6Z   $��2��6�   $ 	DownArrow=�6�   $y�	Collapsed=�6�   5�      5�      5�       5�      P� 5�       �@��Orientation$ 
Horizontal=�61   . �5�      ��  � ��$
 Auto��6.   �� 5�       � ��$ 0��61   �� 5�       � ��$ 8��6/   �� 5�       � ��$ 8��62   �� 5�       � ��
 ���� 63   �� 5�       � �� 5�      �� 5�      " ��6.   .R�5�   "   � $ Bg��6'   
������  . ' 5�   &   �� 5�   *   $
��Auto �6;   �� 5�   *   $��0.00001* �6;   �� 5�   *   $
��Auto �6;   .+�5�   &   �� #��Z( 63   #{�z 6b   $ 	LeftArrow=�6�   $y�	Collapsed=�6�   ]� 5�   &   $ 
PART_Track��6,   $��1��6@   #{�z 6P     5�   *   �� 5�   .   #��Z) 6;   $ 0Q�6j   " 5�   *   �� 5�   .   #��Z* 6;   $ 0Q�6k   $ 5�   *   n� 5�   .   $
% Hand��64   8�� $ HorizontalGripper=�6j   5�   '   �� 5�   &   $��2��63   #��Z+ 6C   #{�z 6s   $ 
RightArrow=�6�   $y�	Collapsed=�6�   5�   #   5�      5�      5�      5�      �� 5�   
   " ��6   .�5�      ��  � ��$
 Left=�6;   �� 5�       � ��$	 Top=�69   �� 5�       � ��$ 5q�6(   �� 5�       � ��$ 0q�60   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      � $
 Grid��6   #��z��6-   ' 5�      �� 5�   "   $��* �63   �� 5�   "   $
��Auto �63    5�      �� 5�   "   $��* �60   �� 5�   "   $
��Auto �60   .+�5�      �� $ Corner��6(   $��1��68   
������ $��1��6[   �� 5�      $!, PART_ScrollContentPresenter��65   #- z��6Z   . .  / .  #��z��6�   #��z��6�   $��0��6"  #��z��62  $��0��6U  �� 5�      $0 PART_VerticalScrollBar��6(   $1 VerticalScrollBar��6H   $% Arrow��6~   $��1��6�   #3 z2 6�   $4 0Q�6�   $��0��6�   #y�z5 6�   #7 z6 6�  #��� 
 6�  8 6&  �� *VerticalOffset+$9 OneWay=�: �� *TemplatedParent+6�  �� 5�      $0 PART_HorizontalScrollBar��6(   $1 HorizontalScrollBar��6J   $% Arrow��6�   $��0��6�   #3 z; 6�   $4 0Q�6�   $< 
Horizontal=�6�   $��1��6�   #y�z= 6�   #7 z> 6�  #��� 
 6�  8 6D  �� *HorizontalOffset+$9 OneWay=�: �� *TemplatedParent+6�  5�      5�      5�      5�      5�      5�      