   M S B A M L   `   `   `  ���� H  DCalculatorWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CalculatorWPFCalculatorWPF      CalculatorWPF.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:CalculatorWPF     -     � WindowStyle$  ThreeDBorderWindow=� � Title$ Simple Calculator��$	��500��$	��330�����	#FF202020 � 
ResizeMode$ 	CanResize=�$	��350��$	��450�� � Icon$ 	/icon.png�� � 	Resources    FocusVisual �� Property �� Value �� StrokeDashArray!  System.Windows.SystemColors   ControlTextBrushKey	 J� SnapsToDevicePixels  Button.Static.Background
 �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 RoundButton �� 
TargetType �� 
TargetType ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName   HighlightBrushKey  FocusVisual1  Button.Static.Background1  Button.Static.Border1  Button.MouseOver.Border1  Button.Pressed.Background1  Button.Pressed.Border1  Button.Disabled.Background1  Button.Disabled.Border1  Button.Disabled.Foreground1  RoundButton1  FocusVisual2  Button.Static.Border2  Button.MouseOver.Border2  Button.Pressed.Background2  Button.Pressed.Border2  Button.Disabled.Background2  Button.Disabled.Border2  Button.Disabled.Foreground2  EqualButton��%�  &	        &	 R     &	 g     &	 |     &	 �     &	 �     &	 �     &	 �     &	 �     &		 �     &	
     7   7  7  7  7  7  7  7 	 &	 "    &	 t    &	 �    &	 �    &	 �    &	 �    &	 �    &	 �    &	     &	     7  7  7  7  7  7  7  &	 9    &	 �    &	 �    &	 �    &	 �    &	 �    &	 �    &	 		    &	 	    7  7  7  7  7  7  7  �� .���  � �� �� .R��� $��2q�$	 1 2R�#���  $
	 true��$��1���� $
 	#FFDDDDDD���� $
 	#FF707070���� $
 	#FFBEE6FD���� $
 	#FF3C7FB1���� $
 	#FFC4E5F6���� $
 	#FF2C628B���� $
 	#FFF4F4F4���� $
 	#FFADB2B5���� $
 	#FF838383���� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# �  ��  � ��$ 0q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border��$ 6��#��z��#��z��#��z��$
	 true��._��� $ contentPresenter��$|�False��#��z��#��z��$
��True��#	 z	 #��z�� P�  �@��IsDefaulted$
 true��. ��� $ border��# �   � ��P�  �@J�IsMouseOver$
 true��. ��� $ border�� � �� �#3b3b3b�� $ border��8   � ��P�  � ��$
 true��. ��� $ border�� � �� �	#FF323232�� $ border��8   � ��P�  � {�$ false��. ��� $ border��8   � ���� $ border��8   � ���� $ contentPresenter��8   � ���� .���  � �� �� .R��� $��2q�$	 1 2R�#���  $
	 true��$��1���� $
 #3b3b3b���� $
 	#FF707070���� $
 	#FF3C7FB1���� $
 	#FFC4E5F6���� $
 	#FF2C628B���� $
 	#FFF4F4F4���� $
 	#FFADB2B5���� $
 	#FF838383���� " ��.���  �@�FocusVisualStyle8   ��  � �� �	#FF3B3B3B��  � ��8  ��  � ��# �  ��  � ��$ 0q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$ 6��$
	 true��._��� $ contentPresenter��$|�False��#��z��#��z��$
��True��#	 z	 #��z�� P�  �@��IsDefaulted$
 true��. ��� $ border��# �   � ��P�  �@J�IsMouseOver$
 true��. ��� $ border�� � �� �#323232�� $ border��8   � ��P�  � ��$
 true��. ��� $ border�� � �� �	#FF3B3B3B�� $ border��8   � ��P�  � {�$ false��. ��� $ border��8   � ���� $ border��8   � ���� $ contentPresenter��8   � ���� .���  � �� �� .R��� $��2q�$	 1 2R�#���  $
	 true��$��1���� $
 	#FF707070���� $
 	#FF3C7FB1���� $
 	#FFC4E5F6���� $
 	#FF2C628B���� $
 	#FFF4F4F4���� $
 	#FFADB2B5���� $
 	#FF838383���� " ��.���  �@�FocusVisualStyle8   ��  � �� �	#FF3B3B3B��  � ��8  ��  � ��# �  ��  � ��$ 0q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$ 6��$
	 true��._��� $ contentPresenter��$|�False��#��z��#��z��$
��True��#	 z	 #��z�� P�  �@��IsDefaulted$
 true��. ��� $ border��# �   � ��P�  �@J�IsMouseOver$
 true��. ��� $ border�� � �� �#ffd260�� $ border��8   � ��P�  � ��$
 true��. ��� $ border�� � �� �	#FFFFd220�� $ border��8   � ��P�  � {�$ false��. ��� $ border��8   � ���� $ border��8   � ���� $ contentPresenter��8   � ��.���  � ColumnDefinitions �� �� �� �� $
��1.1* � � RowDefinitions �� $��3* ��� �� �� �� �� .+��� -   #��� 
 $��C��$|�False��$��2,2,2,2q�$��1�����	#FF323232$��Comic Sans MS)�$��22(�
�������$��0,0,0,0q��� -   #��� 
 $��/��$|�False��$��2,2,2,2q�$��1��$��2�����	#FF323232$��Comic Sans MS)�$��22(�
�������$��0,0,0,0q��� -   #��� 
 $��x��$|�False��$��2,2,2,2q�$��2��$��3�����	#FF323232$��Comic Sans MS)�$��22(�
�������$��0,0,0,0q��� -   #��� 
 $	��↩��$|�False��$��2,2,2,2q�$��1��$��3�����	#FF323232$��Comic Sans MS)�$��20(�
�������$��0,0,0,0q��� -   #��� 
 $��-��$|�False��$��2,2,2,2q�$��3��$��3�����	#FF323232$��Comic Sans MS)�$��26(�
�������$��0,0,0,0q��� -   #���  $��7��$|�False��$��2,2,2,2q�$��2��$��0�����	#FF3B3B3B$��Comic Sans MS)�$��22(�
�������$��0,0,0,0q��� -   #���  $��8��$|�False��$��2,2,2,2q�$��2��$��1�����	#FF3B3B3B$��Comic Sans MS)�$��22(�
�������$��0,0,0,0q��� -	   #���  $��9��$|�False��$��2,2,2,2q�$��2��$��2�����	#FF3B3B3B$��Comic Sans MS)�$��22(�
�������$��0,0,0,0q��� -
   #���  $��4��$|�False��$��2,2,2,2q�$��3��$��0�����	#FF3B3B3B$��Comic Sans MS)�$��22(�
�������$��0,0,0,0q��� -   #���  $��1��$|�False��$��2,2,2,2q�$��4��$��0�����	#FF3B3B3B$��Comic Sans MS)�$��22(�
�������$��0,0,0,0q��� -   #���  $��5��$|�False��$��2,2,2,2q�$��3��$��1�����	#FF3B3B3B$��Comic Sans MS)�$��22(�
�������$��0,0,0,0q��� -   #���  $��2��$|�False��$��2,2,2,2q�$��4��$��1�����	#FF3B3B3B$��Comic Sans MS)�$��22(�
�������$��0,0,0,0q��� -   #���  $��6��$|�False��$��2,2,2,2q�$��3��$��2�����	#FF3B3B3B$��Comic Sans MS)�$��22(�
�������$��0,0,0,0q��� -   #���  $��3��$|�False��$��2,2,2,2q�$��4��$��2�����	#FF3B3B3B$��Comic Sans MS)�$��22(�
�������$��0,0,0,0q��� -   #���  $��0��$|�False��$��2,2,2,2q�$��5��$��0�����	#FF3B3B3B$��Comic Sans MS)�$��22(�
�������$��0,0,0,0q�$��2���� -   #���  $��.��$|�False��$��2,2,2,2q�$��5��$��2�����	#FF3B3B3B$��Comic Sans MS)�$��26(�
�������$��0,0,0,0q��� -   #��� 
 $��+��$|�False��$��2,2,2,2q�$��4��$��3�����	#FF323232$��Comic Sans MS)�$��26(�
�������$��0,0,0,0q��� -   #��� 
 $��%��$|�False��$��2,2,2,2q�$��1��$��1�����	#FF323232$��Comic Sans MS)�$��22(�
�������$��0,0,0,0q��� -   #���  $��=��$|�False��$��2,2,2,2q�$��5��$��3�����	#FFFFD280$��Comic Sans MS)����	#FF3B3B3B$��0,0,0,0q�$��36(�� -    �Name$
 grid��$��4�� �� $
��0.7* ��� $��2* ��� $
��0.5* �.+��� -    ��Name$ Secondary_display��$��0��$��Right=�$��Center=� � Cursor$ Arrow��$��0q�$��4��$��5,9,5,0q� �� TextWrapping$
 Wrap=�$��Bottom=�$��38�����	#FF202020$
}�True��$��Comic Sans MS)����	#FFA3A3A3$��20(� �� MaxLines$ 1�� �� 
IsReadOnly$
 True���� -   $ Primary_display��$��1��$��Right=�$��Center=�$ Arrow��$��4��$��5,0,5,0q�$
 Wrap=����	#FF202020$��0q����	#FFE8E8E8$
��Bold"�$��Comic Sans MS)�$��38(�$
 True��$��Center=����� *ActualHeight+ �� ElementName$
 grid�� �� Mode$ OneWay=��� -   $ Credit_screen��$��2��$��Center=�$��Center=�$
 Hand��$|�False��$��4��$��5,0,5,5q�$
 Wrap=�$��11Code on Github ♥��$��Bottom=�$��0q����	#FF202020$
}�True��$
 True�����	#FF720000$��Center=�