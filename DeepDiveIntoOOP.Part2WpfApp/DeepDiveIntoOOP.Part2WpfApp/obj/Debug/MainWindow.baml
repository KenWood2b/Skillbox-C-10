   M S B A M L   `   `   `  ����V  RDeepDiveIntoOOP.Part2WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:DeepDiveIntoOOP.Part2WpfAppDeepDiveIntoOOP.Part2WpfApp  5   	   ,    &DeepDiveIntoOOP.Part2WpfApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:DeepDiveIntoOOP.Part2WpfApp     5   	     � Title$-  'Управление клиентами��5   	   $	��450��6&   $	��800��63   .��5	      � .+�5   
   �� -   5         ��Name$ RoleSelector��5      $
��Left=�6Z   $	��Top=�6u   $	��120��6�   $��10q�6�   .@�5      �� $��Консультант��6   �� 5      $��Менеджер��6   5      �� 5   
   -   5         ��Name$ AddClientButton��5      $%��Добавить клиента��6*   $	��150��6E   $��30��6Q   $
��Left=�6]   $	��Top=�6x   $��	10,50,0,0q�6�   $y�	Collapsed=�6�   �� 5   
   -   5        $)��#Загрузить клиентов��5      $	��150��6.   $��30��6:   $
��Left=�6F   $	��Top=�6a   $��
10,100,0,0q�6y   6�   �� 5   
   -   5        $+��%Сохранить изменения��5      $	��150��6/   $��30��6;   $��Right=�6G   $	��Top=�6c   $��
0,100,10,0q�6{   6�   �� 5   
   -   5        $0��*Сортировать по фамилии��5      $	��150��62   $��30��6>   $��Right=�6J   $	��Top=�6f   $��	0,50,10,0q�6~   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ClientDataGrid��5         AutoGenerateColumns .  $��Stretch=�6G   $	��Top=�6e   $��10,150,10,10q�6}      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Фамилия��6%      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *
LastName+6S     5      $ Имя��6%    .  62   �� *	FirstName+6P     5      $ Отчество��6%    .  67   �� *
MiddleName+6V     5      $ Телефон��6%    66   �� *PhoneNumber+  5      $ Паспорт��6%    66   �� *PassportNumber+ 6Y   �� *
IsReadOnly+5       5!      5"      