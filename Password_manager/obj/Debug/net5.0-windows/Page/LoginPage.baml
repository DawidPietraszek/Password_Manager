   M S B A M L   `   `   `  ����K  GPassword_manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Password_manager.PagePassword_manager.Page  5      %    Password_manager.Page.LoginPage   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Password_manager.Page     5        N� Title$  	LoginPage��5      $��Stretch=�5      $��Stretch=�5       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Style/Buttons.xaml?�6%   �� 5      $ /Style/CheckBoxs.xaml?�6%   �� 5      $ /Style/Slider.xaml?�6%   �� 5      $ /Style/TextBox.xaml?�6%   %    5      .��5      �� $��2��6   $��3��5      ���#2F3136.+�5"   
   �� ���#CACBCC$��16(�5#      $
��Bold"�5$      .��6"   	Zaloguj6+   ]� 5&   
   $��Stretch=�6   $
��auto��5'      .+�5(      �� $��/Icons/IconLogin.png��6   $��32��5)      $��32��5*      �� 5+      -   5         ��Name$ Login��5,          TextBox_DataInput_TopRounded#��[  5+      
 � Tag$ Login��5-      5.      ]� 50   
   $��Stretch=�6   $
��auto��51      $��0,1,0,0q�52      .+�53      �� $��/Icons/IconPassword.png��6   $��32��54      $��32��55      G� 57      -   5         G�Name$ password��58       ! Password_DataInput_BotRounded#��[ 57      $ Password��59      5:      5;      �� 5=   
   -   5        $��Zaloguj��5=      $��5q�5>       �� 	IsDefault$
 True��5@      $	��164��5A      ���#40444B���#CACBCC$��0q�5D       5F       �� 
TargetType	 �� Property
 �� Value��%c   '��       �� 5G      " ��6   .�5H      �� 	 �@��CornerRadius$
 10��5I      5J      5K      5L      �� 5O   
   -   5        $��labelWrongLoginData��5O      $�� ��5P      $��Ariel)�5Q      
���  ��$��Center=�5S      5U      5W      