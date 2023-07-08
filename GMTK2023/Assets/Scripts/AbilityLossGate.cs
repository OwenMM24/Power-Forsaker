using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityLossGate : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerLogic playerScript = col.gameObject.GetComponent<PlayerLogic>();
            playerScript.spawnPoint = col.gameObject.transform.position;
            AbilityMenu.choosingAbility = true;
            Destroy(gameObject);
        }
    }
}
