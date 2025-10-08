using OlimpikonokWEBApp.Models;
using Microsoft.EntityFrameworkCore;
using OlimpikonokWEBApp.DTOs;

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

        public Sportolo GetSportoloById(int id)
        {
            using (var context = new OlimpikonokContext())
            {
                try
                {
                    Sportolo sportolo = context.Sportolos.FirstOrDefault(s => s.Id == id);
                    return sportolo;
                }
                catch (Exception ex)
                {
                    Sportolo hiba = new Sportolo()
                    {
                        Id = 0,
                        Nev = "Hiba az adatbázis elérésekor!" + ex.Message
                    };
                    return hiba;
                }
            }
        }

        public SportoloDTO GetSportoloDTOId(int id)
        {
            using (var context = new OlimpikonokContext())
            {
                try
                {
                    Sportolo sportolo = context.Sportolos.FirstOrDefault(s => s.Id == id);
                    SportoloDTO sportoloDTO = new SportoloDTO()
                    {
                        Id = sportolo.Id,
                        Nev = sportolo.Nev,
                        Kep = sportolo.Kep
                    };
                    return sportoloDTO;
                }
                catch (Exception ex)
                {
                    SportoloDTO hiba = new SportoloDTO()
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