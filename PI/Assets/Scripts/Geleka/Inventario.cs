using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
	#region Singleton
	public static Inventario instancia;


	void Awake()
	{
		if (instancia != null)
		{
			Debug.LogWarning("Mais de uma instancia de inventário!!!");
			return;
		}
		instancia = this;
	}
	#endregion

	public List<Item> listaDeItens;
	[SerializeField] Transform[] slots;
	[SerializeField] int espaco = 1;
	[SerializeField] float tamanhoDoItemNoInventario = 0.1f;
	[SerializeField] float tempoOriginalAteAReducao = 3f;

	void Start()
	{
		listaDeItens = new List<Item>();
	}

	public void AddItem(Item itemParaAdd)
	{
		if (listaDeItens.Count < espaco)
		{
			listaDeItens.Add(itemParaAdd);
            //itemParaAdd.particula.SetActive(true);
			itemParaAdd.GetComponent<Collider2D>().enabled = false;
			itemParaAdd.transform.SetParent(slots[0]);
			itemParaAdd.transform.position = slots[0].position;
			itemParaAdd.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
			StartCoroutine(DiminuiItem(itemParaAdd.transform));
			//Debug.Log("Player pegou!");
		}
		else
		{
			//Debug.Log("Não tem espaço");
		}
	}

	public void RemoveItem(Item itemParaRemover)
	{
		if (listaDeItens.Count >= espaco)
		{
			listaDeItens.Remove(itemParaRemover);
            itemParaRemover.particula.SetActive(false);
            Destroy(itemParaRemover.gameObject.GetComponent<Item>());		
			itemParaRemover.transform.parent = null;
			itemParaRemover.transform.position = slots[0].position + new Vector3(0.5f, 0, 0);
			itemParaRemover.transform.eulerAngles = new Vector3(0, 0, 0);
			itemParaRemover.GetComponent<Collider2D>().enabled = true;
			itemParaRemover.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
			StartCoroutine(AumentaItem(itemParaRemover.transform));
			//Debug.Log("Player soltou!");
		}
		else
		{
			//Debug.Log("Não tem item");
		}
	}

	IEnumerator DiminuiItem(Transform item)
	{
		WaitForEndOfFrame fimDoFrame = new WaitForEndOfFrame();
		Vector3 escalaAtual = item.localScale;
		float tamanhoInicial = escalaAtual.x;
		float tempoAteReducao = tempoOriginalAteAReducao;

		while (item.localScale.x > tamanhoDoItemNoInventario)
		{
			//Debug.Log("Diminuindo item");
			escalaAtual = Vector3.one * Mathf.Lerp(tamanhoInicial, tamanhoDoItemNoInventario, tempoOriginalAteAReducao - tempoAteReducao);
			item.localScale = escalaAtual;
			tempoAteReducao -= Time.deltaTime;
			yield return fimDoFrame;
		}
	}
	IEnumerator AumentaItem(Transform item)
	{
		WaitForEndOfFrame fimDoFrame = new WaitForEndOfFrame();
		Vector3 escalaAtual = item.localScale;
		float tamanhoInicial = escalaAtual.x;
		float tempoAteReducao = tempoOriginalAteAReducao;

		while (item.localScale.x < 1)
		{
			//Debug.Log("Aumentando item");
			escalaAtual = Vector3.one * Mathf.Lerp(tamanhoInicial, 1, tempoOriginalAteAReducao - tempoAteReducao);
			item.localScale = escalaAtual;
			tempoAteReducao -= Time.deltaTime;
			yield return fimDoFrame;
		}
		item.GetComponent<Collider2D>().enabled = false;
		item.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
	}
}
