   M S B A M L   `   `   `  ����K  GPassword_manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Password_managerPassword_manager  5      %    Password_manager.Page.LoginData   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:Password_manager     5        N� Title$  AddSide��5	       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Style/Buttons.xaml?�6%   �� 5      $ /Style/CheckBoxs.xaml?�6%   �� 5      $ /Style/Slider.xaml?�6%   �� 5      $ /Style/TextBox.xaml?�6%   %    5      .��5      �� $��2��6   $��3��6   ���#2F3136$��30q�6C   .+�5   
   �� ���#CACBCC$��16(�6%   $
��Bold"�63   .��6F   Adres strony6T   ]� 5   
   $��Stretch=�6   $
��auto��62   .+�5      �� $��/Icons/IconWeb.png��6   $��32��61   $��32��6=   �� 5      -   5         ��Name$ ShowUrl��5   I      TextBox_DataInput_Rounded#��[  6   
 � Tag$
 www.��6Z   5       �� 5#   
   ���#CACBCC$��16(�6%   $
��Bold"�63   .��6F   Dane logowania6V   ]� 5%   
   $��Stretch=�6   $
��auto��62   .+�5&      �� $��/Icons/IconLogin.png��6   $��32��63   $��32��6?   �� 5'      -   5        $ 	ShowLogin��5'   L      TextBox_DataInput_TopRounded#��[ 6   $ Login��6_   5(      ]� 5*   
   $��Stretch=�6   $
��auto��62   $��0,1,0,0q�6?   .+�5+      �� $��/Icons/IconPassword.png��6   $��32��66   $��32��6B   �� 5,      -   5        $ ShowPassword��5,   L      TextBox_DataInput_BotRounded#��[ 6   $ Password��6b   5-      �� 50   
   ���#CACBCC$��16(�6%   $
��Bold"�63   .��6F   Adres e-mail6T   ]� 51   
   $��Stretch=�6   $
��auto��62   .+�52      �� $��/Icons/IconEmail.png��6   $��32��63   $��32��6?   �� 53      -   5        $ 	ShowEmail��53   I   #��[  6   $ Adres e-mail (optional)��6\   54      56      59      