using Photon.Pun;
using UnityEngine;

public class CamMovement : MonoBehaviourPun
{
    private GameObject cam;
    public Transform playerT;

    // 마우스 감도
    private float mouseSensitivity = 5f;
    // 마우스의 X 축 변화량 값 저장변수
    private float mouseXMove;
    // 마우스의 Y 축 변화량 값 저장변수
    private float mouseYMove;

    private Vector3 cameraAngle;
    private Quaternion cameraRotation;

    void Start()
    {
        cam = gameObject.transform.GetComponentInChildren<Camera>().gameObject;

        if (!photonView.IsMine)
        {
            cam.SetActive(false);
        }
    }

    private void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }
        else if (photonView.IsMine)
        {
            // 카메라의 위치를 고정함
            transform.position = playerT.position;
            MoveCam();
        }
    }

    private void MoveCam() 
    {
        mouseXMove = Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseYMove = Input.GetAxis("Mouse Y") * mouseSensitivity;

        #region 카메라 수평이동 Legacy
        //gameObject.transform.RotateAround(player.position, Vector3.up, mouseXMove);
        #endregion

        // 마우스의 변화량 값을 더해주어서 delta 로 만들어주어야 한다.
        cameraAngle += new Vector3(-mouseYMove, mouseXMove, 0f);

        // 카메라 x rotation 의 각도를 제한 걸기
        cameraAngle.x = Mathf.Clamp(cameraAngle.x, -45f, 45f);

        cameraRotation = Quaternion.Euler(cameraAngle);
        gameObject.transform.rotation = cameraRotation;
    }
}

