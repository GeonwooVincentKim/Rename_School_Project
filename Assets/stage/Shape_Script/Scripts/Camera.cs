using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Numerics;
using System.Security.Cryptography;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class Camera : MonoBehaviour
{
    // public GameObject Targetposition;
    float LineDistence;

    public float speed;
    float timer;
    float waitingTime;
    int randNum = UnityEngine.Random.Range(1, 4);

    //private int randNum = 4;
    //private float[] moveDist = {40, 15, 20, 30};
    //private Vector3[] moveDir = { Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

    float []moveDistList = { 50f, 40f, 30f, 60f };
    float moveDist;
    Vector3 []moveDir = { Vector3.left, Vector3.right, Vector3.up, Vector3.down };
    int []moveSpeed = { 1, 2, 3, 4 };
    Vector3[] movePos = { Vector_3(0.8f, 2.0f, 60), Vector_3(0.8f, 2.0f, 60), Vector_3(0.8f, 2.0f, 60), Vector_3(0.8f, 2.0f, 60) };

    private static Vector3 Vector_3(float v1, float v2, int v3)
    {
        throw new NotImplementedException();
    }



    // bool inside;
    public bool camera_move_enabled;

    public Camera(int randNum)
    {
        this.randNum = randNum;
    }

    // Fade Scene은 이미 Animator로 구현해놓았으므로, 필요성을 느끼지 못할 것 같습니다.
    // 일단 나중에 필요할 수도 있으니 주석처리를 하도록 하겠습니다.
    /*
     * public FadeScene Fade;
     * IEnumerator Activate()
     * {
     *     yield return new WaitForSeconds(3f);
     *     Fade.FadeIn(0.6f, () =>
     *     {
     *         UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("IntroScene");
     *     });
     * }
     */
    void Start()
    {
        // inside = false;
        camera_move_enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Move_3rd_Floor")
        {
            other.gameObject.SetActive(false);
            Debug.Log("충돌충돌");
        }
    }

    void Update()
    {
        // Blocked this code because it doesn't work.
        // 이 코드는 제대로 작동이 되지 않아 일단 주석처리를 해놓았습니다.
        // StartCoroutine(Activate());

        // 360도 회전 기능 --> 맵 계속 돌아다님
        timer += Time.deltaTime;
        float fMove = Time.deltaTime * speed;
        /*float fMove = Time.deltaTime * moveSpeed[randNum];
        Debug.Log(fMove);
        moveDistList[randNum] += Mathf.Abs(fMove);
        transform.Translate(fMove * moveDir[0]);

        if(moveDist >= moveDistList[randNum])
        {
            randNum = UnityEngine.Random.Range(1, 4);
            transform.position = movePos[randNum];
        }*/
        moveDist += Mathf.Abs(fMove);

        /* if(moveDist[0] == 40)
         {
             randNum = 0;
         }*/
        /*switch (moveDist)
        {
            case 0:
                if(moveDist >= 40f)
                {
                    transform.Translate(Vector3.forward * fMove);
                    Debug.Log("이동");
                    transform.position = new Vector3(0.8f, 2.0f, 60);
                }
                break;

            case 1:
                if(moveDist >= 45f)
                {
                    transform.Translate(Vector3.left * fMove);
                    Debug.Log("이동이동");
                    transform.position = new Vector3(0.8f, 2.0f, 60);
                }
                break;

        }

        if(moveDist < 40f) 
        {
            Debug.Log("Test");
            transform.Translate(Vector3.forward * fMove);
        }
        if (moveDist >= 40f)
        {
            Debug.Log("이동");
            transform.position = new Vector3(0.8f, 2.0f, 60);
            //transform.rotation = Quaternion.Euler(128f, 126, -47);
            // Stage 3으로 일단 먼저 이동   
            // moveDist = 1;
            transform.Translate(Vector3.left * fMove);
        }
        if (moveDist >= 90f)
        {
            transform.Translate(Vector3.left * fMove);
            Debug.Log("Test..");
            transform.position = new Vector3(10.0f, 2.0f, 40);
            moveDist = 0;
        }*/


        //FadeIn(0.2, );
        // Go to Title Scene when input anykey.
        // 아무 키나 누르면 Title Scene으로 직행
        //transform.Translate(Vector3.forward * fMove);

        // transform.Translate(Vector3.left * fMove);

        /*
         The implemented Scene order by Location Camera.
         Scene 순서에 따라 구현된 카메라

         Stage 2 -> Stage 1

         */
        // Stage 1 됐다!!!
        //if (transform.position == new Vector3(-7.625f, 2f, 12.21f) || moveDist <= 40f)
        //{
        //    transform.Translate(Vector3.forward * fMove);
        //    Debug.Log("이동");
        //    //transform.Translate(Vector3.left * fMove);
        //}
        //if (transform.position == new Vector3(-32.23f, 2f, 12.21f) || moveDist >= 40f && moveDist <= 80)
        ////if (transform.position == new Vector3(-7.625f, 2f, 12.21f) || moveDist >= 40f)
        //{
        //    transform.position = new Vector3(0.8f, 2.0f, 60);
        //    //transform.Translate(Vector3.back * fMove);
        //    Debug.Log("CheckCheck");

        //}
        /*if (moveDist >= 40f)
        {
            transform.position = new Vector3(0.8f, 2.0f, 60);
        }*/

        // Stage 2 됐다!!!
        if (transform.position == new Vector3(0.8f, 2.0f, 60) || moveDist <= 10f)
        {

            transform.Translate(Vector3.left * fMove);
            Debug.Log(moveDist);
            Debug.Log("이동2");
            //transform.Translate(Vector3.left * fMove);

        }

        if (transform.position == new Vector3(0.5f, 2.0f, 60) || (moveDist >= 10f && moveDist <= 20))
        {
            transform.Translate(Vector3.right * fMove);
            Debug.Log("돌아가기중");
            //transform.position = new Vector3(-7.625f, 2f, 12.21f);
            /* if (moveDist >= 40f && moveDist <= 80f)
             {
                 transform.Translate(Vector3.left * fMove);
             }*/

        }

        if (transform.position == new Vector3(0.8f, 2.0f, 60) || moveDist <= 10f)
        {
            transform.Rotate(0, 0, 0);
            //transform.position = new Vector3(-7.625f, 2f, 12.21f);
        }



        //transform.Translate(Vector3.forward * fMove);
        /*if (moveDist >= 40f)
        {
            Debug.Log("이동");
            transform.position = new Vector3(0.8f, 2.0f, 60);
            // transform.rotation = Quaternion.Euler(128f, 126, -47);
            // Stage 3으로 일단 먼저 이동
             //moveDist = 1;

        }*/
        /*if (moveDist < 40f && moveDist >= 60f)
        {

            Debug.Log("Test..");
            transform.Translate(Vector3.left * fMove);

            transform.position = new Vector3(10.0f, 2.0f, 40);
            moveDist = 0;
        }*/


        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Title");
        }
    }

    /*private Vector3 Vector3_(float v1, float v2, int v3)
    {
        // throw new NotImplementedException();
    }*/
}
