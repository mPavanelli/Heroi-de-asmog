using System.Collections.Generic;
using UnityEngine;

public class ZonaSegura : MonoBehaviour
{

	[SerializeField] string proximaFase;
	[SerializeField] int espacoTotal = 1;
    [SerializeField] GameObject telaFinal;

	List<int> espacoNecessario;

	void Start()
	{
        telaFinal.SetActive(false);
		espacoNecessario = new List<int>();
	}

	void OnTriggerEnter2D(Collider2D outro)
	{
		if (outro.CompareTag("Player"))
		{
			if (Inventario.instancia.listaDeItens.Count > 0)
			{
				espacoNecessario.Add(1);
				if (espacoNecessario.Count == espacoTotal)
				{
					PassaDeFase();
				}
				Inventario.instancia.RemoveItem(Inventario.instancia.listaDeItens[0]);
				outro.gameObject.GetComponent<Rigidbody2D>().mass /= 1.15f;
			}
			//else
			//	Debug.Log("Não tem item necessario");
		}
	}

	void PassaDeFase()
	{
        //Debug.Log("Passou de fase!");
        telaFinal.SetActive(true);
        Time.timeScale = 0;
        ManagerDialogo.current.emDialogo = true;
	}
}
