using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterVolumes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("volume enter");
        OrcaMotor Orca = collision.transform.GetComponent<OrcaMotor>();
        Orca.WaterVolumes.Add(gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("volume exit");
        OrcaMotor Orca = collision.transform.GetComponent<OrcaMotor>();
        Orca.WaterVolumes.Remove(gameObject);
    }
}
