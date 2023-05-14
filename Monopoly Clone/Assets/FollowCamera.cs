using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Camera followCamera;

    private void Update()
    {
        followCamera.transform.position = GameManager.Instance.ActivePlayer.transform.position;
    }
}
