   M S B A M L   `   `   `  ����X  TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit  5   	   M IKurs_BusinessLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Kurs_BusinessLayer.WindowHelpers Kurs_BusinessLayer.WindowHelpers 5   	   5   /Kurs_BusinessLayer.WindowHelpers.EditTripWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   NwpfTool:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:Kurs_BusinessLayer.WindowHelpers     5   	     � Title$  EditTripWindow��5	   	   $��407.816��6    $��531.863��61   .��5
      � -   5        $��Grid1��5
      $��0,0,2,-5q�6   .+�5   
   �� -   5        $��lbHeader��5   (   $��Добавить рейс��6   $��arial)�68   $��14(�6K   $
��Bold"�6Y   $
��Left=�6k   �� 5   
   $$��Выбрать маршрут:��6   $��28��6+   $
��Left=�67   $��	10,35,0,0q�6R   $	��Top=�6e   $	��133��6}   �� 5   
   $1��+Дата/время отправления:��6   $��28��62   $
��Left=�6>   $��	10,78,0,0q�6Y   $	��Top=�6l   $	��153��6�   �� 5   
   $+��%Дата/время прибытия:��6   $��28��6/   $
��Left=�6;   $��
10,129,0,0q�6V   $	��Top=�6j   $	��143��6�   �� 5   
   $"��Свободных мест:��6   $��28��6*   $
��Left=�66   $��
10,187,0,0q�6Q   $	��Top=�6e   $	��133��6}   �� 5   
   -   5        $
��lbKm��5   \   $��	Цена:��6   $��28��6    $
��Left=�6,   $��275,187,0,0q�6G   $	��Top=�6h   $��52��6�   �� 5   
   -   5         ��Name$ cbRoute��5      $
��Left=�6   $��
168,35,0,0q�6�   $	��Top=�6�   $	��292��6�   $��28��6�   ��6$   �� *Routes+ �� SelectedItem 6C   �� *SelectedRoute+ �� Mode$ OneWayToSource=�6�   &    Xceed.Wpf.Toolkit.DateTimePicker  5   
   -   5        $��dtpDtDep��5   !   &    Xceed.Wpf.Toolkit.DateTimeUpDown   FormatString$ HH:mm��6g   $
��Left=�6|   $	��Top=�6�   $��
168,82,0,0q�6�   $	��292��6�   $��24��6�   �   �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 61   ��  �� Path$ 	Departure�$ OneWayToSource=�5        5   
   -   5        $��dtpDtArr��5   !   $ HH:mm��6e   $
��Left=�6z   $	��Top=�6�   $��168,129,0,0q�6�   $	��292��6�   $��28��6�    61   �� $ Arrival�$ OneWayToSource=�5      �� 5   
   -   5        $��button1��5   ^   $��Cancel��6   $��23��6"   $
��Left=�6.   $��301,332,0,0q�6I   $	��Top=�6�   $��75��6�    J� RenderTransformOrigin$ -0.178,0.663&�6�   ��6m   �� *CancelEditTripCommand+6�   �� 5   
   -   5        $��button2��5   �   $��OK��6   $��22��6   $
��Left=�6*   $��143,333,0,0q�6k   $	��Top=�6�   $��76��6�   $ -0.178,0.663&�6�   ��6E   �� *OkEditTripCommand+6�   �� 5   
   -	   5         ��Name$ tbfreeseats��5   N   $��28��6   $
��Left=�6   $��168,187,0,0q�69   $	��Top=�6c   $��76��6{   ��6�   �� *	Freeseats+$ OneWayToSource=�	 �� UpdateSourceTrigger$	 PropertyChanged=��� 5   
   -
   5        $ tbprice��5   N   $��28��6   $
��Left=�6   $��362,187,0,0q�69   $	��Top=�6_   $��98��6w   ��6�   �� *Price+$ OneWayToSource=�$	 PropertyChanged=��� 5   
   $"��Выбрать статус:��6   $��28��6*   $
��Left=�66   $��
10,240,0,0q�6Q   $	��Top=�6e   $	��133��6}   �� 5   
   -   5        $ cbRoute_Copy��5      $
��Left=�6�   $��168,240,0,0q�6�   $	��Top=�6�   $	��292��6�   $��28��6�   ��6)   �� *
Statuses+ 6J   �� *SelectedStatus+$ OneWayToSource=�6�   5      5      