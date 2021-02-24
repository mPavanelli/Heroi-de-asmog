using UnityEngine;
using UnityEngine.UI;

public class ManagerTempo : MonoBehaviour {

	public Slider sliderTempo;
	public Humano vitima;
	float progresso = 0;
	
	// Update is called once per frame
	void Update () {

		progresso = Mathf.Clamp(vitima.TempoAtual, 0, vitima.TempoAteCair);
		sliderTempo.maxValue = vitima.TempoAteCair;
		sliderTempo.value = progresso;

	}
}
