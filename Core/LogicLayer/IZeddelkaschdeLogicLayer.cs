using Core.DataTypes;

namespace Core.LogicLayer;

public interface IZeddelkaschdeLogicLayer
{
    void AddZeddel(Zeddel zeddel);
    void RemoveZeddel(Zeddel zeddel);
    List<Zeddel> GetZeddelList();

    void AddKaschde(Kaschde kaschde);
    List<Kaschde> GetKaschdeList();
    void RemoveKaschde(Kaschde kaschde);
}
