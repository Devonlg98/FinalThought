using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPick : MonoBehaviour
{
    public GameObject lockPicker;
    public GameObject lockPad;
    private Minigame mini;
    private int pickCount;
    bool stickUpDown;


    // Start is called before the first frame update
    void Start()
    {
        mini = GetComponent<Minigame>();
        stickUpDown = false;
        pickCount = 0;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(mini.yAxis) >= 0.25f && stickUpDown == false)
        {
            Debug.Log("Stick Up");
            pickCount++;
            stickUpDown = true;
        }

        if (Input.GetAxis(mini.yAxis) <= -0.25f && stickUpDown == true)
        {
            Debug.Log("Stick Down");
            pickCount++;
            stickUpDown = false;
        }

        if(pickCount >= 10)
        {

            mini.finish = true;
        }
    }
    private void Reset()
    {
        stickUpDown = false;
        pickCount = 0;
    }
}
