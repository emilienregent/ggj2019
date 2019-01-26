using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterVolumes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OrcaMotor Orca = collision.transform.GetComponent<OrcaMotor>();
        if (Orca != null)
        {
            Orca.WaterVolumes.Add(gameObject    );
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        OrcaMotor Orca = collision.transform.GetComponent<OrcaMotor>();
        if (Orca != null)
        {
            Orca.WaterVolumes.Add(gameObject);
        }
    }
}
