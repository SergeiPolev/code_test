public static class LayerManager
{
    public static int CellLayer = 3;
    public static int HexPileLayer = 6;

    public static int CellLayerMask = 1 << CellLayer;
    public static int HexPileLayerMask = 1 << HexPileLayer;

    public static bool SameLayer(int originLayer, int checkLayer)
    {
        return originLayer == checkLayer;
    }
}