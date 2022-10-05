using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SnakeHead : MonoBehaviour
{
    public Game Game;

    public float ForwardSpeed;
    public float Sensitivity;
    public int Length = 1;
    private Rigidbody _snakeRigidBody;
    internal SnakeTail _snakeTail;

    public TextMeshPro PartsAmountText;
    public Text ScoreText;
    public Text CurrentLevelText;
    public Text NextLevelText;

    private Camera _mainCamera;

    private Vector3 _touchLastPos;
    private float _sidewaysSpeed;

    public Obstacle Obstacle;

    public ObjectPool PickUpsPool;

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
        ScoreText.text = Score.ToString();
        CurrentLevelText.text = (Game.LevelIndex + 1).ToString();
        NextLevelText.text = (Game.LevelIndex + 2).ToString();
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_sidewaysSpeed) > 4) _sidewaysSpeed = 100 * Mathf.Sign(_sidewaysSpeed);
        _snakeRigidBody.velocity = new Vector3(_sidewaysSpeed, 0, ForwardSpeed);

        _sidewaysSpeed = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BonusParts parts))
        {
            Length += parts.Parts;
            Destroy(parts.gameObject);
            for (int i = _snakeTail._bodyParts.Count; i < Length; i++) _snakeTail.AddBodyPart();

            PartsAmountText.SetText(Length.ToString());
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Obstacle obstacle))
        {
            Length --;
            for (int i = _snakeTail._bodyParts.Count; i > Length; i--) _snakeTail.RemoveBodyPart();
            PartsAmountText.SetText(Length.ToString());
            if (Length <= 0)
            {
                Length = 0;
                Die();
            }
            obstacle.MinusParts--;
            obstacle.MinusPartsText.SetText(obstacle.MinusParts.ToString());
            Score += 100;
            ScoreText.text = Score.ToString();
            if (obstacle.MinusParts == 0)
            {
              Destroy(obstacle.gameObject);
            }
        }

    }

    public void ReachFinish()
    {
        Game.OnReachedFinish();
        _snakeRigidBody.velocity = Vector3.zero;
        ForwardSpeed = 0;
        Sensitivity = 0;
        Score += 50*_snakeTail._bodyParts.Count;
    }

    public void Die()
    {
        Game.OnDied();
        _snakeRigidBody.velocity = Vector3.zero;
        ForwardSpeed = 0;
        Sensitivity = 0;
        gameObject.SetActive(false);
        Shreds.SetActive(true);
        Shreds.transform.position = gameObject.transform.position;
    }
}
