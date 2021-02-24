using UnityEngine;

public class ControleDaCamera : MonoBehaviour
{

    [SerializeField] Transform alvo;
    [SerializeField] SpriteRenderer player;
    [SerializeField] public float velocidadeDaCamera = 3;
    [SerializeField] float velocidadeFlip = 3;
    [SerializeField] float distanciaCamera = 5;
    [SerializeField] Vector3 distanciaDoAlvo = new Vector3(0, 0, -10);
    static Vector3 posAtual;
    Vector3 posFinal;
    float velocidadeOriginal;
    Transform alvoAtual;
    Transform tr;
    bool flip = false;
    public static Vector3 PosAtual
    {
        get { return posAtual; }
    }
    [SerializeField] bool fakePixelPerfect = false;
    [SerializeField] float precisao = 6000;
    Vector3 posCorrigida;
    [SerializeField] float distanciaMinima = 1.5f;
    #region Singleton
    public static ControleDaCamera current;

    void Awake()
    {
        if (current != null)
        {
            Debug.LogWarning("Mais de uma instância de ControleDaCamera!");
            return;
        }
        current = this;
    }
    #endregion

    // Use this for initialization
    void Start()
    {
        velocidadeOriginal = velocidadeDaCamera;
        posAtual = GetComponent<Transform>().position;
        tr = transform;
        alvoAtual = alvo;
        distanciaDoAlvo.x = distanciaCamera;
        tr.position = alvo.position + distanciaDoAlvo;

    }

    // Update is called once per frame
    void Update()
    {
        if (!alvoAtual)
            return;
        posFinal = alvoAtual.position;
        MudaCamera();
        posFinal += distanciaDoAlvo;




        if (fakePixelPerfect)
        {
            Debug.Log(Vector3.Distance(tr.position, posFinal));
            if (Vector3.Distance(tr.position, posFinal) > distanciaMinima)
            {
                tr.position = Vector3.Lerp(tr.position, posFinal, velocidadeDaCamera * Time.deltaTime);
            }
            posCorrigida = tr.position;
            posCorrigida.x = Mathf.FloorToInt(tr.position.x * precisao) / precisao;
            posCorrigida.y = Mathf.FloorToInt(tr.position.y * precisao) / precisao;
            tr.position = posCorrigida;
        }
        else
        {
            tr.position = Vector3.Lerp(tr.position, posFinal, velocidadeDaCamera * Time.deltaTime);
        }
    }

    void MudaCamera()
    {
        flip = player.flipX;
        if (flip)
        {
            distanciaDoAlvo.x = Mathf.Lerp(distanciaDoAlvo.x, -distanciaCamera, velocidadeDaCamera / velocidadeFlip * Time.deltaTime);
        }
        else
        {
            distanciaDoAlvo.x = Mathf.Lerp(distanciaDoAlvo.x, distanciaCamera, velocidadeDaCamera / velocidadeFlip * Time.deltaTime);
        }
    }

    public void TrocaAlvo(Transform novoAlvo)
    {
        alvoAtual = novoAlvo;
    }

    public void VoltaAlvo()
    {
        velocidadeDaCamera = velocidadeOriginal;
        alvoAtual = alvo;
    }
}
