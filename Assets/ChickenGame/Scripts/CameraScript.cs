using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform endTransform;
    public float Speed;
    public bool IsEnd;
    private void Start()
    {
        Speed = 0;
        IsEnd = true;
    }
    private void OnEnable()
    {
        ChickenGameStartScript.ChickenGameStart += GameStart;
    }
    private void OnDisable()
    {
        ChickenGameStartScript.ChickenGameStart -= GameStart;
    }
    public void GameStart(int i)
    {
        IsEnd = false;
        Speed = 4;
    }
    void Update()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);

        if (transform.position.x >= endTransform.position.x)
        {
            IsEnd = true;
            Speed = 0;
        }
    }
}
