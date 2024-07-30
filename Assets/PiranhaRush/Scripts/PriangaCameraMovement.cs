using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriangaCameraMovement : MonoBehaviour
{
    public float Speed;

    private void OnEnable()
    {
        PiranhaGameStartScript.StartPiranhaGame += PiranhaGameStarts;   
    }
    private void OnDisable()
    {
        PiranhaGameStartScript.StartPiranhaGame -= PiranhaGameStarts;
    }
    public void PiranhaGameStarts(int i)
    {
        Speed = 1.25f;
    }
    void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }
}
