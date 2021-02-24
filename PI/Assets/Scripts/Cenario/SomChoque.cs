using UnityEngine;

public class SomChoque : MonoBehaviour {

    AudioSource somChoque;
	// Use this for initialization
	void Start () {
        somChoque = GetComponent<AudioSource>();

        somChoque.pitch = Random.Range(1f, 1.3f);
	}
	
}
