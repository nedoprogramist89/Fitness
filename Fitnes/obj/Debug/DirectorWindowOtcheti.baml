   M S B A M L   `   `   `  ����
  Fitnes"    Fitnes.DirectorWindowOtcheti   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   _ [MaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$-  'Формирование отчетов��5   	    � WindowState$ 	Maximized=�6&   ���	#FFFDEFD4$
��1080��6U   $
��1080��6c   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $��* �6    � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��1* �6   .+�5   
   ]� ��.  ���#FFF8DC$��50��6?   $��Center=�6K   $��2��6f   .+�5      �� -   5         � ToolTip$1 +MaterialDesignFloatingActionSecondaryButton��5      $��55��5      $��50��5      ���#FCC874{�5      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�.��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowLeft=�6*   5      �� 5      $��Center=�5      $��16(�5      $��SemiBold"�5      ���#CCA15D$
��10,0q�5!      �� 5"      $-�'Формирование отчетов��6   5#      5$      &   System.Windows.Controls.DataGrid  5'   
   -   5          Name$ dgrdReportData��5(      $��0��5'      $��	0,0,20,20q�6#   ���#FFE9A3	   
IsReadOnly	 . 
   AutoGenerateColumns
 . $��1��5(   F   � 5*   
   $��1��6   $��1��6   $��10q�6,    5+      �� 5,      $��* �6    .+�5/      �� $	��Top=�6   $	��196��62   $��
10,10,10,0q�6?   .+�50      �� -   5         ��Name$ ComboBoxReports��52      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Отчёты��51      $	��0,5q�53       "  MaterialDesignOutlinedComboBox#��[  54      
�������.@�57      �� $%��Загрузка техники��6#   �� 58      $��Доходы��6#   �� 59      $#��Состояние парка��6#   �� 5:      $1��+График техобслуживания��6#   �� 5;      $#��Договоры аренды��6#   5<      �� 5>      -   5        $)��#Сформировать отчет��5>      $��40��66   $��0,20,0,0q�6B   ���#FCC874$��16(�6i   $
��Bold"�6w   $��0q�6�   
���   �5?      5@      5A      5B      5C      