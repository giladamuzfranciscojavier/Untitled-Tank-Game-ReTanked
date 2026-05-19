# Untitled Tank Game ReTanked

Debido a cuestiones laborales, personales, y al resto de actividades del curso, el tiempo dedicado al proyecto ha sido extremadamente limitado y está claramente sin terminar, aún en fase una fase muy temprana y con una build mínima viable apresurada (el nivel es técnicamente funcional, con enemigos, jefe y condiciones de victoria y derrota); siendo fin de la misma actuar como entrega parcial, preferible a no mostrar nada por no estar terminado.

## Lo que hay
La mayoría de mecánicas básicas funcionan. El tanque del jugador es completamente modular (se carga en tiempo de ejecución en base a los módulos cargados en el game manager en formato de scriptable objects, incluyendo los sprites mostrados), teniendo cada parte su propia salud, armadura y peso (el peso del tanque será la suma de sus partes); y el personaje del jugador puede salir del mismo y volver a entrar si se encuentra lo bastante cerca.

Si bien están hechos de formaa apresurada y la calidad de los mismos es dudosa, todos los sprites (exceptuando los básicos de Unity) son de elaboración propia.
## Lo que no hay
Sin embargo, falta por implementar la mecánica de reparación del tanque y la posibilidad de invocar un nuevo tanque si el anterior está demasiado dañado o se encuentra demasiado lejos, lo que puede llevar con facilidad a un softlock (los enemigos destruyen el motor y/o las orugas, el tanque no puede moverse, ser reparado o sustituido, por lo que el personaje queda expuesto hasta su muerte).

La versión actual tampoco cuenta con sonidos, puesto que crear o encontrar efectos de sonido y ajustarlos correctamente es un proceso que requiere de bastante tiempo, y el resultado de querer apurar dicho proceso puede ser cómicamente malo en el mejor de los casos, y causar malestar físico en el peor.
## (Algunos) Problemas conocidos
- La cámara se encuentra demasiado cerca del jugador, impidiendo ver más allá de lo que está justo al lado del mismo. Puesto que cinemachine no permite (o la opción no está clara) alejar directamente la cámara, sería necesario ajustar los propios sprites, aunque ello conllevaría ajustar el nivel al completo
- Interfaz extremadamente básica, basada enteramente en texto, incluida solamente por la necesidad de mostrar información crítica (salud y puntuación). Desarrollar una interfaz más visual y elaborada no sería excesivamente complejo, pero llevaría algo de tiempo
- Si bien el sistema de modularidad del tanque es funcional, no es posible sacarle partido dentro del juego, ya que no hay un menú para dicho propósito (se pueden cambiar dentro del editor, dentro del Game Manager). De nuevo, implementarlo no sería complicado, pero requiere un mínimo de tiempo para montar el menú y estructurar la carga de las escenas, además de aumentar la complejidad y, por lo tanto, el tiempo requerido para realizar pruebas

## Conclusiones
Si bien está entregado, el proyecto está lejos de estar terminado, siendo, irónicamente, más básico en muchos aspectos que el proyecto que en un principio buscaba suceder. Sin embargo, cuenta con una base sobre la que seguir trabajando en un futuro, cuando sea posible dedicarle el tiempo que tanto necesita
