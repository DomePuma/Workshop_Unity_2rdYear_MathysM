# Workshop_Unity_2rdYear_MathysM

Projet Devoir pour E-Artsup

L'objectif était de créer un jeu de récolte très basique.
Le cahier des charges étant :
Un personnage est sur une surface plane.
Le personnage doit se déplacer à l'endroit où le.a joueureuse clique.
Il doit y avoir au moins deux obstacles sur votre surface navigable.
Un objet récoltable (ex : de l'herbe) apparaît sur la surface à intervalles irréguliers et le personnage les ramasse quand il passe à proximité.
Ces objets récoltés finissent dans un inventaire mais ils ne s'empilent (stackent) pas. Donc il n'y aura pas de case d'inventaire avec herbe x9 par exemple.
L'inventaire s'affiche en appuyant sur une touche du clavier et s'en va en réappuyant sur la même touche.
L'inventaire a une place limité. Et les emplacements même vides doivent être visibles.
Si vous faites un drag'n drop d'un objet dans l'inventaire sur un autre identique, il doit se changer en un objet de qualité (ou de niveau) supérieur, genre du bois.
Il faut au moins 6 qualités d'objets dans votre projet.

Le projet est incomplet dût à un problème que je n'ai pas pû résoudre, on peut fusionner les items mais la liste de item ne se vide pas après la fusion et empêche de ramasser de nouveaux items

Le système de déplacement se fait par un simple NavMesh

L'inventaire est une liste d'objets contenant des sciptables objects avec leurs charactérisques : Leur modèle 3D, leur modèle d'UI, et leur type (leur niveau de qualité)

Les objets spawn aléatoirement, à des délais dont on peut choisir le temps minimum et maxixum, sur la zone du NavMesh Surface, et son récupérables avec un collision enter qui les envoient dans l'inventaire à l'aide d'une Action passant par un sciptable object pour passer entre les 2 scènes, et renvoyant un signal pour informer si l'inventaire n'est pas plein avant pour savoir s'il est ajouté et donc détruire l'objet apparu ou pas

L'inventaire se contrôle à la souris en drag & drop grâces aux scripts et méthodes déjà présent dans unity, et la fusion se fait avec un raycast sur l'objet qu'on cible avec celui qu'on tient avec la souris pour voir s'il peuvent bien fusionner ensemble s'ils sont de même type puis supprime les 2 objets de la hiérarchie et (en théorie) de la Liste et instancie un nouveau de qualité supérieure ce dernier (ce tout dernier point ne fonctionnant pas)

Johanne et Logan m'ont beaucoup aidé sur le projet à cause du retard que j'ai eu à cause de ma machine

Il ne me reste qu'à réparer la list qui ne supprime pas les item mais je n'ai aucune idée de pourquoi ça ne le fait pas
