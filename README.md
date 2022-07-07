# Entrega Final Programación II 
## Batalla Naval

Kevin Alvarez

Ingeniería en informática - Universidad Católica del Uruguay

## Defensa de proyecto final.

##Propuesta

Los clientes (profesores) han decidido agregar una nueva funcionalidad al juego. Desean que en cualquier momento de la partida un jugador pueda ejecutar un comando en el bot para solicitar la cantidad de disparos que han tocado el agua, así como de los que han impactado en barcos.

Te pedimos que programes la nueva funcionalidad implementando una o más clases que sumen la cantidad de disparos de ambos jugadores al agua, por un lado, y a barcos, por otro, utilizando los patrones y principios aprendidos en el curso. Luego agrega el comando al bot para mostrar el resultado que obtienes utilizando esas clases.

También deberás programar los casos de prueba correspondientes a las nuevas clases.

Crea tu propia rama en el repositorio de tu proyecto para hacer las modificaciones. La entrega se realiza mediante un link a esa rama.

##Solución desarollada

##Decisiones de desarollo

Se decide el crear una clase Shot en el proyecto de tipo abstract esto permitirá que en el caso de que se quiera desarollar a futuro,
otro tipo de contador de tiros son otros parámetros simplemente se deba de crear otra clase que here de la clase ShotC y sobre escribir sus métodos.
En este caso se pido la implementación de dos tipos de contadores; uno que cuente los tiros realizados en el gua y otro que cuente los tiros 
que fueron hechos a barcos. Por esta misma razón se implemento la clase WaterShot y ShipShot que sobre escriben el método addCount respectivamente.
Ahora, por que razón se decidió el crear dos clases que técnicamente hacen lo mismo? Si se observan el código se podrá notar que la lógica del método
AddCount en WaterShot y ShipShot es la misma pero la diferencia esta en que ambas tienen una atributo de tipo private que lleva cuentas de cosas diferentes.
Una solución a eso pudo haber sido la de poner dos variables en la misma clase y que una cuenta cada cosa pero no estaríamos cumpliendo el patron SRP,
ya que esta supuesta clase con dos atributos tendría la responsabilidad de cambio en el caso que que queramos modificar como se cuentan los tiros 
a los barcos o los tiros al agua. Asi que segregamos dichos funcionamientos creando la clase base ShotC y a su vez permitimos que cada clase tanto WaterShot
y ShipShot tengan una única razón de cambio. A su vez permitimos que este código este cerrado a la modificación y abierto a la extension por el hecho que extendemos la clase Shot
y podemos añadir nuevas funcionalidades a nuestro código según Open Close Principle.

##Ubicación de la decisión de desarollo.

Al pedir como un requerimiento que la cuenta debe ser de ambos jugadores y no de uno y de otro por separado la clase que debe 
de tener al responsabilidad de crear objetos de tipo ShipShot y WaterShot es la clase Game. Esta será la encargada de avisarle a las otras clases ya 
mencionadas cuando deben de sumar uno al contador. Ahora, Porque razón se opto por darle a Game dicha responsabilidad? Por el simple hecho que ella es la
única clase en todo el programa que conoce a los dos jugadores involucrados en la instancia juego y, por lo tanto. La única capaz de saber que jugador
disparo hacia donde y saber el resultado de ella. Es la clase Experta.

##Testeo

Para testear los métodos y su funcionamiento se creo una clase de tipo test en LibraryTests llamada ShotCTest. En esta simula el registro, creación de un 
player y como estos se atacan para asi verificar que el numero del contador aumenta correctamente.

##Implementación del handler ShotCountHandler

Se crea el handler con la keyword /count la cual podrá ser seleccionada en cualquier momento siempre y cuando cabe aclarar el usuario este en jugando, 
por lo que antes deberá de inscribirse en una partida para poder ver el contador por obvias razones. Puede presionar /WaterShotCount o /ShipShotCount
durante la partida para observar el total de tiros realizados a barco a al agua.
Se verifico que los test realizados se ejecuten correctamente, lamentablemente no se ha podido testear el funcionamiento correcto del bot en telegram por no disponer de dos cuentas para el testeo. Se creo un handler especifico que pide que counter mostrar o sino se implemento una funcionalidad similar en MakeShotHandler ya que esta clase como tal es un bucle del cual no se puede salir por lo cual si dentro de esta clase se ejecuta la keyword del handler hecho para los counters no se va a ejecutar por eso mismo se modifico este handler para que se pueda acceder dentro de este igualmente.