/*
 * Puntos ejercicio: 10 (+ 3 xtras)
 *
 * Despues de vencer a Thanos, Bruce Banner ha decidido quedarse con los seis
 * Infinity Stone. "Que se joda el futuro," dijo Bruce, "voy a usarlas para
 * resucitar a Nat".  Mientras intenta construir otro Infinity Gaunlet, Bruce
 * teme que las gemas caigan en manos enemigas.  Es por eso que pide la ayuda
 * de Doctor Strange para proteger las piedras. Para esto, Doctor Strange ha
 * encerrado todas las gemas en una caja de seguridad ("lockbox") hechizada.
 *
 * El lockbox contiene 6 compartimentos independientes, cada uno protegido por
 * una cerradura que solo se abre digitando el password correcto. En cada
 * compartimento, Doctor Strange coloco uno de los Infinity Stones.
 *
 * Cualquier intento de abrir el lockbox a la "fuerza", este se teletransporta
 * instantaneamente a otra dimension!
 *
 * Para digitar las claves, el lockbox tiene por fuera un teclado que permite
 * ingresar un digito (de 0 a 5) y un string. Si el string coincide con la clave
 * que corresponde al compartimento identificado por el digito, la cerradura
 * abre y dentro encontras uno de los Infinity Stones.
 *
 * Desafortunadamente, Doctor Strange olvido las claves que uso para encerrar
 * los Infinity Stones.  Y ahora, los Avengers necesitan de tu ayuda para
 * recuperar los Infinity Stones: el rumor es que el hermano de Thanos, Starfox,
 * viene a vengarse de los Avengers.
 * 
 * De cada password, los Avengers sabe lo siguiente:
 *   a) Cada password consiste entre 3 a 5 letras minusculas.
 *   b) Aparte de esas letras minusculas, ningun otro simbolo aparece
 *   c) No existen 3 vocales consecutivas en el password
 *   d) No existen 3 consonantes consecutivas en el password
 *
 * Para la simulacion de este ejercicio, se te provee una clase llamada LockBox,
 * la cual contiene:
 *   + El Constructor que inicializa el lockbox; no tienes que saber como este
 *     funciona.
 *   + El metodo Unlock(id, string s) devuelve true si el string s coincide con
 *     el password que corresponde al compartimento identificado por id, donde
 *     id es un numero de 0 a 5.  De lo contrario, devuelve false.
 *
 * Para interactuar con la clase LockBox, debes agregar la clase LB.dll a tu
 * proyecto.
 *
 * END CREDIT SCENE: Como en (casi) todas pelicula de Marvel, este ejercicio
 * tambien tiene su "escena" al final de los creditos.  Cuando logres abrir
 * todos los compartimentos, recibiras un mensaje encriptado de (una futura
 * version de) Doctor Strange. Para desencriptarlo, solo tienes que "desordenar"
 * todas las claves (de una manera no especificada) y concatenarlas en ese
 * orden.  Ese string formado de las claves es el password para desencriptar el
 * mensaje.  Para desencriptar, llama el metodo estatico Decrypt en la clase
 * Cryptogram pasandole el mensaje encriptado como parametro y la clave.
 * Por Ejemplo:
 *      string message = Cryptogram.Decrypt("myencryptedmessage", "mypassword");
 *
 * Este metodo devuelve el mensaje desencriptado si logra desencriptarlo y null
 * de lo contrario.
 * 
 * Ubica todas las secciones con el tag TODO.  Cada tag les indicara que deben
 * completar.  Para TODOs que requieren respuestas, escribe las respuestas en
 * un comment.
 *
 * En este ejercicio, puedes agregar nuevas claves,  metodos, atributos y
 * parametros a los metodos existentes, pero no cambies los nombres de las
 * claves, metodos y atributos existentes.
 * 
 */

using System;
using System.Text;
using System.Collections.Generic;


class PasswordCracker
{
  
    string[] crackedPasswords;

    // TODO: Agrega los parametros que necesites a este metodo recursivo
    public void RecursiveCrack(Lockbox box,int Attempts, string CurPass )
    {
        // TODO: implementar un algoritmo Brute Force recursivo con Pruning
        //       para descifrar las claves de los compartimentos en el Lockbox
        // Valor: 10 puntos
        // HINT: La solucion oficial dura un poco mas de 11s en mi laptop
        if (Attempts <= box.NumComparments)
        {

            for (char next = 'a'; next <= 'z'; next++)
            {
                CurPass += next;

                if (CurPass.Length <= 5 && CurPass.Length >= 3)
                {
                    for (int i = 0; i < box.NumComparments; i++)
                    {
                        if (box.Unlock(i, CurPass))
                        {
                            crackedPasswords[i] = CurPass;
                            Attempts++;
                            RecursiveCrack(box, Attempts, string.Empty);
                        }
                    }

                    CurPass = CurPass.Substring(0, CurPass.Length - 1);
                }
                if(CurPass.Length <= 3)
                {
                    RecursiveCrack(box, Attempts, CurPass);
                }


                if (CurPass.Length > 5)
                {
                    CurPass = CurPass.Substring(0, CurPass.Length - 1);
                    RecursiveCrack(box, Attempts, CurPass);
                    return;
                }

            }
            CurPass = CurPass.Substring(0, CurPass.Length - 1);
            /*
            if (CurPass == string.Empty)
            {
                CurPass = "aab"; // primer string que cumple las condiciones
            }
            if (CurPass.Length >= 3 && CurPass.Length <= 5) //Solucion completa
            {
                if (box.Unlock(CompartmentID, CurPass))
                {

                    crackedPasswords[CompartmentID] = CurPass;
                    RecursiveCrack(box, CompartmentID + 1, string.Empty);
                    return;
                }
                else
                {
                    for (int i = 0; i < CurPass.Length; i++)
                    {
                        for (char next = 'a'; next <= 'z'; next++)
                        {
                            if (CurPass.Length < 5)
                            {
                                CurPass += next;
                                RecursiveCrack(box, CompartmentID, CurPass);
                            }
                            else
                            {

                                CurPass = CurPass.Substring(0, CurPass.Length - 1);
                            }
                        }
                    }
                }
            }
            else
            {
                return;
            }



        }
        else
        {
            return;
        }*/
            return;
        }
        return;
    }
   
    
    public string[] Crack(Lockbox box)
    {
        
        // TODO: Puedes alterar este metodo para inicialzar los atributos que
        //       necesites y pasar parametros adicionales a la funcion recursiva

        const int NUM_STONES = 6;

        crackedPasswords = new string[NUM_STONES];

        RecursiveCrack(box , 0, string.Empty);

        return crackedPasswords;
    }
}


public class Lab2x
{
    public static void Main(string[] args)
    {
        Lockbox box = new Lockbox(numCompartments: 6,
                                  spellId: 2019,
                                  minPasswordLength: 3,
                                  maxPasswordLength: 5);

        PasswordCracker cracker = new PasswordCracker(); 

        string[] result = cracker.Crack(box);

        for (int i = 0; i < result.Length; ++i)
        {
            Console.WriteLine("Password for compartment #{0}: {1}",
                              i, result[i]);
        }

        // TODO: descifra el mensaje de Doctor Strange, usando como password
        //       la concatenacion, en algun orden desconocido, de las claves
        //       anteriores.  Una vez descifrado, muestra el mensaje en un
        //       comment.  Tambien debes proveer codigo del algoritmo que
        //       usaste para descifrarlo.
        // Valor: 3 puntos extras
        
    }
}
