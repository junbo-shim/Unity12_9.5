using Photon.Pun;
using UnityEngine;

public class PlayerController2 : MonoBehaviourPun
{
    private Rigidbody playerRigid;
    private Transform playerCam;

    private float playerMoveSpeed = 8f;
    private float playerJumpForce = 3f;
    public bool isJumping;

    private Vector3 playerForward;
    private Vector3 playerRight;
    private Vector3 goDirection;
    private Vector3 lookDirection;


    
    void Start()
    {
        playerRigid = gameObject.GetComponent<Rigidbody>();
        playerCam = gameObject.transform.parent.Find("Cam");
        isJumping = false;
    }

    private void FixedUpdate()
    {
        if (!photonView.IsMine)
        {
            return;
        }
        else
        {
            LookForward();
            MovePlayer();
            Jump();
        }
    }

    private void MovePlayer() 
    {
        playerForward =
            new Vector3(playerRigid.transform.forward.x, 0f, playerRigid.transform.forward.z).normalized;
        playerRight =
            new Vector3(playerRigid.transform.right.x, 0f, playerRigid.transform.right.z).normalized;

        goDirection =
            (playerForward * Input.GetAxis("Vertical")) + (playerRight * Input.GetAxis("Horizontal"));

        playerRigid.transform.position += goDirection * playerMoveSpeed * Time.deltaTime;
        //playerRigid.velocity = goDirection * playerMoveSpeed;

        #region Legacy Position
        //zInput = Input.GetAxisRaw("Vertical");
        //xInput = Input.GetAxisRaw("Horizontal");

        //playerDirection = (playerRigid.transform.forward * zInput) + 
        //    (playerRigid.transform.right * xInput);
        //playerDirection.Normalize();
        //playerDirection.y = 0f;

        //playerRigid.transform.position += playerDirection * playerMoveSpeed * Time.deltaTime;
        #endregion

        #region Legacy Velocity
        //playerDirection.x = Input.GetAxis("Horizontal");
        //playerDirection.z = Input.GetAxis("Vertical");

        //playerRigid.velocity = playerDirection.normalized * playerMoveSpeed;
        #endregion

        #region Legacy forward, right �и�
        //camForward = new Vector3(playerCam.forward.x, 0f, playerCam.forward.z).normalized;
        //camRight = new Vector3(playerCam.right.z, 0f, playerCam.right.z).normalized;

        //playerDirection = (camForward * Input.GetAxis("Vertical")) + (camRight * Input.GetAxis("Horizontal"));

        //// ĳ���Ͱ� �ٶ� ���� ����
        //playerRigid.transform.forward = playerDirection;

        //// ĳ������ ������ ����
        //playerRigid.velocity = playerDirection * playerMoveSpeed * Time.deltaTime;
        #endregion
    }

    private void Jump() 
    {
            Debug.Log(isJumping);
        if (Input.GetKey(KeyCode.Space)) 
        {
            if (isJumping == false)
            {
                playerRigid.AddForce(Vector3.up * playerJumpForce, ForceMode.Impulse);
                isJumping = true;
                Debug.Log(isJumping);
            }
        }
    }

    private void LookForward()
    {
        lookDirection = new Vector3(0f, playerCam.transform.rotation.eulerAngles.y, 0f);
        playerRigid.transform.rotation = Quaternion.Euler(lookDirection);


        #region Legacy 
        //playerDirection.x = Input.GetAxis("Horizontal");
        //playerDirection.z = Input.GetAxis("Vertical");

        //if (playerDirection != Vector3.zero)
        //{
        //    // Lerp �� ���� Vector �� transform.forward �����Ѵ�, ��ȭ���� ����ؼ� ��ȭ�ϴ� deltaTime ���� �����ش�.
        //    playerRigid.transform.forward = Vector3.Lerp(playerRigid.transform.forward, playerDirection, rotateSpeed * Time.deltaTime);
        //}
        #endregion

        #region Legacy 2
        //playerDirection.x = Input.GetAxis("Horizontal");
        //playerDirection.z = Input.GetAxis("Vertical");

        //if (playerDirection != Vector3.zero)
        //{
        //    // Lerp �� ���� Vector �� transform.forward �����Ѵ�, ��ȭ���� ����ؼ� ��ȭ�ϴ� deltaTime ���� �����ش�.
        //    playerRigid.transform.forward = Vector3.Lerp(playerRigid.transform.forward, playerDirection, rotateSpeed * Time.deltaTime);
        //}
        #endregion
    }
}
