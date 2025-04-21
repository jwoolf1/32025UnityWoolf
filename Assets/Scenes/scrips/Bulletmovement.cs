using UnityEngine;

public class Bulletmovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject target;
    public float xAngle, yAngle, zAngle;
    public int enemyhealth;
    void Start()
    {
        enemyhealth = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject != null)
        {
            xAngle = transform.localRotation.eulerAngles.x;
            yAngle = transform.localRotation.eulerAngles.y;
            zAngle = transform.localRotation.eulerAngles.z;

            transform.LookAt(target.transform);
        }
    }
    private void FixedUpdate()
    {
        if (gameObject != null)
        {
            transform.position += transform.right / 5;
            transform.position += transform.forward / 5;

            transform.rotation = Quaternion.Euler(xAngle, yAngle, zAngle);

            if (Vector3.Distance(target.transform.position, transform.position) < 1f * (int)transform.localScale.x)
            {
                enemyhealth -= 1;
                Destroy(gameObject);
                print(enemyhealth);
            }

            if (enemyhealth <= 0)
            {
                Destroy(target);
            }
        }
    }
}
