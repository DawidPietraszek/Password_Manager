   M S B A M L   `   `   `  ���� K  GPassword_manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Password_managerPassword_manager      Password_manager.AddSide   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:Password_manager       N� Title$  AddSide�� � 	Resources  �� MergedDictionaries �� Source��  �� $ /Style/Buttons.xaml?��� $ /Style/CheckBoxs.xaml?��� $ /Style/Slider.xaml?��� $ /Style/TextBox.xaml?�%    .���� $��2��$��3�����#2F3136$��30q�.+��� ���#CACBCC$��16(�$
��Bold"�.��Adres strony]� $��Stretch=�$
��auto��.+��� $��/Icons/IconWeb.png��$��32��$��32���� -    ��Name$	 Url��   TextBox_DataInput_Rounded#��[  
 � Tag$
 www.���� ���#CACBCC$��16(�$
��Bold"�.��Dane logowania]� $��Stretch=�$
��auto��.+��� $��/Icons/IconLogin.png��$��32��$��32���� -   $ Login��   TextBox_DataInput_TopRounded#��[ $ Login��$��5,0,0,0q�]� $��Stretch=�$
��auto��$��0,1,0,0q�.+��� $��/Icons/IconPassword.png��$��32��$��32���� -   $ Password��   TextBox_DataInput_BotRounded#��[ $ Password���� ���#CACBCC$��16(�$
��Bold"�.��Adres e-mail]� $��Stretch=�$
��auto��.+��� $��/Icons/IconEmail.png��$��32��$��32���� -   $ Email��#��[  $ Adres e-mail (optional)���� -   $��Dodaj��$��10q�$	��164�����#40444B���#CACBCC$��0q�  �� 
TargetType �� Property �� Value��%:   '��       �� " ��.���  �@��CornerRadius$ 10��� 	 � ColumnDefinitions	 �� $��1* ��� $
��Auto ��� $��1* �.+��� $��0��$��0,0,5,0q����#707070�� $��Generator Haseł��$��1�����#CACBCC$��16(�$
��Bold"��� $��2��$��5,0,0,0q����#707070�� ���#CACBCC$��16(�$
��Bold"�.��Losowe hasło]� $��Stretch=�$
��auto��.+��� -   $ RandomPassword��#��[  $ Random Passowrd���� ���#CACBCC$��16(�$
��Bold"�.��Długość hasła� 	 �� $��25 ��� $��20 ��� $��* ��� $��20 �.+��� -   $ RandomPasswordLength��$ 12��  TextBox_DataInput_Number#��[ $��0������ 
 �� ElementName$
 Slider_Lenght_Password�� �� Path$ Value� �� UpdateSourceTrigger$ PropertyChanged=�.���� -   $��1��$��20��$��25��$��2,0,2,0q�  Button_PlusAndMinus#��[ ���� $��/IconGlyphMinus.png���� -	    ��Name$ Slider_Lenght_Password��$��2��  AppSliderStyle#��[  �� IsSnapToTickEnabled$
 True�� �� TickFrequency$ 1Q� � Maximum$ 99Q��� -
   $��3��$��20��$��25��#��[ ���� $��/IconGlyphPlus.png���� $
��0,10q�.+�� 	 �� �� �� �� .+��� -    ��Name$ Numbers��$��0��  CheckBox_Style#��[  d� 	IsChecked$
 TrueY�.��123�� -   $	 Low��$��1��#��[ $
 TrueY�.��abc�� -   $
 Uper��$��2��#��[ $
 TrueY�.��ABC�� -   $ Special��$��3��#��[ $
 TrueY�.��#$%�� -   $��Generuj��$��10q�$	��164�����#40444B���#CACBCC$��0q� ��%:   '��       �� " ��.���  �@��CornerRadius$ 10��