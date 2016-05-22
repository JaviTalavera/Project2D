using UnityEngine;

public abstract class BaseMovement: MonoBehaviour
{
    public float minSpeed = 20f;
    public float maxSpeed = 100f;
    public float minInitialOrientation;
    public float maxInitialOrientation;

    protected float speed;
    protected Vector3 velocity;
    protected Vector3 direction;
    protected Transform mTransform;
    protected Transform cachedTransform { get { if (!mTransform) mTransform = transform; return mTransform; } }

    protected virtual void Move()
    {
        velocity.y = GetY();
        cachedTransform.localPosition += (velocity + direction) * Time.deltaTime * speed;
        ReactToEdges();
    }

    protected virtual void ReactToEdges()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(cachedTransform.position);
        // Ping pong between the edges of the screen. If we touched an edge, we reverse the movement direction
        if (viewPos.x <= 0 || viewPos.x >= 1) // left/right edges, reverse the x coord for the direction vector
            direction.x = -direction.x;

        if (viewPos.y <= 0 || viewPos.y >= 1) // bottom/upper edges, reverse the y coord of the direction vector
            direction.y = -direction.y;

        cachedTransform.position = Camera.main.ViewportToWorldPoint(viewPos);
    }

    protected virtual void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        InitDirection();
    }

    protected virtual void Update()
    {
        Move();
    }

    protected virtual void InitDirection()
    {
        // give random orientation
        float randZ = Random.Range(minInitialOrientation, maxInitialOrientation);
        direction = Quaternion.Euler(0, 0, randZ) * cachedTransform.right;
    }

    protected abstract float GetY();
}