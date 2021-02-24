using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public GameObject particula;
    [SerializeField] float multiplicadorMassa = 1f;
    void Start()
    {
        particula.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Player tentou pegar " + name);
            particula.SetActive(true);
			Inventario.instancia.AddItem(this);
			col.gameObject.GetComponent<Rigidbody2D>().mass *= multiplicadorMassa;
        }
    }

}
