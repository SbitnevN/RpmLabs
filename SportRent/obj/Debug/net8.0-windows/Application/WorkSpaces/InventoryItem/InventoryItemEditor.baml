   M S B A M L   `   `   `  ����D  @SportRent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:SportRent.Application.ControlsSportRent.Application.Controls  5   	   H    BSportRent.Application.WorkSpaces.InventoryItem.InventoryItemEditor   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:SportRent.Application.Controls     5   	     � Title$  Редактор��5   	   $	��316��6   $	��303��6'   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��56* �6   �� 5      $	��45* �6   �� 5      $	��40* �6   �� 5      $	��47* �6   �� 5      $	��69* �6   �� 5      $	��43* �6   .+�5   
   �� -   5         ��Name$ AcceptButton��5      $��Принять��6'   $
��Left=�69   $��10,0,0,0q�6T   $��Center=�6f   $��91��6�   $��5��6�   $��20��6�   6�   �� 5   
   -   5        $ CancelButton��5      $��Отмена��6'   $��	202,0,0,0q�68   $��Center=�6K   $��5��6f   $��20��6s   $
��Left=�6�   $��91��6�   �� 5   
   $
��Left=�6   $��	10,24,0,0q�6-    �� TextWrapping$
 Wrap=�6@   $	��Top=�6j   $	��120��6�   $��18��6�   ��6T   �� *Name+6�   �� 5   
   $
��Left=�6   $��	10,12,0,0q�6-   $
 Wrap=�6@   $	��Top=�6q   $	��120��6�   $��1��6�   $��18��6�   ��6T   �� *Description+6�   �� 5   
   $
��Left=�6   $��10,0,0,0q�6-   $
 Wrap=�6?   $��Center=�6i   $	��120��6�   $��2��6�   $��18��6�   ��6S   �� *Size+6�   �� 5   
   $
��Left=�6   $��10,0,0,0q�6-   $
 Wrap=�6?   $��Center=�6j   $	��120��6�   $��3��6�   $��18��6�   ��6S   �� *Price+6�   �� 5   
   -   5         ��Name$ InventoryTypes��5      $
��Left=�6+   $��	10,15,0,0q�6F   $	��Top=�6Y   $	��120��6q   $��4��6}   $��22��6�    �� SelectedItem 6�   �� *
ItemType+��6�   �� *InventoryItemTypeValues+�� 5   
   $
��Left=�6   $��
135,24,0,0q�6/   $
��Wrap=�6C   $��Наименование��6W   $	��Top=�6k   $��18��6�   $	��134��6�   �� 5   
   $
��Left=�6   $��
135,12,0,0q�6/   $
��Wrap=�6C   $��Опысание��6W   $	��Top=�6g   $��18��6   $	��134��6�   $��1��6�   �� 5   
   $
��Left=�6   $��	135,0,0,0q�6/   $
��Wrap=�6B   $��Размер��6V   $��Center=�6d   $��18��6   $	��134��6�   $��2��6�   �� 5   
   $
��Left=�6   $��	135,0,0,0q�6/   $
��Wrap=�6B   $��Цена��6V   $��Center=�6b   $��18��6}   $	��134��6�   $��3��6�   5       5!      