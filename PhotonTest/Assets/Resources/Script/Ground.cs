using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnCollisionStay(Collision other_)
    {
        if (other_.collider.tag.Equals("Player")) 
        {
            other_.transform.GetComponent<PlayerController2>().isJumping = false;
        }
    }
}
