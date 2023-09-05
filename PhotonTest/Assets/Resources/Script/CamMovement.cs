using Photon.Pun;
using UnityEngine;

public class CamMovement : MonoBehaviourPun
{
    private GameObject cam;
    public Transform playerT;

    // ���콺 ����
    private float mouseSensitivity = 5f;
    // ���콺�� X �� ��ȭ�� �� ���庯��
    private float mouseXMove;
    // ���콺�� Y �� ��ȭ�� �� ���庯��
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
            // ī�޶��� ��ġ�� ������
            transform.position = playerT.position;
            MoveCam();
        }
    }

    private void MoveCam() 
    {
        mouseXMove = Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseYMove = Input.GetAxis("Mouse Y") * mouseSensitivity;

        #region ī�޶� �����̵� Legacy
        //gameObject.transform.RotateAround(player.position, Vector3.up, mouseXMove);
        #endregion

        // ���콺�� ��ȭ�� ���� �����־ delta �� ������־�� �Ѵ�.
        cameraAngle += new Vector3(-mouseYMove, mouseXMove, 0f);

        // ī�޶� x rotation �� ������ ���� �ɱ�
        cameraAngle.x = Mathf.Clamp(cameraAngle.x, -45f, 45f);

        cameraRotation = Quaternion.Euler(cameraAngle);
        gameObject.transform.rotation = cameraRotation;
    }
}

