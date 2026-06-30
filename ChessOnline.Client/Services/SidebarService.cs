namespace ChessOnline.Client.Services
{
    public class SidebarService
    {
        public event Action? OnChange;
        public bool isVisible { get; set; }

        public void ToggleSidebar()
        {
            isVisible = !isVisible;
            OnChange?.Invoke();
        }
    }
}
