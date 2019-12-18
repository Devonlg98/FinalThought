using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player[] players;
    public GameObject[] minigames;
    public static GameObject encIntro;
    public static AudioClip minigameWinSnd;
    public static AudioClip minigameLoseSnd;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(players[0].pickedUpPowerUp == true)
        {
            Debug.Log("Player1 slow manager??");
            AssignMinigame(1);
            AssignMinigame(2);
            AssignMinigame(3);
            players[0].pickedUpPowerUp = false;
        }
        if (players[0].encounterTrigger == true)
        {
            if (!players[0].inMinigame)
            {
                AssignMinigame(0);
                players[0].encounterTrigger = false;
            }
        }


        if (players[1].pickedUpPowerUp == true)
        {
            AssignMinigame(0);
            AssignMinigame(2);
            AssignMinigame(3);
            players[1].pickedUpPowerUp = false;
        }
        if (players[1].encounterTrigger == true)
        {
            if (!players[1].inMinigame)
            {
                AssignMinigame(1);
                players[1].encounterTrigger = false;
            }
        }

        if (players[2].pickedUpPowerUp == true)
        {
            AssignMinigame(1);
            AssignMinigame(0);
            AssignMinigame(3);
            players[2].pickedUpPowerUp = false;
        }
        if (players[2].encounterTrigger == true)
        {
            if (!players[2].inMinigame)
            {
                AssignMinigame(2);
                players[2].encounterTrigger = false;
            }
        }

        if (players[3].pickedUpPowerUp == true)
        {
            AssignMinigame(1);
            AssignMinigame(2);
            AssignMinigame(0);
            players[3].pickedUpPowerUp = false;
        }
        if (players[3].encounterTrigger == true)
        {
            if (!players[3].inMinigame)
            {
                AssignMinigame(3);
                players[3].encounterTrigger = false;
            }
        }
    }
    void AssignMinigame(int player)
    {
        int butt;
        butt = (int)Random.Range(0.0f, (float)minigames.Length - 1.0f);
        while (minigames[butt].activeSelf)
        {
            butt = (int)Random.Range(0.0f, (float)minigames.Length - 1.0f);
            Debug.Log(butt);
        }
        //minigames[butt].SetActive(true);
        minigames[butt].GetComponent<Minigame>().TimerSet();
        minigames[butt].GetComponent<Minigame>().finish = false;
        players[player].SetMini(minigames[butt].GetComponent<Minigame>());
        Vector3 pos = new Vector3(players[player].miniWindow.transform.position.x, players[player].miniWindow.transform.position.y, 1);
        minigames[butt].transform.position = pos;
    }
}
