using TMPro;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// Unity has an existing input system and a new one
/// They can not be used simultaneously. To use the new
/// input system, you must open the package manager window
/// then add "Input System" from the Unity Registry
/// </summary>
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;



public class InputExample : MonoBehaviour
{
    [SerializeField]
    public Rigidbody2D jumpingBody, movingBody;
    [SerializeField]
    public bool useForce = true;
    [SerializeField] public float jumpPower = 6f, moveSpeed = 3.0f;
    public float physicsModifier = 100f;
    public Vector2 moveDir = Vector2.zero;
    [SerializeField] public float waypointRadius = 7.18f;
    //[SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource pauseSound;    
    [SerializeField] TMP_Text tPause;
    //public TMP_Text tClear;
    [SerializeField] private AudioMixer myMixer;


    void Start(){

    }

    void Update(){
        if (!jumpingBody){
            // Try to find another jumpingBody in the scene
            GameObject[] jumpingBodies = GameObject.FindGameObjectsWithTag("ball");
            if (jumpingBodies.Length > 0)
            {
                jumpingBody = jumpingBodies[0].GetComponent<Rigidbody2D>();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            if(useForce)    //need to set the flag        
                movingBody.AddForce(moveDir*moveSpeed*Time.deltaTime*physicsModifier, ForceMode2D.Force);
            else{   //we are mainly using this route
                //get ball position to avoid it going into the walls
                Vector2 paddlePos = movingBody.position+(moveDir*moveSpeed*Time.deltaTime);

                if (paddlePos.x > -waypointRadius && paddlePos.x < waypointRadius) {
                    //when the paddle is within the cage, it can go further
                    if (jumpingBody){
                        speed = jumpingBody.velocity.magnitude;
                        if (speed == 0)
                        {
                            //ball will move together with the bar
                            jumpingBody.MovePosition(jumpingBody.position+(moveDir*moveSpeed*Time.deltaTime));     
                        }
                    }
                    //bar will move no matter the speed of the ball inside the cage
                    movingBody.MovePosition(movingBody.position+(moveDir*moveSpeed*Time.deltaTime));
                }
                
            }
    }

    //This function will provide movement using the new input system
    void OnMove(InputValue value)
    {
        moveDir = value.Get<Vector2>() * moveSpeed;
    }
    
    float speed;

    void OnJump()
    {
        //Debug.Log("Spacebar pressed");
        if (jumpingBody){
            speed = jumpingBody.velocity.magnitude;
        if (speed == 0 )
        {
            SetRandomTrajectory();  //this one will allow the ball to start randomly
        }
        else{   //ball is moving
            Scene currentScene = SceneManager.GetActiveScene ();
            string sceneName = currentScene.name;
            
            if (GameObject.Find("Text-clear")){
                Debug.Log("Scene completed - cannot pause/unpause");
            }
            else{
                Debug.Log("Scene is running - can pause/unpause");
                if(sceneName.Contains("game")){
                    pauseSound.Play();
                    if (Time.timeScale == 1) { // pausing the game
                        Time.timeScale = 0;
                        tPause.gameObject.SetActive(true);
                        if (PlayerPrefs.GetInt("MusicMute") == 0) myMixer.SetFloat("Music", -80.0f);
                    }
                    else{
                        Time.timeScale = 1;
                        if (PlayerPrefs.GetInt("MusicMute") == 0){
                            float volume = PlayerPrefs.GetFloat("MusicLv");
                            if (volume != 0)
                                myMixer.SetFloat("Music", Mathf.Log10(volume/20)*20);
                            else
                                myMixer.SetFloat("Music", -80.0f); 
                            }
                        tPause.gameObject.SetActive(false);
                    } 
                }
            }  
        }
        }
        
    }
    
    //created with professor's help
    private void SetRandomTrajectory(){
        Vector2 force = Vector2.up;
        force.x = Random.Range(-1f, 1f);
        jumpingBody.AddForce(force.normalized * jumpPower,ForceMode2D.Impulse);
        jumpingBody.velocity = jumpingBody.velocity.normalized * jumpPower;
    }

}
