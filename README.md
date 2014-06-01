AnUn
====

Another Universe


Konzept - Schiffsaufbau:
Schiffe lassen sich aus gr��eren Teilen zusammen bauen. Gr��ere Teile w�ren Bug, Mittelsektion und Heck.
Diese Gr��eren Sektionen haben Einrichtungsslots, in welche man Schiffssysteme einbauen kann. Die Einrichtungsslots sind im Prinzip K�stchen.
Eine Bugsektion k�nnte also eine gewisse Form haben, die man optisch von au�en Sieht. Diese Form hat innen, von au�en nicht sichtbar, 3x2x2 Einrichtungsslots.
In seinem "Inventar" hat man verschiedene Schiffssysteme zur Verf�gung, die man erbeutet, oder hergestellt hat.
Als Beispiel hat man dort 2 Schildgeneratoren mit 2x1x1 Gr��e, 4 Lader�ume mit 1x1x1 Gr��e und 2 Maschinenraumeinheiten der Gr��e 2x1x1.
Diese kann man nach belieben �ber die verschiedenen slots verteilen. Liegen zwei Module gleicher Kategorie aneinander, so erhalten sie einen Effizientbonus.
Dadurch wird das Schiff aber anf�lliger gegen�ber gezieltem Beschuss, welcher zB die Schildgeneratoren gezielt lahm legen kann.

Zur technischen Realisierung:
Die gro�en Module bilden zusammen ein statisches Kollisionsmesh. Mit statisch ist gemeint, dass dies im Kampf nicht ver�ndert wird.
Im Kampf kann man seine Waffen auf Bereiche des gegnerischen Schiffes zielen lassen. Wird ein Schiff getroffen und Schilde und Panzerung durchdrungen wird ermittelt
welche internen Bereiche getroffen werden. Hat man das gegnerische Schiff ausreichend gescannt, wird einem angezeigt wo zB die Schildgeneratoren des Gegners sind
und man kann diese gezielt angreifen. Hat man den Gegner nicht gescannt kann man schlichtweg raten und auf irgendeine Stelle an der gegnerischen H�lle zielen,
ob man eine der gegnerischen internen Stationen getroffen hat sieht man dann entsprechend daran, dass der gegnerische Antrieb oder etwa die Schilde ausfallen.

Besch�digte Systeme k�nnen durch Reparaturcrews wiederhergestellt werden. Da man aber nur eine begrenzte Menge an Crew dabei hat muss man abwiegen,
welche Systeme Priorit�t haben. Ein System kann auch nur teilweise ausfallen, wenn die dazu geh�rigen R�ume nur leicht besch�digt sind.
Dadurch w�rden die Schilde zB an St�rke verlieren. Der Schaden an der strukturellen Integrit�t des Schiffes kann allerdings nicht so einfach repariert werden.
F�llt diese auf 0 gilt das Schiff als zerst�rt.