namespace PlantsZombiesAR.UIElements
{
    public class PauseMenu : GameMenu
    {
        public override void MenuEnter()
        {
            base.MenuEnter();
            GameManager.GameManager.Instance.PauseGame();
        }

        public override void MenuExit()
        {
            base.MenuExit();
            GameManager.GameManager.Instance.ResumeGame();
        }
    }
}
