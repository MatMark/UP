   M S B A M L   `   `   `  ����D  @Bluetooth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Bluetooth	Bluetooth  5   	       Bluetooth.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Bluetooth     5   	     � Title$  
MainWindow��5   	   $��273.333��6   $��528.666��6-   .��5	      � $��0,0,3,0q�6    � ColumnDefinitions 5
   
   �� 5      $
��229* �6   �� 5      $
��324* �6   �� 5      $
��240* �6   .+�5   
   �� -   5         ��Name$ ListBoxAdapters��5      $
��Left=�6+   $��69��6F   $��9,36,0,0q�6R   $	��Top=�6d   $	��349��6|   $��2��6�   �� 5   
   -   5        $ ListBoxDevices��5      $
��Left=�6*   $��95��6E   $��	9,136,0,0q�6Q   $	��Top=�6d   $	��351��6|   $��2��6�   �� 5   
   -   5         ��Name$ ButtonRefresh��5      $��Scan adapters��6(   $
��Left=�6@   $��	24,36,0,0q�6[   $	��Top=�6n   $	��113��6�   $��2��6�   �� 5   
   -   5        $ ButtonChoose��5      $��Choose��6'   $
��Left=�68   $��	24,61,0,0q�6S   $	��Top=�6f   $	��113��6~   $��2��6�   �� 5   
   -   5        $ 
ButtonInfo��5      $
��Info��6%   $
��Left=�64   $��	24,86,0,0q�6O   $	��Top=�6b   $	��113��6z   $��2��6�   �� 5   
   -   5        $ ButtonConnect��5      $��Connect��6(   $
��Left=�6:   $��
26,186,0,0q�6U   $	��Top=�6i   $	��111��6�   $��2��6�   �� 5   
   -   5        $ ButtonDeviceInfo��5      $
��Info��6+   $
��Left=�6:   $��
26,161,0,0q�6U   $	��Top=�6i   $	��111��6�   $��2��6�   �� 5   
   -   5        $ ButtonSearch��5      $��Search for devices��6'   $
��Left=�6D   $��
26,136,0,0q�6_   $	��Top=�6s   $	��111��6�   $��2��6�   �� 5   
   -	   5         ��Name$ LabelDevices��5      $��Devices��6&   $
��Left=�68   $��9.333,110,0,0q�6S   $	��Top=�6j   $��1��6�   $��53��6�   �� 5   
   -
   5        $ LabelAdapters��5      $��Adapters��6'   $
��Left=�6:   $��2.333,10,0,0q�6U   $	��Top=�6k   $��1��6�   $��60��6�   � 5   
   $��1��6   $
��Left=�6   $	��100��6:   $��94.667,318,0,0q�6G   $	��Top=�6_   $	��100��6w   5      �� 5   
   -   5        $ ButtonChooseFile��5      $��Choose file��6+   $��2��6A   $
��Left=�6Q   $��
26,211,0,0q�6l   $	��Top=�6�   $	��111��6�   6�   5      5       