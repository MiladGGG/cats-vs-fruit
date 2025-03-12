using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerReference : MonoBehaviour
{
    public TowerShoot shooter;
    public GameObject Targeter;
    public Collider selectCollider;

    [Space]
    public string catName;

    [Space]
    public Texture background;

    [Space]
    public int path1Upgrades;
    public int path2Upgrades;
    public Texture[] path1;
    public Texture[] path2;


    [Space]
    public int minor1Upgrades;
    public int minor2Upgrades;
    public int minor3Upgrades;
    public Texture minor1;
    public Texture minor2;
    public Texture minor3;

    [Space]
    [Header("Prices")]
    public int[] path1Prices;
    public int[] path2Prices;
    public int[] minor1Prices;
    public int[] minor2Prices;
    public int[] minor3Prices;

    [Space]
    public int sellPrice;

    [Space]
    [Header("Upgrade Props")]
    public GameObject bombHammer;
    public GameObject bombHammerProjectile;
    [Space]
    public GameObject frostProjectile;
    public GameObject areaProjectile;

    [Space]
    public GameObject laserProjectile;
    public GameObject pelletProjectile;


    public void WeaponVisible()
    {
        shooter.weaponVisible = true;
    }


    public void GetLeft()
    {
        path1Upgrades++;

        if (catName == "Knife Cat")
        {
            //Buff
            if (path1Upgrades == 1) { shooter.damage += 25; shooter.fireRate -= 0.1f; }
            if (path1Upgrades == 2) { shooter.damage += 25; shooter.fireRate -= 0.1f; }
            if (path1Upgrades == 3) { shooter.damage += 25; shooter.fireRate -= 0.15f; }
        }

        if (catName == "Hammer Cat")
        {
            //Stun Shots
            if (path1Upgrades == 1) { shooter.stunTime = 0.3f; }
            if (path1Upgrades == 2) { shooter.stunTime = 0.7f; }
            if (path1Upgrades == 3) { shooter.stunTime = 1.5f; }
        }


        if (catName == "Ice Cat")
        {
            if (path1Upgrades == 1) { shooter.damage = 1f; shooter.projectile = frostProjectile; shooter.freezeIntensity += 0.001f; shooter.ani.speed += 0.5f; }
            if (path1Upgrades == 2) { shooter.damage = 5f; shooter.freezeIntensity += 0.002f; shooter.maxFreeze += 0.05f; shooter.ani.speed += 0.5f; }
            if (path1Upgrades == 3) { shooter.damage = 10f; shooter.freezeIntensity += 0.003f; shooter.maxFreeze += 0.10f; shooter.ani.speed += 0.5f; }
        }


        if (catName == "Wizard Cat")
        {
            //Range
            if (path1Upgrades == 1) { Targeter.transform.localScale += Vector3.one * 15f; }
            if (path1Upgrades == 2) { Targeter.transform.localScale += Vector3.one * 30f; shooter.damage += 20; shooter.speed += 20; }
            if (path1Upgrades == 3) { Targeter.transform.localScale += Vector3.one * 50f; shooter.damage += 50; shooter.speed += 20; }
        }

        if (catName == "Cyborg Cat")
        {
            //Laser
            if (path1Upgrades == 1) { shooter.fireRate -= 0.03f; shooter.projectile = laserProjectile; }
            if (path1Upgrades == 2) { shooter.fireRate -= 0.01f; shooter.damage += 20; }
            if (path1Upgrades == 3) { shooter.fireRate -= 0.02f; shooter.ani.speed += 1; shooter.damage += 10; }
        }


    }

    public void GetRight()
    {
        path2Upgrades++;

        if (catName == "Knife Cat")
        {
            //Buff
            if (path2Upgrades == 1) { GameObject.Find("WaveSpawner").GetComponent<Waves>().money1++; }
            if (path2Upgrades == 2) { GameObject.Find("WaveSpawner").GetComponent<Waves>().money1--; GameObject.Find("WaveSpawner").GetComponent<Waves>().money2++; }
            if (path2Upgrades == 3) { GameObject.Find("WaveSpawner").GetComponent<Waves>().money2--; GameObject.Find("WaveSpawner").GetComponent<Waves>().money3++; }
        }

        if (catName == "Hammer Cat")
        {
            //Explosive Shots
            if (path2Upgrades == 1) { shooter.weapon.SetActive(false); shooter.weapon = bombHammer; shooter.weapon.SetActive(true); shooter.projectile = bombHammerProjectile; shooter.explodeDamage = 20; shooter.radius = 1; }
            if (path2Upgrades == 2) { shooter.explodeDamage = 45; shooter.radius = 2; }
            if (path2Upgrades == 3) { shooter.explodeDamage = 60; shooter.radius = 4; }
        }

        if (catName == "Ice Cat")
        {
            if (path2Upgrades == 1) { shooter.projectile = areaProjectile; shooter.radius = 0; shooter.explodeFreeze = 0.002f; shooter.explodeMaxFreeze = 0.35f; shooter.freezeIntensity -= 0.007f; }
            if (path2Upgrades == 2) { shooter.radius = 1; shooter.explodeFreeze = 0.005f; shooter.explodeMaxFreeze = 0.5f; }
            if (path2Upgrades == 3) { shooter.radius = 2; shooter.explodeFreeze = 0.008f; shooter.explodeMaxFreeze = 0.70f; }
        }

        if (catName == "Wizard Cat")
        {
            //Range
            if (path2Upgrades == 1) { GameObject.Find("WaveSpawner").GetComponent<Waves>().maxTraps++; GameObject.Find("WaveSpawner").GetComponent<Waves>().trap1++; shooter.trapLevel = 1; shooter.PlaceTrap(); }
            if (path2Upgrades == 2) { GameObject.Find("WaveSpawner").GetComponent<Waves>().trap1--; GameObject.Find("WaveSpawner").GetComponent<Waves>().trap2++; shooter.trapLevel = 2; shooter.PlaceTrap(); }
            if (path2Upgrades == 3) { GameObject.Find("WaveSpawner").GetComponent<Waves>().trap2--; GameObject.Find("WaveSpawner").GetComponent<Waves>().trap3++; shooter.trapLevel = 3; shooter.PlaceTrap(); }
        }

        if (catName == "Cyborg Cat")
        {
            //Blunt Pellets
            if (path2Upgrades == 1) { shooter.fireRate += 0.1f; shooter.projectile = pelletProjectile; shooter.damage += 30; shooter.blunt = true; shooter.sharp = false;}
            if (path2Upgrades == 2) { shooter.fireRate -= 0.05f; shooter.damage += 15; }
            if (path2Upgrades == 3) { shooter.fireRate -= 0.05f; shooter.damage += 20; }
        }
    }


    public void GetMinor1()
    {
        minor1Upgrades++;

        if (catName == "Knife Cat")
        {
            //Power
            if (minor1Upgrades == 1) { shooter.damage += 7; }
            if (minor1Upgrades == 2) { shooter.damage += 15; }
            if (minor1Upgrades == 3) { shooter.damage += 20; }
        }

        if (catName == "Hammer Cat")
        {
            //Power
            if(minor1Upgrades == 1){ shooter.damage += 7;  }
            if (minor1Upgrades == 2){ shooter.damage += 15; }
            if (minor1Upgrades == 3){ shooter.damage += 20; }
        }

        if (catName == "Ice Cat")
        {
            //Power
            if (minor1Upgrades == 1) { shooter.freezeIntensity += 0.003f; }
            if (minor1Upgrades == 2) { shooter.freezeIntensity += 0.003f;  }
            if (minor1Upgrades == 3) { shooter.freezeIntensity += 0.004f; }
        }

        if (catName == "Wizard Cat")
        {
            //Power
            if (minor1Upgrades == 1) { shooter.damage += 7; }
            if (minor1Upgrades == 2) { shooter.damage += 15; }
            if (minor1Upgrades == 3) { shooter.damage += 20; }
        }

        if (catName == "Cyborg Cat")
        {
            //Power
            if (minor1Upgrades == 1) { shooter.damage += 7; }
            if (minor1Upgrades == 2) { shooter.damage += 15; }
            if (minor1Upgrades == 3) { shooter.damage += 20; }
        }
    }


    public void GetMinor2()
    {
        minor2Upgrades++;

        if (catName == "Knife Cat")
        {
            //Fire Rate
            if (minor2Upgrades == 1) { shooter.speed += 5; shooter.fireRate -= 0.03f; }
            if (minor2Upgrades == 2) { shooter.speed += 10; shooter.fireRate -= 0.03f; }
            if (minor2Upgrades == 3) { shooter.speed += 15; shooter.fireRate -= 0.03f; }
        }

        if (catName == "Hammer Cat")
        {
            //Fire Rate
            if (minor2Upgrades == 1) { shooter.speed += 5; shooter.fireRate -= 0.05f; }
            if (minor2Upgrades == 2) { shooter.speed += 10; shooter.fireRate -= 0.1f; }
            if (minor2Upgrades == 3) { shooter.speed += 15; shooter.fireRate -= 0.1f; }
        }

        if (catName == "Ice Cat")
        {
            //Fire Rate
            if (minor2Upgrades == 1) { shooter.maxFreeze += 0.05f; }
            if (minor2Upgrades == 2) { shooter.maxFreeze += 0.05f; }
            if (minor2Upgrades == 3) { shooter.maxFreeze += 0.1f; }
        }

        if (catName == "Wizard Cat")
        {
            //Fire Rate
            if (minor2Upgrades == 1) { shooter.speed += 5; shooter.fireRate -= 0.03f; }
            if (minor2Upgrades == 2) { shooter.speed += 10; shooter.fireRate -= 0.08f; }
            if (minor2Upgrades == 3) { shooter.speed += 15; shooter.fireRate -= 0.1f; }
        }

        if (catName == "Cyborg Cat")
        {
            //Fire Rate
            if (minor2Upgrades == 1) { shooter.speed += 5; shooter.fireRate -= 0.01f; }
            if (minor2Upgrades == 2) { shooter.speed += 10; shooter.fireRate -= 0.01f; }
            if (minor2Upgrades == 3) { shooter.speed += 15; shooter.fireRate -= 0.01f; }
        }
    }


    public void GetMinor3()
    {
        minor3Upgrades++;

        if (catName == "Knife Cat")
        {
            //Range
            if (minor3Upgrades == 1) { Targeter.transform.localScale += Vector3.one * 2f; }
            if (minor3Upgrades == 2) { Targeter.transform.localScale += Vector3.one * 3f; }
            if (minor3Upgrades == 3) { Targeter.transform.localScale += Vector3.one * 4f; }
        }

        if (catName == "Hammer Cat")
        {
            //Range
            if (minor3Upgrades == 1) { Targeter.transform.localScale += Vector3.one * 2f; }
            if (minor3Upgrades == 2) { Targeter.transform.localScale += Vector3.one * 3f; }
            if (minor3Upgrades == 3) { Targeter.transform.localScale += Vector3.one * 4f; }
        }

        if (catName == "Ice Cat")
        {
            //Range
            if (minor3Upgrades == 1) { Targeter.transform.localScale += Vector3.one * 2f; }
            if (minor3Upgrades == 2) { Targeter.transform.localScale += Vector3.one * 3f; }
            if (minor3Upgrades == 3) { Targeter.transform.localScale += Vector3.one * 4f; }
        }

        if (catName == "Wizard Cat")
        {
            //Range
            if (minor3Upgrades == 1) { shooter.sharp = false; shooter.blunt = true; shooter.damage -= 10; }
            if (minor3Upgrades == 2) { shooter.damage += 10; }
            if (minor3Upgrades == 3) { shooter.blunt = false; shooter.ignore = true; }
        }

        if (catName == "Cyborg Cat")
        {
            //Range
            if (minor3Upgrades == 1) { Targeter.transform.localScale += Vector3.one * 2f; }
            if (minor3Upgrades == 2) { Targeter.transform.localScale += Vector3.one * 3f; }
            if (minor3Upgrades == 3) { Targeter.transform.localScale += Vector3.one * 4f; }
        }
    }

}
