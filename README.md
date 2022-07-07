# Entrega Final Programación II 
## Batalla Naval

Kevin Alvarez

Ingeniería en informática - Universidad Católica del Uruguay

## Defensa de proyecto final.

#Propuesta

Los clientes (profesores) han decidido agregar una nueva funcionalidad al juego. Desean que en cualquier momento de la partida un jugador pueda ejecutar un comando en el bot para solicitar la cantidad de disparos que han tocado el agua, así como de los que han impactado en barcos.

Te pedimos que programes la nueva funcionalidad implementando una o más clases que sumen la cantidad de disparos de ambos jugadores al agua, por un lado, y a barcos, por otro, utilizando los patrones y principios aprendidos en el curso. Luego agrega el comando al bot para mostrar el resultado que obtienes utilizando esas clases.

También deberás programar los casos de prueba correspondientes a las nuevas clases.

Crea tu propia rama en el repositorio de tu proyecto para hacer las modificaciones. La entrega se realiza mediante un link a esa rama.

#Solución desarollada

#Deciciones de desarollo
Se decide el crear una clase Shot en el proyecto de tipo abstract esto permitira que en el caso de que se quiera desarollar a futuro,
otro tipo de contador de tiros son otros parametros simplemente se deba de crear otra clase que here de la clase ShotC y sobreescribir sus metodos.
En este caso se pido la implementtacion de dos tipos de contadores; unno que cuente los tiros realizados en el gua y otro que cuente los tiros 
que fueron hechos a barcos. Por esta misma razon se implemento la clase WaterShot y ShipShot que sobre escriben el metodo addCount respectivamente.
Ahora, por que razon se decidio el crear dos clases que tecnicamente hacen lo mismo? Si se observan el codigo se podra notar que la logica del metodo
AddCount en WaterShot y ShipShot es la misma pero la diferencia esta en que ambas tienen una atributo de tipo private que lleva centas de cosas diferentes.
Una solucion a eso pudo haber sido la de poner dos variables en la misma clase y que una cuenta cada cosa pero no estariamos cumpliendo el patron SRP,
ya que esta supuiesta clase con dos atributos tendria la responsabilidad de cambio en el caso que que queramos modificar como se cuentan los tiros 
a los barcos o los tiros al agua. Asi que segrgamos dichios funcionamientos creando la clase base ShotC y a su vez permitimos que cada clase tanto WaterShot
y ShipShot tengan una unica razon de cambio. A su vez permitimos que este codigo este cerrado a la modificacion y aboerto a la extension por el hecho que extendemos la clase Shot
y podemos añadir nuevas funcionalidades a nuestro codigo segun Open Close Principle.

#Ubicación de la decición de desarollo.
Al pedir como un requerimiento que la cuenta debe ser de ambos jugadores y no de uno y de otro por separado la clase que debe 
de tener al responsabilidad de crear objetos de tipo ShipShot y WaterShot es la clase Game. Esta será la encargada de avisarle a las otras clases ya 
mencionadas cuando deben de sumar uno al contador. Ahora, Porque razón se opto por darle a Game dicha responsabilidad? Por el simple hehco que ella es la
unica clase en todo el programa que conoce a los dos jugadores involucrados en la insatncia juego y, por lo tanto. La unica capaz de saber que jugador
disparo hacia donde y saber el resultado de ella. Es la clase Experta.

#Testeo
Para testear los metodos y su funcionamiento se creo una clase de tipo test en LibraryTests llamada ShotCTest. En esta simula el registro, creacion de un 
player y como estos se atacan para asi verificar que el numero del contador aumenta correctamente.

#Implementacion del handler ShotCountHandler
Se crea el handler con la keyword /count la cual podra ser seleccionada en cualquier momento siempre y cuando cabe aclarar el usuario este en jugando, 
por lo que antes debera de inscribirse en una partida para poder ver el contador por obvias razones. Puede presionar /WaterShotCount o /ShipShotCount
durante la partida para obseravr el total de tiros realizados a barco a al agua.