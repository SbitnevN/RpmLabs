   M S B A M L   `   `   `  ����U  QMedRepairTrack.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullo<clr-namespace:MedRepairTrack.Application.RequestList.Request.MedRepairTrack.Application.RequestList.Request  5   	   B    <MedRepairTrack.Application.RequestList.Request.RequestEditor   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Nlocal<clr-namespace:MedRepairTrack.Application.RequestList.Request     5   	     � Title$  RequestEditor��5   	   $	��450��6   $	��371��6,   .��5
      �  � RowDefinitions 5   
   �� 5      $	��28* �6   �� 5      $	��48* �6   �� 5      $	��45* �6   �� 5      $	��58* �6   �� 5      $	��50* �6   �� 5      $	��84* �6   �� 5      $	��58* �6   �� 5      $	��41* �6   �� 5      $	��22* �6    � ColumnDefinitions 5   
   �� 5      $	��27* �6   �� 5      $	��26* �6   .+�5   
   �� $��28��6   ${�False��6   $��1��60    �� TextWrapping$
 Wrap=�6=   $��Center=�6i   $��	10,0,10,0q�6�   ��6Q   �� *Number+6�   �� 5   
   $��28��6   ${�False��6   $��3��60   $
 Wrap=�6=   $	��Top=�6y   $��
10,15,10,0q�6�   ��6Q   �� *	Equipment+ �� Mode$ OneWay=�6�   �� 5   
   $��28��6   ${�False��6   $��4��60   $
 Wrap=�6=   $	��Top=�6t   $��	10,5,10,0q�6�   ��6Q   �� *User+$ OneWay=�6�   �� 5   
   $��5��6   $
 Wrap=�6   $��10,10,10,10q�6P   ��63   �� *Description+6P   �� 5    
   $��1��6   $��
Номер��6    $��
10,11,10,0q�60   $��1��6D   $	��Top=�6Q   $��26��6i   �� 5!   
   $��1��6   $��Дата��6    $��
10,10,10,0q�6/   $��2��6C   $	��Top=�6P   $��26��6h   �� 5"   
   $��1��6   $��Описание��6    $��10,13,10,10q�63   $��5��6H   �� 5#   
   $��1��6   $��Статус��6    $��
10,14,10,0q�61   $��6��6E   $��26��6R   $	��Top=�6^   �� 5$   
   -   5        $��1��5$      $-��'Выбрать пользователя��6!   $��Center=�6@   $��4��6]   $	��Top=�6j   $	��162��6�   $��36��6�   $��0,1,0,0q�6�   6�   �� 5%   
   -   5        $��1��5%   j   $-��'Выбрать оборудование��6z   $��3��6�   $��0,10,0,0q�6�   $��Center=�6�   $	��162��6�   $��36��6�   $	��Top=�6�   {�6   ��  �� RelativeSource ��  �� AncestorType
 Window �� Path$ IsCreate�6  �� 5&   
   $��Center=�6   $��6��60   $	��Top=�6=   $	��169��6U   $��30��6a   $��0,14,0,0q�6m    �� SelectedItem 6   �� *RequestStatus+��6�   �� *RequestStatusValues+�� 5'   
   -   5        $
��Ок��5'      $��7��6   $��Center=�6+   $��21��6F   $��	10,0,10,0q�6R   6e   �� 5(   
   -   5        $��Отмена��5(      $��7��6"   $��Center=�6/   $��21��6J   $��7,0,7,0q�6V   $��1��6g   6w   (  "System.Windows.Controls.DatePicker  5)   
   $��2��6�   $	��Top=�6�   $��
10,11,10,0q�6�   {�6   ��  �� 
 Window$ IsCreate�	   SelectedDate	 6n   �� *Date+6�   5+      5,      