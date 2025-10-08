using OlimpikonokWEBApp.Models;
using Microsoft.EntityFrameworkCore;

namespace OlimpikonokWEBApp.Controllers
{
    public class SportoloController
    {
        public List<Sportolo> GetSportolok()
        {
            using (var context = new OlimpikonokContext())
            {
                try
                {
                    List<Sportolo> sportolok = context.Sportolos.Include(s => s.Sportag).ToList();
                    return sportolok;
                }
                catch (Exception ex)
                {
                    List<Sportolo> hiba = new List<Sportolo>();
                    Sportolo uj = new Sportolo()
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
