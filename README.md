# Car-physics

Natacha GUILLET - GUIN14619507

Dorian BOCHÉ - BOCD27119509

## Installation:
Unity Version 2017.2.1f1

## Description:
L'objectif est de réimplémenter de la physique pour simuler un jeu de voiture.

## Démonstration:
Lancer la scène (bouton play) sans le cube sur le chemin pour remarquer l'accélération puis le freinage de la voiture.
Puis lancer la scène avec le cube pour simuler la collision.
On peut également tester la gravité, avec l'impact d'un objet sur le sol, en mettant soit la voiture ou le cube en l'air.

## Fonctionnalités:
- Implémentation d'un transform proche de celui d'Unity qui permet les translations et rotations
/!\ Les erreurs ne sont pas prises en compte lors du calcul de translation ce qui risque de décaler le repère de Unity et donc faire disfonctionner la rotation
Pour la suite on utilisera le transform de unity pour éviter ces erreurs
- Implémentation de la gravité
- Forces agissant spécifiquement sur la voiture :
  - Force de traction
  - Résitance à l'air
  - Résitance au roulement
  - Force de freinage
- Detection de collision avec la technique de sphère englobante
- Calcul des vélocités post-collision (inélastique) entre voiture/cube et le sol

## Fonctionnalités qui ont été implémentées mais dont on ne se sert pas dû aux erreurs qu'elles généraient:
- Calcul du centre de masse
- Calcul des vélocités post collision (élastique) entre voiture et cube

## Problème rencontré:
Nous n'avons pas réussi à faire tourner la voiture malgrés l'essai d'ajout de certaines force pour cela.
Lors de la collision entre le cube et la voiture, les vélocités post collision sont bien calculées, mais on pense que l'implémentation de ces vitesses est fausse vu que le cube et la voiture ne bougent pas après que la collision soit détectée.
Comme expliqué ci-dessus, on a eu des soucis avec le fait qu'on ne calculait pas les erreurs pour les translations et rotations.
