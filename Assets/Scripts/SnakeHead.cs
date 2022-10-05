using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnakeHead : MonoBehaviour
{
    public Game Game;

<<<<<<< HEAD
    public float ForwardSpeed = 150;
    public float Sensitivity = 1000;
=======
    public float ForwardSpeed;
    public float Sensitivity;
>>>>>>> parent of e89f58b (Added Obstacle numbers)
    public int Length = 5;

    public TextMeshPro PartsAmountText;

    private Camera _mainCamera;
    private Rigidbody _snakeRigidBody;
    private SnakeTail _snakeTail;

    private Vector3 _touchLastPos;
    private float _sidewaysSpeed;

<<<<<<< HEAD
    public BonusParts BP;
    public Obstacle Obstacle;
    public ObjectPool PickUpsPool;

=======
>>>>>>> parent of e89f58b (Added Obstacle numbers)
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
 
        for (int i = _snakeTail._bodyParts.Count; i < Length; i++) _snakeTail.AddBodyPart();
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
<<<<<<< HEAD
=======

>>>>>>> parent of e89f58b (Added Obstacle numbers)
        if (Input.GetKeyDown(KeyCode.A))
        {
            Length++;
            _snakeTail.AddBodyPart();
            PartsAmountText.SetText(Length.ToString());
        }
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.D))
=======
        if(Input.GetKeyDown(KeyCode.D))
>>>>>>> parent of e89f58b (Added Obstacle numbers)
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

<<<<<<< HEAD

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BonusParts parts))
        {
            Length += BP.Parts;
            Destroy(parts.gameObject);
            for (int i = _snakeTail._bodyParts.Count; i < Length; i++) _snakeTail.AddBodyPart();

            PartsAmountText.SetText(Length.ToString());
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Obstacle obstacle))
        {
            Length -= 1;
            Score += 10;

            if (_snakeTail._bodyParts.Count <= 0)
            {
             Length = 0;
                Die();
            }

            for (int i = _snakeTail._bodyParts.Count; i > Length; i--) _snakeTail.RemoveBodyPart();
            PartsAmountText.SetText(Length.ToString());

            obstacle.MinusParts -= 1;
            obstacle.MinusPartsText.SetText(obstacle.MinusParts.ToString());

            if (obstacle.MinusParts == 0)
            {
              Destroy(obstacle.gameObject);
            }

        }

    }
=======
>>>>>>> parent of e89f58b (Added Obstacle numbers)

    public void ReachFinish()
    {
        Game.OnReachedFinish();
        ForwardSpeed = 0;
        Sensitivity = 0;
        _snakeRigidBody.velocity = Vector3.zero;
    }


    public void Die()
    {
        Game.OnDied();
        ForwardSpeed = 0;
        Sensitivity = 0;
        _snakeRigidBody.velocity = Vector3.zero;
        GameObject.Find("SnakeHead").SetActive(false);
        Shreds.SetActive(true);
        Shreds.transform.position = gameObject.transform.position;
    }
}
