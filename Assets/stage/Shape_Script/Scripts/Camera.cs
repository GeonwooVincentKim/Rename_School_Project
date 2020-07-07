using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    float timer;
    float waitingTime;
    int randNum;

    //private int randNum = 4;
    //private float[] moveDist = {40, 15, 20, 30};
    //private Vector3[] moveDir = { Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

    private int[] moveSpeed = { 8, 4, 3, 4 };
    float[] moveDistList = { 40, 10, 30f, 60f };
    float moveDist;
    Vector3 []moveDir = { Vector3.forward, Vector3.left, Vector3.right, Vector3.back };
    Vector3[] movePos = { new Vector3(0.5f, 2.0f, 60), new Vector3(0.5f, 2.0f, 60), new Vector3(0.5f, 2.0f, 60), new Vector3(0.8f, 2.0f, 60) };

    // bool inside;
    public bool camera_move_enabled;

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
        randNum = 0;
        //randNum = Random.Range(0, 4);
    }

    void Update()
    {
        // Blocked this code because it doesn't work.
        // 이 코드는 제대로 작동이 되지 않아 일단 주석처리를 해놓았습니다.
        // StartCoroutine(Activate());

        // 360도 회전 기능 --> 맵 계속 돌아다님
        float fMove = Time.deltaTime * moveSpeed[randNum];
        transform.Translate(fMove * moveDir[randNum]);
        moveDist += Mathf.Abs(fMove);

        if (moveDist >= moveDistList[randNum])
        {
            Debug.Log("진입");
            moveDist = 0;
            randNum = Random.Range(0, 4);
            transform.position = movePos[randNum];
        }

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
        transform.position == new Vector3(-7.625f, 2f, 12.21f)
        transform.position == new Vector3(-32.23f, 2f, 12.21f) 
         */
        // Stage 1 됐다!!!
        //if (moveDist <= 40f)
        //{
        //    transform.Translate(Vector3.forward * fMove);
        //    Debug.Log("이동");
        //    //transform.Translate(Vector3.left * fMove);
        //}
        //if (moveDist >= 40f && moveDist <= 80)
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
        //if ( moveDist <= 10f)
        //{

        //    transform.Translate(Vector3.left * fMove);
        //    Debug.Log(moveDist);
        //    Debug.Log("이동2");
        //    //transform.Translate(Vector3.left * fMove);

        //}

        //if (moveDist >= 10f && moveDist <= 20)
        //{
        //    transform.Translate(Vector3.right * fMove);
        //    Debug.Log("돌아가기중");
        //    //transform.position = new Vector3(-7.625f, 2f, 12.21f);
        //    /* if (moveDist >= 40f && moveDist <= 80f)
        //     {
        //         transform.Translate(Vector3.left * fMove);
        //     }*/

        //}

        //if ( moveDist <= 10f)
        //{
        //    transform.Rotate(0, 0, 0);
        //    //transform.position = new Vector3(-7.625f, 2f, 12.21f);
        //}



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
