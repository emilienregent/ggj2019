using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterVolumes : MonoBehaviour
{
    private SplashObject _splash = null;
    private GameObject _orca = null;

    public void Start()
    {
        _splash = GameObject.FindWithTag("Splash").GetComponent<SplashObject>();
        _orca = GameObject.FindWithTag("OrcBody");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("volume enter");
        OrcaMotor Orca = collision.transform.GetComponent<OrcaMotor>();

        if (Orca != null)
        {
            Orca.WaterVolumes.Add(gameObject);

            if (Orca.rbody.velocity.y < -3f && _splash != null)
            {
                _splash.PlaceHere(new Vector2(_orca.transform.position.x, _orca.transform.position.y + .4f));
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("volume exit");
        OrcaMotor Orca = collision.transform.GetComponent<OrcaMotor>();

        if (Orca != null)
            Orca.WaterVolumes.Remove(gameObject);
    }
}
