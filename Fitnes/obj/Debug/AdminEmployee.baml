   M S B A M L   `   `   `  ����
  Fitnes    Fitnes.AdminEmployee   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   _ [MaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$3  -Управление сотрудниками��5   	    � WindowState$ 	Maximized=�6)   ���	#FFFDEFD4$	��780��6X   $
��1080��6h   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $��* �6    � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��1* �6   .+�5   
   ]� ��.  ���#FFF8DC$��50��6?   $��Center=�6K   $��2��6f   .+�5      �� -   5         � ToolTip$1 +MaterialDesignFloatingActionSecondaryButton��5      $��55��5      $��50��5      ���#FCC874{�5      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�.��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowLeft=�6*   5      �� 5      $��Center=�5      $��16(�5      $��SemiBold"�5      ���#CCA15D$
��10,0q�5!      �� 5"      $3�-Управление сотрудниками��6   5#      �� 5$      -   5        $1 +MaterialDesignFloatingActionSecondaryButton��5&      $��Right=�5(      $��60��5)      ���#FCC874$��50��5*   &   {�5%      �� *DataContext.ControlsEnabled+ �� " � �� Mode$ FindAncestor=�.��5+        $ DeleteOutline=�5,      $��31��5-      $��55��5.      $��Center=�5/      $��Center=�50      51      52      &   System.Windows.Controls.DataGrid  54   
   -   5        	  Name$	 dgrdEmployees��55      $��0��54      $��	0,0,20,20q�6#   ���#FFE9A3
   
IsReadOnly
 .    AutoGenerateColumns .  $��1��56   /      Columns 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn   Header$ Имя��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *EmployeeName+  59      $ Фамилия��6%    66   �� *EmployeeSurname+  5:      $ Отчество��6%    67   �� *EmployeeMiddlename+  5;      $ Телефон��6%    66   �� *PhoneNumber+  5<      $ Email��6%    64   �� *Email+  5=      $ Должность��6%    68   �� *JobTitle.JobTitle1+5?      � 5A   
   $��1��6   $��1��6   $��10q�6,    5B      �� 5C      $��* �6    .+�5F      �� $	��Top=�6   $��10q�61   .+�5G      �� -   5         ��Name$ TextBoxEmployeeName��5G      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Имя��67   $��30��6\   $	��0,5q�6h   
�������
�������6�   �� 5H      -   5        $ TextBoxEmployeeSurname��5H      $ Фамилия��6:   $��30��6c   $	��0,5q�6o   
�������
�������6�   �� 5I      -   5        $ TextBoxEmployeeMiddlename��5I      $ Отчество��6=   $��30��6g   $	��0,5q�6s   
�������
�������6�   �� 5J      -   5        $ TextBoxPhoneNumber��5J      $ Телефон��66   $��30��6_   $	��0,5q�6k   
�������
�������6�   �� 5K      -   5        $ TextBoxEmail��5K      $ 
Почта��60   $��30��6W   $	��0,5q�6c   
�������
�������6�   �� 5L      -	   5        $ TextBoxPassword��5L      $ Пароль��63   $��30��6[   $	��0,5q�6g   
�������
�������6�   �� 5M      -
   5         ��Name$ ComboBoxJobTitle��5N      $ Должность��5O      $	��0,5q�5P       "  MaterialDesignOutlinedComboBox#��[  5Q      
������� �� DisplayMemberPath$ 	JobTitle1��5S       �� SelectedValuePath$ ID_JobTitle��5T       �� SelectedValue 5U      �� *JobTitle_ID+5V      �� 5X      -   5        $��Добавление��5X      $��40��6.   $��0,20,0,0q�6:   ���#FCC874$��16(�6a   $
��Bold"�6o   $��0q�6�   
���   �6�   �� 5Y      -   5        $��Изменение��5Y      $��40��6-   $��0,20,0,0q�69   ���#FCC874$��16(�6`   $
��Bold"�6n   $��0q�6�   
���   �6�   �� 5Z      -   5        $��Удаление��5Z      $��40��6,   $��0,20,0,0q�68   ���#FCC874$��16(�6_   $
��Bold"�6m   $��0q�6   
���   �6�   5[      5\      5]      5^      