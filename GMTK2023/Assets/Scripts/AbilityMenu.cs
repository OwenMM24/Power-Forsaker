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
            playerScript.canWalk = RemoveAbility(playerScript.canWalk);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            RemoveAbility(playerScript.canJump);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            RemoveAbility(playerScript.canDoubleJump);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            RemoveAbility(playerScript.canWallJump);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            RemoveAbility(playerScript.canDash);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            RemoveAbility(playerScript.canGlide);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            RemoveAbility(playerScript.canGroundPound);
        }
    }

    bool RemoveAbility(bool ability)
    {
        if (ability == true)
        {
            //ability = false;
            ResumeGame();
            return false;
        }
    }

    void ResumeGame()
    {
        choosingAbility = false;
        Time.timeScale = 1f;
        abilityMenu.SetActive(false);
    }
}
