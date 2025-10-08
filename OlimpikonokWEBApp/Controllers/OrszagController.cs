using OlimpikonokWEBApp.Models;

namespace OlimpikonokWEBApp.Controllers
{
    public class OrszagController
    {
        public List<Orszag> GetOrszagok()
        {
            using (var context = new OlimpikonokContext())
            {
                try
                {
                    List<Orszag> orszagok = context.Orszags.ToList();
                    return orszagok;
                }
                catch (Exception ex)
                {
                    List<Orszag> hiba = new List<Orszag>();
                    Orszag uj = new Orszag()
                    {
                        Id = 0,
                        Nev = "Hiba az adatbázis elérésekor!" + ex.Message
                    };
                    return hiba;
                }
            }
        }
    }
}
