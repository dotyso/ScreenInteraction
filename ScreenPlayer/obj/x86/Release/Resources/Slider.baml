   M S B A M L   `   `   `  ���� \  XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   SliderButtonStyle  �� 
TargetType �� Property �� Value �� 
TargetType  VolSliderThumbStyle A�Name �� 
StartPoint �� EndPoint  BorderLightColor � Color � Offset  BorderDarkColor  ControlMediumColor  ControlLightColor'    !System.Windows.VisualStateManager	    VisualStateGroups%   System.Windows.VisualStateGroup
   States    System.Windows.VisualState   
Storyboard �� TargetProperty �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime  ControlMouseOverColor �� Value  ControlPressedColor  DisabledControlDarkColor 	 SliderThumbStyle 
 HorizontalSlider � RowDefinitions m�Name J� SnapsToDevicePixels m� 	Placement m� Fill  
GlyphColor �� Color ��Name �� CornerRadius  SliderTrackDarkColor ]�Name ]� DecreaseRepeatButton ]� Thumb ]� IncreaseRepeatButton �� Triggers P� Property P� Value �� 
TargetName  VolSliderTemplate  VerticalSlider  � ColumnDefinitions  progressSlider! �� Triggers  	VolSlider�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      %4  &	        &	 �     7  7  7  &		 )    7  7  7  &	
 �    7   7 	 7   &	 $    7   7  7   &	 �    7   7 	 7   &	 '    7 
 7  &	 `    7  7  �� "  ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � �� �� " ��.R��� 
������ �� "  n�.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$ 6����  � ��$ 6����  � �� �� " n�.R�A� $ Ellipse��$��1������ $	 0,0&�$	 0,1&���� � # �  $	 0.0Q�� # �  $	 1.0Q����� $ 0.5,1&�$ 0.5,0&�.��� # �  $ 1Q�� # �  	   CommonStates��.
   
Normal��  	MouseOver��. �� .���� $_ Y(Shape.Fill).                       (GradientBrush.GradientStops)[0].(GradientStop.Color)�$ Ellipse��.g�  $ 0��8     Pressed��. �� .���� $_ Y(Shape.Fill).                       (GradientBrush.GradientStops)[0].(GradientStop.Color)�$ Ellipse��.g�  $ 0��8    Disabled��. �� .���� $_ Y(Shape.Fill).                       (GradientBrush.GradientStops)[0].(GradientStop.Color)�$ Ellipse��.g�  $ 0��8  �� "  n�.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$ 10����  � ��$ 10����  � �� �� " n�.R�A� $ Ellipse��$��1������ $	 0,0&�$	 0,1&���� � # �  $	 0.0Q�� # �  $	 1.0Q����� $ 0.5,1&�$ 0.5,0&�.��� # �  $ 1Q�� # �  	   CommonStates��.
   
Normal��  	MouseOver��. �� .���� $_ Y(Shape.Fill).                       (GradientBrush.GradientStops)[0].(GradientStop.Color)�$ Ellipse��.g�  $ 0��8     Pressed��. �� .���� $_ Y(Shape.Fill).                       (GradientBrush.GradientStops)[0].(GradientStop.Color)�$ Ellipse��.g�  $ 0��8    Disabled��. �� .���� $_ Y(Shape.Fill).                       (GradientBrush.GradientStops)[0].(GradientStop.Color)�$ Ellipse��.g�  $ 0��8  �� " ��.R��  �� $
��Auto ��� $
��Auto �#��z���� $
��Auto �.+�m� $ TopTick�� . $	 Top=�$��4��$y�	Collapsed=� �� # �  �� $ TrackBackground��$��0q�$ 0��$��3��$��1��$��1q����� $	 0,0&�$	 0,1&���� � # �  $	 0.0Q�� # �  $	 1.0Q����� $	 0,0&�$	 0,1&���� � # �  $	 0.0Q�� # �  $	 1.0Q�]� $ 
PART_Track��$��1�� �� 8��  $��Slider.DecreaseLarge�� n� 8��  �� 8�� $��Slider.IncreaseLarge��m� $ 
BottomTick�� . $��2��# z��$ Bottom=�$��4��$y�	Collapsed=� P�  �@��TickPlacement$ TopLeft=�. ��� $ TopTick�� � y�$ Visible=�P�  �@��TickPlacement$ BottomRight=�. ��� $ 
BottomTick�� � y�$ Visible=�P�  �@��TickPlacement$
 Both=�. ��� $ TopTick�� � y�$ Visible=��� $ 
BottomTick�� � y�$ Visible=��� " ��.R��  �� $
��Auto ��� $
��Auto �#��z���� $
��Auto �.+�m� $ TopTick�� . $	 Top=�$��4��$y�	Collapsed=� �� # �  �� $ TrackBackground��$��0q�$ 0��$��1��$��1��$��1q����� $	 0,0&�$	 0,1&���� � # �  $	 0.0Q�� # �  $	 1.0Q����� $	 0,0&�$	 0,1&���� � # �  $	 0.0Q�� # �  $	 1.0Q�]� $ 
PART_Track��$��1�� �� 8��  $��Slider.DecreaseLarge�� n� 8��  �� 8�� $��Slider.IncreaseLarge��m� $ 
BottomTick�� . $��2��# z��$ Bottom=�$��4��$y�	Collapsed=� P�  �@��TickPlacement$ TopLeft=�. ��� $ TopTick�� � y�$ Visible=�P�  �@��TickPlacement$ BottomRight=�. ��� $ 
BottomTick�� � y�$ Visible=�P�  �@��TickPlacement$
 Both=�. ��� $ TopTick�� � y�$ Visible=��� $ 
BottomTick�� � y�$ Visible=��� " ��.R��   �� $
��Auto ��� $
��Auto �#��z���� $
��Auto �.+�m� $ TopTick�� . $
 Left=�$��4��$y�	Collapsed=� �� # �  �� $ TrackBackground��$��0q�$ 2��$��4��$��1��$��1q����� $	 0,0&�$	 1,0&���� � # �  $	 0.0Q�� # �  $	 1.0Q����� $	 1,0&�$ 0.25,0&�.��� # �  $ 0Q�� # �  $ 1Q�]� $ 
PART_Track��$��1�� �� 8��  $��Slider.DecreaseLarge�� n� 8��  �� 8�� $��Slider.IncreaseLarge��m� $ 
BottomTick�� . $��2��# z��$ Right=�$��4��$y�	Collapsed=� P�  �@��TickPlacement$ TopLeft=�. ��� $ TopTick�� � y�$ Visible=�P�  �@��TickPlacement$ BottomRight=�. ��� $ 
BottomTick�� � y�$ Visible=�P�  �@��TickPlacement$
 Both=�. ��� $ TopTick�� � y�$ Visible=��� $ 
BottomTick�� � y�$ Visible=��� "  ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ! P�  �@��Orientation$ 
Horizontal=�. ���  � ��$	 104����  � ��$ 21����  � ��8   P�  �@��Orientation$ Vertical=�. ���  � ��$ 21����  � ��$	 104����  � ��8  �� "  ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ! P�  �@��Orientation$ 
Horizontal=�. ���  � ��$ 60����  � ��$ 21����  � ��8   P�  �@��Orientation$ Vertical=�. ���  � ��$ 21����  � ��$	 104����  � ��8  