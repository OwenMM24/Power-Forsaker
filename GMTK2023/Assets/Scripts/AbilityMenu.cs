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
            ChooseAbility();
        }
    }

    void ChooseAbility()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && playerScript.canJump == false)
        {
            if (playerScript.canWalk == true)
            {
                playerScript.canWalk = false;
                ResumeGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && (playerScript.canDoubleJump == false) && (playerScript.canWallJump = false) && (playerScript.canDash = false) && (playerScript.canGlide = false) && (playerScript.canGroundPound == false))
        {
            if (playerScript.canJump == true)
            {
                playerScript.canJump = false;
                ResumeGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (playerScript.canDoubleJump == true)
            {
                playerScript.canDoubleJump = false;
                ResumeGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (playerScript.canWallJump == true)
            {
                playerScript.canWallJump = false;
                ResumeGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (playerScript.canDash == true)
            {
                playerScript.canDash = false;
                ResumeGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (playerScript.canGlide == true)
            {
                playerScript.canGlide = false;
                ResumeGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (playerScript.canGroundPound == true)
            {
                playerScript.canGroundPound = false;
                ResumeGame();
            }
        }
    }

    /*
    bool RemoveAbility(bool ability) //deprecated, ignore
    {
        if (ability == true)
        {
            ResumeGame();
        }
    }
    */

    void ResumeGame()
    {
        choosingAbility = false;
        Time.timeScale = 1f;
        abilityMenu.SetActive(false);
    }
}
