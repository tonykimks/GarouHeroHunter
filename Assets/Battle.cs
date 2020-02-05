using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Battle : MonoBehaviour
{
    public Character garou;
    public Character enemy;
    private BattleState battleState;
    private enum BattleState
    {
        Start,
        WhatWillYouDo,
        Fight,
        Aim,
        Battle,
        Run,
        Win,
        Lose
    }

    private CursorLocation cursorLocation;
    private enum CursorLocation
    {
        Fight,
        Run,
        Move1,
        Move2,
        Move3,
        Move4
    }

    public GameObject expositionText;
    public GameObject cursor;
    public GameObject fightText;
    public GameObject runText;
    public GameObject move1Text;
    public GameObject move2Text;
    public GameObject move3Text;
    public GameObject move4Text;
    public GameObject targetLine;
    public GameObject targetCenter;
    public GameObject target;
    public GameObject aimText;
    public GameObject enemyHealth;
    public GameObject enemyEnergy;
    public GameObject garouHealth;
    public GameObject garouEnergy;

    private float barStartWidth = 132f;
    private bool battleSequence;

    public GameObject garouDamage;
    public GameObject genosDamage;

    // Start is called before the first frame update
    void Start()
    {
        Stat garouStats = new Stat(2000, 109, 146, 116, 136, 136, 216);
        Move[] garouMoves = new Move[] { Resources.waterStreamFist, Resources.firePunch, Resources.crossChop };
        Stat enemyStats = new Stat(1780, 150, 156, 124, 116, 144, 146);
        Move[] enemyMoves = new Move[] { Resources.machineGunBlows, Resources.firePunch, Resources.waterStreamFist };
        Dictionary<int, Move> garouAllMoves = new Dictionary<int, Move>();
        this.garou = new Character(Resources.Type.Fight, Resources.Type.None, "Garou", Resources.Rank.None, 25, garouStats, garouMoves, garouAllMoves, Resources.Status.Healthy);
        this.enemy = new Character(Resources.Type.Steel, Resources.Type.Electric, "Genos", Resources.Rank.S, 25,  enemyStats, enemyMoves, garouAllMoves, Resources.Status.Healthy);

        this.battleState = BattleState.Start;
        this.cursorLocation = CursorLocation.Fight;
        populateMoves();
        this.battleSequence = false;
    }

    // Update is called once per frame
    void Update()
    {
        setCursorPosition();
        setupPanelGUI();
        if (this.battleState == BattleState.Start)
        {
            // animate the two characters arriving on screen
            // set text to "a hero appeared!"
            // transition to next WhatWillYouDo state
            string introText = "You found the " + this.enemy.getRank().ToString() + " class hero, " + this.enemy.getName() + "!";
            setExpositionText(introText);
            if ( Input.GetKeyDown( KeyCode.Z ) || Input.GetKeyDown( KeyCode.X ) )
            {
                this.battleState = BattleState.WhatWillYouDo;
            }

        } else if (this.battleState == BattleState.WhatWillYouDo)
        {
            // show side menu with options of FIGHT and RUN
            // set text to "what will you do?"
            // upon menu selection, transition to appropriate state
            setExpositionText("What will you do?");
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if ( this.cursorLocation == CursorLocation.Fight )
                {
                    this.cursorLocation = CursorLocation.Move1;
                    this.battleState = BattleState.Fight;
                } else if ( this.cursorLocation == CursorLocation.Run )
                {
                    this.battleState = BattleState.Run;
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.cursorLocation = CursorLocation.Fight;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                this.cursorLocation = CursorLocation.Run;
            }
        } else if (this.battleState == BattleState.Fight)
        {
            // display moves in center menu
            // upon move selection, transition to aim state (if necessary)

            int numMoves = this.garou.getMoves().Length;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (this.cursorLocation == CursorLocation.Move3)
                {
                    this.cursorLocation = CursorLocation.Move1;
                }

                if (this.cursorLocation == CursorLocation.Move4)
                {
                    this.cursorLocation = CursorLocation.Move2;
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (this.cursorLocation == CursorLocation.Move1)
                {
                    if (numMoves >= 3)
                    {
                        this.cursorLocation = CursorLocation.Move3;
                    }
                   
                }

                if (this.cursorLocation == CursorLocation.Move2)
                {
                    if (numMoves == 4)
                    {
                        this.cursorLocation = CursorLocation.Move4;
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (this.cursorLocation == CursorLocation.Move2)
                {
                    this.cursorLocation = CursorLocation.Move1;
                }

                if (this.cursorLocation == CursorLocation.Move4)
                {
                    this.cursorLocation = CursorLocation.Move3;
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (this.cursorLocation == CursorLocation.Move1)
                {
                    if (numMoves >= 2)
                    {
                        this.cursorLocation = CursorLocation.Move2;
                    }
                }

                if (this.cursorLocation == CursorLocation.Move3)
                {
                    if (numMoves == 4)
                    {
                        this.cursorLocation = CursorLocation.Move4;
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                this.battleState = BattleState.Aim;
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                this.battleState = BattleState.WhatWillYouDo;
                this.cursorLocation = CursorLocation.Fight;
            }
        } else if (this.battleState == BattleState.Aim)
        {
            // display aiming mechanism
            // upon aiming, transition to battle state
            setupAimTarget();
            if (Input.GetKeyDown(KeyCode.Z))
            {
                // should make a check for if using move is valid
                // (cost? situation?)
                this.battleState = BattleState.Battle;
                this.battleSequence = true;
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                this.battleState = BattleState.Fight;
            }
        } else if (this.battleState == BattleState.Battle)
        {
            // miss/paralyze/move for first attacker
            // miss/paralyze/move for second attacker
            // status damage for opponent
            // status damage for player
            if (battleSequence)
            {
                StartCoroutine(battle());
            }
        } else if (this.battleState == BattleState.Run)
        {
            // if health is above 50%, switch text to "you ran away" and end battle
            // if health is lower than 50%, switch text to "run failed" and transition to WhatWillYouDo state
            string endText = "Ran away safely!";
            setExpositionText(endText);
        } else if (this.battleState == BattleState.Win)
        {
            // Text is "you defeated .." 
            // apply experience bonus and end battle
            string endText = "You have successfully hunted " + this.enemy.getName() + "!";
            setExpositionText(endText);
        } else if (this.battleState == BattleState.Lose)
        {
            // Text is "you were defeated.." "the hero ranks up for defeating the hero hunter!"
            // end battle
            string endText = "You have been defeated by " + this.enemy.getName() + "...";
            setExpositionText(endText);
        }
    }

    private void setExpositionText( string text)
    {
        this.expositionText.GetComponent<UnityEngine.UI.Text>().text = text;
    }

    private void setupPanelGUI()
    {
        if (this.battleState == BattleState.Start)
        {
            setActiveMoves(false);
            this.expositionText.SetActive(true);
            this.setActiveTargets(false);
            this.aimText.SetActive(false);
            setActiveSideOptions(false);
        }
        else if (this.battleState == BattleState.WhatWillYouDo)
        {
            this.expositionText.SetActive(true);
            setActiveMoves(false);
            this.aimText.SetActive(false);
            setActiveSideOptions(true);
        }
        else if (this.battleState == BattleState.Fight)
        {
            this.expositionText.SetActive(false);
            setActiveMoves(true);
            this.setActiveTargets(false);
            this.aimText.SetActive(false);
            setActiveSideOptions(false);

        }
        else if (this.battleState == BattleState.Aim)
        {
            this.setActiveTargets(true);
            setActiveMoves(false);
            this.aimText.SetActive(true);
        }

        else if (this.battleState == BattleState.Battle)
        {
            this.expositionText.SetActive(true);
            this.setActiveTargets(false);
        } 
        else if (this.battleState == BattleState.Run)
        {

        }
        else if (this.battleState == BattleState.Win)
        {

        }
        else if (this.battleState == BattleState.Lose)
        {

        }
    }

    private void setCursorPosition()
    {
        if (this.battleState == BattleState.WhatWillYouDo || this.battleState == BattleState.Fight)
        {
            this.cursor.SetActive(true);
        }
        else
        {
            this.cursor.SetActive(false);
        }

        if (this.cursorLocation == CursorLocation.Fight)
        {
            this.cursor.transform.position = this.fightText.transform.position;
        } else if (this.cursorLocation == CursorLocation.Run)
        {
            this.cursor.transform.position = this.runText.transform.position;
        } else if (this.cursorLocation == CursorLocation.Move1)
        {
            this.cursor.transform.position = this.move1Text.transform.position;
        } else if (this.cursorLocation == CursorLocation.Move2)
        {
            this.cursor.transform.position = this.move2Text.transform.position;
        } else if (this.cursorLocation == CursorLocation.Move3)
        {
            this.cursor.transform.position = this.move3Text.transform.position;
        } else if (this.cursorLocation == CursorLocation.Move4)
        {
            this.cursor.transform.position = this.move4Text.transform.position;
        }
    }

    private void setActiveMoves( bool active)
    {
        this.move1Text.SetActive(active);
        this.move2Text.SetActive(active);
        this.move3Text.SetActive(active);
        this.move4Text.SetActive(active);
    }

    private void setActiveSideOptions( bool active)
    {
        this.fightText.SetActive(active);
        this.runText.SetActive(active);
    }

    private void setActiveTargets( bool active )
    {
        this.target.SetActive(active);
        this.targetLine.SetActive(active);
        this.targetCenter.SetActive(active);
    }

    private void populateMoves()
    {
        this.move1Text.GetComponent<UnityEngine.UI.Text>().text = this.garou.getMoves()[0].getName();
        if (this.garou.getMoves().Length >= 2)
        {
            this.move2Text.GetComponent<UnityEngine.UI.Text>().text = this.garou.getMoves()[1].getName();
        }
        else
        {
            this.move2Text.GetComponent<UnityEngine.UI.Text>().text = "--";
        }

        if (this.garou.getMoves().Length >= 3)
        {
            this.move3Text.GetComponent<UnityEngine.UI.Text>().text = this.garou.getMoves()[2].getName();
        }
        else
        {
            this.move3Text.GetComponent<UnityEngine.UI.Text>().text = "--";
        }

        if (this.garou.getMoves().Length == 4)
        {
            this.move4Text.GetComponent<UnityEngine.UI.Text>().text = this.garou.getMoves()[3].getName();
        }
        else
        {
            this.move4Text.GetComponent<UnityEngine.UI.Text>().text = "--";
        }

    }

    private Move getSelectedMove()
    {
        Move[] moves = this.garou.getMoves();
        if (this.cursorLocation == CursorLocation.Move1)
        {
            return moves[0];
        } else if (this.cursorLocation == CursorLocation.Move2)
        {
            return moves[1];
        }
        else if (this.cursorLocation == CursorLocation.Move3)
        {
            return moves[2];
        }
        // on move4
        return moves[3];
    }

    private Move getEnemyMove()
    {
        System.Random rnd = new System.Random();
        int numMoves = this.enemy.getMoves().Length;
        int moveIndex = rnd.Next(0, numMoves - 1);
        return this.enemy.getMoves()[moveIndex];
    }

    private float getTrueAccuracy()
    {
        Move selectedMove = getSelectedMove();

        float moveAccuracy = selectedMove.getAccuracy() / 100f;

        float speedDifference = this.garou.getCurrentStats().getSpd() - this.enemy.getCurrentStats().getSpd();

        if (speedDifference < -150f)
        {
            speedDifference = -150f;
        }
        else if (speedDifference > 150f)
        {
            speedDifference = 150f;
        }

        float sdp = (speedDifference + 150f) / 300f;

        float trueAccuracy = ((20f * sdp) + (80 * moveAccuracy)) / 100f;
        return trueAccuracy;
    }

    private float getEnemyAccuracy(Move move)
    {
        float moveAccuracy = move.getAccuracy() / 100f;

        float speedDifference = this.enemy.getCurrentStats().getSpd() - this.garou.getCurrentStats().getSpd();

        if (speedDifference < -150f)
        {
            speedDifference = -150f;
        }
        else if (speedDifference > 150f)
        {
            speedDifference = 150f;
        }

        float sdp = (speedDifference + 150f) / 300f;

        float trueAccuracy = ((20 * sdp) + (80 * moveAccuracy)) / 100f;
        return trueAccuracy;
    }

    private void setupAimTarget()
    {
        float accuracy = getTrueAccuracy();
        float targetSpeed = 5f - (4.5f * accuracy);

        float width = this.targetLine.GetComponent<RectTransform>().rect.width;
        float start = this.targetLine.transform.position.x - (width / 2f);
        float end = start + width;
        float middle = (start + end) / 2f;

        this.target.transform.position = new Vector3(Mathf.Lerp(start, end, Mathf.PingPong(Time.time * targetSpeed, 1)), this.target.transform.position.y, this.target.transform.position.z);
    }

    private void reduceEnemyHealth(int amount)
    {
        Stat enemyCurrStats = this.enemy.getCurrentStats();
        int enemyTotalHp = this.enemy.getOriginalStats().getHp();
        int enemyCurrentHp;
        if (amount >= enemyCurrStats.getHp())
        {
            enemyCurrentHp = 0;
        }
        else
        {
            enemyCurrentHp = enemyCurrStats.getHp() - amount;
        }
        this.enemy.setCurrentStats(enemyCurrentHp, enemyCurrStats.getEnergy(), enemyCurrStats.getAtk(), enemyCurrStats.getSpatk(), enemyCurrStats.getDef(), enemyCurrStats.getSpdef(), enemyCurrStats.getSpd());

        float hpRatio = enemyCurrentHp / (float)enemyTotalHp;
        float newWidth = this.barStartWidth * hpRatio;

        print(amount);
        print(enemyCurrentHp);
        print(hpRatio);

        RectTransform enemyHpBarRect = this.enemyHealth.GetComponent<RectTransform>();
        enemyHpBarRect.position = new Vector2(enemyHpBarRect.position.x - ((enemyHpBarRect.rect.width - newWidth) / 2.0f), enemyHpBarRect.position.y);
        enemyHpBarRect.sizeDelta = new Vector2(newWidth, enemyHpBarRect.sizeDelta.y);
    }

    private void reduceGarouHealth(int amount)
    {
        Stat garouCurrStats = this.garou.getCurrentStats();
        int garouTotalHp = this.garou.getOriginalStats().getHp();
        int garouCurrentHp;
        if (amount >= garouCurrStats.getHp())
        {
            garouCurrentHp = 0;
        }
        else
        {
            garouCurrentHp = garouCurrStats.getHp() - amount;
        }
        this.garou.setCurrentStats(garouCurrentHp, garouCurrStats.getEnergy(), garouCurrStats.getAtk(), garouCurrStats.getSpatk(), garouCurrStats.getDef(), garouCurrStats.getSpdef(), garouCurrStats.getSpd());

        float hpRatio = garouCurrentHp / (float)garouTotalHp;
        float newWidth = this.barStartWidth * hpRatio;

        RectTransform garouHpBarRect = this.garouHealth.GetComponent<RectTransform>();
        garouHpBarRect.position = new Vector2(garouHpBarRect.position.x - ((garouHpBarRect.rect.width - newWidth) / 2.0f), garouHpBarRect.position.y);
        garouHpBarRect.sizeDelta = new Vector2(newWidth, garouHpBarRect.sizeDelta.y);

    }

    IEnumerator battle()
    {
        this.battleSequence = false;
        string critText = "It's a critical hit!";

        // print resultant accuracy
        float diff = Math.Abs(this.targetCenter.transform.position.x - this.target.transform.position.x);
        float accuracy = (1f - (diff / (this.targetLine.GetComponent<RectTransform>().rect.width / 2f))) * 100f;

        this.aimText.GetComponent<UnityEngine.UI.Text>().text = accuracy.ToString() + "%";

        // determine who attacks first

        bool garouAttackFirst = false;
        if (this.garou.getCurrentStats().getSpd() > this.enemy.getCurrentStats().getSpd())
        {
            garouAttackFirst = true;
        }

        if (garouAttackFirst)
        {
            Move move = getSelectedMove();
            reduceGarouEnergy(move.getCost(), move.getPenalty());
            yield return new WaitForSeconds(1);

            string useMoveText = "Garou used " + move.getName() + "!!";
            setExpositionText(useMoveText);
            yield return new WaitForSeconds(1);

            if (accuracy >= 100f - ((move.getAccuracy() / 100f) * 30f))
            {
                // success
                float eff = getEffectiveness(move.getType(), this.enemy);
                if (eff > -0.0001f && eff < 0.001f)
                {
                    useMoveText = "Doesn't affect " + this.enemy.getName() + "...";
                    setExpositionText(useMoveText);
                    yield return new WaitForSeconds(1);
                }
                else
                {
                    if (accuracy >= 97f)
                    {
                        // crit
                        garouAttack(move, eff, true);
                        yield return new WaitForSeconds(1);
                        setExpositionText(critText);
                    }
                    else
                    {
                        // regular
                        garouAttack(move, eff, false);
                    }

                    if (eff >= 2.0f)
                    {
                        useMoveText = "It's Super Effective!";
                        setExpositionText(useMoveText);
                        yield return new WaitForSeconds(1);
                    } else if (eff <= 0.5f)
                    {
                        useMoveText = "Not very effective...";
                        setExpositionText(useMoveText);
                        yield return new WaitForSeconds(1);
                    }
                }
            }
            else
            {
                // fail
                useMoveText = "Garou's attack missed..";
                setExpositionText(useMoveText);
            }

            yield return new WaitForSeconds(1);

            // random enemy move 
            Move enemyMove = getEnemyMove();
            reduceEnemyEnergy(enemyMove.getCost(), enemyMove.getPenalty());
            yield return new WaitForSeconds(1);

            useMoveText = this.enemy.getName() + " used " + enemyMove.getName() + "!!";
            setExpositionText(useMoveText);

            yield return new WaitForSeconds(1);

            float enemyAccuracy = getEnemyAccuracy(enemyMove);
            System.Random rnd = new System.Random();
            int r = rnd.Next(1, 100);
            print(r);
            print(enemyAccuracy);
            print(100f - (enemyAccuracy * 100f));
            if (r >= 100f - (enemyAccuracy * 100f))
            {
                // success
                float eff = getEffectiveness(enemyMove.getType(), this.garou);
                if (eff > -0.0001f && eff < 0.001f)
                {
                    useMoveText = "Doesn't affect " + this.garou.getName() + "...";
                    setExpositionText(useMoveText);
                    yield return new WaitForSeconds(1);
                }
                else
                {
                    if (accuracy >= 97f)
                    {
                        // crit
                        enemyAttack(enemyMove, eff, true);
                        yield return new WaitForSeconds(1);
                        setExpositionText(critText);
                    }
                    else
                    {
                        // regular
                        enemyAttack(enemyMove, eff, false);
                    }

                    if (eff >= 2.0f)
                    {
                        useMoveText = "It's Super Effective!";
                        setExpositionText(useMoveText);
                        yield return new WaitForSeconds(1);
                    }
                    else if (eff <= 0.5f)
                    {
                        useMoveText = "Not very effective...";
                        setExpositionText(useMoveText);
                        yield return new WaitForSeconds(1);
                    }
                }

            }
            else
            {
                // fail
                useMoveText = this.enemy.getName() + "'s attack missed..";
                setExpositionText(useMoveText);
            }
        }
        else
        {
            // random enemy move 
            Move enemyMove = getEnemyMove();
            reduceEnemyEnergy(enemyMove.getCost(), enemyMove.getPenalty());
            yield return new WaitForSeconds(1);

            string useMoveText = this.enemy.getName() + " used " + enemyMove.getName() + "!!";
            setExpositionText(useMoveText);

            yield return new WaitForSeconds(1);

            float enemyAccuracy = getEnemyAccuracy(enemyMove);
            System.Random rnd = new System.Random();
            int r = rnd.Next(1, 100);
            print(r);
            print(enemyAccuracy);
            print(100f - (enemyAccuracy * 100f));
            if (r >= 100f - (enemyAccuracy * 100f))
            {
                // success
                float eff = getEffectiveness(enemyMove.getType(), this.garou);
                if (eff > -0.0001f && eff < 0.001f)
                {
                    useMoveText = "Doesn't affect " + this.garou.getName() + "...";
                    setExpositionText(useMoveText);
                    yield return new WaitForSeconds(1);
                }
                else
                {
                    if (accuracy >= 97f)
                    {
                        // crit
                        enemyAttack(enemyMove, eff, true);
                        yield return new WaitForSeconds(1);
                        setExpositionText(critText);
                    }
                    else
                    {
                        // regular
                        enemyAttack(enemyMove, eff, false);
                    }

                    if (eff >= 2.0f)
                    {
                        useMoveText = "It's Super Effective!";
                        setExpositionText(useMoveText);
                        yield return new WaitForSeconds(1);
                    }
                    else if (eff <= 0.5f)
                    {
                        useMoveText = "Not very effective...";
                        setExpositionText(useMoveText);
                        yield return new WaitForSeconds(1);
                    }
                }

            }
            else
            {
                // fail
                useMoveText = this.enemy.getName() + "'s attack missed..";
                setExpositionText(useMoveText);
            }

            yield return new WaitForSeconds(1);

            Move move = getSelectedMove();
            reduceGarouEnergy(move.getCost(), move.getPenalty());
            yield return new WaitForSeconds(1);

            useMoveText = "Garou used " + move.getName() + "!!";
            setExpositionText(useMoveText);
            yield return new WaitForSeconds(1);

            if (accuracy >= 100f - ((move.getAccuracy() / 100f) * 30f))
            {
                // success
                float eff = getEffectiveness(move.getType(), this.enemy);
                if (eff > -0.0001f && eff < 0.001f)
                {
                    useMoveText = "Doesn't affect " + this.enemy.getName() + "...";
                    setExpositionText(useMoveText);
                    yield return new WaitForSeconds(1);
                }
                else
                {
                    if (accuracy >= 97f)
                    {
                        // crit
                        garouAttack(move, eff, true);
                        yield return new WaitForSeconds(1);
                        setExpositionText(critText);
                    }
                    else
                    {
                        // regular
                        garouAttack(move, eff, false);
                    }

                    if (eff >= 2.0f)
                    {
                        useMoveText = "It's Super Effective!";
                        setExpositionText(useMoveText);
                        yield return new WaitForSeconds(1);
                    }
                    else if (eff <= 0.5f)
                    {
                        useMoveText = "Not very effective...";
                        setExpositionText(useMoveText);
                        yield return new WaitForSeconds(1);
                    }
                }

            }
            else
            {
                // fail
                useMoveText = "Garou's attack missed..";
                setExpositionText(useMoveText);
            }
        }
        yield return new WaitForSeconds(1);
        this.battleState = BattleState.WhatWillYouDo;
        this.cursorLocation = CursorLocation.Fight;
    }

    private void garouAttack(Move move, float eff, bool crit)
    {
        if (move.GetType() == typeof(DamageMove))
        {
            DamageMove dmgMove = (DamageMove)move;
            int dmg = dmgMove.getDamage();
            int totalDamage;

            if (dmgMove.getPhysical())
            {
                // physical move
                float garouAtk = this.garou.getCurrentStats().getAtk();
                float enemyDef = this.enemy.getCurrentStats().getDef();
                totalDamage = (int)Math.Round(dmg * (garouAtk / enemyDef));
            }
            else
            {
                // special
                float garouSpatk = this.garou.getCurrentStats().getSpatk();
                float enemySpdef = this.enemy.getCurrentStats().getSpdef();
                totalDamage = (int)Math.Round(dmg * (garouSpatk / enemySpdef));
            }

            totalDamage = (int)Math.Round(totalDamage * eff);

            if (crit)
            {
                totalDamage = (int)Math.Round(totalDamage * 1.5f);
            }
            reduceEnemyHealth(totalDamage);
            garouDamage.GetComponent<UnityEngine.UI.Text>().text = totalDamage.ToString();
        }
        else if (move.GetType() == typeof(StatusMove))
        {

        }
        else if (move.GetType() == typeof(StatMove))
        {

        }
    }

    private void enemyAttack(Move move, float eff, bool crit)
    {
        if (move.GetType() == typeof(DamageMove))
        {
            DamageMove dmgMove = (DamageMove)move;
            int dmg = dmgMove.getDamage();
            int totalDamage;

            if (dmgMove.getPhysical())
            {
                // physical move
                float enemyAtk = this.enemy.getCurrentStats().getAtk();
                float garouDef = this.garou.getCurrentStats().getDef();
                totalDamage = (int)Math.Round(dmg * (enemyAtk / garouDef));
            }
            else
            {
                // special
                float enemySpatk = this.enemy.getCurrentStats().getSpatk();
                float garouSpdef = this.garou.getCurrentStats().getSpdef();
                totalDamage = (int)Math.Round(dmg * (enemySpatk / garouSpdef));
            }

            totalDamage = (int)Math.Round(totalDamage * eff);

            if (crit)
            {
                totalDamage = (int)Math.Round(totalDamage * 1.5f);
                //totalDamage *= 2;
            }
            reduceGarouHealth(totalDamage);
            genosDamage.GetComponent<UnityEngine.UI.Text>().text = totalDamage.ToString();
        }
        else if (move.GetType() == typeof(StatusMove))
        {

        }
        else if (move.GetType() == typeof(StatMove))
        {

        }
    }

    private void reduceGarouEnergy(int amount, int penalty)
    {
        Stat garouCurrStats = this.garou.getCurrentStats();
        int garouTotalEnergy = this.garou.getOriginalStats().getEnergy();

        // do health damage if no energy left
        if (garouCurrStats.getEnergy()  == 0)
        {
            int garouTotalHp = this.garou.getOriginalStats().getHp();
            int hpPenalty = (int) Math.Round(garouTotalHp * ((float)penalty / 100f));
            reduceGarouHealth(hpPenalty);
        }

        int garouCurrentEnergy;
        if (amount >= garouCurrStats.getEnergy())
        {
            garouCurrentEnergy = 0;
        }
        else
        {
            garouCurrentEnergy = garouCurrStats.getEnergy() - amount;
        }
        this.garou.setCurrentStats(garouCurrStats.getHp(), garouCurrentEnergy, garouCurrStats.getAtk(), garouCurrStats.getSpatk(), garouCurrStats.getDef(), garouCurrStats.getSpdef(), garouCurrStats.getSpd());

        float energyRatio = garouCurrentEnergy / (float)garouTotalEnergy;
        float newWidth = this.barStartWidth * energyRatio;

        RectTransform garouEnergyBarRect = this.garouEnergy.GetComponent<RectTransform>();
        garouEnergyBarRect.position = new Vector2(garouEnergyBarRect.position.x - ((garouEnergyBarRect.rect.width - newWidth) / 2.0f), garouEnergyBarRect.position.y);
        garouEnergyBarRect.sizeDelta = new Vector2(newWidth, garouEnergyBarRect.sizeDelta.y);
    }

    private void reduceEnemyEnergy(int amount, int penalty)
    {
        Stat enemyCurrStats = this.enemy.getCurrentStats();
        int enemyTotalEnergy = this.enemy.getOriginalStats().getEnergy();

        // do health damage if no energy left
        if (enemyCurrStats.getEnergy() == 0)
        {
            int enemyTotalHp = this.enemy.getOriginalStats().getHp();
            int hpPenalty = (int)Math.Round(enemyTotalHp * ((float)penalty / 100f));
            reduceEnemyHealth(hpPenalty);
        }
        int enemyCurrentEnergy;
        if (amount >= enemyCurrStats.getEnergy())
        {
            enemyCurrentEnergy = 0;
        }
        else
        {
            enemyCurrentEnergy = enemyCurrStats.getEnergy() - amount;
        }
        this.enemy.setCurrentStats(enemyCurrStats.getHp(), enemyCurrentEnergy, enemyCurrStats.getAtk(), enemyCurrStats.getSpatk(), enemyCurrStats.getDef(), enemyCurrStats.getSpdef(), enemyCurrStats.getSpd());

        float energyRatio = enemyCurrentEnergy / (float)enemyTotalEnergy;
        float newWidth = this.barStartWidth * energyRatio;

        RectTransform enemyEnergyBarRect = this.enemyEnergy.GetComponent<RectTransform>();
        enemyEnergyBarRect.position = new Vector2(enemyEnergyBarRect.position.x - ((enemyEnergyBarRect.rect.width - newWidth) / 2.0f), enemyEnergyBarRect.position.y);
        enemyEnergyBarRect.sizeDelta = new Vector2(newWidth, enemyEnergyBarRect.sizeDelta.y);
    }

    private float getEffectiveness(Resources.Type moveType, Character t)
    {
        Resources.Effectiveness eff1 = Resources.typeChart[moveType][t.getType1()];

        Resources.Effectiveness eff2 = Resources.Effectiveness.Normal;
        if (t.getType2() != Resources.Type.None)
        {
            eff2 = Resources.typeChart[moveType][t.getType2()];
        }

        if (eff1 == Resources.Effectiveness.None || eff2 == Resources.Effectiveness.None)
        {
            return 0f;
        }

        float result = 1f;

        if (eff1 == Resources.Effectiveness.Super)
        {
            result *= 2f;
        }
        else if (eff1 == Resources.Effectiveness.Weak)
        {
            result *= 0.5f;
        }

        if (eff2 == Resources.Effectiveness.Super)
        {
            result *= 2f;
        }
        else if (eff2 == Resources.Effectiveness.Weak)
        {
            result *= 0.5f;
        }

        return result;
    }
}
