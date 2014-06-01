AnUn
====

Another Universe


Konzept - Schiffsaufbau:
Schiffe lassen sich aus größeren Teilen zusammen bauen. Größere Teile wären Bug, Mittelsektion und Heck.
Diese Größeren Sektionen haben Einrichtungsslots, in welche man Schiffssysteme einbauen kann. Die Einrichtungsslots sind im Prinzip Kästchen.
Eine Bugsektion könnte also eine gewisse Form haben, die man optisch von außen Sieht. Diese Form hat innen, von außen nicht sichtbar, 3x2x2 Einrichtungsslots.
In seinem "Inventar" hat man verschiedene Schiffssysteme zur Verfügung, die man erbeutet, oder hergestellt hat.
Als Beispiel hat man dort 2 Schildgeneratoren mit 2x1x1 Größe, 4 Laderäume mit 1x1x1 Größe und 2 Maschinenraumeinheiten der Größe 2x1x1.
Diese kann man nach belieben über die verschiedenen slots verteilen. Liegen zwei Module gleicher Kategorie aneinander, so erhalten sie einen Effizientbonus.
Dadurch wird das Schiff aber anfälliger gegenüber gezieltem Beschuss, welcher zB die Schildgeneratoren gezielt lahm legen kann.

Zur technischen Realisierung:
Die großen Module bilden zusammen ein statisches Kollisionsmesh. Mit statisch ist gemeint, dass dies im Kampf nicht verändert wird.
Im Kampf kann man seine Waffen auf Bereiche des gegnerischen Schiffes zielen lassen. Wird ein Schiff getroffen und Schilde und Panzerung durchdrungen wird ermittelt
welche internen Bereiche getroffen werden. Hat man das gegnerische Schiff ausreichend gescannt, wird einem angezeigt wo zB die Schildgeneratoren des Gegners sind
und man kann diese gezielt angreifen. Hat man den Gegner nicht gescannt kann man schlichtweg raten und auf irgendeine Stelle an der gegnerischen Hülle zielen,
ob man eine der gegnerischen internen Stationen getroffen hat sieht man dann entsprechend daran, dass der gegnerische Antrieb oder etwa die Schilde ausfallen.

Beschädigte Systeme können durch Reparaturcrews wiederhergestellt werden. Da man aber nur eine begrenzte Menge an Crew dabei hat muss man abwiegen,
welche Systeme Priorität haben. Ein System kann auch nur teilweise ausfallen, wenn die dazu gehörigen Räume nur leicht beschädigt sind.
Dadurch würden die Schilde zB an Stärke verlieren. Der Schaden an der strukturellen Integrität des Schiffes kann allerdings nicht so einfach repariert werden.
Fällt diese auf 0 gilt das Schiff als zerstört.