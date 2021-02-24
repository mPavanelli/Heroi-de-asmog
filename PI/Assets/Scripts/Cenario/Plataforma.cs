using UnityEngine;

public class Plataforma : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    int waypointAtual = 0;
    Rigidbody2D rb;
    [SerializeField] float velDeMovimento = 2;
    Vector2 direcaoDeMovimento;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        AplicaMovimento();
        if (ChegouNoWaypoint())
        {
            AtualizaWaypointAtual();
        }
    }
    void AplicaMovimento()
    {
        //determinar a direção de movimento
        direcaoDeMovimento = (waypoints[waypointAtual].position - (Vector3)rb.position).normalized;
        //aplicar o movimento
        rb.MovePosition(rb.position + (direcaoDeMovimento * velDeMovimento * Time.deltaTime));

    }
    void AtualizaWaypointAtual()
    {
        waypointAtual++;
        if (waypointAtual >= waypoints.Length)
            waypointAtual = 0;
    }

    bool ChegouNoWaypoint()
    {
        if (Vector2.Distance(rb.position, waypoints[waypointAtual].position) < 0.1f)
            return true;

        return false;
    }
}