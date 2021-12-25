using UnityEngine;
using Random = UnityEngine.Random;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruitPrefab;
    public float explosionRadius = 5f;
    private GameManager gameManager;
    public int scoreAmount = 3;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void CreateSlicedFruit()
    {
        gameManager.PlaySliceSound();
        GameObject inst = Instantiate(slicedFruitPrefab, transform.position, transform.rotation);

        Rigidbody[] rbOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in rbOnSliced)
        {
            rigidbody.transform.rotation = Random.rotation;
            rigidbody.AddExplosionForce(Random.Range(500, 1000), transform.position, explosionRadius);
        }
        gameManager.IncreaseScore(scoreAmount);
    
        Destroy(inst, 5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();

        if (!b)
        {
            return;
        }
        
        CreateSlicedFruit();
    }

}
