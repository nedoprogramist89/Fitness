   M S B A M L   `   `   `  ����
  Fitnes    Fitnes.AdminOrder   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   _ [MaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$+  %Управление заказами��5   	    � WindowState$ 	Maximized=�6%   ���	#FFFDEFD4$
��1080��6T   $
��1080��6b   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $��* �6    � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��1* �6   .+�5   
   ]� ��.  ���#FFF8DC$��50��6?   $��Center=�6K   $��2��6f   .+�5      �� -   5         � ToolTip$1 +MaterialDesignFloatingActionSecondaryButton��5      $��55��5      $��50��5      ���#FCC874{�5      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�.��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowLeft=�6*   5      �� 5      $��Center=�5      $��16(�5      $��SemiBold"�5      ���#CCA15D$
��10,0q�5!      �� 5"      $+�%Управление заказами��6   5#      �� 5$      -   5        $1 +MaterialDesignFloatingActionSecondaryButton��5&      $��Right=�5(      $��60��5)      ���#FCC874$��50��5*   &   {�5%      �� *DataContext.ControlsEnabled+ �� " � �� Mode$ FindAncestor=�.��5+        $ DeleteOutline=�5,      $��31��5-      $��55��5.      $��Center=�5/      $��Center=�50      51      52      &   System.Windows.Controls.DataGrid  54   
   -   5        	  Name$	 
dgrdOrders��55      $��1��54      $��0��6    $��	0,0,20,20q�60   ���#FFE9A3
   
IsReadOnly
 .    AutoGenerateColumns .     Columns 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn   Header$ Номер заказа��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *OrderNumber+  59      $ Клиент��6%    65   �� *Clients.CompanyName+  5:      $ Техника��6%    66   �� *Technique.TechniqueName+  5;      $ Дата выдачи��6%    6:   �� *DateOfIssue+  5<      $ Дата возврата��6%    6<   �� *
ReturnDate+  5=      $ Цена��6%    63   �� *Price+  5>      $ Статус заказа��6%    6<   �� *OrderStatus.OrderStatus1+  5?      $ Период аренды��6%    6<   �� *RentalPeriod+  5@      $ Сотрудник��6%    68   �� *Employees.EmployeeName+5B      � 5D   
   $��1��6   $��1��6   $��10q�6,    5E      �� 5F      $��* �6    .+�5I      �� $	��Top=�6   $��10q�61   .+�5J      �� -   5         ��Name$ TextBoxOrderNumber��5J      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Номер заказа��66   $��30��6d   $	��0,5q�6p   
�������
�������6�   �� 5K      -   5         ��Name$ ComboBoxClients��5M      $ Клиент��5L      $	��0,5q�5N       "  MaterialDesignOutlinedComboBox#��[  5O      
������� �� DisplayMemberPath$ CompanyName��5Q       �� SelectedValuePath$ 
ID_Clients��5R       �� SelectedValue 5S      �� *
Clients_ID+5T      �� 5U      -   5        $ ComboBoxTechnique��5W      $ Техника��5V      $	��0,5q�5X      #��[  5Y      
�������$ TechniqueName��5[      $ ID_Technique��5\       5]      �� *Technique_ID+5^      �� 5_      -   5        $ TextBoxDateOfIssue��5_      $ Дата выдачи��66   $��30��6c   $	��0,5q�6o   
�������
�������6�   �� 5`      -   5        $ TextBoxReturnDate��5`      $ Дата возврата��65   $��30��6d   $	��0,5q�6p   
�������
�������6�   �� 5a      -	   5        $ TextBoxPrice��5a      $ Цена��60   $��30��6V   $	��0,5q�6b   
�������
�������6�   �� 5b      -
   5        $ ComboBoxOrderStatus��5d      $ Статус заказа��5c      $	��0,5q�5e      #��[  5f      
�������$ OrderStatus1��5h      $ ID_OrderStatus��5i       5j      �� *OrderStatus_ID+5k      �� 5l      -   5        $ TextBoxRentalPeriod��5l      $ Период аренды��67   $��30��6f   $	��0,5q�6r   
�������
�������6�   �� 5m      -   5        $ ComboBoxEmployees��5o      $ Сотрудник��5n      $	��0,5q�5p      #��[  5q      
�������$ EmployeeName��5s      $ ID_Employees��5t       5u      �� *Employees_ID+5v      �� 5w      -   5        $��Добавление��5w      $��40��6.   $��0,20,0,0q�6:   ���#FCC874$��16(�6a   $
��Bold"�6o   $��0q�6�   
���   �6�   �� 5x      -   5        $��Изменение��5x      $��40��6-   $��0,20,0,0q�69   ���#FCC874$��16(�6`   $
��Bold"�6n   $��0q�6�   
���   �6�   5y      5z      5{      5|      