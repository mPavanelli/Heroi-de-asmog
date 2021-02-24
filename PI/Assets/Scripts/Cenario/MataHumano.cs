using UnityEngine;

public class MataHumano : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Humano"))
		{
            TelaMorte.current.gameObject.SetActive(true);
            TelaMorte.current.texto = "A VÍTIMA CAIU!";
            Time.timeScale = 0;
		}
	}
}
