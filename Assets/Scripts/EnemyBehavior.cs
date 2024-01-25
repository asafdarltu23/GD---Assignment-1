using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public bool Flying;
    public bool Ground;
    GameObject Player;
    public float speed;
    bool facingRight = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Time.deltaTime * speed);

        if (Flying)
        {
            Vector3 player = Camera.main.WorldToScreenPoint(Player.transform.position);

            Vector3 enemypos = Camera.main.WorldToScreenPoint(transform.position);
            player.x = player.x - enemypos.x;
            player.y = player.y - enemypos.y;

            float angle = Mathf.Atan2(player.y, player.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 270));
        }

        if(Ground)
        {
            Vector3 playerpos = Player.transform.position;
            if (playerpos.x > gameObject.transform.position.x && facingRight == false)
            {
                facingRight = !facingRight;
                Vector2 localscale = gameObject.transform.localScale;
                localscale.x *= -1;
                transform.localScale = localscale;
            }
            else if (playerpos.x < gameObject.transform.position.x && facingRight == true)
            {
                facingRight = !facingRight;
                Vector2 localscale = gameObject.transform.localScale;
                localscale.x *= -1;
                transform.localScale = localscale;
            }
        }

    }
}
