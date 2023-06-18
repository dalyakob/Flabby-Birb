using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middlePipe : MonoBehaviour
{
    public LogicManagerScript logicManager;
    public AudioSource ScoreSound;
    public int ScoreToIncrease = 1;
    // Start is called before the first frame update
    void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            logicManager.IncrementScore(ScoreToIncrease);
            ScoreSound.Play();
        }
    }
}
