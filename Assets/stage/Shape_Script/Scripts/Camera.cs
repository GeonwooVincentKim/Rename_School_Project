using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Camera : MonoBehaviour
{
    int randNum;
    private float[] moveSpeed = { 3, 3, 0.5f };
    float[] moveDistList = { 14, 20, 2 };
    float moveDist;
    Vector3[] moveDir = { Vector3.left, Vector3.forward, Vector3.right };
    Vector3[]  movePos = { new Vector3(-13.5f, 0.7f, 57), new Vector3(52.6f, 0.6f, 45.6f), new Vector3(53, 2, 49) };

    void Start()
    {
        randNum = 2;
        //3번째는 180도 1, 2 번째는 90
        if (randNum == 2) transform.rotation = Quaternion.Euler(11, 124, 0);
        else transform.rotation = Quaternion.Euler(0, 90, 0);
        transform.position = movePos[randNum];
    }

    void Update()
    {
        float fMove = Time.deltaTime * moveSpeed[randNum];
        transform.Translate(fMove * moveDir[randNum]);
        moveDist += Mathf.Abs(fMove);

        if (moveDist >= moveDistList[randNum])
        {
            moveDist = 0;

            int oldRandNum;
            do {
                oldRandNum = randNum;
                randNum = Random.Range(0, 3);
            } while (oldRandNum == randNum);

            //3번째는 180도 1, 2 번째는 90
            if (randNum == 2) transform.rotation = Quaternion.Euler(11, 124, 0);
            else transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.position = movePos[randNum];
        }
        
        if (Input.anyKeyDown) SceneManager.LoadScene("Title");
    }
}
