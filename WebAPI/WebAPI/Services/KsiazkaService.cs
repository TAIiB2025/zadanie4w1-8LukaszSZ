using WebAPI.Models;

namespace WebAPI.Services
{
    public class KsiazkaService : IKsiazkaService
    {
        private static int idGen = 1;
        private static List<KsiazkaDTO> lista;

        static KsiazkaService()
        {
            lista = new List<KsiazkaDTO>
            {
                new KsiazkaDTO { Id = idGen++, Tytul = "Zbrodnia i kara", Autor = "Fiodor Dostojewski", Gatunek = "Powieść psychologiczna", Rok = 1866 },
                new KsiazkaDTO { Id = idGen++, Tytul = "Pan Tadeusz", Autor = "Adam Mickiewicz", Gatunek = "Epopeja narodowa", Rok = 1834 },
                new KsiazkaDTO { Id = idGen++, Tytul = "Rok 1984", Autor = "George Orwell", Gatunek = "Dystopia", Rok = 1949 },
                new KsiazkaDTO { Id = idGen++, Tytul = "Wiedźmin: Ostatnie życzenie", Autor = "Andrzej Sapkowski", Gatunek = "Fantasy", Rok = 1993 },
                new KsiazkaDTO { Id = idGen++, Tytul = "Duma i uprzedzenie", Autor = "Jane Austen", Gatunek = "Romans", Rok = 1813 }
            };
        }

        public List<KsiazkaDTO> Get()
        {
            return lista;
        }

        public KsiazkaDTO GetById(int id)
        {
            var ksiazka = lista.FirstOrDefault(k => k.Id == id);
            if (ksiazka == null)
            {
                throw new ArgumentException("Nie znaleziono wskazanej książki");
            }
            return ksiazka;
        }

        public void Delete(int id)
        {
            var ksiazka = lista.FirstOrDefault(k => k.Id == id);
            if (ksiazka == null)
            {
                throw new ArgumentException("Nie znaleziono wskazanej książki");
            }
            lista.Remove(ksiazka);
        }

        public void Put(int id, KsiazkaBodyDTO body)
        {
            Validate(body);

            var index = lista.FindIndex(k => k.Id == id);
            if (index == -1)
            {
                throw new ArgumentException("Nie znaleziono wskazanej książki");
            }

            lista[index] = new KsiazkaDTO
            {
                Id = id,
                Autor = body.Autor,
                Gatunek = body.Gatunek,
                Rok = body.Rok,
                Tytul = body.Tytul
            };
        }

        public void Post(KsiazkaBodyDTO body)
        {
            Validate(body);

            var ksiazka = new KsiazkaDTO
            {
                Id = idGen++,
                Autor = body.Autor,
                Gatunek = body.Gatunek,
                Rok = body.Rok,
                Tytul = body.Tytul
            };

            lista.Add(ksiazka);
        }

        private void Validate(KsiazkaBodyDTO body)
        {
            if (string.IsNullOrWhiteSpace(body.Tytul))
                throw new ArgumentException("Tytuł jest wymagany.");

            if (body.Tytul.Length > 100)
                throw new ArgumentException("Tytuł może mieć maksymalnie 100 znaków.");

            if (string.IsNullOrWhiteSpace(body.Gatunek))
                throw new ArgumentException("Gatunek jest wymagany.");

            var gatunekLower = body.Gatunek.ToLowerInvariant();
            var dozwoloneGatunki = new[] { "fantasy", "romans", "dystopia" };
            if (!dozwoloneGatunki.Contains(gatunekLower))
                throw new ArgumentException("Gatunek musi być jednym z: fantasy, romans, dystopia.");

            if (body.Rok > 2025)
                throw new ArgumentException("Rok nie może być większy niż 2025.");
        }
    }
}
