using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.InputSystem;

    public class PlayerController : MonoBehaviour {

        public Rigidbody2D rb;
        public float speed = 100f;
        public InputAction controls;
        Vector2 direction=Vector2.zero;
        public float smoothTime = 0.1f;
        private Vector2 currentVelocity;
        public GameManager manager;

    private void OnEnable()
    {
        controls.Enable(); 
    }
    private void OnDisable()
    {
        controls.Disable();
    }


        void Start() {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update() {

        if(manager.gameOver) { return; }

        direction = controls.ReadValue<Vector2>();

        direction = Vector2.SmoothDamp(direction, direction, ref currentVelocity, smoothTime);

    }

        
        void FixedUpdate() {

        rb.velocity = new Vector2(direction.x * speed*Time.fixedDeltaTime, direction.y * speed * Time.fixedDeltaTime);
        }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ExtraLife"))
        {
            manager.AddLives(1);
            Destroy(other.gameObject);
        }
    }

}


