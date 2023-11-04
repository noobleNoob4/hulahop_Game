using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ballFixed : MonoBehaviour
{

    public float rotateSpeed = 1;
    public float force = 1000f;

    public AudioSource hulahopSound;



    public static int score;
    public Text scoreText;



    public int ballJump;
    public Text jumpText;
    public bool isballjump;

    private Vector3 startBallPosition; 

    private Vector3 startPosition; 

    private Vector3 endPosition;  

    private Rigidbody ballpyhsics;

   private float ballScorePosition;

   void Awake()
    {


        ballpyhsics = GetComponent<Rigidbody>();
    }

    void Start()
    {
        hulahopSound = GetComponent<AudioSource>();
        score = 0;
        isballjump = false;

        Physics.autoSimulation = false;




        ballpyhsics.isKinematic = true;
        startBallPosition = transform.position;   


    }



    void Update()
    {

        scoreText.text = "Score: " + score;
        jumpText.text = "Jump: " + ballJump;

        SpinBall();
        if (Input.GetMouseButtonDown(0))
        {

            startPosition = getMousePosition();



        }



        if (Input.GetMouseButtonUp(0))
        {
            endPosition = getMousePosition();
            Vector3 power = startPosition - endPosition;
            ballpyhsics.isKinematic = false;
            ballpyhsics.AddForce(power * force, ForceMode.Force);
            isballjump = true;
            ballJump -= 1;


            if (ballJump == 0)
            {


                transform.position = startBallPosition;
                ballJump = 5;
                
            }





        }


    }


    void OnCollisionEnter(Collision collision)
    {
        


        if (!collision.gameObject.tag.Equals("ground")) return;



        ballpyhsics.isKinematic = true;
        transform.position = startBallPosition;
        TimerGameOver.countDownStartValue -= 2;
        ballpyhsics.velocity = Vector3.zero; 
        ballJump = 5;


    }

    private Vector3 getMousePosition()
    {
        return Camera.main.ScreenToViewportPoint(Input.mousePosition);
    }
    private void SpinBall()
    {
        transform.Rotate(0, 0, rotateSpeed, Space.World);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hulahop")
        {
            hulahopSound.Play();
        }

        ballScorePosition = transform.position.y;
        transform.position = startBallPosition;
        ballpyhsics.isKinematic = true;
        ballJump = 5;


    }
    private void OnTriggerExit(Collider other)
    {
        if (transform.position.y < ballScorePosition)
        {
            scoreText.text = "Score: " + score;
            score += 50;




        }
    }














}
