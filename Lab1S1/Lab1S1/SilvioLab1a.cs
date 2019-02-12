/*
 *
 * Puntos ejercicio: 6 puntos
 *
 * La policia nacional te ha contratado para analizar una serie de homicidios 
 * ocurridos en Santo Domingo.  La data que te piden analizar es una secuencia
 * cronologica de eventos, donde cada evento tiene el dia y la localidad donde
 * ocurrio el homicidio.
 * 
 * Queremos determinar:
 * 1) la cantidad maxima de eventos que ocurrieron en un lapso de K dias
 * 2) la localidad con la mayor cantidad de homicidios
 *
 * Ubica todas las secciones identificas con el tag TODO.  Cada tag les indicara
 * que deben completar.  Para TODOs que requieren respuestas, escribe las
 * respuestas en un comment.
 *
 * Instrucciones adicionales: 
 *   a) No borren los comments que existen en este codigo
 *   b) A menos que tengas una razon valida, no debes modificar la clase Event
 *
 */


using System;


// Definicion de un evento
public class Event
{
    public int day; // para simplificar, numeraremos los dias como 1, 2, 3, ...
    public String location;
    public Event(int day, String location)
    {
        this.day      = day;
        this.location = location;
    }
}



public class Lab1a
{
    // Determina cual es la maxima cantidad de eventos en un lapso de K dias.
    // Puedes asumir que el arreglo de eventos 'events' esta ordenada por dia
    static int MaxNumberOfEventsWithinKDays(Event[] events, int K)
    {
        // TODO: implementar algoritmo (no necesariamente eficiente) que
        //       resuelva este problema
        // Valor: 2 puntos
        int counter = 0;
        foreach(Event a in events)
        {
            int temp = 0; 
            for(int i = 0; i < events.Length; i++)
            {
                if(events[i].day <= a.day && events[i].day > a.day-K )
                {
                    temp++;
                }
            }
            if(temp > counter)
            {
                counter = temp;
            }
        }

        return counter;

        
        

        // TODO: indica cual es la complejidad de tu algoritmo en el worst-case
        // Valor: 0.5 puntos

        // La Complejidad es de Theta(N^2) 

    }


    // Determina la localidad donde los homicidios son mas frecuentes
    // En el caso de empates, puedes devolver cualquiera de las localidades
    // que tienen la misma maxima cantidad de homicidios
    static string MostFrequentLocation(Event[] events)
    {
        // TODO: implementar algoritmo (no necesariamente eficiente) que
        //       resuelva este problema
        // Valor: 3 puntos


        string[] locations = new string[events.Length];
        for(int i = 0; i < locations.Length; i++)
        {
            locations[i] = events[i].location;
        }
        string barrio ="";
        int counter = 0;
        foreach(string a in locations)
        {
            int temp = 0;
            for(int i = 0; i < locations.Length; i++)
            {
                if( a == locations[i])
                {
                    temp++; 
                }
            }
            if (temp > counter)
            {
                counter = temp;
                barrio = a;
            }
        }
        return barrio;
        
           


        // TODO: indica cual es la complejidad de tu algoritmo en el worst-case
        // Valor: 0.5 puntos
        // La complejidad es de Theta(N^2)
       
    }


    public static void Main(string[] args)
    {
        Event[] events = new Event[20];
        events[0]  = new Event( 1, "Villa Francisca");
        events[1]  = new Event( 4, "Capotillo");
        events[2]  = new Event( 5, "Capotillo");
        events[3]  = new Event( 5, "Capotillo");
        events[4]  = new Event(10, "Cristo Rey");
        events[5]  = new Event(10, "Los Guandules");
        events[6]  = new Event(10, "La Zurza");
        events[7]  = new Event(12, "Gualey");
        events[8]  = new Event(13, "Villa Juana");
        events[9]  = new Event(16, "27 de Febrero");
        events[10] = new Event(16, "Los Guandules");
        events[11] = new Event(17, "San Carlos");
        events[12] = new Event(22, "Palma Real");
        events[13] = new Event(25, "Palma Real");
        events[14] = new Event(26, "Villa Consuelo");
        events[15] = new Event(28, "Los Rios");
        events[16] = new Event(33, "Villas Agricolas");
        events[17] = new Event(38, "La Cienaga");
        events[18] = new Event(38, "Capotillo");
        events[19] = new Event(41, "Ensanche Espaillat");
        
        Console.WriteLine("Maxima cantidad de eventos en 7 dias: {0}",
                          MaxNumberOfEventsWithinKDays(events, 7));

        Console.WriteLine("Localidad con mayor cantidad de homicidios: {0}",
                          MostFrequentLocation(events));

        Console.Read();

/*
Output de mi solucion:

Maxima cantidad de eventos en 7 dias: 7
Localidad con mayor cantidad de homicidios: Capotillo

*/
    }

}

