   M S B A M L   `   `   `  ����M  IKurs_BusinessLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Kurs_BusinessLayer.WindowHelpers Kurs_BusinessLayer.WindowHelpers  5   	   7    1Kurs_BusinessLayer.WindowHelpers.AddNewCityWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:Kurs_BusinessLayer.WindowHelpers     5   	     � Title$  AddNewCityWindow��5   	   $��162.295��6"   $��352.459��63   .��5	      � -   5        $��Grid1��5	      .+�5
   
   �� -   5        $��lbHeader��5
   )   $!��Добавить город��6   $��arial)�69   $��14(�6L   $
��Bold"�6Z   $
��Left=�6l   �� 5   
   -   5        $��lbName��5   e   $$��Название города:��6   $��28��6+   $
��Left=�67   $��	10,25,0,0q�6R   $	��Top=�6s   $	��112��6�   �� 5   
   -   5        $��tbName��5   M   $��28��6   $
��Left=�6   $��
137,25,0,0q�69   $	��Top=�6[   $	��175��6s   .��6   ��5      �� 5       �� Path$
 Name�6    �� UpdateSourceTrigger$ PropertyChanged=�6&    �� Mode$ OneWayToSource=�6L   5      .��5      5      �� 5   
   -   5        $��button1��5   ]   $��Cancel��6   $��23��6"   $
��Left=�6.   $��
196,83,0,0q�6I   $	��Top=�6�   $��75��6�    J� RenderTransformOrigin$ -0.178,0.663&�6�   ��6l   �� *CancelAddCityCommand+6�   �� 5   
   -   5        $��button2��5   }   $��OK��6   $��23��6   $
��Left=�6*   $��	47,83,0,0q�6j   $	��Top=�6�   $��75��6�   $ -0.178,0.663&�6�   ��6E   �� *OkAddCityCommand+6�   5      5      