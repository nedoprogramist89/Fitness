   M S B A M L   `   `   `  ����
  Fitnes    Fitnes.AdminTechnique   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   _ [MaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$+  %Управление техникой��5   	    � WindowState$ 	Maximized=�6%   ���	#FFFDEFD4$
��1080��6T   $
��1080��6b   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $��* �6    � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��1* �6   .+�5   
   ]� ��.  ���#FFF8DC$��50��6?   $��Center=�6K   $��2��6f   .+�5      �� -   5         � ToolTip$1 +MaterialDesignFloatingActionSecondaryButton��5      $��55��5      $��50��5      ���#FCC874{�5      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�.��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowLeft=�6*   5      �� 5      $��Center=�5      $��16(�5      $��SemiBold"�5       ���#CCA15D$
��10,0q�5"      �� 6   $+�%Управление техникой��6    6>   �� 5#      -   5        $1 +MaterialDesignFloatingActionSecondaryButton��5%      $��Right=�5'      $��60��5(      ���#FCC874$��50��5*      {�5$      �� *DataContext.ControlsEnabled+ �� " � �� Mode$ FindAncestor=�.��5+        $ DeleteOutline=�5,      $��31��5-      $��55��5.      $��Center=�5/      $��Center=�50      51      52      &   System.Windows.Controls.DataGrid  54   
   -   5        	  Name$	 dgrdTechnique��54   k   $��1��6   $��0��6    $��	0,0,20,20q�60   ���#FFE9A3
   
IsReadOnly
 .    AutoGenerateColumns .  ��55      �� *
Techniques+ �� SelectedItem 66   �� *SelectedTechnique+ �� Mode$ TwoWay=�   Columns 56      0  *System.Windows.Controls.DataGridTextColumn  57      ,  &System.Windows.Controls.DataGridColumn   Header$ Номер техники��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *TechnicianNumber+  58      $% Название техники��6%    6?   �� *TechniqueName+  59      $! Модель техники��6%    6=   �� *TechniqueModel+  5:      $ Год выпуска��6%    6:   �� *YearOfManufacture+  5;      $% Стоимость аренды��6%    6?   �� *
RentalCost+  5<      $ Состояние��6%    68   �� *States.States1+5>      � 5@   
   $��1��6   $��1��6   $��10q�6,    5A      �� 5B      $��* �6    .+�5E      �� $	��Top=�6   $��10q�61   .+�5F      �� -   5         ��Name$ TextBoxTechnicianNumber��5F      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Номер техники��6;   $��30��6j   $	��0,5q�6v   
�������
�������6�   �� 5G      -   5        $ TextBoxTechniqueName��5G      $% Название техники��68   $��30��6j   $	��0,5q�6v   
�������
�������6�   �� 5H      -   5        $ TextBoxTechniqueModel��5H      $! Модель техники��69   $��30��6i   $	��0,5q�6u   
�������
�������6�   �� 5I      -   5        $ TextBoxYearOfManufacture��5I      $ Год выпуска��6<   $��30��6i   $	��0,5q�6u   
�������
�������6�   �� 5J      -   5        $ TextBoxRentalCost��5J      $% Стоимость аренды��65   $��30��6g   $	��0,5q�6s   
�������
�������6�   �� 5K      -	   5         ��Name$ ComboBoxState��5M      $ Состояние��5L      $	��0,5q�5N       "  MaterialDesignOutlinedComboBox#��[  5O      
������� �� DisplayMemberPath$ States1��5Q       �� SelectedValuePath$ ID_State��5R       �� SelectedValue 5S      �� *
State_ID+�� 5V      -
   5        $��Добавление��5V      $��40��6.   $��0,20,0,0q�6:   ���#FCC874$��16(�6a   $
��Bold"�6o   $��0q�6�   
���   �6�   �� 5W      -   5        $��Изменение��5W      $��40��6-   $��0,20,0,0q�69   ���#FCC874$��16(�6`   $
��Bold"�6n   $��0q�6�   
���   �6�   �� 5X      -   5        $��Удаление��5X      $��40��6,   $��0,20,0,0q�68   ���#FCC874$��16(�6_   $
��Bold"�6m   $��0q�6   
���   �6�   5Y      5Z      5[      5\      