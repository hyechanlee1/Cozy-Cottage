using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] float movementSpeed = 3f;
    [SerializeField] float rotSpeed = 100f;
    private bool IsWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsWandering == false)
        {
            StartCoroutine(Wander());
        }
        if (isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        }
        if (isMoving == true)
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
    }

    IEnumerator Wander()
    {
        int rotTime = Random.Range(1,2);
        int rotateWait = Random.Range(0,1);
        int rotateLorR = Random.Range(0,2);
        int walkWait = Random.Range(0,1);
        int walkTime = Random.Range(1,3);

        IsWandering = true;

        yield return new WaitForSeconds(walkWait);
        isMoving = true;
        yield return new WaitForSeconds(walkTime);
        isMoving = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotateLorR == 0)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        else
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }
        IsWandering = false;
    }
}
