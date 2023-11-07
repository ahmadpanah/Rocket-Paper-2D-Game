
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using EasyJoystick;

public class PlayerMovment : MonoBehaviour {


[SerializeField] float moveSpeed;
[SerializeField] float rotationSpeed;
[SerializeField] private Joystick joystick;


[SerializeField] Text score;

float counter = 0;
int scr = 0;

bool gameover = false;



Rigidbody2D rb;

Camera cam;

public AudioClip auC;
public AudioSource auS;

void Start() {
    rb = GetComponent <Rigidbody2D> ();
    cam = Camera.main;
    joystick.ArrowKeysSimulationEnabled = true;

}

void setScore() {
    counter += Time.deltaTime;
    if (counter >=.5f){
        counter = 0f;
        scr++;
        score.text = scr.ToString("000");
    }
}

void Update() {
   if (!gameover) {
     
    setScore();

     float horizontalInput = joystick.Horizontal();
            if (horizontalInput > 0)
            {
                transform.Rotate(Vector3.forward * (-rotationSpeed) * Time.deltaTime);
            }
            else if (horizontalInput < 0)
            {
                transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            }
   }
}

void FixedUpdate() {
    if (!gameover)
    rb.AddRelativeForce(new Vector3(moveSpeed*Time.fixedDeltaTime,0f,0f));
}

void LateUpdate() {
    if(!gameover) {
        cam.transform.position = new Vector3(transform.position.x,transform.position.y,cam.transform.position.z);
    }
}

void OnCollisionEnter2D(){
    if (!gameover) {
        gameover = true;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponentInChildren<TrailRenderer>().enabled = false;
        GetComponentInChildren<ParticleSystem>().Play();
        auS.PlayOneShot(auC);
        Invoke("restart", 10f);
    }
}

void restart(){
    SceneManager.LoadScene(0);
}

}