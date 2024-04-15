# Introducción
En este documento se muestran los modelos de los objetos que el equipo cree necesario para  crear el juego “El Estanciero”  junto a todo lo que conlleva el mismo, como tarjetas, jugadores, reglas del juego, entre otros.
___
## Clases
### Jugador
~~~
Jugador
{
String color;
Int dinero;
List misCasillasCasillas;
List misTarjetasTarjetas;
} 
~~~
Esta clase se pensó como la Clase padre, teniendo las características generales de un jugador en el  juego “El Estanciero”. Se pensó en que el id que distingue a los jugadores entre si es el color.
 Cada jugador tiene recursos, como lo es el dinero, las tarjetas que compra a medida que el juego avanza y las tarjetas que colecciona que le tocan de forma aleatoria en ciertas casillas.
### Bot : Jugador
~~~
Jugador
{
String tipo;
MiTipoCiudad()
ComprarChacras()
} 
~~~
La clase Bot hereda los atributos de la clase Jugador, y según cual es el tipo, tendrá comportamientos distintos, los cuales se verán en acción cuando se ejecuten los métodos.
### JugadorPrincipal : Jugador
~~~
JugadorPrincipal
 {
CompraCasilla()
CompraChacra()
VenderCasilla() 
} 
~~~
Al igual que la clase bot, esta clase también hereda los atributos de la clase Jugador, pero a diferencia de los Bots, los jugadores no siguen comportamientos programados, sino que él es libre de gestionar sus recursos como quiera, como por ejemplo comprar todas las casillas donde caiga, siempre y cuando tenga el dinero suficiente.
### Tarjeta
~~~
Tarjeta
{
int id;
String nombre;
String tipo;
AccionTarjeta()
} 
~~~
La clase tarjeta hacer referencia a las tarjetas de Suerte y destino, con el ID podremos identificar tanto la cantidad de tarjetas como crear las barajas de las mismas.
### Casilla
~~~
Casilla
{
Int id;
Int preciocompra;
Int precioVenta;
}
~~~
La clase Casilla es nuestra segunda clase padre del proyecto, con la cual podremos distinguir con su id la posición de la casilla en el tablero. También cuenta con atributos de precio de compra y venta, los cuales sirven para manejar la economía del juego.
### Escrituras : Casilla
~~~
Escrituras
{
int cantidadChacras;
String ciudad;
CalcularPrecio()
}
~~~
Las escrituras serán parte fundamental del juego, son las principales casillas que le permitirán al jugador obtener o perder dinero. El dinero que se puede adquirir o perder es medido por la cantidad de chacras que posee la escritura y el tipo de ciudadprovincia de la casilla.
### Ferrocaril : Casilla
~~~
Ferrocarril
{
String nombre;
CalcularPrecio()
}
~~~
Los Ferrocarriles son mas escasos que las escrituras, pero también afectan a la economía. Al tener diferentes comportamientos que las Escrituras se decidió hacer una clase aparte;
### Compania : Casilla
~~~
Compania
{
String nombre;
CalcularPrecio()
}
~~~

Las compañías son más escasas que las escrituras y que los ferrocarriles, pero también afectan a la economía. Al tener diferentes comportamientos que las Escrituras se decidió hacer una clase aparte;
### GrupoTerreno
~~~
GrupoTerreno 
{
String nombreGrupo;
List casillasGrupo[Casilla] ;
}
~~~
Esta clase nos permitirá agrupar las casillas que compartan atributos, como los ferrocarriles, compañías y escrituras según su localización en el tablero.
### Tablero
~~~
Tablero {
List casillastablero[Casillas]
List tarjetasTablero[Tarjetas]
List lustaJugadores[jugadores]
TirarDados()
}
~~~
La clase tablero es fundamental, es la que nos proporcionara los datos mas importantes del juego, como las casillas que están y no están disponibles del tablero, la baraja de tarjetas de suerte y destino, la lista de jugadores con las que realizaremos las acciones de moverse por el tablero, compra y venta de casillas y negociaciones entre jugadores
___
Recordamos que estas Clases no son las definitivas, a medida que el proyecto avance es muy probable que surjan alteraciones a las mismas, ya sean para eliminar o agregar atributos, o empezar a aplicar patrones de diseño como interfases. 
