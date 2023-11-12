namespace JK.Roguelike
{
    public class PlayerHealth : Health
    {
        protected override void Die()
        {
            base.Die();
            //load gameover stuff.
            print("YOU DIED!");
        }
    }
}