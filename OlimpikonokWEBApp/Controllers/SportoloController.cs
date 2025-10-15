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
                    return context.Sportolos.Include(s => s.Sportag).ToList();
                }
                catch (Exception ex)
                {
                    List<Sportolo> hibaLista = new List<Sportolo>();
                    hibaLista.Add(new Sportolo
                    {
                        Id = 0,
                        Nev = "Hiba az adatbázis elérésekor!" + ex.Message
                    });
                    return hibaLista;
                }
            }
        }

        public SportoloDTO GetSportoloDTOById(int id)
        {
            using (var context = new OlimpikonokContext())
            {
                try
                {
                    var sportolo = context.Sportolos.FirstOrDefault(s => s.Id == id);
                    if(sportolo != null)
                    {
                        return new SportoloDTO
                        {
                            Id = sportolo.Id,
                            Kep = sportolo.Kep
                        };
                    }
                    else
                    {
                        return new SportoloDTO
                        {
                            Id = 0,
                            Kep = Array.Empty<byte>()
                        };
                    }
                }
                catch(Exception ex)
                {
                    return new SportoloDTO
                    {
                        Id = 0,
                        Kep = Array.Empty<byte>()
                    };
                }
            }
        }

        public string PutSportolo(Sportolo modositSportolo)
        {
            using (var context = new OlimpikonokContext())
            {
                try
                {
                    if(modositSportolo != null)
                    {
                        Sportolo letezo = context.Sportolos.FirstOrDefault(s => s.Id == modositSportolo.Id);
                        if(letezo != null)
                        {
                            context.Sportolos.Update(modositSportolo);
                            //context.SaveChanges();
                            return "Sikeresen módosítattuk az adatokat!";
                        }
                        else
                        {
                            return $"Nincs ilyen sportoló! {modositSportolo.Id}";
                        }
                    }
                    else
                    {
                        return "Üres objektumot kaptam, nem lehet módosítani!";
                    }
                }
                catch(Exception ex)
                {
                    return $"Nem sikerült a módosítás\n{ex.Message}";
                }
            }
        }
    }
}