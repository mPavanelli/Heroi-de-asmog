using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{

	[SerializeField] Text textoCronometro;
	float tempo;
	public float Tempo
	{
		get { return tempo; }
		set { }
	}

	#region Singleton
	public static Cronometro current;

	void Awake()
	{
		if (current != null)
		{
			Debug.LogWarning("Mais de uma instancia de cronometro");
			return;
		}
		current = this;
	}
	#endregion

	void Start()
	{
		tempo = Time.timeSinceLevelLoad;
	}

	void Update()
	{
		if (!ManagerDialogo.current.emDialogo)
		{
			tempo += Time.deltaTime / 2f;
			textoCronometro.text = tempo.ToString("0.00");
		}
	}
}
