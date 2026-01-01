using UnityEngine;

public class PlayerMove_Key : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        Vector3 move = Vector3.zero;

        // ÁÂ¿ì
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            move.x -= 1;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            move.x += 1;

        // »óÇÏ
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            move.y += 1;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            move.y -= 1;

        transform.Translate(move.normalized * speed * Time.deltaTime);
    }
}
