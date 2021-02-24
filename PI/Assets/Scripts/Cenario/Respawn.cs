using UnityEngine;

public class Respawn : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D quemEntrou)
    {
        switch (quemEntrou.tag)
        {
            case "Player":
                Debug.Log("Você morreu!");
                TelaMorte.current.gameObject.SetActive(true);
                TelaMorte.current.texto = "VOCÊ SE LASCOU!";
                Time.timeScale = 0;
                break;
            case "Chao":
                Destroy(gameObject);
                break;
        }
    }
}
