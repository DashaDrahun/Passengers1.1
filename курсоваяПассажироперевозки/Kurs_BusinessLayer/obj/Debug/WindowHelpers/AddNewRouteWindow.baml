   M S B A M L   `   `   `  ����M  IKurs_BusinessLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Kurs_BusinessLayer.WindowHelpers Kurs_BusinessLayer.WindowHelpers  5   	   8    2Kurs_BusinessLayer.WindowHelpers.AddNewRouteWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:Kurs_BusinessLayer.WindowHelpers     5   	     � Title$  AddNewRouteWindow��5   	   $��274.483��6#   $��512.974��64   .��5	      � -   5        $��Grid1��5	      $��	0,0,-8,-7q�6   .+�5
   
   �� -   5        $��lbHeader��5
   +   $%��Добавить маршрут��6   $��arial)�6;   $��14(�6N   $
��Bold"�6\   $
��Left=�6n   �� 5   
   -   5        $��	lbCityDep��5   g   $(��"Город отправления:��6   $��28��6-   $
��Left=�69   $��	10,35,0,0q�6T   $	��Top=�6x   $	��133��6�   �� 5   
   -   5        $��	lbCityArr��5   f   $&�� Город назначения:��6   $��28��6,   $
��Left=�68   $��	10,85,0,0q�6S   $	��Top=�6w   $	��133��6�   �� 5   
   -   5        $
��lbKm��5   e   $!��Расстояние, км:��6   $��28��6*   $
��Left=�66   $��
10,133,0,0q�6Q   $	��Top=�6q   $	��133��6�   �� 5   
   -   5         ��Name$ 	cbCityDep��5       �� DisplayMemberPath$
 Name��6E   $
��Left=�6�   $��
168,35,0,0q�6�   $	��Top=�6�   $	��292��6�   $��28��6�   ��6&   �� *Cities+ �� SelectedItem 6^   �� *SelectedCityDep+ �� Mode$ OneWayToSource=�6�   �� 5   
   -   5        $ 	cbCityArr��5      $
 Name��6E   $
��Left=�6�   $��
168,85,0,0q�6�   $	��Top=�6�   $	��292��6�   $��28                   ��6�   ��6&   �� *Cities+ 6^   �� *SelectedCityArr+$ OneWayToSource=�6�   �� 5   
   -   5        $
��tbKm��5   �   $��28��6j   $
��Left=�6v   $��168,133,0,0q�6�   $	��Top=�6�   $	��292��6�   ��6   �� *Kilometress+$ OneWayToSource=� �� UpdateSourceTrigger$ PropertyChanged=�.��6�   5      �� 5   
   -	   5        $��button1��5   ^   $��Cancel��6   $��23��6"   $
��Left=�6.   $��284,202,0,0q�6I   $	��Top=�6�   $��75��6�    J� RenderTransformOrigin$ -0.178,0.663&�6�   ��6m   �� *CancelAddRouteCommand+6�   �� 5   
   -
   5        $��button2��5   �   $��OK��6   $��22��6   $
��Left=�6*   $��124,202,0,0q�6k   $	��Top=�6�   $��76��6�   $ -0.178,0.663&�6�   ��6E   �� *OkAddRouteCommand+6�   5      5      