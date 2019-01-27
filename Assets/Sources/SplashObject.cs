using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashObject : MonoBehaviour
{
    public float timer = 0f;
    public float _endTimer = .5f;

    public void PlaceHere(Vector2 pos)
    {
        timer = 0;
        gameObject.SetActive(true);
        transform.position = pos;
    }

    void Update()
    {
        if (timer < _endTimer)
        {
            timer += Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
