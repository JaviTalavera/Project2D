 using UnityEngine;
 using System.Collections;
 
 public class SineWaveMovement : BaseMovement
{
    [SerializeField]
    private float frequency = 1f;
    [SerializeField]
    private float wavelength = 1f;

    private float PingPongHPosition;
    private float DistanceHRecorrida = 0f;
    public float MaxRecorridoPingPong; // Con 0 movimiento infinito

    protected override float GetY()
    {
        // try and mess with some of the values here to see what dif results you get...
        return Mathf.Sin(2 * Mathf.PI * Time.time * frequency) * wavelength;
    }

    protected override void ReactToEdges()
    {
        // Calculamos la distancia horizontal recorrida desde el último rebote
        DistanceHRecorrida = Mathf.Abs(transform.position.x - PingPongHPosition);

        if (DistanceHRecorrida >= MaxRecorridoPingPong)
        {
            direction.x = -direction.x;
            Vector3 newScale = transform.localScale;
            newScale.x = newScale.x * -1;
            transform.localScale = newScale;

            // Actualizamos la posición horizontal de referencia para el cálculo de rebote horizontal (ping-pong)
            PingPongHPosition = transform.position.x;
        }
    }

    protected override void Move()
    {
        base.Move();
    }

    protected override void Start ()
    {
        base.Start();
        PingPongHPosition = transform.position.x;
    }
}