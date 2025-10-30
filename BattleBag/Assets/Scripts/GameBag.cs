using Items;

public static class GameBag
{
    public static GameItem[] _gameSlotsItem = new GameItem[9];

    public static void SetGameItem(GameItem[] gameSlotsItem)
    {
        _gameSlotsItem = gameSlotsItem;
    }

    public static GameItem[] GetGameItem()
    {
        return _gameSlotsItem;
    }

    public static bool IsFullBag()
    {
        foreach (GameItem item in _gameSlotsItem)
        {
            if (item != null)
                return true;
        }
        return false;
    }
}
