   M S B A M L   `   `   `  ����M  IKurs_BusinessLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Kurs_BusinessLayer.PagesKurs_BusinessLayer.Pages  5      (    "Kurs_BusinessLayer.Pages.OrderPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:Kurs_BusinessLayer.Pages     5        N� Title$  	OrderPage��5	      .��5      � $��0,0,-276,10q�6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   6.   �� 5      6!   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dGrid��5      $��1��6"      AutoGenerateColumns .     RowHeaderWidth$ 50Q�6l      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ OrderID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6|   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 66   �� 
 �� Path$
 OrderId� �� UpdateSourceTrigger$ PropertyChanged=�   	CellStyle 5      �� 5      .�5      ��  �� Property �@��TextAlignment �� Value$ Right=�6H   5      5        5      $ Клиент��6%   	 65   �� $
 Client�$ PropertyChanged=�  5      $ Рейс��6%   	 63   �� $

 Trip�$ PropertyChanged=�  5      $ 
Место��6%   	 64   �� $
 
SeatNumber�$ PropertyChanged=�  5      $ Статус��6%   	 65   �� $
 Status�$ PropertyChanged=�  5      $ Цена��6%   	 63   �� $
 
Trip.Price�$ PropertyChanged=�5      5       5!      