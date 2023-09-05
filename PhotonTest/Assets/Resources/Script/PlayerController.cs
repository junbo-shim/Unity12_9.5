using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Legacy
    //private Rigidbody playerRigid;
    //private Vector3 playerLookingVector;
    //private Vector3 playerMoveSpeed;
    //private Quaternion playerForward;
    //private Quaternion playerLooking;

    //private float xValue;
    //private float zValue;
    //private float yValue;

    //private float playerSpeed = 2f;
    //private float jumpForce = 15f;
    //private float rotationSpeed = 15f;


    //private void Awake()
    //{
    //    playerRigid = GetComponent<Rigidbody>();
    //}

    //private void FixedUpdate()
    //{
    //    MovePlayer();
    //    LookFront();
    //}

    //#region 플레이어 이동
    //private void MovePlayer()
    //{
    //    xValue = Input.GetAxisRaw("Horizontal");
    //    zValue = Input.GetAxisRaw("Vertical");

    //    playerLookingVector = new Vector3(xValue, 0f, zValue).normalized;
    //    playerMoveSpeed = playerLookingVector * playerSpeed;

    //    playerRigid.position += playerMoveSpeed * Time.deltaTime;


    //    #region Legacy
    //    //playerDirection.x = Input.GetAxis("Horizontal");
    //    //playerDirection.z = Input.GetAxis("Vertical");

    //    //xVector = (transform.right * playerDirection.x * playerSpeed);
    //    //zVector = (transform.forward * playerDirection.z * playerSpeed);
    //    //yVector = transform.up * playerRigid.velocity.y;

    //    //playerDirection = (xVector + zVector);
    //    //playerMovePosition = playerDirection;

    //    //Vector3 upV = Vector3.up * playerRigid.velocity.y;
    //    //Vector3 resultV = sideV + frontV;
    //    //playerPosition = resultV + upV;a
    //    #endregion
    //}
    //#endregion

    //#region 플레이어 시선처리
    //private void LookFront() 
    //{
    //    xValue = Input.GetAxisRaw("Horizontal");
    //    zValue = Input.GetAxisRaw("Vertical");

    //    playerForward = Quaternion.Euler(playerRigid.transform.forward);
    //    playerLooking = Quaternion.Euler(playerLookingVector);

    //    //if (Math.Abs(playerRigid.transform.forward.y - playerLookingVector.y) > 90)
    //    //{
    //    //    playerRigid.transform.Rotate(0f, 1f, 0f);
    //    //}
    //    playerRigid.transform.rotation = Quaternion.Lerp(playerForward, playerLooking, rotationSpeed * Time.deltaTime);

    //    #region Legacy
    //    //playerDirection.x = Input.GetAxis("Horizontal");
    //    //playerDirection.z = Input.GetAxis("Vertical");

    //    //if (playerDirection != Vector3.zero)
    //    //{
    //    //    // Lerp 의 시작 Vector 가 transform.forward 여야한다, 변화량은 계속해서 변화하는 deltaTime 값을 곱해준다.
    //    //    playerRigid.transform.forward = Vector3.Lerp(playerRigid.transform.forward, playerDirection, 1);
    //    //}
    //    #endregion
    //}
    //#endregion
    #endregion

    private Rigidbody playerRigid;
    private GameObject followCam;
    private Vector3 lookDirection;
    private Vector3 cameraDirection;
    
    private Quaternion lerpQuaternion;
    private Quaternion targetQuaternion;

    private float xInput;
    private float zInput;
    private float moveSpeed = 4f;
    private float rotateSpeed = 5f;

    private void Awake()
    {
        playerRigid = GetComponent<Rigidbody>();
        //followCam = Camera.main.gameObject;
        lookDirection = Vector3.zero;
        cameraDirection = Vector3.zero;
    }

    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void MovePlayer()
    {
        zInput = Input.GetAxisRaw("Vertical");
        xInput = Input.GetAxisRaw("Horizontal");

        lookDirection = (playerRigid.transform.forward * zInput) + (playerRigid.transform.right * xInput);
        lookDirection.Normalize();
        lookDirection.y = 0f;

        playerRigid.transform.position += lookDirection * moveSpeed * Time.deltaTime;

        Debug.Log(lookDirection);
    }

    private void RotatePlayer() 
    {
        Debug.LogFormat("지금 어느 좌표를 보는거지? {0}", lookDirection);
        Debug.LogFormat("{0}", playerRigid.transform.rotation);


        #region Legacy
        //cameraDirection = (followCam.transform.forward * zInput) + (followCam.transform.right * xInput);
        //cameraDirection.Normalize();
        //cameraDirection.y = 0f;

        //if (cameraDirection == Vector3.zero) 
        //{
        //    cameraDirection = playerRigid.transform.forward;
        //}

        //targetQuaternion = Quaternion.LookRotation(cameraDirection);
        //lerpQuaternion = Quaternion.Slerp(playerRigid.transform.rotation, targetQuaternion, rotateSpeed * Time.deltaTime);
        //playerRigid.transform.rotation = lerpQuaternion;
        #endregion
    }
}
