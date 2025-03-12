using Core.DataTypes;

namespace Core.DataAccessLayer;

public class ZeddelkaschdeAccessLayer : IZeddelkaschdeAccessLayer
{
    public void AddZeddel(Zeddel zeddel)
    {
        using var db = new ZeddelkaschdeContext();
        db.ZeddelList.Add(zeddel);
        db.SaveChanges();
    }

    public void RemoveZeddel(Zeddel zeddel) => throw new NotImplementedException();

    public List<Zeddel> GetZeddelList()
    {
        using var db = new ZeddelkaschdeContext();
        return [.. db.ZeddelList];
    }


    public void AddKaschde(Kaschde kaschde) => throw new NotImplementedException();

    public void RemoveKaschde(Kaschde kaschde) => throw new NotImplementedException();

    public List<Kaschde> GetKaschdeList() => throw new NotImplementedException();


}
