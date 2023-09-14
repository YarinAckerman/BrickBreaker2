using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class BallInitializer : MonoBehaviour {
        
        public Rigidbody2D rb;
        public float speed = 500f;
        public bool inPlay;
        public Transform player;
        public GameManager Manager;
        public InputAction controls;
        public Transform powerUp;


    private void Start() {

        rb = GetComponent<Rigidbody2D>();
    }

        private void Update()
        {
        if (Manager.gameOver) { return; } 
        if (!inPlay) { transform.position = player.position; }
        if(controls.triggered && !inPlay) { inPlay = true; rb.AddForce(Vector2.up * 500); }

    }
        //SceneManager.LoadScene("SampleScene");
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Brick"))
        {

            BrickScript brickScript = other.gameObject.GetComponent<BrickScript>();

            if (brickScript.hitsToBreak > 1)
            {
                brickScript.BreakBrick();
            }
            else
            {
                Manager.UpdateNumOfBricks();
                if(Manager.numOfBricks==Manager.powerUpBrick) {
    
                    Instantiate(powerUp, other.transform.position, other.transform.rotation);
                }
                Manager.AddScore(brickScript.points);
                Destroy(other.gameObject);
            }


        }
        else if (other.gameObject.CompareTag("Bottom"))
        {
            rb.velocity = Vector2.zero;
            inPlay = false;
            Manager.AddLives(-1);
        }
        ;

        //SceneManager.LoadScene("SampleScene");
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }

}