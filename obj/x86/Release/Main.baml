   M S B A M L   `   `   `  ���� E  ACrazyStorm, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:CrazyStorm
CrazyStorm      CrazyStorm.Main   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     *localclr-namespace:CrazyStorm     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Cef4http://schemas.microsoft.com/expression/2010/effects       � Title$  Crazy Storm�� � WindowStartupLocation$ CenterScreen=� � WindowState$ Normal=� � Icon$ icon.ico��{�. $
��1024��$	��768�� � DataContext ��  � 	Resources #   CrazyStorm.LayerIconConverter   LayerIconConverter#   CrazyStorm.LayerAxisConverter  LayerAxisConverter$  CrazyStorm.LayerStartConverter  LayerStartConverter%  CrazyStorm.LayerLengthConverter  LayerLengthConverter'  !CrazyStorm.ResourceValidConverter  ResourceValidConverter �� 
TargetType �� Triggers P� Property	 P� Value
 �� Property �� Value �� 	Resources �� Color �� Path �� RelativeSource �� Mode �� AncestorType �� AncestorLevel �� 
TargetType �� Padding J� SnapsToDevicePixels �� ContentStringFormat �� ContentStringFormat �� Triggers �� 
TargetName C� ResourceKey ]� 
Conditions �� Property �� Value �� CornerRadius  CanCloseStyle  ComponentItem �� ImageSource  j� TileMode! j� Viewbox" �� 	Converter# �� Left
$ �� Top% J� Opacity  DelComponent& �� Text  UpComponent 	 DownComponent 
 LeftComponent  RightComponent  	SelectAll  Undo  Redo��%�	  &	        &	      &	 
     &	      &	      '��      '�� ]     '�� 	    &	 L    &	     7  &	     &	 3    &		 J    &	
 c    &	 |    &	 �    &	 �    &	 �              �� " �� P�  � {�	 .  . ��� 
 �@J�Opacity$	 0.4Q��� " �� ���� $ 	#00FFFFFF��(��       *SystemColors.ControlBrushKey+)�� $ 
 #00FFFFFF��(��       * SystemColors.HighlightBrushKey+).��� 
 � �� �	#00FFFFFF�� 
 � �� �� $  HorizontalContentAlignment� �� $ FindAncestor=�$ ItemsControlL�$ 1���� 
 � �� �� $ VerticalContentAlignment� �� $ FindAncestor=�$ ItemsControlL�$ 1���� 
 � ��$ 2,0,0,0q��� 
 � �� �� " ��.R��� $��Bd��#��z��# z��#��z��#��z�� . ._��� #��z��#��z��# z #��z��#��z��# z  P�  �@��
IsSelected	 . . ��� $ Bd��
 � �� �	#00FFFFFF�� 
 � �� C� # Z��]�  ��  �@��
IsSelected . ��  �@��IsSelectionActive .  ./��� $ Bd��
 � �� �	#00FFFFFF�� 
 � �� C� # Z��P�  � {�	 .  . ��� 
 � �� C� # Z��P�  �@J�IsMouseOver	 . . ��� $ Bd��
 � �� �	#00FFFFFF�� " ��.��� 
 � �� �� " ��.R�� .+��� $��bd��#��z�����#8C8E94$��1q�$ 1,1,0,0��$��0,0,0,0q�._��� $��Header��$	��8,1q� P�  �@��
IsSelected	 . . ��� $ bd��
 � ��
 ������� $ bd��
 � ��$ 0q�P�  �@J�IsMouseOver	 . . ��� $ bd��
 � ��
 ������� " ��.��� 
 � �� �� " ��.R�� .+��� $��bd��#��z�����#8C8E94$��1q�$ 1,1,0,0��$��0,0,0,0q�._�]� .+��� $	��8,1q�$
��Left=����� *Name+�� $��TabClose��-   $��Images/close.png��$��11��$��11��$��0,0,5,0q�$��Center=�$��Right=�$��Right=� P�  �@��
IsSelected	 . . ��� $ bd��
 � ��
 ������� $ bd��
 � ��$ 0q�P�  �@J�IsMouseOver	 . . ��� $ bd��
 � ��
 ������� .R��� .+��� $��Frame��$��32��$��32������ $ Images/layercolor.png��$  FlipY=�! �� $ Color�8"   �� $
��Icon��$# 2��$$ 2��$��Uniform=�$��28��$��28���� $	��Box��$% 0Q�$��Images/aimBox.png��$��32��$��32���� $& DelComponent���� $& UpComponent���� $& DownComponent���� $& LeftComponent���� $& RightComponent���� $& 	SelectAll���� $
& Undo���� $
& Redo��' J� InputBindings' �� 
( �� Key$( Delete��) �� Command#) [ �� $( W��#) [ �� $( S��#) [	 �� $( A��#) [
 �� $( D��#) [ �� * �� 	Modifiers$* Controlf�$( A��#) [ �� $* Controlf�$( Z��#) [ �� $* Controlf�$( Y��#) [ + J� CommandBindings+ )  #System.Windows.Input.CommandBinding  -   ,   Command#, [   -   #, [   -   #, [	   -   #, [
   -   #, [   -   #, [   -   #, [   -	   #, [ .��]� -
   $��
dockPanel1��$
��Auto��$
��Auto��.+�o� -   $��menu1��$��23��$
��Auto��$	��Top=�$��2,0,0,0q�{�. ���� - �� EndPoint$- 0.5,1&�. �� 
StartPoint$. 0.5,0&�.��� / � Color$/ White��0 � Offset$0 0Q�� $/ 	#FFE8E8E8��$0 1Q�.@�m� $��文件��.@�m� $��新建��m� $��打开��m� $��保存��1 m� InputGestureText$1 Ctrl+S��m� $��另存为...��$1 Ctrl+Shift+S���� m� -   $��屏幕设置���� m� $��退出��m� $��编辑��.@�m� -   $��UndoItem��$��撤销��$1 Ctrl+Z��m� -   $��RedoItem��$��恢复��$1 Ctrl+Y���� m� -   $��CutItem��$��剪切��$1 Ctrl+X��m� -   $��CopyItem��$��复制��$1 Ctrl+C��m� -   $��	PasteItem��$��粘贴��$1 Ctrl+V���� m� $��查找��$1 Ctrl+F��m� -   $��选中全部��$1 Ctrl+A��m� $��资源��.@�m� -   $��添加图案��m� $��添加音效��m� $��添加脚本��m� -   $��ParticleMenu��$��粒子��.@�m� -   $��AddParticleItem��$��添加粒子��m� -   $��DeleteParticleItem��$��删除粒子���� m� -   $��CopyParticleItem��$��复制粒子���� m� -   $��SetParticleItem��$��粒子设置��m� -   $��	LayerMenu��$��图层��.@�m� -   $��AddLayerItem��$��添加图层��m� -   $��DeleteLayerItem��$��删除图层���� m� -   $��CopyLayerItem��$��复制图层���� m� -   $��SetLayerItem��$��图层设置��m� $��组件��.@�m� -   $��DeleteComponentItem��$��删除组件��$	1 Del���� m� -   $��BindComponentItem��$��组件绑定��$1 Ctrl+B��m� -    $��UnbindComponentItem��$��组件解绑��$1 Ctrl+N��m� $��测试��.@�m� $��测试当前粒子��$1 F5��m� $��测试所有粒子��$	1 F10���� m� $��测试设置��m� $��帮助��.@�m� $��教程��$1 F1��m� $��关于���� $��23��$
��Auto��$��Bottom=����	#FFE4E4E4$��1,0,6,0q�.@��� -!   $��
StatusText�����	#FFF9F9F9���� $ Status�c� -"   $��ToolBar��$��34��$
��Auto��$	��Top=�$��Stretch=�2 J� 	AllowDrop2 .  ���� $- 0.5,1&�$. 0.5,0&�.��� $/ White��$0 0Q�� $/ 	#FFF6F6F6��$0 1Q�.@��� -#   $��	NewButton��3 �� 	IsDefault3 .  4 �� IsCancel4 .  $��Stretch=�$��Stretch=�5 � ToolTip$5 新建��.���� $��Images/document-new-3.ico��$
��None=��� -$   $��
OpenButton��3 .  4 .  $��Stretch=�$��Stretch=�$5 打开��.���� $ ��Images/document-open-2.ico��$
��None=��� -%   $��
SaveButton��3 .  4 .  $��Stretch=�$��Stretch=�$5 保存��.���� $ ��Images/document-export.ico��$
��None=��� �� -&   $��	CutButton��3 .  4 .  $��Stretch=�$��Stretch=�$5 剪切��.���� $��Images/edit-cut-3.ico��$
��None=��� -'   $��
CopyButton��3 .  4 .  $��Stretch=�$��Stretch=�$5 复制��.���� $��Images/edit-copy-3.ico��$
��None=��� -(   $��PasteButton��3 .  4 .  $��Stretch=�$��Stretch=�$5 粘贴��.���� $��Images/edit-paste-3.ico��$
��None=��� -)   $��
FindButton��3 .  4 .  $��Stretch=�$��Stretch=�$5 查找��.���� $��Images/edit-find-5.ico��$
��None=��� �� -*   $��
UndoButton��3 .  4 .  $��Stretch=�$��Stretch=�$5 撤销��.���� $��Images/edit-undo-3.ico��$
��None=��� -+   $��
RedoButton��3 .  4 .  $��Stretch=�$��Stretch=�$5 恢复��.���� $��Images/edit-redo-3.ico��$
��None=��� �� -,   $��
PlayButton��3 .  4 .  $��Stretch=�$��Stretch=�$5 测试��.���� $��Images/arrow-right-3.ico��$
��None=��� --   $��SettingButton��3 .  4 .  $��Stretch=�$��Stretch=�$5 设置��.���� $��Images/configure-5.ico��$
��None=�� $
��Auto��$
��Auto��6 � RowDefinitions6 �� �� $	��126 �7 � ColumnDefinitions7 �� .+�� $��0��6 �� 7 �� $	��230 ��� .+��� -.   $��gridSplitter3��$��Right=�$��1�����	#FFDBDBDB{�.  �� $��1��$
��Auto=�$
��Auto=�.���� -/   $��ParticleTabControl������ $- 0.5,1&�$. 0.5,0&�.��� $/ 	#FFD4D4D4��$0 0Q�� $/ White��$0 1Q����� .R��� $��Screen��-0   ���� $ ScreenWidth����� $ ScreenHeight����� $ Black��.+��� ���� $ ScreenWidth����� $ ScreenHeight����� 8 j� Stretch$8 Uniform=� �� $ 	ImagePath�.+��� $
��Grid��$$ 0��$# 0������ $ ScreenWidth����� $ ScreenHeight����� $ Images/grid.png��$8 Uniform=�$
  Tile=�9 j� ViewportUnits$9 Absolute=�: j� Viewport$: 	0,0,32,32�% �� $ GridAlignment��� $��Images/center.png��$��65��$��65��$
��Fill=�; J� RenderTransformOrigin$; 0.5,0.5&�z�V� .~��� �� �� T� < T� X$	< -33Q�= T� Y$	= -33Q�# �� $ ScreenWidthOver2�$ �� $ ScreenHeightOver2�% �� $ CenterDisplay��� $��ComponentLayer��$$ 0��$# 0������ $ ScreenWidth����� $ ScreenHeight��� $��AimBox��$% 0Q�$��Images/aimBox.png��$��32��$��32���� $��SelectingBox��$��Images/selecting.png��$��0��$��0��$
��Fill=�]� ���	#FFF9F9F9.+��� -1   $��SelectedGroup��$��Bottom=�$��	已选中��$	��100�����	#FFC6C6C6$% 0Q����� $ Images/selectedgroup.png��$8 Uniform=�.���� }�. ���� .+��� -2   $��SelectedGroupImage��> �� BitmapScalingMode$> HighQuality=�$��Images/button1.png��$��42��$# 10��$$ 10��? J� Effect? 3  -System.Windows.Media.Effects.DropShadowEffect  @   ShadowDepth$@ 0Q�A   
BlurRadius$A 10Q�B   Opacity$	B 0.5Q��� -3   $��SelectedGroupType��$# 66��$$ 10���� -4   $��SelectedGroupName��$# 66��$$ 26��$��20(����� *Name+�� -5   $��SelectedGroupTip��$# 8��$$ 59�����	#FF8B8B8B�� -6   $��LeftTabControl��$��0,0,0,0q�$��Stretch=�$��Stretch=�.@��� -7   $��Frequent��$��组件��$��6,5,6,1q�.��]� -8   $��ComponentPanel��.+��� $	��Top=�$��	组件板��$	��Top=�$��60��$��Stretch=�$��Center=�$��Center=����	#FFC6C6C6.���� -9   $��stackPanel1��C �� Orientation$C 
Horizontal=�$��Center=�$��Center=�.+��� -:   $��MultiEmitter��$��32��$��32��$��0q�$��1,1,2,1q����	#00000000.���� -;   $��MultiEmitterImage��$> NearestNeighbor=�$��Images/button1.png��$��Uniform=�$5 多向发射器��$��28��$��28��D � UseLayoutRoundingD . �� -<   $��CurveEmitter��$��32��$��32��$��0q�$��1,1,2,1q���Z� .���� -=   $��CurveEmitterImage��$> NearestNeighbor=�$��Images/button2.png��$��Uniform=�$5 曲线发射器��$��28��$��28��D . �� ->   $
��Mask��$��0q�$��1,1,2,1q�$��32��$��32����Z� .���� -?   $��	MaskImage��$> NearestNeighbor=�$��Images/button3.png��$5 遮罩��$��28��$��28��D . �� -@   $��Rebound��$��32��$��32��$��0q�$��1,1,2,1q���Z� .���� -A   $��ReboundImage��$> NearestNeighbor=�$��Images/button4.png��$��Uniform=�$5 	反弹板��$��28��$��28��D . �� -B   $��Force��$��32��$��32��$��0q�$��1,1,2,1q���Z� .���� -C   $��
ForceImage��$> NearestNeighbor=�$��Images/button5.png��$��Uniform=�$5 力场��$��28��$��28��D . �� -D   $��Explorer��$��组件浏览器��$��Stretch=�$��Stretch=�.��R� -E   $��ComponentList��$��-2,1,1,1q�$��Stretch=�$��Stretch=�2 . ���� E �� ItemsSourceE �� *
Children+.R��� -F   ���� *Name+F � ContextMenuF �� .@�m� $��CopyComponent��-G   $��复制��m� $��DeleteComponent��-H   $��删除������ " �� �� G �� BindingG �� *HasOutStandingTask+H �� ValueH true.a��� 
 � ��
 � ����� G �� *HasOutStandingTask+	H false.a��� 
 � ��
 ��� ��� -I   $��Resource��$��资源��$��6,5,6,1q�.���� $
��Auto=�.���� .+��� $��图案��$	��131��$��0q�.��R� -J   $��	ImageList��$��	-12,1,1,1q�$
��Auto=�$
��Auto=�F �� .@�m� -K   $��AddImage��$��添加图案������ .R�]� F �� .@�m� $��DeleteImage��-L   $��删除��.+��� ���� $ Label����� $ Valid�#" [ 5 _� .���� $��Uniform=�$	��128��$	��128��I �� StretchDirection$
I Both=����� $ AbsolutePath��� $��音效��$	��131��$��0q�.��R� -M   $��	SoundList��$��	-12,1,1,1q�F �� .@�m� -N   $��AddSound��$��添加音效���� $��全局变量��$	��130��$��0q�.��R� -O   $��
GlobalList��$��	-12,1,1,1q�F �� .@�m� -P   $��	AddGlobal��$��添加全局变量��� $��1��J � ShowGridLinesJ .  $��0q�7 �� $	��220 ��� $��10 ��� .+�]� -Q   $��Layer��$��2��.+�]� -R   $��stackPanel2��$	��Top=�$��0q����� $- 0.5,1&�$. 0.5,0&�.��� $/ White��$0 0Q�� $/ 	#FFE0E0E0��$0 1Q�.+��� -S   $��label1��$��图层��$��28��$	��208��$��5,6,5,5q���Z� �� -T   $��NewLayer��$��12��$��12��$��Right=����� $ Images/layernew.png��$8 Uniform=�K j� 
AlignmentX$
K Left=�L j� 
AlignmentY$	L Top=�5 �� $��新建��R� -U   M R�Name$M 	LayerTree��
�������$��Disabled=����� .R�]� $��LayerElement��-V   $	��225��$��	-22,0,0,0q���Z� F �� .@�m� N m�Name$N LayerShortSetting��-W   $��设置��m� $N LayerShortCopy��-X   $��复制��m� $N LayerShortDelete��-Y   $��删除��.+��� O ��Name$O 	LayerDown��-Z   $��12��$��12��$��Right=����� $ Images/layerdown.png��$8 Uniform=�$
K Left=�$	L Top=��� $O LayerUp��-[   $��12��$��12��$��Right=����� $ Images/layerup.png��$8 Uniform=�$
K Left=�$	L Top=��� $O LayerVisible��-\   $��12��$��12��$��2,0,2,0q�$��Right=����� $ Images/layervisible.png��$8 Uniform=�$
K Left=�$	L Top=�% �� $ Visible��� $O 
LayerColor��-]   $��12��$��12��$��5,0,5,0q�$; 0.5,0.5&����� $ Images/layercolor.png��$
8 None=�$
K Left=�$	L Top=�! �� $ Color�#" [  �� P ��Name$P border��._��� ���� $
 Name�]� -^   $��TimeAxis��$��2��Q ^� 	Placement$Q Relative=�$��Disabled=����� $8 Uniform=�$ Images/rulerscale.png��$
  Tile=�$9 Absolute=�$: 
0,-2,30,16�5 _� -_   R _�Name$R axisTip��.���� .+��� -`   $��	TimeScale��$	��Top=�$��30��$��0q�$��Stretch=�$��Stretch=����� $ Images/ruler.png��$8 Uniform=�$
  Tile=�$: 	0,0,30,30�$9 Absolute=��� -a   $��	LayerAxis��$��0q�$	��Top=�$��	-3,-1,0,0q�$��Hidden=���Z� ��Z� ��Z� ���� .R��� $��16��$��0q�$	��Top=�$
��Left=����� $ Images/layercolor.png��$  FlipY=�! �� $ Color�#" [ ���� $ 
BeginFrame�#" [ ���� $ 
TotalFrame�#" [ �� -b   $��gridSplitter4��$��Stretch=�$��1��$��Right=����	#FFDBDBDB$��1��{�.  �� -c   $��gridSplitter1��$��1��$	��Top=�$��1��$��Stretch=�
�������{�.  