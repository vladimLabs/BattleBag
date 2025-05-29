using Items;

public static class GameBag
{
    public static GameItem[] _gameSlotsItem = new GameItem[9];

    public static void GetGameItem(GameItem[] gameSlotsItem)
    {
        _gameSlotsItem = gameSlotsItem;
    }

}
