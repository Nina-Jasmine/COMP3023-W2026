using UnityEngine;

public class Eagle : Enemy
{
    public GameObject deathEffectPrefab;
    public int scoreValue = 100;

    public override void TakeDamage()
    {
        Debug.Log("Eagle was defeated!");

        GameManager.AddScore(scoreValue);

        // Safety Check
        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}