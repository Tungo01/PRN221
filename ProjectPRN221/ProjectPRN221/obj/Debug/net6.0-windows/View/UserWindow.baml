   M S B A M L   `   `   `  ????H  DProjectPRN221, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ProjectPRN221.ViewProjectPRN221.View  5   	   #    ProjectPRN221.View.UserWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:ProjectPRN221.View     5   	   _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5          ?Name$  window??5   	      MaterialDesignBody#???   5
   	   $??Regular"?5   	   $??13(?5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=?5   	      TextRenderingMode$
 Auto=?5   	     MaterialDesignPaper#???  5   	     MaterialDesignFont#???  5   	    ? 
ResizeMode$ NoResize=?5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? Title$ 
UserWindow??5   	   $	??450??6   $	??500??6)   .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??auto ?6   6,   ?? 5      6   .+?5   
   ? $??1??6    5       ?? 5!      $
??auto ?6    60   ?? 5"      $
??auto ?6    60   ?? 5#      6"   .+?5'      #  MaterialDesignThemes.Wpf.Card  $??0??6"   $??5q?6/   .??5(      ? $??0 5 0 10q?6   .+?5)      ?? $	??120??6`   $??5 5 15 5q?6l   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Name??6~    % !MaterialDesignFloatingHintTextBox#??[ 6?   ??6   ?? *DisplayName+ ?? UpdateSourceTrigger$ PropertyChanged=?6?   ?? 5*      $	??120??6]   $??5 5 15 5q?6i   $ UserName??6{   #??[ 6?   ??6   ?? *
UserName+$ PropertyChanged=?6?   ?? 5+      $	??120??6?   $??5 5 15 5q?6?   	 ?? 
IsEditable$
	 True??6?   $
 Role??6?    & "MaterialDesignFloatingHintComboBox#??[ 6?   ??6   ?? *Role+
 ?? SelectedItem
 6<   ?? *SelectedRole+ ?? Mode$ TwoWay=?$ PropertyChanged=?6?   5,      5-        5/      $??1??6"   $??5q?6/   .??50      ? .+?51      ?? $	??Add??6<   $??5q?6J   $	??150??6U   ??6   ?? *
AddCommand+6c   ?? 52      $??Update??6?   $??5q?6P   $	??150??6[   ??6   ?? *UpdateCommand+6i   ?? 53      $??Delete??6?   $??5q?6P   $	??150??6[   ??6   ?? *DeleteCommand+6i   ?? 54      $??Change Password??6G   $??5q?6a   $	??150??6l   ??6   ?? *ChangePasswordCommand+6z   55      56        59      $??2??6"   $??5q?6/   $??Stretch=?6:   .??5:      ?? $
??Auto=?6   .??5;      ?? ??6   ?? *List+
 6<   ?? *SelectedItem+$ OneWayToSource=? ?? View 5<      ?? 5=      .P?5>   "   ?? $??Id??61    ?? DisplayMemberBinding 6=   ?? *Id+6c   ?? 5?   "   $
??Name??61    6?   ?? *DisplayName+6n   ?? 5@   "   $??UserName??61    6C   ?? *
UserName+6o   ?? 5A   "   $
??Role??61    6?   ?? *Role.DisplayName+6s   5B      5D      5E      5F      5G      5H      5I      