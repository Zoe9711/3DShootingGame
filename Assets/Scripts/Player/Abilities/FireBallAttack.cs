using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallAttack : Ability
{
    public override void Use(Vector3 spawnPos)
    {
        RaycastHit hit;
        if (Physics.SphereCast(spawnPos, 0.5f, transform.forward, out hit, m_Info.Range))
        {
            if (hit.collider.CompareTag("Chicken"))
            {
                hit.collider.GetComponent<ChickenController>().DecreaseHealth(m_Info.Power);

            }

        }
        cc_PS.transform.position = hit.point;
        cc_PS.Play();
    }
}
