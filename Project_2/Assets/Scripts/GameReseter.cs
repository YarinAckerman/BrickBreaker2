using UnityEngine;
using UnityEngine.SceneManagement;

    public class GameReseter : MonoBehaviour  {

    public GameManager Manager;

        public void OnCollisionEnter2D(Collision2D other) {
            if (!other.gameObject.CompareTag("Ball")) return;
            Manager.AddLives(-1);
            //SceneManager.LoadScene("SampleScene");
        }
    }
