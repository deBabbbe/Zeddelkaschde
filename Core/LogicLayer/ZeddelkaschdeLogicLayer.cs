using Core.DataAccessLayer;
using Core.DataTypes;

namespace Core.LogicLayer;

public class ZeddelkaschdeLogicLayer(IZeddelkaschdeAccessLayer accessLayer) : IZeddelkaschdeLogicLayer
{
    public void AddZeddel(Zeddel zeddel) => accessLayer.AddZeddel(zeddel);

    public void RemoveZeddel(Zeddel zeddel) => accessLayer.RemoveZeddel(zeddel);

    public List<Zeddel> GetZeddelList() => accessLayer.GetZeddelList();

    public void AddKaschde(Kaschde kaschde) => accessLayer.AddKaschde(kaschde);

    public void RemoveKaschde(Kaschde kaschde) => accessLayer.RemoveKaschde(kaschde);

    public List<Kaschde> GetKaschdeList() => accessLayer.GetKaschdeList();
}
