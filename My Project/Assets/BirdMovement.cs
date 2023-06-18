using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BirdMovement : MonoBehaviour
{
    public float flapStrength = 15f;
    public new Rigidbody2D rigidbody;
    public LogicManagerScript logicManager;
    public AudioSource flapSound;
    public AudioSource deathSound;
    public Animator wingAnimator; 
    public Animator birdAnimator;

    // Start is called before the first frame update
    void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (logicManager.IsGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            logicManager.PlayAgain();  
        }
        if(Input.GetKeyDown(KeyCode.Space) && !logicManager.IsGameOver && Time.timeScale != 0)
        {
            rigidbody.velocity = Vector2.up * flapStrength;
            flapSound.Play();
            wingAnimator.SetTrigger("Fly");
        }
        if (logicManager.IsGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            logicManager.PlayAgain();
        }
        if ( 18 < transform.position.y || transform.position.y < -17)
        {
            logicManager.GameOver();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicManager.GameOver(); 
        deathSound.Play();
        birdAnimator.SetTrigger("BirdSplat");
    }
}
