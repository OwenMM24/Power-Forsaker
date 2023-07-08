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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerScript.canWalk = false;
            ResumeGame();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerScript.canJump = false;
            ResumeGame();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerScript.canDoubleJump = false;
            ResumeGame();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playerScript.canWallJump = false;
            ResumeGame();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            playerScript.canDash = false;
            ResumeGame();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            playerScript.canGlide = false;
            ResumeGame();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
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
