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
                ResumeGame();
            }
        }
    }
    public void Ability3()
    {
        if (playerScript.canDoubleJump == true)
        {
            playerScript.canDoubleJump = false;
            ResumeGame();
        }
    }
    public void Ability4()
    {
        if (playerScript.canWallJump == true)
        {
            playerScript.canWallJump = false;
            ResumeGame();
        }
    }
    public void Ability5()
    {
        if (playerScript.canDash == true)
        {
            playerScript.canDash = false;
            ResumeGame();
        }
    }
    public void Ability6()
    {
        if (playerScript.canGlide == true)
        {
            playerScript.canGlide = false;
            ResumeGame();
        }
    }
    public void Ability7()
    {
        if (playerScript.canGroundPound == true)
        {
            playerScript.canGroundPound = false;
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
