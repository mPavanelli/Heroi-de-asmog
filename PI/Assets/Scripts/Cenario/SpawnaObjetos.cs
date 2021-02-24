using UnityEngine;

public class SpawnaObjetos : MonoBehaviour
{

    [SerializeField] float pontoMinX = 5, pontoMaxX = 5, pontoMinY = 5, pontoMaxY =5 , numeroDeObjetos = 3;
    [SerializeField] GameObject prefab;
    ObjetoDeMorte obj;
    Vector3 posicao;

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            for (int i = 0; i < numeroDeObjetos; i++)
            {
                posicao = new Vector3(Random.Range(pontoMinX, pontoMaxX), Random.Range(pontoMinY, pontoMaxY), 0);
                Instantiate(prefab, posicao, Quaternion.identity);
            }
        }
    }

    void OnTriggerExit2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
