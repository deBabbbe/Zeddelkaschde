namespace Core;

public class Logic
{
    private readonly List<Zeddel> _zeddelList = [];
    private readonly List<Kaschde> _kaschdeList = [];

    public void AddZeddel(Zeddel zeddel) => _zeddelList.Add(zeddel);

    public void AddKaschde(Kaschde kaschde) => _kaschdeList.Add(kaschde);

    public void RemoveZeddel(Zeddel zeddel) => _zeddelList.Remove(zeddel);

    public void RemoveKaschde(Kaschde kaschde) => _kaschdeList.Remove(kaschde);

    public List<Zeddel> GetZeddelList() => _zeddelList;

    public List<Kaschde> GetKaschdeList() => _kaschdeList;
}
