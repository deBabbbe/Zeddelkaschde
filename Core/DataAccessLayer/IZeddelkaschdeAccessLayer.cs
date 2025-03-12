using Core.DataTypes;

namespace Core.DataAccessLayer;

public interface IZeddelkaschdeAccessLayer
{
    void AddZeddel(Zeddel zeddel);
    void RemoveZeddel(Zeddel zeddel);
    List<Zeddel> GetZeddelList();

    void AddKaschde(Kaschde kaschde);
    List<Kaschde> GetKaschdeList();
    void RemoveKaschde(Kaschde kaschde);
}
