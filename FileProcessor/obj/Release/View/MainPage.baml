   M S B A M L   `   `   `  ����   FileProcessor!    FileProcessor.View.MainPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     �Name$  frmApp�� � Title$ File Contacts Processor��$��364.644��$��657.741�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�.��� -    �Name$ frmMain��$��0,0,0,-2q� � ColumnDefinitions �� $
��323* ��� $
��327* ���
�  
� GradientOrigin$ 1,0.0&�.���  � Color$ 
WhiteSmoke�� � Offset$	 0.2Q�� $ DimGray��$	 0.5Q�� $ black��$	 1.5Q�	 � RowDefinitions	 �� $
��Auto ��� $��* ��� $
��Auto �.+��� -   
 ��Name$
 UserGrid��$��0,93,0,0q�$��2��$��2�����	#FF712204���� *	Records+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.��� $ Black��$ 0Q�� $ 	#FF203E2F��$ 1Q� �� View �� -   GrdContacts��.P��� $��
First Name�� �� Width$ 80�� �� DisplayMemberBinding �� *	FirstName+�� $��	Last Name��$	 100�� �� *
LastName+�� $��Address��$	 150�� �� *	Address+�� $��Phone Number��$	 100�� �� *PhoneNumber+�� -    ��Name$ btnOpenFile��$��	Load File��$��23��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��133��
����  �$
��Bold"�$��12(�$��Italic$���
�  
� Center$ 0.5,0.5&� 
� RadiusX$	 1.0Q� 
� RadiusY$	 1.0Q�.��� $ Yellow��$	 0.0Q�� $	 Red��$	 1.0Q�z�V� .~��� -   	scaButton�� �� ScaleX$ 1Q� �� ScaleY$ 1Q� �� CenterX$ 50Q� �� CenterY$ 25Q� � Triggers :�  :� RoutedEvent$ ButtonBase.Click��.[��� .���� .��U�  �� 
TargetName$ 	scaButton�� �� TargetProperty$ (ScaleTransform.ScaleX)�.\���  O� KeyTime$ 0:0:00.0�� O� Value$	 1.0Q��� $ 0:0:00.5��$	 2.0Q��� $ 0:0:01.0��$	 1.0Q�U� $ 	scaButton��$ (ScaleTransform.ScaleY)�.\��� $ 0:0:00.0��$	 1.0Q��� $ 0:0:00.5��$	 2.0Q��� $ 0:0:01.0��$	 1.0Q��� -   $ btnPrintFile��$��Print��$��Right=�$��0,60,144,39q�$��73��
�������$
��Bold"�$��12(�$��Italic$�$��1��{�.  ��
� $ 0.5,0.5&�$	 1.0Q�$	 1.0Q�.��� $	 red��$	 0.0Q�� $
 blue��$	 1.0Q�z�V� .~��� -   	rotButton��  �� Angle$  0Q�! �� CenterX$! 38Q�" �� CenterY$" 12Q� :� $ ButtonBase.Click��.[��� .���� .��U� $ 	rotButton��$ (RotateTransform.Angle)�.\��� $ 0:0:00.0��$	 0.0Q��� $ 0:0:00.5��$ 360.0Q�	� -	   # 	�Name$# optFrequency��$��By Frequency��$��1��$
��Left=�$��	225,6,0,0q�$	��Top=�$ d� 	IsChecked$
$ TrueY�	� -
   $# 	optCustom��$��	Grid View��$��1��$
��Left=�$��
225,45,0,0q�$	��Top=�	� -   $# optName��$��	Name List��$��1��$
��Left=�$��
225,65,0,0q�$	��Top=�	� -   $# 
optAddress��$��
By Address��$��1��$
��Left=�$��
225,25,0,0q�$	��Top=�