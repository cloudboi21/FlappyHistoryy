using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScreen : MonoBehaviour
{
    public GameObject CheckpointPannel;


    void Start()
    {
        Time.timeScale = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    public void resume()
    {
        CheckpointPannel.SetActive(false);
        Time.timeScale = 1;
    }
}
