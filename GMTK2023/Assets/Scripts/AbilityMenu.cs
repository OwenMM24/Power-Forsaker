using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject abilityMenu;
    PlayerLogic playerScript;
    public static bool isPaused = false;
    public static bool choosingAbility = false;

    public GameObject[] abilities;
    
    void Start()
    {
        abilityMenu.SetActive(false);
        playerScript = player.GetComponent<PlayerLogic>();
    }

    void Update()
    {
        if (choosingAbility)
        {
            abilityMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Ability1()
    {
        if (playerScript.canWalk == true)
        {
            if (playerScript.canJump == false)
            {
                playerScript.canWalk = false;
                if (abilities[0] != null)
                {
                    abilities[0].SetActive(false);
                }
                ResumeGame();
            }
        }
    }
    public void Ability2()
    {
        if (playerScript.canJump == true)
        {
            if ((playerScript.canDoubleJump == false) && (playerScript.canWallJump == false) && (playerScript.canDash == false) && (playerScript.canGlide == false) && (playerScript.canGroundPound == false))
            {
                playerScript.canJump = false;
                if (abilities[1] != null)
                {
                    abilities[1].SetActive(false);
                }
                ResumeGame();
            }
        }
    }
    public void Ability3()
    {
        if (playerScript.canDoubleJump == true)
        {
            playerScript.canDoubleJump = false;
            if (abilities[2] != null)
            {
                abilities[2].SetActive(false);
            }
            ResumeGame();
        }
    }
    public void Ability4()
    {
        if (playerScript.canWallJump == true)
        {
            playerScript.canWallJump = false;
            if (abilities[3] != null)
            {
                abilities[3].SetActive(false);
            }
            ResumeGame();
        }
    }
    public void Ability5()
    {
        if (playerScript.canDash == true)
        {
            playerScript.canDash = false;
            if (abilities[4] != null)
            {
                abilities[4].SetActive(false);
            }
            ResumeGame();
        }
    }
    public void Ability6()
    {
        if (playerScript.canGlide == true)
        {
            playerScript.canGlide = false;
            if (abilities[5] != null)
            {
                abilities[5].SetActive(false);
            }
            ResumeGame();
        }
    }
    public void Ability7()
    {
        if (playerScript.canGroundPound == true)
        {
            playerScript.canGroundPound = false;
            if (abilities[6] != null)
            {
                abilities[6].SetActive(false);
            }
            ResumeGame();
        }
    }

    void ResumeGame()
    {
        choosingAbility = false;
        Time.timeScale = 1f;
        abilityMenu.SetActive(false);
    }
}
