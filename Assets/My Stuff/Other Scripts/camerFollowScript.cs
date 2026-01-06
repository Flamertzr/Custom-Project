using UnityEngine;

public class camerFollowScript : MonoBehaviour
{
    public Transform player;
    private float fixedY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fixedY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        LateUpdate();
    }

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, fixedY, transform.position.z);
        }
    }
}
