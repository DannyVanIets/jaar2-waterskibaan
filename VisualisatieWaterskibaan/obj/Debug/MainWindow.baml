   M S B A M L   `   `   `  ����S  OVisualisatieWaterskibaan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:VisualisatieWaterskibaanVisualisatieWaterskibaan  5   	   )    #VisualisatieWaterskibaan.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:VisualisatieWaterskibaan     5   	     � Title$  Waterskibaan��5   	   $	��450��6   $
��1500��6+   .��5	      � .+�5
   
   �� -   5         ��Name$ LabelAlleWachtrijen��5
      $����Er zitten 0/100 sporters in de wachtrij voor instructies.                
Er zitten 0/5 sporters in de instructiegroep.                
Er zitten 0/20 sporters te wachten op een lijn.��6-   $
��Left=�5   F   $��
240,10,0,0q�6a   $	��Top=�6u   $��59��6�   $	��315��6�   �� 5   
   -   5        $  LabelAantalSecondenVoorbij��5      $ ��Aantal seconden voorbij: 0��64   $
��Left=�6Y   $��
902,13,0,0q�6t   $	��Top=�6�   $��25��6�   $	��179��6�   �� 5   
   
���   �$��1q�6%   $
��Left=�69   $��59��6T   $��
240,10,0,0q�6`   $	��Top=�6t   $	��315��6�   �� 5   
   
���   �$��1q�6%   $
��Left=�69   $	��157��6T   $��
902,13,0,0q�6a   $	��Top=�6u   $	��282��6�   �� 5   
   -   5        $  LabelTotaalAantalBezoekers��5      $ ��Totaal aantal bezoekers: 0��64   $
��Left=�6Y   $��
902,63,0,0q�6t   $	��Top=�6�   $��27��6�   $	��282��6�   �� 5   
   -   5         ��Name$ watercirkel��5      $
��Left=�6&   $	��301��6A   $��
556,97,0,0q�6N   $	��Top=�6b   $	��315��6z   ���	#FF2A81FF6�   �� 5   
   -   5        $ LabeLijnvoorraad��5      $��15 lijn(en) op voorraad��6*   $
��Left=�6L   $��
902,38,0,0q�6g   $	��Top=�6{   $��30��6�   $	��179��6�   � 5   
   -   5         �Name$# ProgressBarWaitingInstruction��5      $
��Left=�6=   $��15��6X   $��	26,60,0,0q�6d   $	��Top=�6w   $	��200��6�    � Maximum$ 3Q�6�   �� 5   
   -   5        $ CanvasWaitingInstructions��5      $
��Left=�64   $	��200��6O   $��	26,75,0,0q�6\   $	��Top=�6o   $	��200��6�   ���	#FFECFF7F6�   �� 5   
   $��Instructie wachten��6   $
��Left=�6-   $��	26,13,0,0q�6H   $	��Top=�6[   $��47��6s   $	��224��6   $��24(�6�    J� RenderTransformOrigin$ 0.147,0.715&�6�   �� 5   
   -   5        $ CanvasInstructionGroep��5      $
��Left=�61   $��50��6L   $��
26,348,0,0q�6X   $	��Top=�6l   $	��250��6�   ���	#FFFFE3366�   � 5   
   -	   5        $  ProgressBarInstructieGroep��5      $
��Left=�6:   $��15��6U   $��
26,332,0,0q�6a   $	��Top=�6u   $	��250��6�   $ 4Q�6�   �� 5   
   $��Instructie groep��6   $
��Left=�6+   $��
26,285,0,0q�6F   $	��Top=�6Z   $��47��6r   $	��200��6~   $��24(�6�   $ 0.147,0.715&�6�   �� 5   
   -
   5        $ CanvasInstructieStarting��5      $
��Left=�63   $	��200��6N   $��307,198,0,0q�6[   $	��Top=�6p   $	��200��6�   ���	#FFFFA62F6�   �� 5   
   $��Instructie klaar��6   $
��Left=�6+   $��307,131,0,0q�6F   $	��Top=�6[   $��47��6s   $	��224��6   $��24(�6�   $ 0.147,0.715&�6�   � 5   
   -   5        $$ ProgressBarInstructionStarting��5      $
��Left=�6>   $��15��6Y   $��307,183,0,0q�6e   $	��Top=�6z   $	��200��6�   $ 3Q�6�   �� 5   
   -   5        $. (LabelTotaalAantalBezoekersMetRodeKleding��5      $1��+Totaal aantal bezoekers met rode kleding: 0��6B   $
��Left=�6x   $��
902,90,0,0q�6�   $	��Top=�6�   $��27��6�   $	��282��6�   �� 5   
   
���   �$��1q�6%   $
��Left=�69   $	��183��6T   $��910,227,0,0q�6a   $	��Top=�6v   $	��274��6�   ._�5      �� -   5        $ Top10LichsteKleuren��5      ���	#FFE5E5E5$��0.2,-0.8,-1.2,-1.6q�6I   5      �� 5    
   $��Lichste kleuren��6   $
��Left=�6*   $��931,175,0,0q�6E   $	��Top=�6Z   $��47��6r   $	��224��6~   $��24(�6�   $ 0.147,0.715&�6�   �� 5!   
   $��Lijnen��6   $
��Left=�6!   $��
658,38,0,0q�6<   $	��Top=�6P   $��47��6h   $��94��6t   $��24(�6   $ 0.147,0.715&�6�   �� 5"   
   -   5        $ LabelHoogsteScore��5"      $��Hoogste score: 0��6+   $
��Left=�6F   $��902,117,0,0q�6a   $	��Top=�6v   $��27��6�   $	��282��6�   �� 5#   
   -   5        $ LabelTotaalAantalRondjes��5#      $0��*Totaal aantal rondjes die worden gedaan: 0��62   $
��Left=�6g   $��902,143,0,0q�6�   $	��Top=�6�   $��27��6�   $	��282��6�   �� 5$   
   -   5        $ CanvasUniekeMoves��5$      $
��Left=�6,   $	��121��6G   $��1228,57,0,0q�6T   $	��Top=�6i   $	��256��6�   �� 5%   
   $��Unieke moves��6   $
��Left=�6'   $��1228,10,0,0q�6B   $	��Top=�6W   $��47��6o   $	��224��6{   $��24(�6�   $ 0.147,0.715&�6�   5&      5'      