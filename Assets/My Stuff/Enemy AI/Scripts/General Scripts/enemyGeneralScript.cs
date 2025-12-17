using UnityEngine;

public class enemyGeneralScript : MonoBehaviour
{
    [SerializeField] public int dmg;

    public int damage;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        damage = dmg;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
