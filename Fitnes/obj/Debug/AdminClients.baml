   M S B A M L   `   `   `  ����
  Fitnes    Fitnes.AdminClients   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   _ [MaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$-  'Управление клиентами��5   	    � WindowState$ 	Maximized=�6&   ���#FFF8D6$	��780��6S   $
��1080��6c   .��5      �  � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $��* �6    � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��1* �6   .+�5   
   ]� ��.  ���#FFF8DC$��50��6?   $��Center=�6K   $��2��6f   .+�5      �� -   5         � ToolTip$1 +MaterialDesignFloatingActionSecondaryButton��5      $��55��5      $��50��5      ���#FCC874{�5      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�.��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowLeft=�6*   5      �� 5!      $-��'Управление клиентами��6   $��Center=�5"      $��16(�5#      $��SemiBold"�5$      ���#CCA15D$
��10,0q�5&      �� 5'      -   5        $1 +MaterialDesignFloatingActionSecondaryButton��5)      $��Right=�5+      $��60��5,      ���#FCC874$��50��5.      {�5(      �� *DataContext.ControlsEnabled+ �� " � �� Mode$ FindAncestor=�.��5/        $ DeleteOutline=�50   	   $��31��51   	   $��55��52   	   $��Center=�53   	   $��Center=�54   	   55      57      &   System.Windows.Controls.DataGrid  5:   
   -   5        	  Name$	 dgrdClients��5:   m   $��1��6   $��0��6    $��
10,0,10,20q�60   ���#FFE9A3
   
IsReadOnly
 .    AutoGenerateColumns .  ��5;      �� *	Clients+ �� SelectedItem 63   �� *SelectedClient+ �� Mode$ TwoWay=�   Columns 5<      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn   Header$' !Название компании��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *CompanyName+  5>      $ Телефон��6%    66   �� *PhoneNumber+  5?      $ 
Адрес��6%    64   �� *	Address+  5@      $ Email��6%    64   �� *Email+  5A      $# Контактное лицо��6%    6>   �� *ContactPersonName+  5B      $ Фамилия��6%    66   �� *ContactPersonSurname+  5C      $ Отчество��6%    67   �� *ContactPersonMiddlename+  5D      $! Номер договора��6%    6=   �� *ContractNumber+5F      � 5I   
   $��1��6   $��1��6   $��10q�6,    5J      �� 5K      $��* �6    .+�5O      �� $	��Top=�6   $��10q�61   .+�5Q      �� -   5         ��Name$ TextBoxCompanyName��5Q      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$' !Название компании��66   $��30��6i   $	��0,5q�6u   
�������
�������6�   �� 5R      -   5        $ TextBoxPhoneNumber��5R      $! Номер телефона��66   $��30��6f   $	��0,5q�6r   
�������
�������6�   �� 5S      -   5        $ TextBoxAddress��5S      $ Адресс��62   $��30��6Z   $	��0,5q�6f   
�������
�������6�   �� 5T      -   5        $ TextBoxEmail��5T      $ 
Почта��60   $��30��6W   $	��0,5q�6c   
�������
�������6�   �� 5U      -   5        $ TextBoxContactPersonName��5U      $ Имя��6<   $��30��6a   $	��0,5q�6m   
�������
�������6�   �� 5V      -	   5        $! TextBoxContactPersonSurname��5V      $ Фамилия��6?   $��30��6h   $	��0,5q�6t   
�������
�������6�   �� 5W      -
   5        $$ TextBoxContactPersonMiddlename��5W      $ Отчество��6B   $��30��6l   $	��0,5q�6x   
�������
�������6�   �� 5X      -   5        $ TextBoxContractNumber��5X      $! Номер договора��69   $��30��6i   $	��0,5q�6u   
�������
�������6�   �� 5\      -   5        $��Добавление��5\      $��40��6.   $��0,20,0,0q�6:   ���#FCC874$��16(�6a   $
��Bold"�6o   $��0q�6�   
���   �6�   �� 5]      -   5        $��Изменение��5]      $��40��6.   $��0,20,0,0q�6:   ���#FCC874$��16(�6a   $
��Bold"�6o   $��0q�6�   
���   �6�   �� 5^      -   5        $��Удаление��5^      $��40��6,   $��0,20,0,0q�68   ���#FCC874$��16(�6_   $
��Bold"�6m   $��0q�6   
���   �6�   5_      5`      5a      5b      