using System.Security.Cryptography.X509Certificates;

public class Ability
{
    private int _basicDamage;
    private int _actionPoints;
    private string _name;
    public Ability(int basicDamage, int actionPoints, string name)
    {
        _basicDamage = basicDamage;
        _actionPoints = actionPoints;
        _name = name;
    }

    public void Effect(int characterAttack)
    {
        
    }

}
