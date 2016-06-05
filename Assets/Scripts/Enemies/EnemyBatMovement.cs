using UnityEngine;
using System;
 
// Tipos enumerados para definir las direcciones
public enum DireccionH { Izquierda, Derecha }

public class EnemyBatMovement : MonoBehaviour
{
    // Es la velocidad a la que se moverá el enemigo en el eje horizontal.
    public float VelocidadH = 0.3F;

    // Indica el sentido horizontal al que comenzará a moverse el enemigo.
    public DireccionH SentidoH = DireccionH.Izquierda;


    // Es el la distancia que recorrerá el enemigo en modo ping-pong.
    // Para desactivar el modo ping-pong, establecer esta variable a -1.
    public float MaxRecorridoPingPong = 5.0F;
    public bool HacerPingPong = true;


    // Variables privadas
    private Transform Enemigo;
    private float DistanceHRecorrida = 0.0F;
    private float PingPongHPosition;


    void Start()
    {
        Enemigo = transform;

        // Guardamos la posición inicial del enemigo
        //PosicionInicialEnemigo = Enemigo.position;

        // Inicializamos la posición de referencia para el cálculo de rebote horizontal (ping-pong)
        PingPongHPosition = Enemigo.position.x;
    }


    void Update()
    {
        // Calculamos la distancia horizontal recorrida desde el último rebote
        DistanceHRecorrida = Math.Abs(Enemigo.position.x - PingPongHPosition);

        if (HacerPingPong && DistanceHRecorrida >= MaxRecorridoPingPong)
        {
            // Si la función de Ping-Pong esta activada y se ha hecho el máximo recorrido en horizontal, el enemigo cambia de sentido
            if (SentidoH == DireccionH.Izquierda)
            {
                SentidoH = DireccionH.Derecha;
                Vector3 newScale = transform.localScale;
                newScale.x = newScale.x * -1;
                transform.localScale = newScale;
            }
            else
            {
				SentidoH = DireccionH.Izquierda;
                Vector3 newScale = transform.localScale;
                newScale.x = newScale.x * -1;
                transform.localScale = newScale;
            }

            // Actualizamos la posición horizontal de referencia para el cálculo de rebote horizontal (ping-pong)
            PingPongHPosition = Enemigo.position.x;
        }

     
        // Configuramos el sentido del movimiento horizontal
        if (SentidoH == DireccionH.Izquierda)
        {
            VelocidadH = -Math.Abs(VelocidadH);
        }
        else
        {
            VelocidadH = Math.Abs(VelocidadH);
        }


        // Movemos el enemigo
        Enemigo.Translate(new Vector3(VelocidadH, 0, 0) * Time.deltaTime);
    }


}