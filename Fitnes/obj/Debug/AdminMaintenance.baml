   M S B A M L   `   `   `  ����
  Fitnes    Fitnes.AdminMaintenance   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   _ [MaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$5  /Управление обслуживанием��5   	    � WindowState$ 	Maximized=�6*   ���	#FFFDEFD4$
��1080��6Y   $
��1080��6g   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $��* �6    � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��1* �6   .+�5   
   ]� ��.  ���#FFF8DC$��50��6?   $��Center=�6K   $��2��6f   .+�5      �� -   5         � ToolTip$1 +MaterialDesignFloatingActionSecondaryButton��5      $��55��5      $��50��5      ���#FCC874{�5      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�.��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowLeft=�6*   5      �� 5      $��Center=�5      $��16(�5      $��SemiBold"�5      ���#CCA15D$
��10,0q�5!      �� 5"      $5�/Управление обслуживанием��6   5#      �� 5$      -   5        $1 +MaterialDesignFloatingActionSecondaryButton��5&      $��Right=�5(      $��60��5)      ���#FCC874$��50��5*   &   {�5%      �� *DataContext.ControlsEnabled+ �� " � �� Mode$ FindAncestor=�.��5+        $ DeleteOutline=�5,      $��31��5-      $��55��5.      $��Center=�5/      $��Center=�50      51      52      &   System.Windows.Controls.DataGrid  54   
   -   5        	  Name$	 dgrdMaintenance��55      $��1��54      $��0��6    $��	0,0,20,20q�60   ���#FFE9A3
   
IsReadOnly
 .    AutoGenerateColumns .     Columns 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn   Header$' !Дата обслуживания��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *MaintenanceDate+  59      $ Тип работы��6%    69   �� *
TypeOfWork+  5:      $+ %Статус обслуживания��6%    6B   �� *&$MaintenanceStatus.MaintenanceStatus1+  5;      $ Техника��6%    66   �� *Technique.TechniqueName+5=      � 5?   
   $��1��6   $��1��6   $��10q�6,    5@      �� 5A      $��* �6    .+�5D      �� $	��Top=�6   $��10q�61   .+�5E      �� -   5         ��Name$ TextBoxMaintenanceDate��5E      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$' !Дата обслуживания��6:   $��30��6m   $	��0,5q�6y   
�������
�������6�   �� 5F      -   5        $ TextBoxTypeOfWork��5F      $ Тип работы��65   $��30��6a   $	��0,5q�6m   
�������
�������6�   �� 5G      -   5         ��Name$ ComboBoxMaintenanceStatus��5H      $+ %Статус обслуживания��5I      $	��0,5q�5J       "  MaterialDesignOutlinedComboBox#��[  5K      
������� �� DisplayMemberPath$ MaintenanceStatus1��5M       �� SelectedValuePath$ ID_MaintenanceStatus��5N       �� SelectedValue 5O      �� *MaintenanceStatus_ID+5P      �� 5Q      -   5        $ ComboBoxTechnique��5R      $ Техника��5S      $	��0,5q�5T      #��[  5U      
�������$ TechniqueName��5W      $ ID_Technique��5X       5Y      �� *Technique_ID+5Z      �� 5\      -   5        $��Добавление��5\      $��40��6.   $��0,20,0,0q�6:   ���#FCC874$��16(�6a   $
��Bold"�6o   $��0q�6�   
���   �6�   �� 5]      -	   5        $��Изменение��5]      $��40��6-   $��0,20,0,0q�69   ���#FCC874$��16(�6`   $
��Bold"�6n   $��0q�6�   
���   �6�   �� 5^      -
   5        $��Удаление��5^      $��40��6,   $��0,20,0,0q�68   ���#FCC874$��16(�6_   $
��Bold"�6m   $��0q�6   
���   �6�   5_      5`      5a      5b      