   M S B A M L   `   `   `  ����M  IKurs_BusinessLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Kurs_BusinessLayer.WindowHelpers Kurs_BusinessLayer.WindowHelpers  5   	   8    2Kurs_BusinessLayer.WindowHelpers.AddNewOrderWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:Kurs_BusinessLayer.WindowHelpers     5   	     � Title$  AddNewOrderWindow��5   	   $��407.816��6#   $��531.863��64   .��5	      � -   5        $��Grid1��5	      $��0,0,2,-5q�6   .+�5
   
   �� -   5        $��lbHeader��5
   :   $?��9Добавить заказ для клиента,ФИО:��6   $��arial)�6J   $��14(�6]   $
��Bold"�6k   $
��Left=�6}   $��
0,10,0,-10q�6�   �� 5   
   -   5        $��lbclient��5   p   
�������$��arial)�6�   $��14(�6�   $
��Bold"�6�   $
��Left=�6�   $��254,10,0,341q�6�   $	��260��6�   ��6&   �� *client+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $��Выбрать рейс:��6   $��28��6(   $
��Left=�64   $��	10,70,0,0q�6O   $	��Top=�6b   $	��133��6z   �� 5   
   -   5         ��Name$ cbRoute��5      $
��Left=�6�   $��
143,70,0,0q�6�   $	��Top=�6�   $	��350��6�   $��28��6�   ��6$   �� *Trips+ �� SelectedItem 6B   �� *SelectedTrip+$ OneWayToSource=�$ PropertyChanged=�6�   �� 5   
   $��Цена рейса:��6   $��28��6&   $
��Left=�62   $��
10,131,0,0q�6M   $	��Top=�6a   $	��133��6y   �� 5   
   $��arial)�6�   $��14(�6�   $
��Bold"�6�   $
��Left=�6�   $��143,128,0,223q�6�   $	��106��6�   ��6   �� *Priceoftrip+$ OneWay=�$ PropertyChanged=� �� NotifyOnSourceUpdated . 6�   �� 5   
   -   5        $��button2��5   �   $��OK��6   $��22��6   $
��Left=�6*   $��128,207,0,0q�6k   $	��Top=�6�   $��76��6�    J� RenderTransformOrigin$ -0.178,0.663&�6�   ��6E   �� *OkAddOrderCommand+6�   5      5      