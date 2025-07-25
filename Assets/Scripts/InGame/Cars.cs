using UnityEngine;

public class Cars : PoolableObject
{
    private float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }

    private void OnBecameInvisible()
    {
        //Push();
    }

    public void CrushCar()
    {
        transform.localScale = new Vector3(transform.localScale.x, 0.5f, transform.localScale.z);
        GetComponent<BoxCollider>().enabled = false;
    }
}
