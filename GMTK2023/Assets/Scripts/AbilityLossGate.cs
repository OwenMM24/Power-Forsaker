using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityLossGate : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            AbilityMenu.choosingAbility = true;
            Destroy(gameObject);
        }
    }
}
