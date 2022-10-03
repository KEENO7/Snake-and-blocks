using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnakeHead : MonoBehaviour
{
    public Game Game;

    public float ForwardSpeed;
    public float Sensitivity = 10;
    public int Length = 5;

    public TextMeshPro PartsAmountText;

    private Camera _mainCamera;
    private Rigidbody _snakeRigidBody;
    private SnakeTail _snakeTail;

    private Vector3 _touchLastPos;
    private float _sidewaysSpeed;

    public GameObject Shreds;
    public int Score
    {
        get => PlayerPrefs.GetInt("Score", 0);
        set
        {
            PlayerPrefs.SetInt("Score", value);
            PlayerPrefs.Save();
        }
    }
    private void Start()
    {
        _mainCamera = Camera.main;
        _snakeRigidBody = GetComponent<Rigidbody>();
        _snakeTail = GetComponent<SnakeTail>();
  
        for (int i = 0; i < Length; i++) _snakeTail.AddBodyPart();
 
        PartsAmountText.SetText(Length.ToString());

    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _touchLastPos = _mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            _sidewaysSpeed = 0;
        }
        else if(Input.GetMouseButton(0))
        {
            Vector3 delta = (Vector3)_mainCamera.ScreenToViewportPoint(Input.mousePosition) - _touchLastPos;
            _sidewaysSpeed += delta.x * Sensitivity;
            _touchLastPos = _mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Length++;
            _snakeTail.AddBodyPart();
            PartsAmountText.SetText(Length.ToString());
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            Length--;
            _snakeTail.RemoveBodyPart();
            PartsAmountText.SetText(Length.ToString());
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_sidewaysSpeed) > 4) _sidewaysSpeed = 100 * Mathf.Sign(_sidewaysSpeed);
        _snakeRigidBody.velocity = new Vector3(_sidewaysSpeed, 0, ForwardSpeed);

        _sidewaysSpeed = 0;
    }

    public void ReachFinish()
    {
        Game.OnReachedFinish();
        _snakeRigidBody.velocity = Vector3.zero;
    }


    public void Die()
    {
        Game.OnDied();
        _snakeRigidBody.velocity = Vector3.zero;
        gameObject.SetActive(false);
        Shreds.SetActive(true);
        Shreds.transform.position = gameObject.transform.position;
    }
}
