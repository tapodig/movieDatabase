   M S B A M L   `   `   `  ����H  DmovieDatabase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:movieDatabasemovieDatabase  5   	       movieDatabase.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:movieDatabase     5   	     � Title$  
MainWindow��5   	   $	��600��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��50 �6   �� 5      $	��400 �6   �� 5      .+�5   
   ]� .+�5      o� $	��Top=�6   .@�5      m� $��Program��6   .@�5      m� -   5         m�Name$ btLogin��5      $��Bejelentkezés��60   6G   m� 5      -   5        $ btAbout��5      $��Névjegy��60   6A   m� 5      -   5        $ btExit��5      $��	Kilépés��6/   6@   5      5      5      �� 5   
   -   5         ��Name$ kereso��5      $��1��6"   $��1��62   $��30��6?   �� 5!   
   -   5         ��Name$ 
keresoGomb��5!      $��Keresés��6%   $��70��67   $��30��6B   $��1��6N   $��2��6[   $
��Left=�6�   &   System.Windows.Controls.DataGrid  5"   
   -   5          Name$ dgGrid��5"   >   $��3��6N   $��0��6[      RowBackground
 ��ح�   AlternatingRowBackground
 �����$��15(�5%      ��5"   k   �� 5%        5&   
   -   5        $ dgGridActors��5&      $��2��6)   $��2��66   ��6F   ��   5'   
   -   5        $ dgGridGenres��5'      $��3��6)   $��2��66   ��6F   �� �� 5(   
   $��0��6   $��2��6%   .+�5)      �� -	   5        $��cover_image��5)      $��10q�6'   5*      �� 5,   
   $��1��6   $��2��6%   .+�5-      �� -
   5        	 ��Name$	 title��5-      $��Center=�6(   $	��Top=�6E   �� 5.      -   5        $	 description��5.   ;   $��18(�6   $
��Wrap=�6&   $	��Top=�6Q   �� 5/      -   5        $
	 year��5/   ;   $��18(�6   $
��Wrap=�6&   $	��Top=�6J   �� 50      -   5        $
	 time��50   ;   $��18(�6   $
��Wrap=�6&   $	��Top=�6J   �� 51      -   5        $	 language��51   ;   $��18(�6   $
��Wrap=�6&   $	��Top=�6N   �� 52      -   5        $	 director��52   ;   $��18(�6   $
��Wrap=�6&   $	��Top=�6N   54      r� 55   
   -   5        
 r�Name$
 trailer��55       r� LoadedBehavior$ Manual=�6(    r� Source$" trailers/Csúcsformában.mp4?�6@   $	��200��6d   $	��120��6r   $��1��6�   $��3��6�   56      57      