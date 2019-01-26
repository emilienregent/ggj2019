using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echelle : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject TeleportPoint;

    [SerializeField]
    private GameObject _climbAnim = null;

    [SerializeField]
    private float _animTimer = 1f;

    private GameObject _climbingHuman = null;
    private bool _isClimbing = false;
    private float _animTime = 0f;

    public void Update()
    {
        if (!_isClimbing)
        {
            return;
        }
         
        _animTime += Time.deltaTime;

        if (_animTime > _animTimer)
        {
            _climbAnim.SetActive(false);
            _climbingHuman.SetActive(true);
            _climbingHuman.transform.position = TeleportPoint.transform.position;
            _isClimbing = false;
        }
    }

    public void Interact()
    {

    }

    public void DashIn()
    {

    }

    public bool JumpOn(HumanMotor Human)
    {
        _animTime = 0f;
        _climbingHuman = Human.gameObject;
        _climbingHuman.SetActive(false);
        _climbAnim.SetActive(true);
        _isClimbing = true;
        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ICharacter>() != null)
            collision.GetComponent<ICharacter>().InteractableList.Add(this);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ICharacter>() != null)
            collision.GetComponent<ICharacter>().InteractableList.Remove(this);
    }
}
