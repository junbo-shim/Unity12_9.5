using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public static GameManager instance
    {
        get
        {
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if (m_instance == null)
            {
                // ������ GameManager ������Ʈ�� ã�� �Ҵ�
                m_instance = FindObjectOfType<GameManager>();
            }

            // �̱��� ������Ʈ�� ��ȯ
            return m_instance;
        }
    }

    private static GameManager m_instance; // �̱����� �Ҵ�� static ����
    public GameObject playerPrefab;
    private Vector3 respawnPosition;

    // �ֱ������� �ڵ� ����Ǵ�, ����ȭ �޼���
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // ���� ������Ʈ��� ���� �κ��� �����
        if (stream.IsWriting)
        {

        }
        else
        {
            // ����Ʈ ������Ʈ��� �б� �κ��� �����         

        }
    }

    private void Awake()
    {
        // ���� �̱��� ������Ʈ�� �� �ٸ� GameManager ������Ʈ�� �ִٸ�
        if (instance != this)
        {
            // �ڽ��� �ı�
            Destroy(gameObject);
        }
    }

    void Start()
    {
        respawnPosition = new Vector3(12f, 0f, 12f);
        PhotonNetwork.Instantiate(playerPrefab.name, respawnPosition, Quaternion.identity);
    }

    // Ű���� �Է��� �����ϰ� ���� ������ ��
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PhotonNetwork.LeaveRoom();
        }
    }

    // ���� ������ �ڵ� ����Ǵ� �޼���
    public override void OnLeftRoom()
    {
        // ���� ������ �κ� ������ ���ư�
        SceneManager.LoadScene("LobbyScene");
    }
}
