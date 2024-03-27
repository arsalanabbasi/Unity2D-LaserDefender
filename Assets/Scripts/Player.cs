using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 inputValue;
    [SerializeField] float moveSpeed = 10f;

    void Update()
    {
        Movement();
    }

    void Movement(){
        Vector3 delta = inputValue * moveSpeed * Time.deltaTime;
        transform.position += delta;
        }

    void OnMove(InputValue value){
        inputValue = value.Get<Vector2>();
        }
}
