   M S B A M L   `   `   `  ????B  >Balance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Balance.View.WindowsBalance.View.Windows  5   	   5clr-namespace:Balance.ModelViewBalance.ModelView  5   	   %    Balance.View.Windows.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Balance.View.Windows     5   	   .mvclr-namespace:Balance.ModelView     5   	     ? Title$  
MainWindow??5	   	   $	??450??5
   	   $	??800??5   	   $	??450??5   	   $	??800??5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? 
ResizeMode$ CanResizeWithGrip=?5   	    ? WindowStyle$
 None=?5   	    ? AllowsTransparency . 
??????  ? DataContext 5      %  Balance.ModelView.MainViewModel  5   
   .??5      ??  ?? CornerRadius$ 
10 10 0 10??6   ??5   
   ?? 5       ?? Color$ #434242??6   ._?5   
   ]? .+?5      ? $??25??6   $	??Top=?6    ? ColumnDefinitions 5      ?? 5      $??* ?6'   ?? 5       $??75 ?6'   .+?5"      ?? -   5        
?????? 5"   F   ? 5#      $??1??6   $??Center=?6,   .+?5$      ?? ???#FED049???	#FFC8A335   UpperButtonMenu#??[  6n   ??6   ?? *HideApplication+6n   ?? 5%      ???#68B984???	#FF56946B#??[  6t   ??6   ?? *ChangeSizeApplication+6t   ?? 5&      ???#D23369???	#FF98224A#??[  6r   ??6   ?? *ExitFromApplication+6r   5(      5)      ?? 5+      $	??Top=?6   $??50??6*   $	??Top=?66   $
??10 0q?6N   $ 25??6\   ??5,      ?? 5-      $ #222222??6&   ._?50      ? $??Center=?6   $??Center=?69   .+?51      ?? $#??Список расходов??6F     
MenuButton#??[ 6`   ??6   ?? *ChangePageToExpenses+6`   ?? 52      $??Настройки??6F   #??[ 6Z   ??6   ?? *ChangePageToSettings+6Z   53      54      ? 55      $??Bottom=?6   $??25??6+   $??Bottom=?67   $
??Left=?6R   .+?56      ?? -   5        	 ??Name$
	 logs??56      ???#FFF$
??Left=?6=   57       ? 58      $??0 10 0 0q?59      
  ? NavigationUIVisibility$
 Hidden=?5:        ? Source 5;      ??  ?? Path$ MainPage? ?? Mode$ TwoWay=? ?? NotifyOnTargetUpdated . 5?      5@      5A      