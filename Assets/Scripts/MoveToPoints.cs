using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoints : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField]
    private GameObject _shield;
    private Vector2 input;
    private float SpeedRotation = 2f;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        RotateShip();
        if(Input.anyKey)
            //���������� � ������� ����������� ���������� ��� �������� �������� ��� ������� 
        rb2D.AddForce(transform.TransformDirection(input));;
    }
    private void RotateShip()
    {
        //������� ������� � ������� �����
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        //�������� ���� ����� ��������� (-180, 180), �������� 90 ��������, ����� ������� �� ������� �����
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, SpeedRotation * Time.deltaTime);
    }

}
