using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HumansMove : MonoBehaviour
{
    [SerializeField] private int _speed_y = 2;
    [SerializeField] private int _speed_x = 2;        

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        transform.position += new Vector3(Time.deltaTime * _speed_x, Time.deltaTime * _speed_y, 0);                      
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _speed_y = SwitchCords(_speed_y);
            _speed_x = SwitchCords(_speed_x);
        }         
    }
    int SwitchCords(int _speed)
    {
        switch (Random.Range(1, 3))
        {
            case 1:
                _speed = 2;
                break;
            case 2:
                _speed = -2;
                break;
            default:
                _speed = 0;
                break;
        }        
        return _speed;
    }

}
