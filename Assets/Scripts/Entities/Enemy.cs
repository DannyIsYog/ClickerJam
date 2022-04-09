using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ulong health;
    [SerializeField] ulong currencyDrop;

    public HealthBar healthBar;

    public GameObject healthBarObject;
    public Collider2D colliderComponent;

    // Start is called before the first frame update
    void Start()
    {
        int level = EnemiesManager.Instance.level;
        bool isBoss = EnemiesManager.Instance.isEnemyInFrontBoss();

        //Calculate Health
        float a = Mathf.Pow(1.55f, level - 1);
        this.health = (ulong)10 * (ulong)(level - 1 + Mathf.Pow(1.55f, level - 1));
        if (isBoss) this.health *= 10;
        healthBar.SetMaxHealth(health);

        //Calculate currencyDrop
        this.currencyDrop = this.health / 10;

        gameObject.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 0.4f, 0.4f, 1f, 1f);

        if (isBoss)
        {
            CanvasManager.managerInstace.changeSceneActivate();
        }

    }

    private void OnMouseDown()
    {
        EnemiesManager.Instance.damageFirstInLine();
        if (Random.Range(0f, 1f) < 0.1f) AudioManager.instance.Play("hurt");
    }

    public void dealDamage(ulong damage)
    {
        Debug.Log(damage);
        if (this.health < damage)
        {
            die();
            return;
        }
        this.health -= damage;
        updateHealthBar();
        if (this.health == 0) die();
    }

    void die()
    {
        CurrencyManager.Instance.addMonsterCurrency(currencyDrop);
        EnemiesManager.Instance.removeFirstInLine();
        Destroy(gameObject);
    }

    void updateHealthBar()
    {
        healthBar.SetHealth(this.health);
    }

    public void toFront()
    {
        healthBarObject.SetActive(true);
        colliderComponent.enabled = true;
    }
}
