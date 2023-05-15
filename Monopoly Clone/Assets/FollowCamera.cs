using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Camera followCamera;
    [SerializeField] private float distanceOffset = 6f;
    [SerializeField] private float heightOffset = 2f;

    private void Update()
    {
        var player = GameManager.Instance.ActivePlayer.Token;
        var forwardDirection = player.transform.forward;
        var position = player.transform.position - forwardDirection * distanceOffset;
        position.y = player.transform.position.y + heightOffset;
        var targetRotation = Quaternion.LookRotation(player.transform.position - followCamera.transform.position);
        
        followCamera.transform.position = position;
        followCamera.transform.rotation = targetRotation;
    }
}

